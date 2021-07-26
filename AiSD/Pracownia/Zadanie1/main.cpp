#include <bits/stdc++.h>

using namespace std;

#define F first
#define S second

typedef long long ll;

vector <pair<ll,ll> > dane;

int bin_search(int l, int p, ll szukana)
{
	int mid;
	if(l<=p)
	{
		mid = (l + p)/2;
		if(dane.at(mid).F == szukana){
            return mid;
		}
		if(dane.at(mid).F > szukana){
            return bin_search(l,mid-1,szukana);
		}
		return bin_search(mid+1,p,szukana);

    }
	return -1;
}

int main()
{
    int a, iter=0;
    ll sznurek, ilosc, wynik=0;
    scanf("%d", &a);
    for(int i=0;i<a;i++){
        scanf("%lld %lld", &sznurek, &ilosc);
        dane.push_back(pair<ll, ll>(sznurek,ilosc));
    }

    sort(dane.begin(),dane.end());

    do{
        if(dane.at(iter).S%2!=0){
            dane.at(iter).S-=1;
            wynik+=1;
        }
        if(dane.at(iter).S==0){
            iter+=1;
        }
        else{
            dane.at(iter).F*=2;
            dane.at(iter).S/=2;
            int szukana=bin_search(iter+1,dane.size()-1,dane[iter].F);
            if(szukana != -1){
                dane.at(szukana).S+=dane.at(iter).S;
                iter+=1;
            }
        }
    }
    while(iter<a);

    printf("%lld", wynik);
}
