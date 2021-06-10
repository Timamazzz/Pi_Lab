using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pi_Lab_4B_Poli
{
    public partial class Form1 : Form
    {
       
        Rectangle rec;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Периметр прямоугольника = {rec.Perimeter}", "Периметр");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();

            rec = new Rectangle(f2.A, f2.B);

            label1.Visible = true;
            label1.Text = rec.Print();

            label2.Visible = true;

            if (rec)
                label2.Text = "Квадрат";
            else
                label2.Text = "Не квадрат";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Площадь прямоугольника = {rec.Square}", "Площадь");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rec++;
            label1.Text = rec.Print();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rec--;
            label1.Text = rec.Print();
        }
    }
}
