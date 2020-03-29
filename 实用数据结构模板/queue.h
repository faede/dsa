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