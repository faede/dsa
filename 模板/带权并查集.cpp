//带权并查集 HDU 3038
#include <iostream>
#include <cstdio>
#include <cmath>
#include <algorithm>
using namespace std;
typedef long long ll;
int n , m , fa [200000 + 5], v [200000 + 5] ,cnt;//v[i]: 到fa[i]的距离
//并查集的fa就是左端点 路径压缩的时候find（x ）会自动扩张到
int find (int x)
{
	if (x == fa[x]) return x;
	int t = find(fa[x]);//找根节点
	v[x] += v[fa[x]];//逐层累加
	return fa[x] = t;
}
void addedge (int x, int y, int w)
{
	int fx, fy;
	fx = find(x);
	fy = find(y);
	if (fx != fy)
	{
		//fa[fx] = fy;
		//v[fx] = - v[x] + v[y] - w;
        if(fx < fy){   
            fa[fy] = fx;
            v[fy] = -v[y] + v[x] + w; 
        } 
        else{
            fa[fx] = fy;
            v[fx] = -v[x] + v[y] - w;
        }
	}
	else if (v[y] - v[x] != w)
			cnt ++;
}
int main()
{
    int x , y ,w ;
    while (cin>>n>>m){
        cnt = 0;
        for(int i = 0 ; i <= n ; i++)
            fa[i] = i,v[i] = 0;

        for(int i = 1 ; i <= m ;i++){
            cin>>x>>y>>w;
            x--;
            addedge(x,y,w);
        }
        cout<<cnt<<endl;
    }

    //system("pause");
    return 0 ;
}