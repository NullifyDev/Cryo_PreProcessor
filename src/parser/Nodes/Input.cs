using System.ComponentModel.DataAnnotations;

namespace Cryo;

public partial class Expression 
{
    public record Input : Node
    {
        public Cryo.Data? Data;

        public Input(string file, int line, int col, DataTypeKind? type = null, object? value = null) : base(file, line, col)
        {
            this.Data = type == null ? null : new ((DataTypeKind)type, value);
        }

        public void Get()
        {
            this.Data?.Value = System.Console.ReadLine()!;
        }

        public override string ToString() => this.Data == null ? "Input" : $"Input: {this.Data.Type}";
    }
}