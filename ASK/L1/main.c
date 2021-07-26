#include <stdio.h>
#include <stdlib.h>
//Z1

unsigned int bit(unsigned int x, unsigned int i, unsigned int k){
    x=x&(1<<i)?                 //pytamy czy zmienna x ma zapalony i-ty bit
        x|(1<<k):               //jeœli tak to zapalamy k-ty bit jeœli jeszcze nie jest zapalony
        x&~(1<<k);              //jeœli nie, gasimy k-ty je¿eli zapalony
    return x;
}

//Z2

int nbits(unsigned int n)//z2 - sumowanie bitow po 2,4,8,16
{
    n=(n&0x55555555)+((n>>1)&0x55555555);   // sumuje 01010101 -> przesuwa o 1
    n=(n&0x33333333)+((n>>2)&0x33333333);   // sumuje 00110011 -> przesuwa o 2
    n=(n&0x0F0F0F0F)+((n>>4)&0x0F0F0F0F);   // sumuje 11110000 -> przesuwa o 4
    n=(n&0x00FF00FF)+((n>>8)&0x00FF00FF);   // sumuje 11111111 -> przesuwa o 8
    return (n&0xFF)+(n>>16);
}
// Z3

typedef struct A
{
    void *b;//4 bajtow
    int16_t d;//2 bajty
    int8_t a;//1 bajty
    int8_t c;//1 bajty
}A;

typedef struct B
{
    uint16_t a;//2 bajty
    double b;// 8 bajtow
    void* c;// 4 bajtow
}B;

//procesor zajmuje 8 bajtowe bloki, jeœli dana zmienna nie mieœci siê, przechodzi do nowej, zostawiaj¹c poprzednia//
// kompilator zapisuje zmienne po kolei od góry, zatem najlepszym rozwi¹zaniem jest ich tak aby zape³nia³y 8 bajtowe bloki//
/*

Z4


- <<volatile>> - zmienna ulotna - dodanie violatile do zmiennej
powoduje ze kompilator wezmie pod uwage ze zmienna moze zostac zmieniona
"z zewnatrz", nie tylko przez nasz kod
- <<static>> - zmienna nie usuwana przy zakonczeniu funkcji i zachowuje
swoja wartosc  - jest zapisywana w tej samej pamieci co zmienne globalne
i inicjowana wartoscia 0, zmienna ta jest dostepna tylko w obrebie funkcji
- <<restrict>> - wskaznik, ktory jest jedynym wskaznikiem na dany obszar
pamieci
*/

//Z5

/*s+=b[j+1]+b[--j];
        |
        V
    t := j+1
    t1 := t*4
    t2 := b[t1]
    j := j-1
    t3:= j*4
    t4 := b[t3]
    s := s+t2
    s := s+t5

a[i++]-=*b*(c[j*2]+1);

            |
            V

    t := j*2
    t1 := t*4
    t2 := c[t1]
    t3 := t2 + 1
    t4 := &b     //b jest wskaznikiem
    t5 := t4 * t3
    t6 := i*4
    t7 := a[t6]
    t8 := t7 - t5
    i := i + 1
*/
int main()
{
    unsigned n = 22;
    int i = nbits(n);
    printf("%d",i);
    return 0;
}
