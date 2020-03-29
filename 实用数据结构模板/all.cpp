#include <cstdio>
#include <string>
#include <iostream>
using namespace std;
/**************         单独实现了数据结构, STL模板  所以直接套用。 剩余部分待完善     *******************************/
//upper_bound() upper_bound() sort()

/**
 *  @brief sort a equence using a predicate for comparison.
 *  @param begin    An iterator.
 *  @param end      Another iterator.
 *  @param comp     A comparison functor.
 *  @param fuction  The mothod of sort.
 *  @return         Nothing.
 *  Rearranges the elements in the range @p [begin,end)
*/
template <typename T>
void merge_sort()
{
}
template <typename T>
void quick_sort(T *begin, T *end)
{
}
template <typename T>
void sort(T *begin, T *end)
{
    quick_sort(begin, end);
}
template <typename T,typename G>
void sort(T *begin, T *end, G comp  ,void * fuction)
{
    
}
template <typename T,typename G>
void sort(T *begin, T *end, G comp  )
{
}
template <typename T>
T *lower_bound(T *be, T *ed, T dt)
{
    unsigned long long mid, left = 0, right = ed - be ;
    while (left < right)
    {
        mid = left + (right - left) / 2;
        if (*(be + mid) < dt)
        {
            left = mid + 1;
        }
        else
        {
            right = mid;
        }
    }
    return be + left;
}
template <typename T,typename G>
T *lower_bound(T *be, T *ed, T dt, G comp )
{
    unsigned long long mid, left = 0, right = ed - be ;
    while (left < right)
    {
        mid = left + (right - left) / 2;
        if (comp(*(be + mid), dt))
        {
            left = mid + 1;
        }
        else
        {
            right = mid;
        }
    }
    return be + left;
}
template <typename T>
T * upper_bound(T *be, T *ed, T dt)
{
    unsigned long long mid, left = 0, right = ed - be ;
    while (left < right)
    {
        mid = left + (right - left) / 2;
        if (*(be + mid) <= dt)
        {
            left = mid + 1;
        }
        else
        {
            right = mid;
        }
    }
    return be + left;
}
template <typename T,typename G>
T * upper_bound(T *be, T *ed, T dt, G comp )
{
    unsigned long long mid, left = 0, right = ed - be ;
    while (left < right)
    {
        mid = left + (right - left) / 2;
        if (!comp(dt,*(be + mid) ))
        {
            left = mid + 1;
        }
        else
        {
            right = mid;
        }
    }
    return be + left;
}
// vector allocate mem : if capt fact < 0.5 or not enough : resize()
// provide ADT : push_back(T data)  empty() T * begin() T* end()
//  void clear()

template <typename T>
class vector
{
private:
    T *_elem;
    T *_now;
    const unsigned long long INIT_SIZE = 32;
    const unsigned long long MIN_SIZE = 16; 
    unsigned long long _size = 0;
    unsigned long long _capacity = 32;
    void resize()
    {
        if (_size == _capacity)
        {
            _capacity = _capacity << 1;
            T *temp = new T[_capacity + 1];
            for (unsigned long long i = 0; i < _size; i++)
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
        else if (_size >= MIN_SIZE && _size < (_capacity >> 1))
        {
            _capacity = _capacity >> 1;
            T *temp = new T[_capacity + 1];
            for (unsigned long long i = 0; i < _size; i++)
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
        _elem = new T[INIT_SIZE + 1];
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
    T *find()
    {
        return NULL;
    }
    T *earse(const T *loc)
    {
        unsigned long long pos = loc - _elem;
        for (unsigned long long i = pos; i < _size; i++)
        {
            _elem[i] = _elem[i + 1];
        }
        _size--;
        resize();
        return pos + _elem;
    }
    void pop_back()
    {
        _elem[_size - 1] = T();
        _size--;
        resize();
    }

    void clear()
    {
    }
    unsigned long long size()
    {
        return _size;
    }
    unsigned long long capacity()
    {
        return _capacity;
    }
    inline T operator[](const unsigned long long pos) const
    {
        return *(_elem + pos);
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
        data = T();
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
    unsigned long long _size = 0;
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
    int remove(unsigned long long num)
    {
        unsigned long long i = 0;
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
    unsigned long long size()
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
    unsigned long long size()
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
    unsigned long long size()
    {
        return s.size();
    }
};
int comp(int a, int b){return a<b;}
int main()
{
    system("pause");
    return 0;
}
