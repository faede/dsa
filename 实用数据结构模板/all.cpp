#include <cstdio>
#include <string>
#include <iostream>
#include <algorithm>
using namespace std;
/**************         单独实现了数据结构模板 所以直接套用。 剩余部分待完善     *******************************/
// vector allocate mem : if capt fact < 0.5 or not enough : resize()
// provide ADT : push_back(T data)  empty() T * begin() T* end()
// T* lower_bound(T*begin , T* end ,T dt) T* lower_bound(T*begin , T* end ,T dt,void * comp)
// T* upper_bound() T* find() void clear()
template <typename T>
class vector
{
private:
    T *_elem;
    T *_now;
    unsigned int INIT_SIZE = 100;
    unsigned int _size = 0;
    unsigned int _capacity = 100;
    void resize()
    {
        if (_size > _capacity)
        {
            _capacity = _capacity << 1;
            T *temp = new T[_capacity + 1];
            for (int i = 0; i < _size; i++)
            {
                temp[i] = _elem[i];
            }
            delete[] _elem;
            _elem = temp;
            if (_size >= 1)
                _now = _elem + (_size - 1);
            else
            {
                _now = _elem;
            }
        }
        else if (_size < (_capacity >> 1))
        {
            _capacity = _capacity >> 1;
            T *temp = new T[_capacity + 1];
            for (int i = 0; i < _size; i++)
            {
                temp[i] = _elem[i];
            }
            delete[] _elem;
            _elem = temp;
            if (_size >= 1)
                _now = _elem + (_size - 1);
            else
            {
                _now = _elem;
            }
        }
    }

public:
    ~vector() { delete[] _elem; };
    vector()
    {
        _elem = new T[INIT_SIZE];
        _size = 0;
        _capacity = INIT_SIZE;
        _now = _elem;
    }
    void push_back(T data)
    {
        resize();
        _elem[_size] = data;
        _size++;
        _now = _now + 1;
    }
    bool empty()
    {
        return _size == 0;
    }
    T *begin()
    {
        return _elem;
    }
    T *end()
    {
        return _elem + _size;
    }
    T *lower_bound(T *begin, T *end, T dt)
    {
        return NULL;
    }
    T *lower_bound(T *begin, T *end, T dt, void *comp)
    {
        return NULL;
    }
    T *upper_bound()
    {
        return NULL;
    }
    T *find()
    {
        return NULL;
    }
    void clear()
    {
    }
};

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

//on List ,I found in cppreference the operate of list provide can't meet the
// need on practice ,so I reconstrut the ADT .
template <typename T>
class list : public node<T>
{
private:
    unsigned int _size = 0;
    node<T> *head;
    node<T> *tail;

public:
    ~list() { clear(); };
    list()
    {
        head = new node<T>();
        tail = new node<T>();
        head->next = tail;
        tail->prev = head;
    }
    bool empty()
    {
        return (_size == 0);
    }
    void push_back(T data)
    {
        new node<T>(tail->prev, tail, data);
        _size++;
    }
    void push_front(T data)
    {
        new node<T>(head, head->next, data);
        _size++;
    }
    void pop_back()
    {
        node<T> *p = tail->prev, *q;
        q = p->prev;
        q->next = tail;
        tail->prev = q;
        delete p;
        _size--;
    }
    void pop_front()
    {
        /*if(size()==0){//或许是这里出现了问题
            return ;
        }*/
        node<T> *p = head->next, *q;
        q = p->next;
        head->next = q;
        if (q != NULL)
            q->prev = head;
        delete p;
        _size--;
    }
    void clear()
    {
        node<T> *p = tail->prev, *q;
        while (p != head)
        {
            q = p->prev;
            q->next = tail;
            tail->prev = q;
            delete p;
            p = q;
        }
        _size = 0;
    }
    node<T> *find_first(T data)
    {
        node<T> *p = head->next;
        while (p != tail)
        {
            if (p->data == data)
            {
                return p;
            }
            else
            {
                p = p->next;
            }
        }
        return NULL;
    }
    int remove(unsigned int num)
    {
        unsigned int i = 0;
        node<T> *p = head, *before, *after;
        while (i <= num)
        {
            if (p != tail)
            {
                p = p->next;
                i++;
            }
            else
                return -1;
        }
        before = p->prev;
        after = p->next;
        after->prev = before;
        before->next = after;
        delete p;
        _size--;
        return 0;
    }
    void print_list_inorder()
    {
        node<T> *p = head->next;
        std::cout << "the elem of list :";
        while (p != tail)
        {
            cout << p->data << " ";
            p = p->next;
        }
        std::cout << endl;
    }
    unsigned int size()
    {
        return _size;
    }
    void reverse()
    {
    }
    void merge()
    {
    }
    T back()
    {
        return tail->prev->data;
    }
    T front()
    {
        return head->next->data;
    }
    node<T> *end()
    {
        return tail;
    }
};

//stack :
template <typename T>
class stack : private list<T>
{
private:
    list<T> s;

public:
    ~stack(){};
    void pop()
    {
        s.pop_front();
    }
    T top()
    {
        return s.front();
    }
    void push(T data)
    {
        s.push_front(data);
    }
    bool empty()
    {
        return s.empty();
    }
    unsigned int size()
    {
        return s.size();
    }
};

//queue :
template <typename T>
class queue : private list<T>
{
private:
    list<T> s;

public:
    ~queue(){};
    T front()
    {
        return s.front();
    }
    void push(T data)
    {
        s.push_back(data);
    }
    void pop()
    {
        s.pop_front();
    }
    bool empty()
    {
        return s.empty();
    }
    unsigned int size()
    {
        return s.size();
    }
};
int main()
{
    
    system("pause");
    return 0;
}
