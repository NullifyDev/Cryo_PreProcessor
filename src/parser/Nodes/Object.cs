namespace Cryo.PreProcessor;

public partial class Expression 
{
    public record Object(string file, int line, int col, Cryo.PreProcessor.Object Obj) : Node(file, line, col)
    {
        public override string ToString()
            => $"Object {this.Obj}";
    }
}