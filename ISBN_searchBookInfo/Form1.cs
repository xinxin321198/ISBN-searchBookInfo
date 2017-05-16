using System;
using System.Windows.Forms;
using ISBNQuery;
using System.Collections.Generic;

namespace ISBNQuery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox_isbn.Text = "";
        }


        private void textBox_content_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void button_query_Click(object sender, EventArgs e)
        {
            textBox_bookInfo.Clear();
            Dictionary<String, String> map = new Dictionary<string, string>();
            String one = "";
            String two ="";
            String three ="";
            try
            {
                map = opcaForISBN.getbookInfo(textBox_isbn.Text);
                //获取单个数据的方式
                one = map["题名与责任"];
                two = map["著者"];
                three = map["不存在的字段"];//如果取不存在的字段会抛错，给定关键字不在字典中
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                foreach (KeyValuePair<String, String> p in map)
                {
                    textBox_bookInfo.Text += p.Key + ":" + p.Value + "\r\n";
                    textBox_bookInfo.Text += "---------------------------------------\r\n";
                }
                textBox_bookInfo.Text += "*****分割线*******以上是遍历获取所有值*********以下是获取单个值*************\r\n";
                textBox_bookInfo.Text += one + "\r\n" + two + "\r\n"+three;
            }
        }
    }
}
