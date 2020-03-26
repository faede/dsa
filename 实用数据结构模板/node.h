//  single dirction node
template <typename T>
class node
{
public:
    T data;
    node<T> *next;
    node<T> *prev;
    node()
    {
        next = nullptr;
        prev = nullptr;
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
        next = nullptr;
        prev = nullptr;
    }
};
