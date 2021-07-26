#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <limits>

////2
/*
    0.15625 == 0 01100 01000000000 == (-1)^0 * 2 ^ -3 * 1,25 ;; BIAS = exp - E
    0.15625 == 0 01111100 01000000000000000 = (-1)^0 * 2^-3 * 1,25
    Half Float (16 bits) =  min -2^16+e maks 2^16-e  1.9990234375
    Single Float (32 bits ) min -2^128+e maks 2^128-e  1.9999998807907104
*/


//4.
// na int_max np
// int_min - cokolwiek / int max - int min
// #t
// #t
// np z = 0




int main()
{
    int32_t x = 2147483647;
    int32_t y = 2147483647;
    int32_t z = 0;
    printf("%d \n %d \n %d", x, y, z);
    double dx = x;
    double dy = y;
    double dz = z;
    if(x){
        return( dx / dx == dz / dz );
    }
}
