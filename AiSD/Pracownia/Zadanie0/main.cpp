#include <iostream>

using namespace std;

int main()
{
    int a,b;
    scanf("%d %d", &a, &b);
    if(a>b){
        int t=a;
        a=b;
        b=t;
    }
    for (a; a<=b; a++){
        printf("%d \n", a);
    }


    return 0;
}
