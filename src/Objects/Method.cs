namespace Cryo.PreProcessor;

public record Method : Object
{
    public Object[] Params;
    public Object Type;

    public Method(Object type, Object[]? parameters = null)
    {
        this.Params = parameters ?? new Object[0];
        this.Type = type;
    }

    public override string ToString()
        => $"Method({string.Join(", ", this.Params)}): {this.Type.ToString()}";
}