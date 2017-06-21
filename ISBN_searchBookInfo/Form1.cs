using System;
using System.Windows.Forms;
using ISBNQuery;
using System.Collections.Generic;
using ISBN_searchBookInfo;

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
            comboBox_booklist.Items.Clear();
            try
            {
                comboBox_booklist.Enabled = false;
                button_detail.Enabled = false;
                String html = opcaForISBN.getResultHtmlStr(textBox_isbn.Text);
                bool isTable = opcaForISBN.isDetailOrList(html);
                if (isTable)
                {
                    //以详情形式解析
                    List<String> tdList = opcaForISBN.getDetailTdList(html);

                    Dictionary<String, String> map = opcaForISBN.getDetails(tdList);
                    foreach (KeyValuePair<String, String> p in map)
                    {
                        textBox_bookInfo.Text += p.Key + ":" + p.Value + "\r\n";
                        textBox_bookInfo.Text += "---------------------------------------\r\n";
                    }
                }
                else
                {
                    //以列表形式解析
                    comboBox_booklist.Enabled = true;
                    button_detail.Enabled = true;

                    List<Title> titleList = opcaForISBN.getTileList(html);
                    foreach (Title title in titleList)
                    {
                        comboBox_booklist.Items.Add(title);
                    }
                    comboBox_booklist.DisplayMember = "Name";
                    comboBox_booklist.ValueMember = "Href";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_isbn.Text = "9787555227069";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox_isbn.Text = "112233";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox_isbn.Text = @"isbn=""123""";
        }

        private void button_detail_Click(object sender, EventArgs e)
        {
            textBox_bookInfo.Clear();
            if(null != comboBox_booklist.SelectedItem)
            {
                Title title = (Title)comboBox_booklist.SelectedItem;
                String html = opcaForISBN.getHtmlStr(title.Href);
                bool isDetail = opcaForISBN.isDetailOrList(html);
                if (isDetail)
                {
                    //必须是detail的页面才能解析
                    List<String> tdList = opcaForISBN.getDetailTdList(html);
                    Dictionary<String, String> map = opcaForISBN.getDetails(tdList);

                    foreach (KeyValuePair<String, String> p in map)
                    {
                        textBox_bookInfo.Text += p.Key + ":" + p.Value + "\r\n";
                        textBox_bookInfo.Text += "---------------------------------------\r\n";
                    }
                
                }
                else
                {
                    MessageBox.Show("此连接请求到一个书本列表，不能解析");
                }
            }
            else
            {
                MessageBox.Show("请选择一本书再进行查询");
            }
        }
    }
}
