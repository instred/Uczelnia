#include <stdio.h>
#include <stdlib.h>

int main()
{
    printf("Hello world!\n");
    return 0;
}


//1
/*
1.wartosc z danego adresu
2.wartosc z danego adresu
2.dana wartosc
*/

//3

1. jae ~CF
CF set if carry/borrow out from most significant bit
2. jl SF ^ OF
OF - overflow
SF - is negative
3. ja ~CF & ~ZF
ZF - if a==b


//4
%edi = 0x4A 3B 2C 1D

ROR %edi, 8         %edi = 0x1D 4A 3B 2C
ROL %di, 8          %edi = 0x1D 4A 2C 3B
ROL %edi, 16         %edi = 0x2C 3B 1D 4A
ROL %di, 8          %edi = 0x2C 3B 4A 1D
ROR %edi, 8         %edi = 0x1D 2C 3D 4A
MOVQ %edi,%eax      %eax = 0x1D 2C 3D 4A

uint32_t rotr32 (uint32_t value, unsigned int count) {
    const unsigned int mask = 8 * sizeof(value) - 1;
    count &= mask;
    return (value >> count) | (value << (-count & mask));
}
//7
add(%rdi,)
cmovenc(,%rax)
