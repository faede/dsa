//queue :
template <typename T>
class queue : private list<T>
{
private:
    list<T> s;

public:
    T front()
    {
        s.front();
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