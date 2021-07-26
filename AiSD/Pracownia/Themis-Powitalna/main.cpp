#include <iostream>
#include <math.h>
//Jakub Bok, 317026, PGA



using namespace std;

int main()
{
    float start,endd;
    scanf("%f %f", &start, &endd);
    for (float i=ceil(start/2021);i<floor(endd/2021)+1;i++){
        printf("%d ", (int)i*2021);
    }

}
