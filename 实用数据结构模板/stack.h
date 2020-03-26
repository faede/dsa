//stack :
template <typename T>
class stack : private list<T>
{
private:
    list<T> s;

public:
    void pop()
    {
        s.pop_front();
    }
    T top()
    {
        s.front();
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
