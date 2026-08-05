namespace Cryo;

public partial class Expression
{
    public record Arrow(Token token) : Node(token.File, token.Line, token.Col);
}
