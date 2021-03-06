bool toposort() {
    q = new queue();
    for (i = 0; i < n; i++)
        if (in_deg[i] == 0) q.push(i);
    ans = new vector();
    while (!q.empty()) {
        u = q.pop();
        ans.push_back(u);
        for each edge(u, v) {
            if (--in_deg[v] == 0) q.push(v);
        }
    }
    if (ans.size() == n) {
        for (i = 0; i < n; i++)
            std::cout << ans[i] << std::endl;
        return true;
    } else {
        return false;
    }
}





// dfs 版本
bool dfs(int u) {
  c[u] = -1;
  for (int v = 0; v <= n; v++)
    if (G[u][v]) {
      if (c[v] < 0)
        return false;
      else if (!c[v])
        dfs(v);
    }
  c[u] = 1;
  topo.push_back(u);
  return true;
}
bool toposort() {
  topo.clear();
  memset(c, 0, sizeof(c));
  for (int u = 0; u <= n; u++)
    if (!c[u])
      if (!dfs(u)) return false;
  reverse(topo.begin(), topo.end());
  return true;
}