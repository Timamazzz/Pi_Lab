using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_Lab_8
{
   
    public partial class Form2 : Form
    {
        
        public Form2(string s1, string s2, string s3, int i1)
        {
            InitializeComponent();
            if (s1 == "" && s2 == "" && s3 == "" && i1 == 0)
            {
                button1.Text = "Добавить";
                this.Text = "Добавление";
            }
            else
            {
                button1.Text = "Изменить";
                this.Text = "Изменение";
                textBox1.Text = s1;
                textBox2.Text = s2;
                textBox3.Text = s3;
                textBox4.Text = Convert.ToString(i1);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public string Fet
        {
            get { return textBox1.Text; }
            set { }
        }

        public string Root
        {
            get { return textBox2.Text; }
            set {}
        }

        public string Name_0
        {
            get { return textBox3.Text; }
            set { }
        }

       public int CF
       {
            get { return Convert.ToInt32(textBox4.Text); }
            set { }
       }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
