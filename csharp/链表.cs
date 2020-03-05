using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    


     public partial class DSA_LIST : Form
     {
          class CSListnode<Type>//单链表结点类
          {
               private Type data;
               private CSListnode<Type> next;
               private int age = 0;
               //--------------------------------------------------------------------------------
               public CSListnode()
               {
                    //data=0;
                    next = null;
               }
               public CSListnode(Type data)
               {
                    this.data = data;
                    next = null;
               }
               public CSListnode(Type data, CSListnode<Type> next)
               {
                    this.data = data;
                    this.next = next;
               }
               public Type Data
               {
                    get
                    {
                         return data;
                    }
                    set
                    {
                         data = value;
                    }
               }
               public CSListnode<Type> Next
               {
                    get
                    {
                         return next;
                    }
                    set
                    {
                         next = value;
                    }
               }
          }
          //================================================================================
          class CSList<Type>
          {
               private CSListnode<Type> head;
               private CSListnode<Type> current;//指向当前节点的指针
                                                //--------------------------------------------------------------------------------
               public CSList()
               {
                    head = new CSListnode<Type>();
                    current = head;
               }
               public void SetCurrent(CSListnode<Type> cp) { current = cp; }//设置当前指针
               public CSListnode<Type> GetCurrent() { return current; }//返回当前指针
               public Type GetCurrentData() { return current.Data; }//返回当前数据
               public CSListnode<Type> Getnext() { return current.Next; }//返回下一结点地址
               public CSListnode<Type> Gethead() { return head; }//返回头结点地址
               public void Modifydata(Type value) { current.Data = value; }//修改当前结点数据
               public CSListnode<Type> Current//返回指针
               {
                    get
                    {
                         return current;
                    }
                    set
                    {
                         current = value;
                    }
               }
               public CSListnode<Type> Next
               {
                    get
                    {
                         return current.Next;
                    }
               }
               public CSListnode<Type> Head
               {
                    get
                    {
                         return head;
                    }
               }
               public Type CurrentData
               {
                    get
                    {
                         return current.Data;
                    }
                    set
                    {
                         current.Data = value;
                    }
               }
               public CSListnode<Type> Rear
               {
                    get
                    {
                         CSListnode<Type> p = head;
                         while (p.Next != null)
                              p = p.Next;
                         return p;
                    }
               }
               public int Length//单链表长度
               {
                    get
                    {
                         CSListnode<Type> p = head.Next;
                         int count = 0;
                         while (p != null)
                         {
                              p = p.Next;
                              count++;
                         }
                         return count;
                    }
               }
               public Type FirstNode()//设置头结点为当前结点
               {
                    current = head;
                    return current.Data;
               }
               public Type NextNode()//设置下一结点为当前结点
               {
                    if (current.Next != null)
                         current = current.Next;
                    return current.Data;
               }
               public void Create(Type[] dt, int n, bool InsertInHead)//生成n个结点
               {
                    MakeEmpty();
                    if (InsertInHead)
                    {
                         for (int i = 1; i <= n; i++)
                              Insert(dt[i - 1], 1);
                    }
                    else
                    {
                         for (int i = 1; i <= n; i++)
                              Insert(dt[i - 1], i);
                    }
                    current = head;
               }
               public void CreateHead(Type[] dt, int n)//头插法生成n个结点
               {
                    MakeEmpty();
                    for (int i = 1; i <= n; i++)
                         head.Next = new CSListnode<Type>(dt[i - 1], head.Next);
                    current = head.Next;
               }
               public void CreateRear(Type[] dt, int n)//尾插法生成n个结点
               {
                    MakeEmpty();

                    for (int i = 1; i <= n; i++)
                    {
                         current.Next = new CSListnode<Type>(dt[i - 1]);
                         current = current.Next;
                    }
                   
               }
               public void MakeEmpty()//清空单链表
               {
                    head.Next = null;
                    current = head;
               }
               public void DeleteLast()//删除最后一个节点
               {


               }
               public CSListnode<Type> Find(Type value)//按给定值查找单链表
               {
                    CSListnode<Type> p = head;
                    while (p.Next!=null)
                    {
                         if (p.Data.Equals(value))
                              return p;
                         else
                         {
                              p = p.Next;
                         }
                    }
                    return null;
               }
               public CSListnode<Type> Getnode(int i)//返回第i个结点的地址
               {
                    CSListnode<Type> p = head;
                    int j = 0;
                    while (p.Next != null && j < i)
                    {
                         p = p.Next;
                         if (++j == i)
                              break;
                    }
                    return p;
               }
               public Type Getdata(int i)//返回第i个结点的数据
               {
                    CSListnode<Type> p = head;
                    int j = 0;
                    while (p.Next != null && j < i)
                    {
                         p = p.Next;
                         if (++j == i)
                              break;
                    }
                    return p.Data;

               }
               public void Insert(Type value, int i)//在第i个结点处插入结点
               {

               }
               public void Insert(Type value, bool before)//在当前结点处插入结点
               {

               }
               public void InsertHead(Type value)//在头插法插入结点
               {

               }
               public void AppendRear(Type value)//在尾插法插入结点
               {

               }
               public void Delete(int i)//删除第i个结点
               {

               }

          }

          CSList<int> m_slist = new CSList<int>();
          void DrawSList()
          {
               //画背景色
               Graphics myg = pBox_slist.CreateGraphics();
               Brush bkbrush = new SolidBrush(Color.White);
               int xmin = 0;
               int ymin = 0;
               int xmax = pBox_slist.Width;
               int ymax = pBox_slist.Height;
               myg.FillRectangle(bkbrush, xmin, ymin, xmax - xmin, ymax - ymin);

               CSListnode<int> cp;
               cp = m_slist.Current;
               //设置坐标数组
               int n;
               n = m_slist.Length;
               int[] lx = new int[n + 2];
               int[] ly = new int[n + 2];
               int cw = xmax / 15;
               int cwd = (xmax - (xmax / 15 * 10)) / 11 - 4;
               int ch = ymax / 15;
               int chd = (ymax - (ymax / 15 * 10)) / 11;
               for (int i = 0; i <= n; i++)
               {
                    if ((i / 10) % 2 == 0)
                    {
                         lx[i + 1] = xmax / 11 * (i % 10 + 1);
                    }
                    else
                    {
                         lx[i + 1] = xmax / 11 * (10 - i % 10);
                    }
                    ly[i + 1] = ymax / 11 * (i / 10 + 1);
               }
               //设置显示颜色
               Color bkColor0, bkColor1, bkColor2;
               Brush bkBrushnow, bkBrush0, bkBrush1, bkBrush2;
               bkColor0 = Color.FromArgb(255, 125, 125, 125);//头节点颜色
               bkBrush0 = new SolidBrush(bkColor0);
               bkColor1 = Color.FromArgb(255, 255, 255, 0);//一般节点颜色
               bkBrush1 = new SolidBrush(bkColor1);
               bkColor2 = Color.FromArgb(255, 0, 255, 0);//当前节点颜色
               bkBrush2 = new SolidBrush(bkColor2);
               string m_nodedata;
               Point p1, p2;
               //遍历单链表
               m_slist.FirstNode();
               for (int i = 0; i <= n; i++)
               {
                    if (m_slist.Current == cp)
                    {
                         bkBrushnow = bkBrush2;
                         if (i == 0)
                              m_nodedata = "";
                         else
                              m_nodedata = "" + m_slist.CurrentData;
                         tb_address.Text = "" + m_slist.Current.GetHashCode();
                         tb_data.Text = "" + m_nodedata;
                         if (m_slist.Next != null)
                              tb_next.Text = "" + m_slist.Next.GetHashCode();
                         else
                              tb_next.Text = "null";
                    }
                    else if (i == 0)
                    {
                         bkBrushnow = bkBrush0;
                         m_nodedata = "";
                    }
                    else
                    {
                         bkBrushnow = bkBrush1;
                    }
                    Rectangle rc = new Rectangle(lx[i + 1] - cw / 2, ly[i + 1] - ch / 2, cw, ch);
                    myg.FillRectangle(bkBrushnow, rc);

                    System.Drawing.Drawing2D.AdjustableArrowCap lineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);
                    Pen penLine = new Pen(Color.Red, 1);
                    penLine.CustomEndCap = lineCap;
                    Pen pen1 = new Pen(Color.Red, 1);
                    myg.DrawRectangle(pen1, rc);
                    if (i != 0)
                    {
                         string str = "" + m_slist.CurrentData;
                         Font font = new Font("Arial", 12);
                         SolidBrush b1 = new SolidBrush(Color.Blue);
                         StringFormat sf1 = new StringFormat();
                         myg.DrawString(str, font, b1, lx[i + 1] - cw / 2 + 5, ly[i + 1] - ch / 2 + 6, sf1);
                    }
                    if (i <= n - 1)
                    {
                         if (i % 10 != 9)
                         {
                              if ((i / 10) % 2 == 0)
                              {
                                   p1 = new Point(lx[i + 1] + cw / 2, ly[i + 1]);
                                   p2 = new Point(lx[i + 1] + cw / 2 + cwd, ly[i + 1]);
                                   myg.DrawLine(penLine, p1, p2);
                              }
                              else
                              {
                                   p1 = new Point(lx[i + 1] - cw / 2, ly[i + 1]);
                                   p2 = new Point(lx[i + 1] - cw / 2 - cwd, ly[i + 1]);
                                   myg.DrawLine(penLine, p1, p2);
                              }
                         }

                         if (i % 10 == 9)
                         {
                              if ((i / 10) % 2 == 0)
                              {
                                   p1 = new Point(lx[i + 1] + cw / 2, ly[i + 1]);
                                   p2 = new Point(lx[i + 1] + cw / 2 + cwd, ly[i + 1]);
                                   myg.DrawLine(pen1, p1, p2);
                                   p1 = new Point(lx[i + 1] + cw / 2 + cwd, ly[i + 1]);
                                   p2 = new Point(lx[i + 1] + cw / 2 + cwd, ly[i + 2]);
                                   myg.DrawLine(pen1, p1, p2);
                                   p1 = new Point(lx[i + 1] + cw / 2 + cwd, ly[i + 2]);
                                   p2 = new Point(lx[i + 1] + cw / 2, ly[i + 2]);
                                   myg.DrawLine(penLine, p1, p2);
                              }
                              else
                              {
                                   p1 = new Point(lx[i + 1] - cw / 2, ly[i + 1]);
                                   p2 = new Point(lx[i + 1] - cw / 2 - cwd, ly[i + 1]);
                                   myg.DrawLine(pen1, p1, p2);
                                   p1 = new Point(lx[i + 1] - cw / 2 - cwd, ly[i + 1]);
                                   p2 = new Point(lx[i + 1] - cw / 2 - cwd, ly[i + 2]);
                                   myg.DrawLine(pen1, p1, p2);
                                   p1 = new Point(lx[i + 1] - cw / 2 - cwd, ly[i + 2]);
                                   p2 = new Point(lx[i + 1] - cw / 2, ly[i + 2]);
                                   myg.DrawLine(penLine, p1, p2);
                              }
                         }
                    }
                    m_slist.NextNode();
               }
               m_slist.Current = cp;
          }
          public DSA_LIST()
          {
               InitializeComponent();
          }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

          private void init_Click(object sender, EventArgs e)
          {
               int n = Convert.ToInt32(list_length.Text);
               int []dt = new int[n];
               for (int i = 0; i < n; i++)
                    dt[i] = i+1;
               if(InsertInHead.Checked)
                    m_slist.CreateHead(dt, n);
               else
                    m_slist.CreateRear(dt, n);
               DrawSList();
          }

          private void clear_Click(object sender, EventArgs e)
          {
               m_slist.MakeEmpty();
               DrawSList();
          }

          private void headnode_Click(object sender, EventArgs e)
          {
               m_slist.SetCurrent(m_slist.Head);
               DrawSList();
          }

          private void nextnode_Click(object sender, EventArgs e)
          {
               m_slist.SetCurrent(m_slist.Next);
               DrawSList();
          }

          private void editnode_Click(object sender, EventArgs e)
          {
               m_slist.CurrentData = Convert.ToInt32(editnum.Text);
               DrawSList();
          }

          private void findnode_Click(object sender, EventArgs e)
          {
               m_slist.SetCurrent(m_slist.Find(Convert.ToInt32(editnum.Text)));
               DrawSList();
          }
     }
}
