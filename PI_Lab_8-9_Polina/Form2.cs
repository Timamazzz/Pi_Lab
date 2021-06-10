using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_8_9_Polina
{
    public partial class Form2 : Form
    {
        public Form2(int s1, int s2, string s3, string s4, int i1)
        {
            InitializeComponent();
            if (s1 == 0 && s2 == 0 && s3 == "" && s4 == "" && i1 == 0)
            {
                button1.Text = "Добавить";
                this.Text = "Добавление";
            }
            else
            {
                button1.Text = "Изменить";
                this.Text = "Изменение";
                textBox1.Text = s1.ToString();
                textBox2.Text = s2.ToString();
                textBox3.Text = s3;
                textBox4.Text = s4;

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public int Cap
        {
            get { return Convert.ToInt32(textBox1.Text); }
            set { }
        }

        public int Fec
        {
            get { return Convert.ToInt32(textBox2.Text); }
            set { }
        }

        public string Man
        {
            get { return textBox3.Text; }
            set { }
        }

        public string Mod
        {
            get { return textBox4.Text; }
            set { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
