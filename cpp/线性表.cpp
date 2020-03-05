#define OK 1
#define ERROR 0
#define OVERFLOW -2
typedef int Status;


typedef int ElemType;

//顺序表
typedef struct 
{
    ElemType *elem;
    int length;
}SqList;


//单向链表

typedef struct LNode{
   ElemType data;
   struct LNode *next;
}LNode,*LinkList;

//双向链表


typedef struct DuLNode
{
    ElemType data;
    struct DuLNode * prior;
    struct DuLNode * next;
}DuLNode,*DuLinkList;


typedef struct PNode
{
    float coef; //系数
    int expn;
    struct PNode *next; 
}PNode,* Polynomial;



//单向链表

Status InitList(LinkList &L)
{
    L = new LNode ;
    L->next = NULL;
    return OK;
} 

Status GetElem(LinkList L , int i , ElemType & e)
{
    LNode *p = L->next; 
    int j = 1;
    while(p&&j<i)
    {
        p = p->next;
        ++j;
    }
    if(!p||j>i)return ERROR;
    e = p->data;
    return OK;
}

LNode *LocateELem(LinkList L, ElemType e){
    LNode *p = L->next;
    while (p&&p->data!=e)
    {
        p = p->next;
    }
    return p;    
}

Status ListInsert(LinkList & L,int i, ElemType e)
{//在第i个位置插入 （到第i前
    LNode *p = L;
    int j = 0;
    while(p&&(j<i-1)){
        p = p->next;
        ++j;
    }
    if(!p||j>i-1)
        return ERROR;
    LNode *s = new LNode;
    s->data = e;
    s->next = p->next;
    p->next = s;
    return OK;
}

Status ListDelete(LinkList & L,int i)
{
    LNode *p = L;
    int j = 0;
    while((p->next) && (j<i-1)){
        p = p->next;
        ++j;
    }
    if(!(p->next)||j>i-1)
        return ERROR;
    LNode *q = p->next;
    p->next = q->next;
    delete q;
    return OK;
}

//前插法 输入顺序和线性表中逻辑顺序相反
void CreateList_H(LinkList &L ,int n)
{//逆序输入
    L = new LNode;
    L->next = NULL;
    LNode * p;
    for(int i = 0; i < n; i++)
    {
        p = new LNode;
        cin>>p->data;
        p->next = L->next;
        L->next = p;
    }
}

//后插法  相同
void CreateList_R(LinkList &L, int n){
    L = new LNode;
    L->next = NULL;
    LNode * r = L;
    LNode * p;
    for(int i = 0; i < n; i++){
        p = new LNode;
        cin>>p->data;
        p->next = NULL;
        r->next = p;
        r = p;
    }
}



//          循环链表 A B均为尾指针
//       合并：
//          p = B->next->next;   
//          B->next = A->next;
//          A->next = p;
//          delete B的头节点


//双向链表


Status ListDelete_Dul(DuLinkList &L, int i, ElemType e)
{// i前插入e
    DuLNode * p;
    if (!(p = GetElem_Dul(L,i)))
        return ERROR;
    DuLNode *s = new DuLNode;
    s->data = e;
    s->prior = p->prior;
    s->next = p;
    p->prior = s;
    return OK;
}

Status ListDelete_Dul(DuLinkList &L, int i)
{
    DuLNode * p;
    if(!(p = GetElem_Dul(L,i)))
        return ERROR;
    p->prior->next = p ->next;
    p->next->prior = p->prior;
    delete p;
    return OK;
}




void MergeList (List &LA, List LB)
{//把B中不在A中的插入A中
    int m = ListLength(LA), n = ListLength(LB);
    for(int i = 1; i <= n ;i++)
    {
        GetElem(LB, i, e);
        if(!LocateELem(LA,e))
            ListInsert(LA,++m,e);
    }
}
void MergeList_Sq(SqList LA, SqList LB,SqList & LC)
{//顺序有序表非递减
    LC.length = LA.length + LB.length;
    LC.elem = new ElemType[LC.length];
    ElemType * pc = LC.elem;
    ElemType * pa = LA.elem;
    ElemType * pb = LB.elem;
    ElemType * pa_last = LA.elem + LA.length - 1;
    ElemType * pb_last = LB.elem + LB.length - 1;
    while((pa <= pa_last)&&(pb <= pb_last))
    {
        if(*pa <= *pb)
            *pc++ = *pa++;
        else
            *pc++ = *pb++;
    }    
    while(pa <= pa_last)
        *pc++ = *pa++;
    while(pb <= pb_last)
        *pc++ = *pb++;
}
void MergeList_L(LinkList &LA, LinkList &LB, LinkList &LC)
{//LA LB非递减排列
    LNode * pa = LA->next;
    LNode * pb = LA->next;
    LC = LA;
    LNode * pc = LC;
    while(pa&&pb){
        if(pa->data )
    }

}

void MergeList_L(LinkList &LA, LinkList &LB, LinkList &LC)
{//LA LB非递减排列
    LNode * pa = LA->next;
    LNode * pb = LA->next;
    LC = LA;
    LNode * pc = LC;
    while(pa&&pb){
        if(pa->data <= pb->data){
            pc->next = pa;
            pc = pa ;
            pa = pa->next;
        }
        else
        {
            pc->next = pb;
            pc = pb;
            pb = pb->next;
        }
        
    }
    pc->next = pa? pa:pb;
    delete LB;
}









void CreatePolyn (Polynomial &P,int n)
{
    P = new PNode;
    P->next = NULL;
    PNode *pre;//前驱
    PNode *q;//第一个大于等于s的位置
    for(int i = 1; i <= n; i++)
    {
        PNode *s = new PNode;
        cin>>s->coef>>s->expn;
        pre = P;
        q = P->next;
        while (q&&q->expn < s->expn)
        {
            pre = q;
            q = q->next;
        }
        s->next = q;
        pre->next = s;
    }
} 

void AddPolyn (Polynomial &Pa,Polynomial &Pb)
{//多项式加法
    PNode *p1 = Pa->next;
    PNode *p2 = Pb->next;
    PNode *p3 = Pa; //当前操作的指针
    PNode *r;//删除节点用
    while(p1&p2)
    {
        if(p1->expn == p2->expn)
        {
            int sum = p1->coef + p2->coef;
            if(sum != 0)
            {
                p1->coef = sum;
                p3->next = p1;
                p3 = p1;
                p1 = p1->next;
                r = p2;
                p2 = p2->next;
                delete r;
            }
            else
            {
                r = p1;
                p1 = p1->next;
                delete r;
                r = p2;
                p2 = p2->next;
                delete r;
            }
            
        }
        else
        {
            if(p1->expn < p2->expn)
            {
                p3->next = p1;
                p3 = p1;
                p1 = p1->next;
            }
            else
            {
                p3->next = p2;
                p3 = p2;
                p2 = p2->next; 
            }
            
        }
        
    }
    
    p3->next = p1? p1 : p2;
    delete Pb;
}


