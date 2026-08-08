namespace Cryo;

public class Parser 
{
    private IEnumerator<Token> token;
    private Stack<Node> pastNodes;
    private Stack<Token> futureTokens;
 
    public Parser(IEnumerable<Token> Tokens)
    {
        this.token = Tokens.GetEnumerator();
        this.pastNodes = new();
        this.futureTokens = new();
    }

    public Parser()
    {
        this.pastNodes = new();
        this.futureTokens = new();
        this.token = new Token[0].AsEnumerable().GetEnumerator();
    }

    public IEnumerable<Node> Parse()
    {
        Node n = new Expression.EOF("EOF", 0, 0);
        while(token.MoveNext()) 
        {
            n = this.ParseOnce(Peek(0));

            switch(n)
            {

                // case Expression.EOF:
                //     this.pastNodes.TryPop(out n);
                //     yield return n ?? new Expression.EOF(n.file, n.line, n.col);
                //     break;
                case Expression.Continue:
                    continue;

                case Expression.Data d:
                    if (d  == null) 
                        continue;

                    break;
                    
                case Expression.Input i: 
                    if (i.Data == null) 
                        continue;

                    break;

                case Expression.Register r:
                    if (r.Data == null)
                        continue;

                    break;
            }
            yield return n;
        }
    }

    private Node ParseOnce(Token tok)
    {
        Node? n = new Expression.Unknown(tok);

        switch (tok.Type)
        {
            case TokenType.EOF:
                n = new Expression.EOF(tok.File, tok.Line, tok.Col);
                break;

            case TokenType.EOL:
                n = new Expression.EOL(tok.File, tok.Line, tok.Col);
                break;

            case TokenType.LParen:
                List<Token> toks = new();
                while (Next().Type != TokenType.RParen)
                    toks.Add(Peek());

                new Parser(toks.AsEnumerable()).Parse();
                break;

            case TokenType.Data:
                var d = new Expression.Data(tok.File, tok.Line, tok.Col, tok.Lex);
                this.pastNodes.Push(d);
                n = Next(1).Type == TokenType.Colon 
                    ? new Expression.Continue(tok.File, tok.Line, tok.Col)
                    : d;
                break;

            case TokenType.Register:
                var r = new Expression.Register(tok.File, tok.Line, tok.Col, tok.Lex, null);
                this.pastNodes.Push(r);
                n = Next(1).Type == TokenType.Colon 
                    ? ParseOnce(Peek())
                    : new Expression.Register(tok.File, tok.Line, tok.Col, tok.Lex, DataTypeKind.Int);
                break;

            case TokenType.Input:
                var i = new Expression.Input(tok.File, tok.Line, tok.Col);
                this.pastNodes.Push(i);
                n = i;
                break;

            case TokenType.Identifier:
                throw new Exception($"{tok}: Unknown Identifier \"{tok.Lex}\"");
                
            case TokenType.Colon:
                this.pastNodes.TryPop(out Node? left);
                ParseOnce(Next());
                this.pastNodes.TryPop(out Node? right);

                if (left == null) 
                    throw new Exception($"left of ':' is null - unknown target. ");

                if (right is not Expression.Data)
                    throw new Exception($"Expected a data type but got: {left.GetType().FullName}");

                var ri = right as Expression.Data;
                n = left switch
                {
                    Expression.Register rr => new Expression.Register(tok.File, tok.Line, tok.Col, rr.Id, ri!.Type),
                    Expression.Input    ii => new Expression.Input(tok.File, tok.Line, tok.Col, ri!.Type, ri.Value),
                                        _  => throw new Exception($"Expected either a register or an input on the left and a data type on the right of ':' - got \"{left.GetType().FullName}\":\"{right.GetType().FullName}\" (Parse.cs L111)")
                };
                break;

            case TokenType.Arrow:
                if (this.pastNodes.Count() > 0) {
                    this.pastNodes.TryPop(out n);
                    switch (n)
                    {
                        case Expression.Input inp:
                            inp.Data = new(DataTypeKind.Str, null);
                            break;

                        case Expression.Register reg:
                            reg.Data = new(reg.file, reg.line, reg.col, "int", 0);
                            break;
                    }
                    this.pastNodes.Clear();
                }

                n ??= new Expression.Arrow(tok);
                break;
            
            default:
                // System.Console.WriteLine(tok);
                break;
        }

        return n;
    }

    private Node Prev(int past = 1)
    {
        Stack<Node> t = new();
        Node res;
        if (this.pastNodes.Count() > 0)
            for(int i = 0; i < past; i++)
                t.Push(this.pastNodes.Pop());

        res = t.Pop();
        t.Push(res);

        while(t.Count > 0)
            this.pastNodes.Push(t.Pop());

        return res;
    }

    private Token Peek() => token.Current;
    private Token Peek(int ahead = 0) 
    {
        Token? t = null;
        if (ahead < 0) ahead = 0;
        if (ahead > 0) 
        {
            t = token.Current;
            while (ahead > 0)
            {
                while (futureTokens.Count() < ahead)
                    if (token.MoveNext())
                        futureTokens.Push(token.Current);

                t = token.Current;
                ahead--;
            }
            return t;
        }
        return token.Current;
    }

    private Token Next(int ahead = 1)
    {
        while (ahead-- > 0) 
            this.token.MoveNext();
        
        return this.token.Current;
    }
}