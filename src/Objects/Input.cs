namespace Cryo;

public record Input : Object
{
    public Data? Data;

    public Input()
    {
        this.Data = null;
    }

    public Input(DataTypeKind type)
    {
        this.Data = new(type);
    }

    public Input(Data data)
    {
        this.Data = data;
    }

    public override string ToString()
        => $"Input: {this.Data?.Type}";
}