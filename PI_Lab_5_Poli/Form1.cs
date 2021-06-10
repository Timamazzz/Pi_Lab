using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_Lab_5_Poli
{
    public partial class Form1 : Form
    {
        public Form1()

        {

            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)

        {

            double sum = Convert.ToDouble(dataGridView1[1, 0].Value) + Convert.ToDouble(dataGridView1[1, 1].Value) + Convert.ToDouble(dataGridView1[1, 2].Value);

            label5.Text = Convert.ToString(sum);

            //double proc = sum / 100.0;

            double[] kat = new double[3];

            double[] xris = new double[3];

            var labels = new[] { label1, label2, label3 };

            for (int i = 0; i < 3; ++i)

            {

                kat[i] = Convert.ToDouble(dataGridView1[1, i].Value) / sum * 100.0;

                xris[i] = kat[i] * 3.4;

            }

            Graphics g = pictureBox1.CreateGraphics();

            g.Clear(Color.White);

            SolidBrush myBrush = new SolidBrush(Color.Green);

            Pen myPen = new Pen(Color.Black, 2);

            //график

            g.DrawLine(myPen, 10, 10, 10, 340);

            //рисовать 3 пустые полоски

            int j = 1;

            while (j != 19)

            {

                g.DrawLine(myPen, 10, 20 * j, 340, 20 * j);//верх

                g.DrawLine(myPen, 10, 20 * (j + 3), 340, 20 * (j + 3));//низ

                g.DrawLine(myPen, 340, 20 * (j + 3), 340, 20 * (j + 3));//право

                j += 6;

            }

            //заливка

            j = 1;

            for (int i = 0; i < 3; ++i)

            {

                if (kat[i] > 0)

                {

                    g.FillPolygon(myBrush, new Point[] // корпус (трапеция)

                    {

new Point(10,20*j),new Point(Convert.ToInt16(xris[i]),20*j),

new Point(Convert.ToInt16(xris[i]),20*j),new Point(Convert.ToInt16(xris[i]),20*(j+3)),

new Point(Convert.ToInt16(xris[i]),20*(j+3)),new Point(10,20*(j+3)),

new Point(10,20*(j+3)),new Point(10,20*j)

                    });

                    labels[i].Text = kat[i].ToString("##.##");

                }

                else

                    labels[i].Text = kat[i].ToString("0");

                j += 6;

            }

        }

        private void Form1_Load(object sender, EventArgs e)

        {

            BindingList<SampleRow> data = new BindingList<SampleRow>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview

            data.Add(new SampleRow("Категория 1", 0));

            data.Add(new SampleRow("Категория 2", 0));

            data.Add(new SampleRow("Категория 3", 0));

            dataGridView1.DataSource = data;

        }

        class SampleRow

        {

            public string Name { get; set; } //обязательно нужно использовать get конструкцию

            public int Count { get; set; }

            public string Hidden = ""; //Данное свойство не будет отображаться как колонка

            public SampleRow(string name, int count)

            {

                this.Name = name;

                this.Count = count;

            }

        }

    }

}
    

