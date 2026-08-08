namespace Cryo;

public class Lexer
{
    private string file, contents;
    private int line, col, curr;
    private Dictionary<string, TokenType> keyword;

    public Lexer(string file, string src)
    {
        this.file = file;
        this.contents = src;
        this.curr = 0;
        this.line = 1;
        this.col  = 1;
        this.keyword = new()
        {
            ["input"] = TokenType.Input,
        };
    }

    public IEnumerable<Token> Lex(char? lexItem = null)
    {
        while(!AtEnd()) 
        {
            char c = lexItem ?? Peek();
            switch(c)
            {
                case ' ': break;

                case '(': 
                    yield return new Token(file, TokenType.LParen, "(", line, col);
                    break;

                case ')': 
                    yield return new Token(file, TokenType.RParen, ")", line, col);
                    break;

                case '\n':
                    Token t = new Token(file, TokenType.EOL, "\\n", line, col);
                    line++;
                    col=1;
                    yield return t;
                    break;

                case '-':
                    if (Next() == '>') 
                        yield return new Token(file, TokenType.Arrow, "->", line, col);
                    break;

                case ':':
                    yield return new Token(file, TokenType.Colon, c.ToString(), line, col);
                    break;

                default:
                    yield return char.IsLetterOrDigit(c)
                        ? scanIdentifier()
                        : new Token(file, TokenType.Unknown, c.ToString(), line, col);
                    break;
            }
            Next();
        }
        yield return new Token(file, TokenType.EOF, "\\0", line, col);
    }

    private Token scanIdentifier()
    {
        int l = line, co = col;
        string token = Peek().ToString();
        while (Peek(1) == '_' || char.IsLetterOrDigit(Peek(1))) token += Next(); 

        
        // Next();
        if (Expression.Register.IsRegister(token))
            return new(file, TokenType.Register, token, l, col);

        if (Expression.Data.IsData(token))
            return new(file, TokenType.Data, token, l, col);

        if (this.keyword.ContainsKey(token))
            return new(file, keyword[token], token, l, col);

        return new (file, TokenType.Identifier, token, l, col);
    }

    // private Token scanStringLit()
    // {
    //     int l = line, c = col;
    //     string token = ""; // Peek().ToString();
    //     while (Peek(1) != '"') token += Next();

    //     Next();
    //     return new(file, TokenType.StringLiteral, token, l, c-1);
    // }

    private bool AtEnd(int ahead = 0) => this.curr + ahead >= this.contents.Length;
    private char Peek (int ahead = 0) => AtEnd(ahead) ? '\0' : this.contents[this.curr+ahead];
    private char Next (int ahead = 1)
    {
        if (ahead < 1) ahead = 1;
        curr+=ahead;
        col+=ahead;
        return Peek();
    }
}