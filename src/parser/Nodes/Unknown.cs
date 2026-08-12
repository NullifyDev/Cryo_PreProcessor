namespace Cryo.PreProcessor;

public partial class Expression
{
    public record Unknown : Node
    {
        public TokenType Type;
        public string Lex;

        public Unknown(Token token) : base(token.File, token.Line, token.Col)
        {
            this.Lex = token.Lex;
            this.Type = token.Type;
        }
        public override string ToString()
        => $"Unknown: {this.Type} ({this.Lex})";
    }
}