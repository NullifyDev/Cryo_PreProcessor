public enum DataTypeKind
{
    None,
    Str,
    Int,
}

public enum RegType
{
    // 64bit
    rax,
    rcx,
    rdx,
    rbx,
    rsp,
    rbp,
    rsi,
    rdi,
    r8,
    r9,
    r10,
    r11,
    r12,
    r13,
    r14,
    r15,

    // 32bit
    eax,
    ecx,
    edx, 
    ebx,
    esp,
    ebp,
    esi,
    edi,

    r8d,
    r9d,
    r10d,
    r11d,
    r12d,
    r13d,
    r14d,
    r15d,


    // 16bit
    ax,
    cx,
    dx,
    bx,
    sp,
    bp,
    si,
    di,

    r8w,
    r9w,
    r10w,
    r11w,
    r12w,
    r13w,
    r14w,
    r15w,
}