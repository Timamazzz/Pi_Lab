using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Globalization;

namespace PI_Lab_7_Poli
{
    public partial class Form1 : Form
    {
        ArrayList list = new ArrayList();
        bool flag;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            toolStrip1.Visible = false;
            flag = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            list.Add(new My_Rectangle());

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = list;
            dataGridView1.Refresh();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

            list.RemoveAt(index);

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            dataGridView1.DataSource = list;
            dataGridView1.Refresh();
        }
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list = new ArrayList();
            list.Add(new My_Rectangle());
            MessageBox.Show("Коллекция создана");
            flag = true;
            toolStrip1.Visible = false;

        }

        private void просмотретьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = list;
            toolStrip1.Visible = false;
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            dataGridView1.DataSource = list;
            toolStrip1.Visible = true;
            flag = true;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            FileStream file = new FileStream($"{filename}.txt", FileMode.Create);
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (My_Rectangle p in list)
                {
                    string s = $"{p.a} {p.b} ";
                    sw.WriteLine(s);
                }
            }
            MessageBox.Show("Коллекция сохранена");
            toolStrip1.Visible = false;
            flag = false;
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            list = new ArrayList();
            using (StreamReader sr = new StreamReader(filename, System.Text.Encoding.Default))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] subs = line.Split(' ');

                    list.Add(new My_Rectangle(Convert.ToInt32(subs[0]), Convert.ToInt32(subs[1])));

                }
                MessageBox.Show("Коллекция загружена");

            }

            toolStrip1.Visible = false;
            flag = true;
        }



        private void случайнаяКоллекцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            list = new ArrayList();

            Random rdn = new Random();

            for (int i = 0; i < 100; i++)
                list.Add(new My_Rectangle(rdn.Next(0, 100), rdn.Next(0, 100)));
            MessageBox.Show("Коллекция сгенерирована");
            toolStrip1.Visible = false;
            flag = true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                DialogResult result = MessageBox.Show("Вы не сохранили свои действия, уверены что хотите выйти?", "Выход", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    flag = false;
                    Application.Exit();
                }
                else
                {
                    
                    flag = false;

                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                    // получаем выбранный файл
                    string filename = saveFileDialog1.FileName;
                    // сохраняем текст в файл
                    FileStream file = new FileStream($"{filename}.txt", FileMode.Create);
                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        foreach (My_Rectangle p in list)
                        {
                            string s = $"{p.a} {p.b} ";
                            sw.WriteLine(s);
                        }
                    }
                    MessageBox.Show("Коллекция сохранена");
                    toolStrip1.Visible = false;

                }
            }
            else { Application.Exit(); }
        }

        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                My_Rectangle a = list[i] as My_Rectangle;

                for (int j = i + 1; j < list.Count; j++)
                {

                    My_Rectangle b = list[j] as My_Rectangle;

                    if (a.Perimeter() < b.Perimeter())
                    {
                        list[i] = b;
                        list[j] = a;

                        a = list[i] as My_Rectangle;
                        b = list[j] as My_Rectangle;
                    }
                }
            }
            dataGridView1.Refresh();

            toolStrip1.Visible = false;
            flag = true;
        }



        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            My_Rectangle max0 = list[0] as My_Rectangle;
            My_Rectangle max1 = list[1] as My_Rectangle;
            My_Rectangle max2 = list[2] as My_Rectangle;

            for (int i = 3; i < list.Count; i++)
            {
                My_Rectangle temp = list[i] as My_Rectangle;

                if (max0.Perimeter() < temp.Perimeter())
                {
                    max0 = temp;
                }
                else
                {
                    if (max1.Perimeter() < temp.Perimeter())
                    {
                        max1 = temp;
                    }
                    else
                    {
                        if (max2.Perimeter() < temp.Perimeter())
                            max2 = temp;
                    }
                }
            }

            MessageBox.Show($"Прямоугольники с макс. периметром\n {max0.Print()}\n {max1.Print()}\n {max2.Print()}", "Поиск");

        }

        private void заданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sum_sqr = 0, sum_per = 0, sum_a = 0, count = 0;

            for (int i = 0; i < list.Count; i++)
            {
                My_Rectangle temp = list[i] as My_Rectangle;

                if (temp.a == temp.b)
                {
                    sum_sqr += temp.Square();
                    sum_per += temp.Perimeter();
                    sum_a += temp.a;
                    count++;
                }

            }

            MessageBox.Show($"Количество квадратов: {count}\n" +
                $"Средняя площадь: {sum_sqr / count}\n" +
                $"Средний периметр: {sum_per / count}\n" +
                $"Средняя длина стороны: {sum_a / count}", "Задание");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Программа написанная для лабораторной работы №7", "О программе");
            toolStrip1.Visible = false;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag)
            {
                DialogResult result = MessageBox.Show("Вы не сохранили свои действия, уверены что хотите выйти?", "Выход", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    flag = false;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                    flag = false;

                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                    // получаем выбранный файл
                    string filename = saveFileDialog1.FileName;
                    // сохраняем текст в файл
                    FileStream file = new FileStream($"{filename}.txt", FileMode.Create);
                    using (StreamWriter sw = new StreamWriter(file))
                    {
                        foreach (My_Rectangle p in list)
                        {
                            string s = $"{p.a} {p.b} ";
                            sw.WriteLine(s);
                        }
                    }
                    MessageBox.Show("Коллекция сохранена");
                    toolStrip1.Visible = false;

                }
            }
            else { Application.Exit(); }
        }

    }

}

