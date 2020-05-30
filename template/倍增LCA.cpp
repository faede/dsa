#include <iostream>
#include <cstdio>
#include <cstring>
#include <algorithm>
using namespace std;
inline int read() {
  char c = getchar();
  int x = 0, f = 1;
  while (c < '0' || c > '9') {
    if (c == '-') f = -1;
    c = getchar();
  }
  while (c >= '0' && c <= '9') {
    x = x * 10 + c - '0';
    c = getchar();
  }
  return x * f;
}

struct edge{
    int v ,nxt ;
}e[2*500000+100];

int head[500000+10] , tot , Lognn[500000+10],depth[500000+10],fa[500000+10][22];
void addedge(int x,int y){
    e[++tot].v = y;
    e[tot].nxt = head[x];
    head[x] = tot;
}
void dfs(int now ,int fath){
    fa[now][0] = fath;
    depth[now] = depth[fath] + 1;
    for(int i = 1; i <= Lognn[depth[now]]; i++)
        fa[now][i] = fa[fa[now][i-1]][i-1];
    for(int i = head[now]; i ; i = e[i].nxt )
        if(e[i].v != fath)
            dfs(e[i].v , now);
}
int LCA(int x , int y){
    if(depth[x] < depth[y])
        swap(x , y);
    while(depth[x] > depth[y])
       x = fa[x][Lognn[ depth[x] - depth[y] ] - 1];
    if(x == y )
        return x;
    for(int k = Lognn[depth[x]]  - 1; k >=0; k--)
        if(fa[x][k] != fa[y][k])
            x = fa[x][k] , y = fa[y][k];
    return fa[x][0]; 
}
int main() {
    int n, m, s; scanf("%d%d%d", &n, &m, &s);
    for(int i = 1; i <= n-1; ++i) {
        int x, y; scanf("%d%d", &x, &y);
        addedge(x, y); addedge(y, x);
    }
    for(int i = 1; i <= n; ++i)
        Lognn[i] = Lognn[i-1] + (1 << Lognn[i-1] == i);
    dfs(s, 0);
    for(int i = 1; i <= m; ++i) {
        int x, y; scanf("%d%d",&x, &y);
        printf("%d\n", LCA(x, y));
    }
    return 0;
}