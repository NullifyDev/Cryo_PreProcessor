namespace Cryo.PreProcessor;

public record Method : Object
{
    public Object[] Params;
    public Object Type;

    public Method(Object type, Object[]? parameters = null)
    {
        if(type is not Register && (type is not Data && (type as Data).Type != DataTypeKind.None)) 
        {
            System.Console.WriteLine($"Error: return types must either have \"None\" or registers of any type other than \"None\" - got: {type switch
            {
                Data d => $"Data:{d.Type}",
                Method m =>  $"Method({string.Join(", ", m.Params)}) -> {m.Type}",
                Input i => $"Input:{i.Data.Type}"
            }}");
            Environment.Exit(1);
        }

        foreach(var p in (this.Params ?? new Object[0]))
            if (p is Data) {
                System.Console.WriteLine($"Error: Parameter must NOT be Data got: Data.{p}");
                Environment.Exit(1);
            }
            
        this.Params = parameters ?? new Object[0];
        this.Type = type;
    }

    public override string ToString()
        => $"Method({string.Join(", ", this.Params)}): {this.Type.ToString()}";
}