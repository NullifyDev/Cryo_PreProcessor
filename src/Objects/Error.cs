namespace Cryo.PreProcessor;

public record Error : Object
{
    public ErrorType Type;
    public string Message;

    public Error(ErrorType type, string? msg)
    {
        this.Type = type;
        this.Message = $"{type}: {msg}" ?? type.ToString();
    }

    public override string ToString() => $"{this.Type}";
}

public enum ErrorType
{
    Success,
    UnknownObject,
}