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
            this.Data = type == null ? null : new Data(file, line, col, type.ToString() ?? "None");
        }

        public Register(string file, int line, int col, RegType register, DataTypeKind? type = null) : base(file, line, col)
        {
            this.Id = register;
            this.Data = type == null ? null : new Data(file, line, col, type.ToString() ?? "None");
        }

        public static RegType? GetRegister(string r) => r.ToLower() switch
        {   
            "rax"  => RegType.rax,
            "rcx"  => RegType.rcx,
            "rdx"  => RegType.rdx, 
            "rbx"  => RegType.rbx,
            "rsp"  => RegType.rsp,
            "rbp"  => RegType.rbp,
            "rsi"  => RegType.rsi,
            "rdi"  => RegType.rdi,
            "r8"   => RegType.r8,
            "r9"   => RegType.r9,
            "r10"  => RegType.r10,
            "r11"  => RegType.r11,
            "r12"  => RegType.r12,
            "r13"  => RegType.r13,
            "r14"  => RegType.r14,
            "r15"  => RegType.r15,
            "eax"  => RegType.eax,
            "ecx"  => RegType.ecx,
            "edx"  => RegType.edx, 
            "ebx"  => RegType.ebx,
            "esp"  => RegType.esp,
            "ebp"  => RegType.ebp,
            "esi"  => RegType.esi,
            "edi"  => RegType.edi,
            "r8d"  => RegType.r8d,
            "r9d"  => RegType.r9d,
            "r10d" => RegType.r10d,
            "r11d" => RegType.r11d,
            "r12d" => RegType.r12d,
            "r13d" => RegType.r13d,
            "r14d" => RegType.r14d,
            "r15d" => RegType.r15d,
            "ax"   => RegType.ax,
            "cx"   => RegType.cx,
            "dx"   => RegType.dx,
            "bx"   => RegType.bx,
            "sp"   => RegType.sp,
            "bp"   => RegType.bp,
            "si"   => RegType.si,
            "di"   => RegType.di,
            "r8w"  => RegType.r8w,
            "r9w"  => RegType.r9w,
            "r10w" => RegType.r10w,
            "r11w" => RegType.r11w,
            "r12w" => RegType.r12w,
            "r13w" => RegType.r13w,
            "r14w" => RegType.r14w,
            "r15w" => RegType.r15w,
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
                case "eax":
                case "ecx":
                case "edx": 
                case "ebx":
                case "esp":
                case "ebp":
                case "esi":
                case "edi":
                case "r8d":
                case "r9d":
                case "r10d":
                case "r11d":
                case "r12d":
                case "r13d":
                case "r14d":
                case "r15d":
                case "ax":
                case "cx":
                case "dx":
                case "bx":
                case "sp":
                case "bp":
                case "si":
                case "di":
                case "r8w":
                case "r9w":
                case "r10w":
                case "r11w":
                case "r12w":
                case "r13w":
                case "r14w":
                case "r15w":
                    return true;

                default: return false;
            }
        }

        public override string ToString()
            => this.Data == null ? $"Register: {this.Id} (null)" : $"Register: {this.Id} ({this.Data.Type.ToString().ToLower()})";
    }
}