
#include<bits/stdc++.h>
using namespace std;

const int ceilN = 1e6;
int ceilW = 1e9;
int parent[ceilN], rrank[ceilN];
int n,m,a,b,w;

pair<int, pair<int, int> > edges[ceilN];

int find_u(int a){
    if(parent[a] == a)
        return parent[a];

    return parent[a] = find_u(parent[a]);
}

void Unioon(int a, int b){
    if (rrank[a] < rrank[b])
        parent[a] = b;
    else if (rrank[a] > rrank[b])
        parent[b] = a;

    else {
        parent[a] = b;
        rrank[b]++;
    }

}

void find_mst(){
    for (int i=0; i<=n; i++){
        parent[i] = i;
        rrank[i] = -1;
    }
    for (int i=0; i<m; i++) {
        int a = edges[i].second.first;
        int b = edges[i].second.second;
        a = find_u(a);
        b = find_u(b);
        if (a != b) {
            Unioon(a, b);
            if(ceilW > -edges[i].first){
                ceilW = -edges[i].first;
            }
        }
    }
    printf("%d", ceilW);
}

void compute(){

    scanf("%d %d", &n, &m);
    for(int i=0;i<m;i++){
        scanf("%d %d %d", &a, &b, &w);
        edges[i] = {-w, {a,b}};
    }
    sort(edges, edges+m);
    find_mst();
}

int main(){

    compute();
    return 0;
}

