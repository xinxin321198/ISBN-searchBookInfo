namespace ISBNQuery
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_query = new System.Windows.Forms.Button();
            this.textBox_isbn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_bookInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox_booklist = new System.Windows.Forms.ComboBox();
            this.button_detail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_query
            // 
            this.button_query.Location = new System.Drawing.Point(416, 27);
            this.button_query.Name = "button_query";
            this.button_query.Size = new System.Drawing.Size(75, 23);
            this.button_query.TabIndex = 1;
            this.button_query.Text = "搜索";
            this.button_query.UseVisualStyleBackColor = true;
            this.button_query.Click += new System.EventHandler(this.button_query_Click);
            // 
            // textBox_isbn
            // 
            this.textBox_isbn.Location = new System.Drawing.Point(103, 24);
            this.textBox_isbn.Name = "textBox_isbn";
            this.textBox_isbn.Size = new System.Drawing.Size(298, 25);
            this.textBox_isbn.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "ISBN编码";
            // 
            // textBox_bookInfo
            // 
            this.textBox_bookInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_bookInfo.Location = new System.Drawing.Point(12, 97);
            this.textBox_bookInfo.Multiline = true;
            this.textBox_bookInfo.Name = "textBox_bookInfo";
            this.textBox_bookInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_bookInfo.Size = new System.Drawing.Size(950, 436);
            this.textBox_bookInfo.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "该isbn编码的书籍列表";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "详情";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(612, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "没有记录";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(708, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "解析错误";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox_booklist
            // 
            this.comboBox_booklist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_booklist.Enabled = false;
            this.comboBox_booklist.FormattingEnabled = true;
            this.comboBox_booklist.Location = new System.Drawing.Point(182, 60);
            this.comboBox_booklist.Name = "comboBox_booklist";
            this.comboBox_booklist.Size = new System.Drawing.Size(669, 23);
            this.comboBox_booklist.TabIndex = 12;
            // 
            // button_detail
            // 
            this.button_detail.Enabled = false;
            this.button_detail.Location = new System.Drawing.Point(857, 59);
            this.button_detail.Name = "button_detail";
            this.button_detail.Size = new System.Drawing.Size(75, 23);
            this.button_detail.TabIndex = 13;
            this.button_detail.Text = "查看详情";
            this.button_detail.UseVisualStyleBackColor = true;
            this.button_detail.Click += new System.EventHandler(this.button_detail_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 537);
            this.Controls.Add(this.button_detail);
            this.Controls.Add(this.comboBox_booklist);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_bookInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_isbn);
            this.Controls.Add(this.button_query);
            this.Name = "Form1";
            this.Text = "根据ISBN编码查询图书信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_query;
        private System.Windows.Forms.TextBox textBox_isbn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_bookInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox_booklist;
        private System.Windows.Forms.Button button_detail;
    }
}

