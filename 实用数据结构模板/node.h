//  double dirction node
template <typename T>
class node
{
public:
    ~node(){};
    T data;
    node<T> *next;
    node<T> *prev;
    node()
    {
        next = NULL;
        prev = NULL;
        data = NULL;
    }
    node(node<T> *pra, node<T> *nxt, T dt)
    {
        data = dt;
        next = nxt;
        prev = pra;
        pra->next = this;
        nxt->prev = this;
    }
    node(T dt)
    {
        data = dt;
        next = NULL;
        prev = NULL;
    }
};