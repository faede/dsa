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
