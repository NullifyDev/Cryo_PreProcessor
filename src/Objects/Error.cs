namespace Cryo;

public record Error : Object
{
    public ErrorType Type;

    public Error(ErrorType type)
    {
        this.Type = type;
    }

    public override string ToString() => $"{this.Type}";
}

public enum ErrorType
{
    Success,
    UnknownObject,
}