namespace Cryo.PreProcessor;

public partial class Expression 
{
    public record Register : Node
    {
        public RegType Id;
        public Data? Data;

        public Register(string file, int line, int col, string register, DataTypeKind? type = null) : base(file, line, col)
        {
            RegType? r = Register.GetRegister(register) 
                      ?? throw new Exception($"Unknown register {Register.GetRegister(register)}");

            this.Id = (RegType)r;
            this.Data = type == null ? null : new Data(file, line, col, type.ToString() ?? "Int");
        }

        public Register(string file, int line, int col, RegType register, DataTypeKind? type = null) : base(file, line, col)
        {
            this.Id = register;
            this.Data = type == null ? null : new Data(file, line, col, type.ToString() ?? "Int");
        }

        public static RegType? GetRegister(string r) => r.ToLower() switch
        {   
            "rax" => RegType.rax,
            "rcx" => RegType.rcx,
            "rdx" => RegType.rdx,
            "rbx" => RegType.rbx,
            "rsp" => RegType.rsp,
            "rbp" => RegType.rbp,
            "rsi" => RegType.rsi,
            "rdi" => RegType.rdi,
            "r8"  => RegType.r8,
            "r9"  => RegType.r9,
            "r10" => RegType.r10,
            "r11" => RegType.r11,
            "r12" => RegType.r12,
            "r13" => RegType.r13,
            "r14" => RegType.r14,
            "r15" => RegType.r15,
                _ => null
        };

        public static bool IsRegister(string type)
        {
            switch(type.ToLower())
            {
                case "rax":
                case "rcx":
                case "rdx":
                case "rbx":
                case "rsp":
                case "rbp":
                case "rsi":
                case "rdi":
                case "r8":
                case "r9":
                case "r10":
                case "r11":
                case "r12":
                case "r13":
                case "r14":
                case "r15":
                    return true;

                default: return false;
            }
        }

        public override string ToString()
            => this.Data == null ? $"Register: {this.Id} (null)" : $"Register: {this.Id} ({this.Data.Type.ToString().ToLower()})";
    }
}