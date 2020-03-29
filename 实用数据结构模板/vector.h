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
