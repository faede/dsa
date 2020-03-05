using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_CSharp
{
     public partial class CSeqList_Form : Form
     {
          class CSeqList<Type>//顺序表泛型类
          {
               private Type[] data;//顺序表数据
               private int MaxSize;//最大空间
               private int datasize;//实际元素个数
               public CSeqList(int MaxSize)//构造函数
               {
                    this.MaxSize = MaxSize;
                    data = new Type[MaxSize];
                    datasize = 0;
               }
               public CSeqList(int MaxSize, Type[] data, int n)
               {
                    this.MaxSize = MaxSize;
                    this.data = new Type[MaxSize];
                    for (int i = 0; i < n; i++)
                         this.data[i] = data[i];
                    datasize = n;
               }
               public bool Inset(int k, Type dt)
               {
                    if (k < 1 || k > datasize + 1)
                         return false;
                    if (datasize == MaxSize)
                         return false;
                    for (int i = datasize - 1; i >= k - 1; i--)
                         data[i + 1] = data[i];
                    data[k - 1] = dt;
                    datasize++;
                    return true;
               }
               public bool Delete(int k)
               {
                    if (k < 1 || k > datasize)
                         return false;
                    for (int i = k - 1; i < datasize - 1; i++)
                         data[i] = data[i + 1];
                    datasize--;
                    return true;
               }
               public bool Update(int k, Type dt)
               {
                    if (k < 1 || k > datasize)
                         return false;
                    data[k - 1] = dt;
                    return true;
               }
               public void MakeEmpty()
               {
                    datasize = 0;
               }
               public Type GetData(int i)
               {
                    return data[i - 1];
               }
               public int DataSize
               {
                    get
                    {
                         return datasize;
                    }
               }

               public string MyPrint()
               {
                    string strout = "";
                    for (int i = 0; i < MaxSize; i++)
                    {
                         if (i < datasize)
                              strout += (i + 1) + "\t【" + data[i] + "】\n";
                    }
                    return strout;
               }


          };
          private CSeqList<int> m_seqlist;

          public CSeqList_Form()
          {
               InitializeComponent();
          }

          private void CSeqList_Form_Load(object sender, EventArgs e)
          {
               m_seqlist = new CSeqList<int>(100);
          }

          private void bt_create_Click(object sender, EventArgs e)
          {
               int m_createmaxno = Convert.ToInt16(tb_maxcount.Text);
               int m_createno = Convert.ToInt16(tb_count.Text);
               if (m_createmaxno >= m_createno && m_createmaxno >= 1 && m_createno >= 1)
               {
                    int[] dt = new int[m_createno];
                    Random ran = new Random();
                    for (int i = 0; i < m_createno; i++)
                    {
                         if (ct_ln.Checked == true)
                              dt[i] = i + 1;
                         else
                              dt[i] = ran.Next(m_createno) + 1;
                    }
                    if (m_createno <= m_createmaxno && m_createno >= 1)
                    {
                         m_seqlist = new CSeqList<int>(m_createmaxno, dt, m_createno);
                         string str = m_seqlist.MyPrint();
                         richTextBox1.Text = str;
                    }
               }
               else
               {
                    MessageBox.Show("请检查最大个数或数据个数！");
               }

          }

          private void cl_l_Click(object sender, EventArgs e)
          {
               m_seqlist.MakeEmpty();
               string str = m_seqlist.MyPrint();
               richTextBox1.Text = str;
          }

          private void bt_insert_Click(object sender, EventArgs e)
          {
               int k;
               if (tb_modify_no.Text == null)
               {
                    k = Convert.ToInt16(tb_modify_no.Text);
                    int dt = Convert.ToInt16(tb_modify_dt.Text);
                    if (bt_up.Checked)
                    {
                         if (m_seqlist.Inset(1, dt))
                         {

                              string str = m_seqlist.MyPrint();
                              richTextBox1.Text = str;
                         }
                         else
                         {
                              MessageBox.Show("插入的节点位置错误 !");
                         }
                    }
                    else if (bt_down.Checked)
                    {
                         if (m_seqlist.Inset(m_seqlist.DataSize + 1, dt))
                         {
                              string str = m_seqlist.MyPrint();
                              richTextBox1.Text = str;
                         }
                         else
                         {
                              MessageBox.Show("插入的节点位置错误 !");
                         }
                    }
                    else
                    {
                         if (m_seqlist.Inset(k, dt))
                         {
                              string str = m_seqlist.MyPrint();
                              richTextBox1.Text = str;
                         }
                         else
                         {
                              MessageBox.Show("插入的节点位置错误 !");
                         }

                    }
               }
               else
               {
                    MessageBox.Show("请检查操作数据 !");
               }

          }

          private void bt_update_Click(object sender, EventArgs e)
          {
               int k;
               if (bt_up.Checked)
               {
                    k = 1;
               }
               else if (bt_down.Checked)
               {
                    k = m_seqlist.DataSize;
               }
               else
               {
                    k = Convert.ToInt16(tb_modify_no.Text);

               }
               if (k <= m_seqlist.DataSize && k >= 1)
               {
                    int dt = Convert.ToInt16(tb_modify_dt.Text);
                    if (m_seqlist.Update(k, dt))
                    {
                         string str = m_seqlist.MyPrint();
                         richTextBox1.Text = str;
                    }
                    else
                    {
                         MessageBox.Show("更新的节点位置错误 !");
                    }
               }
               else
               {
                    MessageBox.Show("更新的节点位置错误 !");
               }
          }

          private void bt_delete_Click(object sender, EventArgs e)
          {
               int k;
               if (bt_up.Checked)
               {
                    k = 1;
               }
               else if (bt_down.Checked)
               {
                    k = m_seqlist.DataSize;
               }
               else
               {
                    k = Convert.ToInt16(tb_modify_no.Text);

               }
               if (k <= m_seqlist.DataSize && k >= 1)
               {
                    if (m_seqlist.Delete(k))
                    {
                         string str = m_seqlist.MyPrint();
                         richTextBox1.Text = str;
                    }
                    else
                    {
                         MessageBox.Show("删除的节点位置错误 !");
                    }
               }
               else
               {
                    MessageBox.Show("删除的节点位置错误 !");
               }
          }

          private void quit_Click(object sender, EventArgs e)
          {
               this.Close();
          }

          private void groupBox1_Enter(object sender, EventArgs e)
          {

          }

          private void button1_Click(object sender, EventArgs e)
          {

               int m_createmaxno = Convert.ToInt16(tb_maxcount.Text);
               int m_createno = Convert.ToInt16(tb_count.Text);
               if (m_createmaxno >= m_createno && m_createmaxno >= 1 && m_createno >= 1)
               {
                    int[] dt = new int[m_createno];
                    int[] dt2 = new int[m_createno];
                    Random ran = new Random();
                    int c = 0;
                    bool b = true;
                    for (int i = 1; i <= m_createno; i++)
                    {
                         dt2[i - 1] = i;
                    }
                    for (int i = 1; i <= m_createno; i++)
                    {
                         while (dt[i - 1] == 0)
                         {
                              c = ran.Next(m_createno) + 1;
                              if (dt2[c - 1] != 0)
                              {
                                   dt[i - 1] = dt2[c - 1];
                                   dt2[c - 1] = 0;
                              }
                              else
                                   dt[i - 1] = 0;
                         }
                    }
                    m_seqlist = new CSeqList<int>(m_createmaxno, dt, m_createno);
                    string str = m_seqlist.MyPrint();
                    richTextBox1.Text = str;

               }
               else
               {
                    MessageBox.Show("请检查最大个数或数据个数！");
               }
          }

          private void tb_count_TextChanged(object sender, EventArgs e)
          {

          }

          private void button2_Click(object sender, EventArgs e)
          {
               int m_createmaxno = Convert.ToInt16(tb_maxcount.Text);
               int m_createno = Convert.ToInt16(tb_count.Text);
               if (m_createmaxno >= m_createno && m_createmaxno >= 1 && m_createno >= 1)
               {
                    int[] dt = new int[m_createno];
                    int count = 0;
                    int i = 2;
                    Random ran = new Random();
                    bool b = true;
                    while (i <= m_createno)
                    {
                         for (int j = 2; j < i / 2; j++)
                         {
                              if (i % j == 0)
                                   b = false;
                         }
                         if (b)
                         {
                              dt[count] = i;
                              count++;
                         }
                         b = true;
                         i++;
                    }
                    for (int n = 0; n < m_createno; n++)
                    {
                         if (dt[n] == 0)
                         {
                              count = n;
                              break;
                         }
                         else
                              count = m_createno;

                    }
                    int[] dt2 = new int[count];
                    for (int n = 0; n < count; n++)
                    {
                         dt2[n] = dt[n];

                    }
                    m_seqlist = new CSeqList<int>(m_createmaxno, dt2, count);
                    string str = m_seqlist.MyPrint();
                    richTextBox1.Text = str;
               }
          }

          private void richTextBox1_TextChanged(object sender, EventArgs e)
          {

          }

          private void fib_Click(object sender, EventArgs e)
          {
               int m_createmaxno = Convert.ToInt16(tb_maxcount.Text);
               int m_createno = Convert.ToInt16(tb_count.Text);
               if (m_createmaxno >= m_createno && m_createmaxno >= 1 && m_createno >= 1)
               {
                    int[] dt = new int[m_createno];
                    int a = 0, b = 1, c = 1, i = 2;
                    dt[0] = 0; dt[1] = 1;
                    while (i < m_createno)
                    {
                         c = a + b;
                         dt[i] = c;
                         a = b;
                         b = c;
                         i++;
                    }
                    if (m_createno <= m_createmaxno && m_createno >= 1)
                    {
                         m_seqlist = new CSeqList<int>(m_createmaxno, dt, m_createno);
                         string str = m_seqlist.MyPrint();
                         richTextBox1.Text = str;
                    }
               }
               else
               {
                    MessageBox.Show("请检查最大个数或数据个数！");
               }
          }

          private void reverse_Click(object sender, EventArgs e)
          {


               int i = 1, j = m_seqlist.DataSize;
               while (i < j)
               {
                    int r = m_seqlist.GetData(j);
                    m_seqlist.Update(j, m_seqlist.GetData(i));
                    m_seqlist.Update(i,r);
                    i++;
                    j--;
               }
               string str = m_seqlist.MyPrint();
               richTextBox1.Text = str;


          }
     }
}
