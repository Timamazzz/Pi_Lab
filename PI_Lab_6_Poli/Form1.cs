using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PI_Lab_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;

            chart1.Visible = false;

            comboBox1.SelectedIndex = 0;

            panel1.Visible = false;
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label6.Text = "(x-1)/(x+2)+lg(x+2)";
                
            }
            else
            {
                label6.Text = "6x^2-2x-2";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    double x = Convert.ToDouble(textBox1.Text);
                    double eps = Convert.ToDouble(textBox2.Text);

                    Delegate try1 = new Delegate(x, eps);

                    if (comboBox1.SelectedIndex == 0)
                    {
                        Func<double, double> f = try1.f1;
                        textBox3.Text = Convert.ToString(f(x));

                        Func<double, double> df = try1.df1;
                        textBox4.Text = Convert.ToString(df(x));

                        textBox5.Text = Convert.ToString(try1.method_N(f, df, 1, 3));

                        textBox6.Text = Convert.ToString(try1.half_division_method(f, 1, 2));

                        chart1.Visible = true;

                        chart1.Series[0].Points.Clear();

                        for (int i = -1; i <= 10; i++)
                        {
                            chart1.Series[0].Points.AddXY(i, f(i));
                        }

                    }
                    else
                    {
                        Func<double, double> f = try1.f2;
                        textBox3.Text = Convert.ToString(f(x));

                        Func<double, double> df = try1.df2;
                        textBox4.Text = Convert.ToString(df(x));

                        textBox5.Text = Convert.ToString(try1.method_N(f, df, -10, 10));

                        textBox6.Text = Convert.ToString(try1.half_division_method(f, -10, 10));

                        chart1.Visible = true;

                        chart1.Series[0].Points.Clear();

                        for (int i = -1; i <= 10; i++)
                        {
                            chart1.Series[0].Points.AddXY(i, f(i));
                        }
                    }
                }
                else
                {
                    throw new Exception ("Введите данные");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       

    private void button2_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
            }
            else 
            {
                panel1.Visible = true;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
