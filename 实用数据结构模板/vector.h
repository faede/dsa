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