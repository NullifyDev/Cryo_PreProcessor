namespace Cryo.PreProcessor;

public record Register : Object
{
    public RegType Id;
    public Data Data;

    public Register(RegType id, Data data)
    {
        this.Id = id;
        this.Data = data;
    }

    public override string ToString() 
        => this.Data.Value == null 
            ? $"{this.Id}:{this.Data.Type}" 
            : $"{this.Id}:{this.Data.Type} = {this.Data.Value}";
}