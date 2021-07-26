#include <iostream>
#include <bits/stdc++.h>

using namespace std;

double metoda_bisekcji(double a, double b);
double f(double x);

int main()
{
    cout << metoda_bisekcji(-1, 0) << endl << metoda_bisekcji(0, 1);
    return 0;
}

double metoda_bisekcji(double a, double b)
{
    for(int i=0; i<16; i++)
    {
        if(f((a+b)/2)==0)
            return (a+b)/2;
        else if(f(a)*f((a+b)/2)<0)
            b = (a+b)/2;
        else
            a = (a+b)/2;
    }
    return (a+b)/2;
}

double f(double x)
{
    return ((x*x) - 2*cos(3*x + 1));
}
