using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 数独
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int[,] m;
        private bool flag = false;
        private void btn_reset_Click(object sender, EventArgs e)
        {
            foreach (Control tb in this.Controls)
            {
                if(tb.GetType() == typeof(TextBox))
                    tb.Text = "0";
            }            
        }
        private void input()
        {
            m = new int[9,9];
            int[] n = new int[81];
            int k;
            foreach (Control tb in this.Controls)
            {
                if (tb.GetType() == typeof(TextBox))
                {
                    k = tb.TabIndex;
                    n[k] = Convert.ToInt32(tb.Text);
                    //k++;
                }
            }
            k = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    
                    m[i,j] = n[k];
                    k++;
                }
            }
            //for (int i = 0; i < 9; i++)
            //{
            //    for (int j = 0; j < 9; j++)
            //    {
            //        listBox1.Items.Add(m[i, j].ToString());
            //    }
            //    listBox1.Items.Add("\n");
            //}
        }
        private void output()
        {
            if (flag == false)
            {
                MessageBox.Show("无解");
            }
            //for (int i = 0; i < 9; i++)
            //{
            //    for (int j = 0; j < 9; j++)
            //    {
            //        listBox1.Items.Add(m[i, j].ToString());
            //    }
            //    listBox1.Items.Add("\n");
            //}
            int k;
            foreach (Control tb in this.Controls)
            {
                if (tb.GetType() == typeof(TextBox))
                {
                    k = tb.TabIndex;
                    tb.Text = m[k / 9 , k % 9].ToString();
                }
            }
            flag = false;
        }
        private bool check(int index1, int n)
        {
            int r = index1 / 9;
            int c = index1 % 9;
            for (int i = 0; i < 9; i++)
            {
                if (m[r, i] == n)
                {
                    return false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (m[i, c] == n)
                {
                    return false;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (m[r - r % 3 + i, c - c % 3 + j] == n)
                    {
                        return false;
                    }
                }
            }
            ///* x为n所在的小九宫格左顶点竖坐标 */
            //int x = r / 3 * 3;

            ///* y为n所在的小九宫格左顶点横坐标 */
            //int y = c / 3 * 3;

            ///* 判断n所在的小九宫格是否合法 */
            //for (int i = x; i < x + 3; i++)
            //{
            //    for (int j = y; j < y + 3; j++)
            //    {
            //        if (m[i, j] == n) return false;
            //    }
            //}
            return true;
        }
        
        private void calcu(int index)
        {
            int k = index;
            if (k > 80)
            {
                flag = true;
                return;
            }
            else
            {
                //for (int k = index; k < 81; k++)
                //{
                    if (m[k / 9, k % 9] != 0)
                    {
                        calcu(k + 1);
                    }
                    else
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            if (check(k, i + 1))
                            {
                                m[k / 9, k % 9] = i + 1;
                                calcu(k + 1);
                                if (flag == true)
                                {
                                    return;
                                }
                                m[k / 9, k % 9] = 0;
                            }
                        }
                    }
                //}
            }
        }
        private void btn_calcu_Click(object sender, EventArgs e)
        {
            input();
            calcu(0);
            output();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
