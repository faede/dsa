#define OK 1
#define ERROR 0
#define OVERFLOW -2
typedef int Status;


//顺序栈
#define MAXSIZE 100
typedef int SElemType;

typedef struct 
{
    SElemType *base;//栈底指针
    SElemType *top;//栈顶指针
    int stacksize;//栈可用最大容量
}SqStack;

Status InitStack(SqStack &S)
{
    S.base = new SElemType[MAXSIZE];
    if(!S.base)
        exit(OVERFLOW);
    S.top = S.base;
    S.stacksize = MAXSIZE;
    return OK;
}

Status Push(SqStack &S, SElemType e)
{
    if(S.top - S.base == S.stacksize)
        return ERROR;
    *S.top++ = e;
    return OK;
}
Status Pop(SqStack &S, SElemType &e)
{
    if(S.top == S.base)
        return ERROR;
    e = *--S.top;
    return OK;
}

SElemType GetTop(SqStack S)
{
    if(S.top != S.base)
        return *(S.top - 1);
}

// --------- 链式栈的存储结构
typedef int ElemType;
typedef struct StackNode;
{
    ElemType data;
    struct StackNode *next;
}StackNode,* LinkStack;

Status Push(LinkStack & S,SElemType e)
{
    StackNode *p = new StackNode;
    p->data = e;
    p->next = S;
    S = p;
    retunr OK;
}
Status Pop(LinkStack & S, SElemType &e)
{
    if(S==NULL)
        return ERROR;
    e = S->data;
    StackNode *p = S;
    S = S->next ;
    delete p;
    return OK;
}
SElemType GetTop(LinkStack S)
{
    if(S!=NULL)
        return S->data;
}
