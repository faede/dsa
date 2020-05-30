
#include <iostream>
#include <vector>
#include <queue>
#include <cstdio>
#include <algorithm>
using namespace std;
const int MAXM= 2*500010;
const int MAXN= 100010;
int head[MAXN],dis[MAXN],cnt,vis[MAXN]; 
struct Edge{
    int v,w,nxt;
}e[MAXM];
void add(int u,int v ,int w){
    e[++cnt].v = v;
    e[cnt].w = w;
    e[cnt].nxt = head[u];
    head[u] = cnt;
}
typedef pair <int ,int > pii;
priority_queue<pii,vector<pii>,greater<pii> > q; 
int s ;
void dij(){
    dis[s] = 0;
    q.push(make_pair(0,s));
    while (!q.empty()){
        int d = q.top().first;//not used
        int u = q.top().second;
        q.pop();
        if(vis[u])
            continue ;
        vis [u] = 1;
        for(int i = head[u] ; i ; i = e[i].nxt){
            if(dis[u]+e[i].w<dis[e[i].v]){
                    dis[e[i].v] = dis[u] + e[i].w;
                    q.push(make_pair(dis[e[i].v] ,e[i].v ));
            }
        }
    }
}

int m,n;

int main()
{
    scanf( "%d%d%d", &n, &m, &s );
    for(int i = 1; i <= n; ++i)dis[i] = 0x0c0c0c0c;
    for( register int i = 0; i < m; ++i )
    {
        register int u, v, d;
        scanf( "%d%d%d", &u, &v, &d );
        add( u, v, d );
    }
    dij();
    for( int i = 1; i < n; i++ )
        printf( "%d ", dis[i] );
        printf( "%d\n", dis[n] );
    system("pause");
    return 0;
}