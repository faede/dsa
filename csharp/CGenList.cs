using System;
using System.Collections.Generic;
using System.Text;



namespace 广义表
{

     class CGenListnode
     {
          public int utype;
          public CGenListnode tnext;//指向广义表接点的指针
          public object hnext;//指向数据的指针
          public CGenListnode(int u)
          {
               utype = u;
               tnext = null;
               hnext = null;
          }
          public CGenListnode(int u, CGenListnode tn, object hn)
          {
               utype = u;
               tnext = tn;
               hnext = hn;
          }
     }
     class Rational
     {
          private int num;//分子
          private int den;//分母
          public int Num
          {
               get { return num; }
               set { num = value; }
          }
          public int Den
          {
               get { return den; }
               set { den = value; }
          }
          public Rational()//无参的构造有理数
          { num = 0; den = 1; }
          public Rational(int x, int y)//已知分子分母构造有理数
          { num = x; den = y; optimization(); }
          public Rational(Rational ob)//拷贝构造函数
          { num = ob.num; den = ob.den; optimization(); }
          public Rational(double x)//通过实数构造有理数
          {
               if ((int)(x) == x)
               { num = (int)x; den = 1; }
               else
               { num = (int)(x * 1000 + 0.5); den = 1000; }
               optimization();
          }
          public Rational string_double(string s)
          {
               int num, den;
               bool is_n = false, is_l = true;
               int p = 0;
               if (s[0] == '-')
               {

               }
               string t = "";
               for (int i = 0; i < s.Length; i++)
               {
                    if (s[i] == '-')
                    {
                         is_n = true;
                         continue;
                    }
                    else if (s[i] == '.')
                    {
                         is_l = false;
                    }
                    else
                    {
                         if (!is_l)
                         {
                              p++;
                         }
                         t += s[i];
                    }
               }
               num = Convert.ToInt32(t);
               if (is_n)
                    num = -num;
               den = 1;
               for (int i = 0; i < p; i++)
               {
                    den *= 10;
               }
               Rational dou = new Rational(num, den);
               dou.optimization();
               return dou;
          }
          private void optimization()//辗转相除法约分
          {
               if (num * den == 0)
                    return;
               if (Math.Abs(num) > Math.Abs(den))
               {
                    int x = num;
                    int y = den;
                    int c = 0;
                    while (x * y != 0)
                    {
                         c = y;
                         y = x % y;
                         x = c;

                    }
                    num = num / x;
                    den = den / x;
               }
               else
               {
                    int x = den;
                    int y = num;
                    int c = 0;
                    while (x * y != 0)
                    {
                         c = y;
                         y = x % y;
                         x = c;
                    }
                    num = num / x;
                    den = den / x;
               }

          }
          public string output()//输出有理数字符串
          {
               string s = null;
               if (den == 1)
                    s = Convert.ToString(num);
               else if (den < 0 && den != -1)
                    s = "-" + Convert.ToString(num) + "/" + Convert.ToString(den);
               else if (den == -1)
                    s = "-" + Convert.ToString(num);
               else
                    s = Convert.ToString(num) + "/" + Convert.ToString(den);
               return s;
          }
          public static Rational operator +(Rational rat1, Rational rat2)
          {
               Rational temp = new Rational(0, 1);
               temp.den = rat1.den * rat2.den;
               temp.num = rat1.num * rat2.den + rat1.den * rat2.num;
               temp.optimization();
               return temp;
          }
          public static Rational operator -(Rational rat1, Rational rat2)
          {
               Rational temp = new Rational(0, 1);
               temp.den = rat1.den * rat2.den;
               temp.num = rat1.num * rat2.den - rat1.den * rat2.num;
               temp.optimization();
               return temp;
          }
          public static Rational operator *(Rational rat1, Rational rat2)
          {
               Rational temp = new Rational(0, 1);
               temp.den = rat1.den * rat2.den;
               temp.num = rat1.num * rat2.num;
               temp.optimization();
               return temp;
          }
          public static Rational operator /(Rational rat1, Rational rat2)
          {
               Rational temp = new Rational(0, 1);
               temp.den = rat1.den * rat2.num;
               temp.num = rat1.num * rat2.den;
               temp.optimization();
               return temp;
          }
          public static Rational operator ++(Rational rat1)
          {
               Rational rat2 = new Rational(1, 1);
               rat1 = rat1 + rat2;
               rat1.optimization();
               return rat1;
          }
          public static Rational operator ^(Rational rat1, Rational rat2)
          {
               Rational temp1 = new Rational(0, 1);
               double x1 = Convert.ToDouble(rat2.num);
               double x2 = Convert.ToDouble(rat2.den);
               double y1 = Convert.ToDouble(rat1.num);
               double y2 = Convert.ToDouble(rat1.den);
               temp1 = new Rational(Math.Pow(y1 / y2, x1 / x2));
               return temp1;
          }
     }
     public interface ICStack<Type>//接口
     {
          bool IsEmpty();//判栈空
          bool IsFull();//判栈满
          void MakeEmpty();//清空
          bool Push(Type item);//入栈
          Type Pop();//出栈
          Type Gettop();//取栈顶
          string GetStackALLDate(string sname);
     }
     class CStacknode<Type>//链栈结点类
     {
          private Type data;
          private CStacknode<Type> next;
          //--------------------------------------------------------------------------------
          public CStacknode()
          {
               next = null;
          }
          public CStacknode(Type data)
          {
               this.data = data;
               next = null;
          }
          public CStacknode(Type data, CStacknode<Type> next)
          {
               this.data = data;
               this.next = next;
          }
          public Type Data
          {
               get { return data; }
               set { data = value; }
          }
          public CStacknode<Type> Next
          {
               get { return next; }
               set { next = value; }
          }
     }
     class CLinkStack<Type> : ICStack<Type>
     {
          private CStacknode<Type> top;
          //--------------------------------------------------------------------------------
          public CStacknode<Type> Top
          {
               get { return top; }
          }
          public void MakeEmpty() { top = null; }//清空
          public bool IsEmpty() { return top == null; }//判栈空
          public bool IsFull() { return false; }//判栈满

          public CLinkStack()
          {
               top = null;
          }
          public bool Push(Type item)//入栈
          {
               top = new CStacknode<Type>(item, top);
               return (true);
          }
          public Type Pop()//出栈
          {
               Type dt = top.Data;
               top = top.Next;
               return dt;
          }
          public Type Gettop()//取栈顶
          {
               if (top == null)
                    return default(Type);
               else
                    return top.Data;
          }
          public string GetStackALLDate(string sname)
          {
               string str = "  】";
               if (IsEmpty()) str = sname + " stack is null";
               CStacknode<Type> p = top;
               while (p != null)
               {
                    str = p.Data + "    " + str;
                    p = p.Next;
               }
               str = "【  " + str + "\r\n";
               str = str + "---------------------------------------" + "\r\n";
               return str;
          }
     }
     class CGenList
     {
          const int HEAD = 0;
          const int INT = 1;
          const int DOUBLE = 2;
          const int CHAR = 3;
          const int STRING = 4;
          const int RATIONAL = 5;
          const int CHILD = 10;
          private CGenListnode head;//广义表的头节点
                                    //private CGenListnode[] current=new CGenListnode[10];//广义表的分支当前节点
          private CGenListnode cp;//存放栈顶的返回值
          public CGenListnode Head
          {
               get { return head; }
               set { head = value; }
          }
          public CGenList()
          {
               head = new CGenListnode(HEAD);
          }
          public void MakeEmpty(out String strout)
          {
               if (head.tnext == null)
               {
                    strout = "广义表为空表!";
                    return;
               }
               else
               {
                    strout = "广义表清空!";
                    head.tnext = null;
               }

          }
          public void CreateGL(string strin, out string strout)
          {
               if (head.tnext != null)
                    MakeEmpty(out strout);

               string tstr;
               strout = "输入字符串=";
               tstr = strin;
               strout += tstr + "\r\n";
               strout = "广义表的创建\r\n";
               CLinkStack<CGenListnode> stp = new CLinkStack<CGenListnode>();
               stp.Push(head);//初态时head结点入栈
               strout += "Create 【BEGIN】";
               strout += "\r\n";
               char ch;
               string temp, temp1;
               CGenListnode cp;//存放栈顶的返回值
               int i = 1, j, k;//从输入串第一个"("的后面开始
               int ti, tnum, tden;
               double tf;
               ch = strin[0];
               int n = strin.Length;
               while (i < n)
               {
                    ch = strin[i++];
                    if (ch == '(')//'('后应生成子表的标志结点
                    {
                         cp = stp.Gettop();
                         cp.tnext = new CGenListnode(CHILD);
                         strout += "Create 【CHILD】\r\n";
                         //将子表的标志结点接在栈顶的tnext域
                         stp.Push(cp.tnext);//子表的标志结点成为新的栈顶
                         cp.tnext.hnext = new CGenListnode(HEAD);//生成子表的head结点
                         stp.Push((CGenListnode)cp.tnext.hnext);//子表的head结点入栈
                         strout += "Create 【HEAD】\r\n";
                         continue;
                    }
                    string strt = "0123456789./";
                    if (strt.IndexOf(ch) >= 0)//输入的是int,double,rational
                    {
                         j = 0;
                         temp = "";
                         temp += ch;
                         ch = strin[i++];
                         while (strt.IndexOf(ch) >= 0)//输入的还是数字
                         {
                              temp += ch;
                              ch = strin[i++];
                         }
                         if (temp.IndexOf('/') >= 0)//输入的是rational数
                         {
                              j = 0;
                              temp1 = "";
                              while (temp[j] != '/')
                                   temp1 += temp[j++];
                              tnum = Convert.ToInt16(temp1);
                              j++;
                              temp1 = "";
                              while (j < temp.Length)
                                   temp1 += temp[j++];
                              tden = Convert.ToInt16(temp1);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(RATIONAL);
                              //将rational结点接在栈顶的tnext域
                              cp.tnext.hnext = new Rational(tnum, tden);
                              strout += "Create 【RATIONAL】--";
                              Rational r = (Rational)cp.tnext.hnext;
                              tstr = "(" + r.output() + ")\r\n";
                              strout += tstr;
                              stp.Push(cp.tnext);//将rational结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         else if (temp.IndexOf('.') >= 0)//输入的是double数
                         {
                              tf = Convert.ToDouble(temp);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(DOUBLE);
                              //将double结点接在栈顶的tnext域
                              cp.tnext.hnext = tf;
                              strout += "Create 【DOUBLE】--";
                              tstr = "(" + tf + ")\r\n";
                              strout += tstr;
                              stp.Push(cp.tnext);//将double结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         else //输入的是int数
                         {
                              ti = Convert.ToInt16(temp);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(INT);
                              //将int结点接在栈顶的tnext域
                              cp.tnext.hnext = ti;
                              strout += "Create 【INT】--";
                              tstr = "(" + ti + ")\r\n";
                              strout += tstr;
                              stp.Push(cp.tnext);//将int结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         continue;
                    }
                    if (ch == '\'')//输入的字符
                    {
                         cp = stp.Gettop();
                         cp.tnext = new CGenListnode(CHAR);
                         //将char结点接在栈顶的tnext域
                         ch = strin[i++];
                         cp.tnext.hnext = ch;
                         strout += "Create 【CHAR】--";
                         tstr = "(\'" + ch + "\')\r\n";
                         strout += tstr;
                         stp.Push(cp.tnext);//将char结点成为新的栈顶                    
                         ch = strin[i++];
                         continue;
                    }
                    if (ch == '\"')//输入的字符串
                    {
                         cp = stp.Gettop();
                         j = 0;
                         ch = strin[i++];
                         temp = "";
                         while (ch != '\"')
                         {
                              temp += ch;
                              ch = strin[i++];
                         }
                         cp.tnext = new CGenListnode(STRING);
                         //将string结点接在栈顶的tnext域
                         cp.tnext.hnext = temp;
                         strout += "Create 【STRING】--";
                         tstr = "(\"" + temp + "\")\r\n";
                         strout += tstr;
                         stp.Push(cp.tnext);//将string结点成为新的栈顶
                         continue;
                    }
                    if (ch == ',')//输入的是','
                    { continue; }
                    if (ch == ')')//输入的是')'
                    {
                         do
                         {
                              cp = stp.Gettop();
                              if (cp.utype != HEAD)
                                   stp.Pop();
                         } while (cp.utype != HEAD);//将head指向的结点出栈.
                         stp.Pop();//将head结点出栈.

                         continue;
                    }
               }
               strout += "广义表创建完毕----------------------------------\r\n";
          }
          public string PrintGL()
          {
               string strout = "";
               CLinkStack<CGenListnode> stp = new CLinkStack<CGenListnode>();
               strout = "广义表为:(";
               CLinkStack<int> stpno = new CLinkStack<int>();
               int cno = 0;

               stp.Push(head);//初态时head结点入栈
               stpno.Push(1);
               while (!stp.IsEmpty())
               {

                    //CHILD
                    //第一次访问时：输出‘(’，将cp.hnext进栈；(HEAD)
                    //第二次访问时：若cp.tnext非空，则将其入栈，并输出‘,’；
                    //第三次访问时：出栈。
                    //HEAD
                    //第一次访问时：若cp.tnext非空，则将其入栈；
                    //第二次访问时：出栈，并输出‘)’ 。
                    //数据
                    //出栈，输出数据，若cp.tnext非空，则将其入栈，并输出‘,’
                    cp = stp.Gettop();
                    switch (cp.utype)
                    {
                         case CHILD:
                              //第一次访问时：输出‘(’，将cp.hnext进栈；(HEAD)
                              //第二次访问时：若cp.tnext非空，则将其入栈，并输出‘,’；
                              //第三次访问时：出栈。
                              cno = stpno.Pop();
                              if (cno == 1)
                              {
                                   strout += "("; stpno.Push(2);
                                   stp.Push((CGenListnode)cp.hnext); stpno.Push(1);
                              }
                              else if (cno == 2)
                              {
                                   stpno.Push(3);
                                   if (cp.tnext != null)
                                   { strout += ","; stp.Push(cp.tnext); stpno.Push(1); }
                              }
                              else if (cno == 3)
                                   stp.Pop();
                              break;
                         case HEAD:
                              //第一次访问时：若cp.tnext非空，则将其入栈；
                              //第二次访问时：出栈，并输出‘)’ 。
                              cno = stpno.Pop();
                              if (cno == 1)
                              {
                                   stpno.Push(2);
                                   if (cp.tnext != null)
                                   { stp.Push(cp.tnext); stpno.Push(1); }
                              }
                              else if (cno == 2)
                              { stp.Pop(); strout += ")"; }
                              break;
                         case INT:
                              //出栈，输出数据，若cp.tnext非空，则将其入栈，并输出‘,’
                              cno = stpno.Pop();
                              strout += cp.hnext;
                              stp.Pop();
                              if (cp.tnext != null)
                              {
                                   strout += ",";
                                   stp.Push(cp.tnext);
                                   stpno.Push(1);
                              }
                              break;
                         case DOUBLE:
                              //出栈，输出数据，若cp.tnext非空，则将其入栈，并输出‘,’
                              cno = stpno.Pop();
                              strout += cp.hnext;
                              stp.Pop();
                              if (cp.tnext != null)
                              {
                                   strout += ",";
                                   stp.Push(cp.tnext);
                                   stpno.Push(1);
                              }
                              break;
                         case CHAR:
                              //出栈，输出数据，若cp.tnext非空，则将其入栈，并输出‘,’
                              cno = stpno.Pop();
                              strout += "\'";
                              strout += cp.hnext;
                              strout += "\'";
                              stp.Pop();
                              if (cp.tnext != null)
                              {
                                   strout += ",";
                                   stp.Push(cp.tnext);
                                   stpno.Push(1);
                              }
                              break;
                         case STRING:
                              //出栈，输出数据，若cp.tnext非空，则将其入栈，并输出‘,’
                              cno = stpno.Pop();
                              strout += "\"";
                              strout += cp.hnext;
                              strout += "\"";
                              stp.Pop();
                              if (cp.tnext != null)
                              {
                                   strout += ",";
                                   stp.Push(cp.tnext);
                                   stpno.Push(1);
                              }
                              break;
                         case RATIONAL:
                              //出栈，输出数据，若cp.tnext非空，则将其入栈，并输出‘,’
                              cno = stpno.Pop();
                              Rational r1 = (Rational)cp.hnext;
                              strout += r1.output();
                              stp.Pop();
                              if (cp.tnext != null)
                              {
                                   strout += ",";
                                   stp.Push(cp.tnext);
                                   stpno.Push(1);
                              }
                              break;
                    }
               }

               return strout;
          }
          public string CopyGL(CGenList ob)
          {
               /*string strout = "";
               if (head.tnext != null)
                   MakeEmpty(out strout);*/
               int cno = 0;

               string s = "";
               CGenListnode now = new CGenListnode(CHILD);
               CGenListnode op = new CGenListnode(1);
               CLinkStack<CGenListnode> stp = new CLinkStack<CGenListnode>();
               CLinkStack<CGenListnode> stpob = new CLinkStack<CGenListnode>();
               CLinkStack<int> stpobno = new CLinkStack<int>();
               stpob.Push(ob.head);
               stpobno.Push(1);
               stp.Push(head);

               /* cpob.utype=CHILD:                第一次访问时：将ob子表的HEAD结点进栈；                对this表，生成（CHILD）和（HEAD）结点，链接进栈；                第二次访问时：（CHILD）右边访问结束，（CHILD）出栈 ；                对this表， （CHILD）不出栈（因为要倒序）                cpob.utype=HEAD:                第一次访问时：将HEAD指向的链全入栈；                第二次访问时：表示HEAD右边已处理完，其出栈。                对this表，已经链接完，并已反序，将this中各元素出栈（到H）                cpob.utype=DATA:                先ob出栈，创建this的数据结点，链接栈顶并入栈。            */
               while (!stpob.IsEmpty())
               {
                    op = stpob.Gettop();
                    cp = stp.Gettop();
                    switch (op.utype)
                    {
                         case CHILD:
                              cno = stpobno.Pop();
                              if (cno == 1)
                              {
                                   stpobno.Push(2);
                                   stpob.Push((CGenListnode)op.hnext); stpobno.Push(1);
                                   now = new CGenListnode(op.utype);
                                   cp.tnext = now;
                                   stp.Push(now);
                                   s += "CHILD  ";
                                   now = new CGenListnode(HEAD);
                                   cp.tnext.hnext = now;
                                   s += "HEAD  ";
                                   stp.Push(now);
                              }
                              else if (cno == 2)
                              {
                                   stpob.Pop();
                              }
                              break;
                         case HEAD:
                              cno = stpobno.Pop();
                              if (cno == 1)
                              {
                                   stpobno.Push(2);
                                   while (op.tnext != null)
                                   {
                                        stpob.Push(op.tnext); stpobno.Push(1); op = stpob.Gettop();

                                   }
                              }
                              else if (cno == 2)
                              {
                                   //cp.tnext = null;
                                   stpob.Pop();
                                   while (cp.utype != HEAD)
                                   {
                                        stp.Pop();
                                        cp = stp.Gettop();
                                   }
                                   stp.Pop();
                              }
                              break;
                         case INT:
                              cno = stpobno.Pop();
                              stpob.Pop();
                              now = new CGenListnode(op.utype);
                              now.hnext = op.hnext;
                              cp.tnext = now;
                              stp.Push(now);
                              s += "INT  ";
                              break;
                         case DOUBLE:
                              cno = stpobno.Pop();
                              stpob.Pop();
                              now = new CGenListnode(op.utype);
                              now.hnext = op.hnext;
                              cp.tnext = now;
                              stp.Push(now);
                              s += "DOUBLE  ";
                              break;
                         case CHAR:
                              cno = stpobno.Pop();
                              stpob.Pop();
                              now = new CGenListnode(op.utype);
                              now.hnext = op.hnext;
                              cp.tnext = now;
                              stp.Push(now);
                              s += "CHAR  ";
                              break;
                         case STRING:
                              cno = stpobno.Pop();
                              stpob.Pop();
                              now = new CGenListnode(op.utype);
                              now.hnext = op.hnext;
                              cp.tnext = now;
                              stp.Push(now);
                              s += "STRING  ";
                              break;
                         case RATIONAL:
                              cno = stpobno.Pop();
                              stpob.Pop();
                              now = new CGenListnode(op.utype);
                              now.hnext = op.hnext;
                              cp.tnext = now;
                              stp.Push(now);
                              s += "RATIONAL  ";
                              break;
                    }
               }
               return s;
          }

          public void out_num(string strin, out string strout)
          {
               if (head.tnext != null)
                    MakeEmpty(out strout);

               string tstr;
               strout = "输入字符串=";
               tstr = strin;
               strout += tstr + "\r\n";
               strout = "广义表的原子元素为\r\n";
               CLinkStack<CGenListnode> stp = new CLinkStack<CGenListnode>();
               stp.Push(head);//初态时head结点入栈
               int doube_num = 0, char_num = 0, string_num = 0, rational_num = 0, int_num = 0;
               char ch;
               string temp, temp1;
               CGenListnode cp;//存放栈顶的返回值
               int i = 1, j, k;//从输入串第一个"("的后面开始
               int ti, tnum, tden;
               double tf;
               ch = strin[0];
               int n = strin.Length;
               while (i < n)
               {
                    ch = strin[i++];
                    if (ch == '(')//'('后应生成子表的标志结点
                    {
                         cp = stp.Gettop();
                         cp.tnext = new CGenListnode(CHILD);
                         //将子表的标志结点接在栈顶的tnext域
                         stp.Push(cp.tnext);//子表的标志结点成为新的栈顶
                         cp.tnext.hnext = new CGenListnode(HEAD);//生成子表的head结点
                         stp.Push((CGenListnode)cp.tnext.hnext);//子表的head结点入栈
                         continue;
                    }
                    string strt = "0123456789./";
                    if (strt.IndexOf(ch) >= 0)//输入的是int,double,rational
                    {
                         j = 0;
                         temp = "";
                         temp += ch;
                         ch = strin[i++];
                         while (strt.IndexOf(ch) >= 0)//输入的还是数字
                         {
                              temp += ch;
                              ch = strin[i++];
                         }
                         if (temp.IndexOf('/') >= 0)//输入的是rational数
                         {
                              j = 0;
                              temp1 = "";
                              while (temp[j] != '/')
                                   temp1 += temp[j++];
                              tnum = Convert.ToInt16(temp1);
                              j++;
                              temp1 = "";
                              while (j < temp.Length)
                                   temp1 += temp[j++];
                              tden = Convert.ToInt16(temp1);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(RATIONAL);
                              //将rational结点接在栈顶的tnext域
                              cp.tnext.hnext = new Rational(tnum, tden);
                              rational_num++;
                              strout += "(RATIONAL   -";
                              strout += Convert.ToString(rational_num);
                              strout += ") ";
                              Rational r = (Rational)cp.tnext.hnext;
                              tstr = "" + r.output() + "\r\n";
                              strout += tstr;
                              stp.Push(cp.tnext);//将rational结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         else if (temp.IndexOf('.') >= 0)//输入的是double数
                         {
                              tf = Convert.ToDouble(temp);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(DOUBLE);
                              //将double结点接在栈顶的tnext域
                              cp.tnext.hnext = tf;
                              doube_num++;
                              strout += "(DOUBLE -";
                              strout += Convert.ToString(doube_num);
                              strout += ") ";
                              tstr = "" + tf + "\r\n";
                              strout += tstr;
                              stp.Push(cp.tnext);//将double结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         else //输入的是int数
                         {
                              ti = Convert.ToInt16(temp);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(INT);
                              //将int结点接在栈顶的tnext域
                              cp.tnext.hnext = ti;
                              int_num++;
                              strout += "(INT    -";
                              strout += Convert.ToString(int_num);
                              strout += ") ";
                              tstr = "" + ti + "\r\n";
                              strout += tstr;
                              stp.Push(cp.tnext);//将int结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         continue;
                    }
                    if (ch == '\'')//输入的字符
                    {
                         cp = stp.Gettop();
                         cp.tnext = new CGenListnode(CHAR);
                         //将char结点接在栈顶的tnext域
                         ch = strin[i++];
                         cp.tnext.hnext = ch;
                         char_num++;
                         strout += "(CHAR   -";
                         strout += Convert.ToString(char_num);
                         strout += ") ";
                         tstr = "\'" + ch + "\'\r\n";
                         strout += tstr;
                         stp.Push(cp.tnext);//将char结点成为新的栈顶                    
                         ch = strin[i++];
                         continue;
                    }
                    if (ch == '\"')//输入的字符串
                    {
                         cp = stp.Gettop();
                         j = 0;
                         ch = strin[i++];
                         temp = "";
                         while (ch != '\"')
                         {
                              temp += ch;
                              ch = strin[i++];
                         }
                         cp.tnext = new CGenListnode(STRING);
                         //将string结点接在栈顶的tnext域
                         cp.tnext.hnext = temp;
                         string_num++;
                         strout += "(STRING -";
                         strout += Convert.ToString(string_num);
                         strout += ") ";
                         tstr = "\"" + temp + "\"\r\n";
                         strout += tstr;
                         stp.Push(cp.tnext);//将string结点成为新的栈顶
                         continue;
                    }
                    if (ch == ',')//输入的是','
                    { continue; }
                    if (ch == ')')//输入的是')'
                    {
                         do
                         {
                              cp = stp.Gettop();
                              if (cp.utype != HEAD)
                                   stp.Pop();
                         } while (cp.utype != HEAD);//将head指向的结点出栈.
                         stp.Pop();//将head结点出栈.

                         continue;
                    }
               }
          }

          public void out_sum(string strin, out string strout)
          {
               if (head.tnext != null)
                    MakeEmpty(out strout);

               Rational sum = new Rational();
               string tstr;
               strout = "输入字符串=";
               tstr = strin;
               strout += tstr + "\r\n";
               strout = "";
               CLinkStack<CGenListnode> stp = new CLinkStack<CGenListnode>();
               stp.Push(head);//初态时head结点入栈
               char ch;
               string temp, temp1;
               CGenListnode cp;//存放栈顶的返回值
               int i = 1, j, k;//从输入串第一个"("的后面开始
               int ti, tnum, tden;
               double tf;
               ch = strin[0];
               int n = strin.Length;
               while (i < n)
               {
                    ch = strin[i++];
                    if (ch == '(')//'('后应生成子表的标志结点
                    {
                         cp = stp.Gettop();
                         cp.tnext = new CGenListnode(CHILD);
                         //将子表的标志结点接在栈顶的tnext域
                         stp.Push(cp.tnext);//子表的标志结点成为新的栈顶
                         cp.tnext.hnext = new CGenListnode(HEAD);//生成子表的head结点
                         stp.Push((CGenListnode)cp.tnext.hnext);//子表的head结点入栈
                         continue;
                    }
                    string strt = "0123456789./";
                    if (strt.IndexOf(ch) >= 0)//输入的是int,double,rational
                    {
                         j = 0;
                         temp = "";
                         temp += ch;
                         ch = strin[i++];
                         while (strt.IndexOf(ch) >= 0)//输入的还是数字
                         {
                              temp += ch;
                              ch = strin[i++];
                         }
                         if (temp.IndexOf('/') >= 0)//输入的是rational数
                         {
                              j = 0;
                              temp1 = "";
                              while (temp[j] != '/')
                                   temp1 += temp[j++];
                              tnum = Convert.ToInt16(temp1);
                              j++;
                              temp1 = "";
                              while (j < temp.Length)
                                   temp1 += temp[j++];
                              tden = Convert.ToInt16(temp1);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(RATIONAL);
                              //将rational结点接在栈顶的tnext域
                              cp.tnext.hnext = new Rational(tnum, tden);
                              Rational r = (Rational)cp.tnext.hnext;
                              sum = sum + r;
                              tstr = r.output();
                              if (strout == "")
                              {
                                   strout += tstr;
                              }
                              else
                              {
                                   strout += "+";
                                   strout += tstr;
                              }
                              stp.Push(cp.tnext);//将rational结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         else if (temp.IndexOf('.') >= 0)//输入的是double数
                         {
                              tf = Convert.ToDouble(temp);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(DOUBLE);
                              //将double结点接在栈顶的tnext域
                              cp.tnext.hnext = tf;



                              Rational r = sum.string_double(Convert.ToString(tf));
                              sum = sum + r;
                              tstr = r.output();
                              if (strout == "")
                              {
                                   strout += tstr;
                              }
                              else
                              {
                                   strout += "+";
                                   strout += tstr;
                              }
                              stp.Push(cp.tnext);//将double结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         else //输入的是int数
                         {
                              ti = Convert.ToInt16(temp);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(INT);
                              //将int结点接在栈顶的tnext域
                              cp.tnext.hnext = ti;

                              tstr = "" + ti + "\r\n";
                              Rational r = new Rational(ti, 1);
                              sum = sum + r;
                              tstr = r.output();
                              if (strout == "")
                              {
                                   strout += tstr;
                              }
                              else
                              {
                                   strout += "+";
                                   strout += tstr;
                              }
                              stp.Push(cp.tnext);//将int结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         continue;
                    }
                    if (ch == '\'')//输入的字符
                    {
                         cp = stp.Gettop();
                         cp.tnext = new CGenListnode(CHAR);
                         //将char结点接在栈顶的tnext域
                         ch = strin[i++];
                         cp.tnext.hnext = ch;
                         tstr = "\'" + ch + "\'\r\n";
                         stp.Push(cp.tnext);//将char结点成为新的栈顶                    
                         ch = strin[i++];
                         continue;
                    }
                    if (ch == '\"')//输入的字符串
                    {
                         cp = stp.Gettop();
                         j = 0;
                         ch = strin[i++];
                         temp = "";
                         while (ch != '\"')
                         {
                              temp += ch;
                              ch = strin[i++];
                         }
                         cp.tnext = new CGenListnode(STRING);
                         //将string结点接在栈顶的tnext域
                         cp.tnext.hnext = temp;
                         tstr = "\"" + temp + "\"\r\n";
                         stp.Push(cp.tnext);//将string结点成为新的栈顶
                         continue;
                    }
                    if (ch == ',')//输入的是','
                    { continue; }
                    if (ch == ')')//输入的是')'
                    {
                         do
                         {
                              cp = stp.Gettop();
                              if (cp.utype != HEAD)
                                   stp.Pop();
                         } while (cp.utype != HEAD);//将head指向的结点出栈.
                         stp.Pop();//将head结点出栈.

                         continue;
                    }
               }
               strout += "=";
               strout += sum.output();

          }
          public string S_CopyGL(CGenList ob)
          {
               int cno = 0;

               string s = "";
               //CGenListnode now = new CGenListnode(CHILD);
               //CGenListnode op = new CGenListnode(1);
               CGenListnode now, op;
               CLinkStack<CGenListnode> stp = new CLinkStack<CGenListnode>();
               CLinkStack<CGenListnode> stpob = new CLinkStack<CGenListnode>();
               CLinkStack<int> stpobno = new CLinkStack<int>();
               stpob.Push(ob.head);
               stpobno.Push(1);
               stp.Push(head);
               while (!stpob.IsEmpty())
               {
                    op = stpob.Gettop();
                    cp = stp.Gettop();
                    switch (op.utype)
                    {
                         case CHILD:
                              cno = stpobno.Pop();
                              if (cno == 1)
                              {
                                   stpobno.Push(2);
                                   stpob.Push((CGenListnode)op.hnext);
                                   stpobno.Push(1);
                                   s += "CHILD  ";
                                   now = new CGenListnode(HEAD);
                                   // now.tnext = op.tnext;
                                   //now.tnext = ((CGenListnode)op.hnext).tnext;
                                   //s += "CHILD  ";
                                   cp.hnext = now;
                                   stp.Push(now);

                              }
                              else if (cno == 2)
                              {
                                   stpobno.Push(3);
                                   if (op.tnext != null)
                                   {
                                        stpob.Push(op.tnext);
                                        now = new CGenListnode(op.tnext.utype);
                                        now.hnext = op.tnext.hnext;
                                        cp.tnext = now;
                                        stp.Push(now);
                                        stpobno.Push(1);
                                   }
                                   
                              }
                              else if (cno == 3)
                              {
                                   stp.Pop();
                                   stpob.Pop();
                              }
                              break;
                         case HEAD:
                              cno = stpobno.Pop();
                              if (cno == 1)
                              {
                                   stpobno.Push(2);
                                   if (op.tnext != null)
                                   {
                                        stpob.Push(op.tnext);
                                        now = new CGenListnode(op.tnext.utype);
                                        now.hnext = op.tnext.hnext;
                                        cp.tnext = now;
                                        stp.Push(now);
                                        stpobno.Push(1);
                                   }
                                   
                                   
                              }
                              else if (cno == 2)
                              {

                                   stpob.Pop();
                                   stp.Pop();
                              }
                              break;
                         case INT:
                              stpobno.Pop();
                              stpob.Pop();  
                              if (op.tnext != null)
                              {
                                   stpob.Push(op.tnext);
                                   now = new CGenListnode(op.tnext.utype);
                                   now.hnext = op.tnext.hnext;
                                   cp.tnext = now;
                                   stp.Push(now);
                                   stpobno.Push(1);
                              }
                              s += "INT  ";
                              break;

                    case DOUBLE:
                             stpobno.Pop();
                             stpob.Pop();
                             if (op.tnext != null)
                             {
                                stpob.Push(op.tnext);
                                now = new CGenListnode(op.tnext.utype);
                                now.hnext = op.tnext.hnext;
                                cp.tnext = now;
                                stp.Push(now);
                                stpobno.Push(1);
                             }                           
                             s += "DOUBLE  ";
                              break;
                         case CHAR:
                            stpobno.Pop();
                            stpob.Pop();
                             if (op.tnext != null)
                            {
                                stpob.Push(op.tnext);
                                now = new CGenListnode(op.tnext.utype);
                                now.hnext = op.tnext.hnext;
                                cp.tnext = now;
                                stp.Push(now);
                                stpobno.Push(1);
                            }
                              s += "CHAR  ";
                              break;
                         case STRING:
                                stpobno.Pop();
                                stpob.Pop();
                                if (op.tnext != null)
                                {
                                    stpob.Push(op.tnext);
                                    now = new CGenListnode(op.tnext.utype);
                                    now.hnext = op.tnext.hnext;
                                    cp.tnext = now;
                                    stp.Push(now);
                                    stpobno.Push(1);
                                }
                                s += "STRING  ";
                              break;
                         case RATIONAL:
                                stpobno.Pop();
                                stpob.Pop();
                                if (op.tnext != null)
                                {
                                    stpob.Push(op.tnext);
                                    now = new CGenListnode(op.tnext.utype);
                                    now.hnext = op.tnext.hnext;
                                    cp.tnext = now;
                                    stp.Push(now);
                                    stpobno.Push(1);
                                }
                                s += "RATIONAL  ";
                              break;
                    }
               }
               return s;
          }

          public void out_dep(string strin, out string strout)
          {
               int dep = 1, max = 1;
               if (head.tnext != null)
                    MakeEmpty(out strout);

               string tstr;
               strout = "输入字符串=";
               tstr = strin;
               strout += tstr + "\r\n";
               strout = "广义表的层次为\r\n";
               CLinkStack<CGenListnode> stp = new CLinkStack<CGenListnode>();
               stp.Push(head);//初态时head结点入栈
               //int doube_num = 0, char_num = 0, string_num = 0, rational_num = 0, int_num = 0;
               char ch;
               string temp, temp1;
               CGenListnode cp;//存放栈顶的返回值
               int i = 1, j, k;//从输入串第一个"("的后面开始
               int ti, tnum, tden;
               double tf;
               ch = strin[0];
               int n = strin.Length;
               while (i < n)
               {
                    ch = strin[i++];
                    if (ch == '(')//'('后应生成子表的标志结点
                    {
                         dep++;
                         if (dep > max)
                              max = dep;
                         cp = stp.Gettop();
                         cp.tnext = new CGenListnode(CHILD);
                         //将子表的标志结点接在栈顶的tnext域
                         stp.Push(cp.tnext);//子表的标志结点成为新的栈顶
                         cp.tnext.hnext = new CGenListnode(HEAD);//生成子表的head结点
                         stp.Push((CGenListnode)cp.tnext.hnext);//子表的head结点入栈
                         continue;
                    }
                    string strt = "0123456789./";
                    if (strt.IndexOf(ch) >= 0)//输入的是int,double,rational
                    {
                         j = 0;
                         temp = "";
                         temp += ch;
                         ch = strin[i++];
                         while (strt.IndexOf(ch) >= 0)//输入的还是数字
                         {
                              temp += ch;
                              ch = strin[i++];
                         }
                         if (temp.IndexOf('/') >= 0)//输入的是rational数
                         {
                              j = 0;
                              temp1 = "";
                              while (temp[j] != '/')
                                   temp1 += temp[j++];
                              tnum = Convert.ToInt16(temp1);
                              j++;
                              temp1 = "";
                              while (j < temp.Length)
                                   temp1 += temp[j++];
                              tden = Convert.ToInt16(temp1);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(RATIONAL);
                              //将rational结点接在栈顶的tnext域
                              cp.tnext.hnext = new Rational(tnum, tden);
                              //rational_num++;
                              strout += "(RATIONAL   -";
                              strout += Convert.ToString(dep);
                              strout += ") ";
                              Rational r = (Rational)cp.tnext.hnext;
                              tstr = "" + r.output() + "\r\n";
                              strout += tstr;
                              stp.Push(cp.tnext);//将rational结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         else if (temp.IndexOf('.') >= 0)//输入的是double数
                         {
                              tf = Convert.ToDouble(temp);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(DOUBLE);
                              //将double结点接在栈顶的tnext域
                              cp.tnext.hnext = tf;
                              //doube_num++;
                              strout += "(DOUBLE -";
                              strout += Convert.ToString(dep);
                              strout += ") ";
                              tstr = "" + tf + "\r\n";
                              strout += tstr;
                              stp.Push(cp.tnext);//将double结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         else //输入的是int数
                         {
                              ti = Convert.ToInt16(temp);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(INT);
                              //将int结点接在栈顶的tnext域
                              cp.tnext.hnext = ti;
                              //int_num++;
                              strout += "(INT    -";
                              strout += Convert.ToString(dep);
                              strout += ") ";
                              tstr = "" + ti + "\r\n";
                              strout += tstr;
                              stp.Push(cp.tnext);//将int结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         continue;
                    }
                    if (ch == '\'')//输入的字符
                    {
                         cp = stp.Gettop();
                         cp.tnext = new CGenListnode(CHAR);
                         //将char结点接在栈顶的tnext域
                         ch = strin[i++];
                         cp.tnext.hnext = ch;
                         //char_num++;
                         strout += "(CHAR   -";
                         strout += Convert.ToString(dep);
                         strout += ") ";
                         tstr = "\'" + ch + "\'\r\n";
                         strout += tstr;
                         stp.Push(cp.tnext);//将char结点成为新的栈顶                    
                         ch = strin[i++];
                         continue;
                    }
                    if (ch == '\"')//输入的字符串
                    {
                         cp = stp.Gettop();
                         j = 0;
                         ch = strin[i++];
                         temp = "";
                         while (ch != '\"')
                         {
                              temp += ch;
                              ch = strin[i++];
                         }
                         cp.tnext = new CGenListnode(STRING);
                         //将string结点接在栈顶的tnext域
                         cp.tnext.hnext = temp;
                         //string_num++;
                         strout += "(STRING -";
                         strout += Convert.ToString(dep);
                         strout += ") ";
                         tstr = "\"" + temp + "\"\r\n";
                         strout += tstr;
                         stp.Push(cp.tnext);//将string结点成为新的栈顶
                         continue;
                    }
                    if (ch == ',')//输入的是','
                    { continue; }
                    if (ch == ')')//输入的是')'
                    {
                         dep--;
                         do
                         {
                              cp = stp.Gettop();
                              if (cp.utype != HEAD)
                                   stp.Pop();
                         } while (cp.utype != HEAD);//将head指向的结点出栈.
                         stp.Pop();//将head结点出栈.

                         continue;
                    }
               }

               strout += "\r\n";
               strout += "总层次为:";
               strout += Convert.ToInt32(max);
          }
         
          public void out_deply(string strin, out string strout)
          {
               
               int dep = 1, max = 1;
               if (head.tnext != null)
                    MakeEmpty(out strout);

               string tstr;
               strout = "输入字符串=";
               tstr = strin;
               strout += tstr + "\r\n";
               strout = "广义表的资源管理器\r\n";
               CLinkStack<CGenListnode> stp = new CLinkStack<CGenListnode>();
               stp.Push(head);//初态时head结点入栈
               //int doube_num = 0, char_num = 0, string_num = 0, rational_num = 0, int_num = 0;
               char ch;
               string temp, temp1;
               CGenListnode cp;//存放栈顶的返回值
               int i = 1, j, k;//从输入串第一个"("的后面开始
               int ti, tnum, tden;
               double tf;
               ch = strin[0];
               int n = strin.Length;
               while (i < n)
               {
                    ch = strin[i++];
                    if (ch == '(')//'('后应生成子表的标志结点
                    {
                         dep++;
                         if (dep > max)
                              max = dep;
                         cp = stp.Gettop();
                         cp.tnext = new CGenListnode(CHILD);
                         //将子表的标志结点接在栈顶的tnext域
                         stp.Push(cp.tnext);//子表的标志结点成为新的栈顶
                         cp.tnext.hnext = new CGenListnode(HEAD);//生成子表的head结点
                         stp.Push((CGenListnode)cp.tnext.hnext);//子表的head结点入栈
                         continue;
                    }
                    string strt = "0123456789./";
                    if (strt.IndexOf(ch) >= 0)//输入的是int,double,rational
                    {
                         j = 0;
                         temp = "";
                         temp += ch;
                         ch = strin[i++];
                         while (strt.IndexOf(ch) >= 0)//输入的还是数字
                         {
                              temp += ch;
                              ch = strin[i++];
                         }
                         if (temp.IndexOf('/') >= 0)//输入的是rational数
                         {
                              j = 0;
                              temp1 = "";
                              while (temp[j] != '/')
                                   temp1 += temp[j++];
                              tnum = Convert.ToInt16(temp1);
                              j++;
                              temp1 = "";
                              while (j < temp.Length)
                                   temp1 += temp[j++];
                              tden = Convert.ToInt16(temp1);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(RATIONAL);
                              //将rational结点接在栈顶的tnext域
                              cp.tnext.hnext = new Rational(tnum, tden);
                              //rational_num++;
                              for (int i2 = 0; i2 < dep; i2++)
                                   strout += "  ";
                              strout += "---";
                              strout += "(RATIONAL   -";
                              strout += Convert.ToString(dep);
                              strout += ") ";
                              Rational r = (Rational)cp.tnext.hnext;
                              tstr = "" + r.output() + "\r\n";
                              strout += tstr;
                              stp.Push(cp.tnext);//将rational结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         else if (temp.IndexOf('.') >= 0)//输入的是double数
                         {
                              tf = Convert.ToDouble(temp);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(DOUBLE);
                              //将double结点接在栈顶的tnext域
                              cp.tnext.hnext = tf;
                              //doube_num++;
                              for (int i2 = 0; i2 < dep; i2++)
                                   strout += "  ";
                              strout += "---";
                              strout += "(DOUBLE -";
                              strout += Convert.ToString(dep);
                              strout += ") ";
                              tstr = "" + tf + "\r\n";
                              strout += tstr;
                              stp.Push(cp.tnext);//将double结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         else //输入的是int数
                         {
                              ti = Convert.ToInt16(temp);
                              cp = stp.Gettop();
                              cp.tnext = new CGenListnode(INT);
                              //将int结点接在栈顶的tnext域
                              cp.tnext.hnext = ti;
                              //int_num++;
                              for (int i2 = 0; i2 < dep; i2++)
                                   strout += "  ";
                              strout += "---";
                              strout += "(INT    -";
                              strout += Convert.ToString(dep);
                              strout += ") ";
                              tstr = "" + ti + "\r\n";
                              strout += tstr;
                              stp.Push(cp.tnext);//将int结点成为新的栈顶
                              i--;//符号串下标回退一格

                         }
                         continue;
                    }
                    if (ch == '\'')//输入的字符
                    {
                         cp = stp.Gettop();
                         cp.tnext = new CGenListnode(CHAR);
                         //将char结点接在栈顶的tnext域
                         ch = strin[i++];
                         cp.tnext.hnext = ch;
                         //char_num++;
                         for (int i2 = 0; i2 < dep; i2++)
                              strout += "  ";
                         strout += "---";
                         strout += "(CHAR   -";
                         strout += Convert.ToString(dep);
                         strout += ") ";
                         tstr = "\'" + ch + "\'\r\n";
                         strout += tstr;
                         stp.Push(cp.tnext);//将char结点成为新的栈顶                    
                         ch = strin[i++];
                         continue;
                    }
                    if (ch == '\"')//输入的字符串
                    {
                         cp = stp.Gettop();
                         j = 0;
                         ch = strin[i++];
                         temp = "";
                         while (ch != '\"')
                         {
                              temp += ch;
                              ch = strin[i++];
                         }
                         cp.tnext = new CGenListnode(STRING);
                         //将string结点接在栈顶的tnext域
                         cp.tnext.hnext = temp;
                         //string_num++;
                         for (int i2 = 0; i2 < dep; i2++)
                              strout += "  ";
                         strout += "---";
                         strout += "(STRING -";
                         strout += Convert.ToString(dep);
                         strout += ") ";
                         tstr = "\"" + temp + "\"\r\n";
                         strout += tstr;
                         stp.Push(cp.tnext);//将string结点成为新的栈顶
                         continue;
                    }
                    if (ch == ',')//输入的是','
                    { continue; }
                    if (ch == ')')//输入的是')'
                    {
                         dep--;
                         do
                         {
                              cp = stp.Gettop();
                              if (cp.utype != HEAD)
                                   stp.Pop();
                         } while (cp.utype != HEAD);//将head指向的结点出栈.
                         stp.Pop();//将head结点出栈.

                         continue;
                    }
               }
                             
          }

          //-------------------------------------------------------------------------
     }


}
