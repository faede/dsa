//on List ,I found in cppreference the operate of list provide can't meet the
// need on practice ,so I reconstrut the ADT .
template <typename T> class list:public node<T> {
    private:
        unsigned int _size = 0;
        node<T> *head;
        node<T> *tail; 
    public:
    list(){
        head = new  node<T>();
        tail = head;
    }
    bool empty(){
        return (size == 0 );
    }
    void insert(T data){
        node<T> *p = new node<T>(data);
        if(p == nullptr){
            //std::cout<<"mem not enough! please try again"<<endl;
            return ;
        }
        tail->next = p; 
        tail = p;
        _size++;
    }
    void push_back(){

    }
    void push_front(){

    }
    void clear(){

    }
    
    void remove(){

    }
    unsigned int size(){
        return _size;
    }
    void reverse(){

    }
    void merge(){

    }
    node<T> * back(){
        return tail;
    }
    node<T> * front(){
        return head->next;
    }
    
};