namespace Cryo.PreProcessor;

public partial class Expression 
{
    public record Continue(string file, int line, int col) : Node(file, line, col)
    {
        public override string ToString()
            => $"Continue";
    }
}