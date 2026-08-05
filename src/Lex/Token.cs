public enum TokenType
{
    Identifier,
    Register,
    Data,
    Input,
    
    Arrow,

    Colon,

    LParen, RParen,

    EOL, EOF,
    Unknown
}

public record Token
{
    public string File, Lex;
    public TokenType Type;
    public int Line, Col;

    public Token(string file, TokenType type, string lex, int line, int col)
    {
        this.File = file;
        this.Col = col;
        this.Line = line;
        this.Type = type;
        this.Lex = lex;
    }

    public override string ToString() 
        => $"Token({this.File}({this.Line}:{this.Col}): {this.Type}: {this.Lex})";
}