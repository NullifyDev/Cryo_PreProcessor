namespace Cryo.PreProcessor;

public partial class Expression 
{
    public record EOL(string file, int line, int col) : Node(file, line, col)
    {
        public override string ToString()
        => $"EOL";
    }
}