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
