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