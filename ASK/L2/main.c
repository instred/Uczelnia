int main(){
    long x = -100010101;
    long y = x>>31;
    long z;
    z = (x^y) - y;
    return z;
}
