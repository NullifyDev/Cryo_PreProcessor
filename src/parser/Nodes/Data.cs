namespace Cryo;

public partial class Expression
{
    public record Data : Node
    {
        public DataTypeKind Type;
        public object? Value;

        public Data(string file, int line, int col, string dataType) : base(file, line, col)
        {
            DataTypeKind? dt = Data.GetDataType(dataType)
                      ?? throw new Exception($"Unknown register {Register.GetRegister(dataType)}");

            this.Type = (DataTypeKind)dt;
            this.Value = null;
        }

        public Data(string file, int line, int col, string dataType, object? value = null) : base(file, line, col)
        {
            DataTypeKind? dt = Data.GetDataType(dataType)
                      ?? throw new Exception($"Unknown register {Register.GetRegister(dataType)}");

            this.Type = (DataTypeKind)dt;
            this.Value = value;
        }

        public static DataTypeKind? GetDataType(string r) 
            => r.ToLower() switch
            {
                "str"  => DataTypeKind.Str,
                "int"  => DataTypeKind.Int,
                "none" => DataTypeKind.None,
                _      => DataTypeKind.None
            };
            // Enum.TryParse(typeof(DataTypeKind), r, true, out object? x);
            // return x as DataTypeKind?;
        // }

        public void SetType(string type)
        {
            Type = type.ToLower() switch
            {
                "str"  => DataTypeKind.Str,
                "int"  => DataTypeKind.Int,
                "none" => DataTypeKind.None,
                _      => DataTypeKind.None
            };
        }

        public static bool IsData(string type) => type.ToLower() switch
        {
            "str"  => true,
            "int"  => true,
            "none" => true,
            _      => false
        };

        public override string ToString()
            => $"Data: {this.Type}";
    }
}