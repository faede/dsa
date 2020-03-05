#include <cstdio>
#include <cstring>
#include<iostream>
#include<cmath>
#include <algorithm>
using namespace std;
const int maxn = 100000+5,logn = 18;
int f[maxn][logn] , Logn[maxn] , bin[22];
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
void pre(){
    Logn[1] = 0;
    Logn[2] = 1;
    for(int i = 3; i < maxn; i++)
        Logn[i] = Logn[i/2] + 1;
    bin[0] = 1;
    for(int i = 1 ;i <= 21; i++)
        bin[i] = bin[i-1]*2;
}
int n , m;
int main(){
     //cout<<log2(100000)<<endl;
    int n = read(), m = read();
    for(int i = 1; i <= n; i++)
        f[i][0] = read();
    pre();
    for(int j = 1; j <= logn; j++)
        for(int i = 1; i +  bin[j-1] <= n; i++)
            f[i][j] = max (f[i][j-1] ,f[i+bin[j-1]][j-1] );
    for(int i = 1; i<= m; i++){
        int x = read(), y = read();
        int s = Logn[y - x + 1];
        printf("%d\n",max(f[x][s],f[y - bin[s]+1][s]));
    }
    //system("pause");
    return 0;
}