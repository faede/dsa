#define OK 1
#define ERROR 0
#define OVERFLOW -2
typedef int Status;
#define MAXQSIZE 100
typedef int QElemType ;
typedef int SElemType;
typedef struct 
{
    QElemType *base;
    int front;
    int rear;
}SqQueue;
// 循环队列
Status InitQueue(SqQueue & Q)
{
    Q.base = new QElemType [MAXQSIZE];
    if(!Q.base)
        exit(OVERFLOW);
    Q.front = Q.rear = 0;
    return OK;
}
int QueueLength(SqQueue Q)
{
    return (Q.rear - Q.front + MAXQSIZE) % MAXQSIZE;
}
Status DeQueue(SqQueue &Q ,QElemType &e)
{
    if(Q.front == Q.rear)
        return ERROR;
    e = Q.base[Q.front];
    Q.front = (Q.front + 1)%MAXQSIZE;
    return OK;
}
SElemType GetHead(SqQueue Q)
{
    if(Q.front != Q.rear)
        return Q.base[Q.front];
}
//队列的链式存储
typedef struct QNode
{
    QElemType data;
    struct QNode *next;
}QNode, *QueuePtr;
typedef struct 
{
    QueuePtr front;
    QueuePtr rear;
}LinkQueue;


Status InitQueue(LinkQueue &Q)
{
    Q.front =  Q.rear = new QNode;
    Q.front->next = NULL;
    return OK;
}
Status EnQueue(LinkQueue &Q,QElemType &e)
{
    QNode * p = new QNode;
    p->data = e;
    p->next =NULL;
    Q.rear->next = p;
    Q.rear = p;
    return OK;
}

Status DeQueue(LinkQueue &Q ,QElemType &e)
{
    if(Q.front == Q.rear)
        return ERROR;
    QNode *p = Q.front->next;
    p->next = Q.front->next->next;
    e = p->data;
    Q.front->next = p->next;
    if(Q.rear = p)
    {
        Q.rear = Q.front;
    }
    delete p;
    return OK;
}
