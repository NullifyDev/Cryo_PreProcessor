namespace Cryo;

public partial class Expression
{
    public record Block : Node
    {
        

        public Block(string file, int line, int col) : base(file, line, col)
        {
            
        }
    }
}
