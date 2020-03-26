#include <cstdio>
#include <string>
#include<iostream>
#include <algorithm>
using namespace std;
// vector allocate mem : if capt fact < 0.5 or not enough : resize()
// provide ADT : push_back(T data)  empty() T * begin() T* end()
// T* lower_bound(T*begin , T* end ,T dt) T* lower_bound(T*begin , T* end ,T dt,void * comp)
// T* upper_bound() T* find() void clear()
template <typename T> class vector{
    private:
        T * _elem;
        T * _now;
        unsigned int INIT_SIZE = 100;
        unsigned int _size = 0;
        unsigned int _capacity = 100;
        void resize(){
            if( _size > _capacity ){
                _capacity = _capacity<<1;
                T * temp = new T [_capacity+1];
                for(int i = 0; i < _size; i++){
                    temp[i] = _elem[i];
                }
                delete []_elem;
                _elem = temp;
                if(_size >= 1)
                    _now = _elem + (_size - 1);
                else{
                    _now = _elem;
                }
            }
            else if( _size < (_capacity>>1)){
                _capacity = _capacity>>1;
                T * temp = new T [_capacity+1];
                for(int i = 0; i < _size; i++){
                    temp[i] = _elem[i];
                }
                delete []_elem;
                _elem = temp;
                if(_size >= 1)
                    _now = _elem + (_size - 1);
                else{
                    _now = _elem;
                }
            }
        }
    public:
        vector(){
            _elem = new T [INIT_SIZE];
            _size = 0;
            _capacity = INIT_SIZE;
            _now = _elem;
        }
        void push_back(T data){
            resize();
            _elem[_size] = data;
            _size++;
            _now = _now + 1;
        }
        bool empty(){
            return _size == 0;
        }
        T * begin(){
            return _elem;
        }
        T* end(){
            return _elem + _size ;
        }
        T* lower_bound(T*begin , T* end ,T dt){
            return nullptr;
        } 
        T* lower_bound(T*begin , T* end ,T dt,void * comp){
            return nullptr;
        }
        T* upper_bound(){
            return nullptr;
        }
        T* find(){
            return nullptr;
        }
        void clear(){

        }
};

//  single dirction node
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
template <typename T> class stack:public list<T>{
    private:
    public:
    void pop(){

    }
    T top(){

    }
    void push(){

    }
};
template <typename T> class queue:public list<T>{
    private:
    public:
    T front(){

    }
    T push(){

    }
    T pop(){

    }
};
int main()
{
    list<int> l;
    l.insert(5);
    cout<<l.front()->data<<endl;
    system("pause");
    return 0;
}