namespace Cryo;

public record Data : Object
{
    public DataTypeKind Type;
    public object? Value;

    public Data(DataTypeKind type, object? value = null)
    {
        this.Type = type;
        this.Value = value;
    }
    public override string ToString() => this.Value == null ? $"{this.Type}" : $"({this.Type}){this.Value}";
}