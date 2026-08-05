namespace Cryo;

public record Node(string file, int line, int col) : Object
{
    public override string ToString() => "";
}