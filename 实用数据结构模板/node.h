template <typename T> class node{
    public:
        T data;
        node * next;
    node(){
        next = nullptr;
        data = NULL;
    }
    node(T dt,node * nxt){
        data = dt;
        next = nxt;
    }
    node(T dt){
        data = dt;
        next = nullptr;
    }
};