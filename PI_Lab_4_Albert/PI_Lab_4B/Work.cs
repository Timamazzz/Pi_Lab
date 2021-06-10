using System;
using System.Windows.Forms;

namespace PI_Lab_4A
{
    public partial class Work : Form
    {
        public Work()
        {
            InitializeComponent();           
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main_Menu fr1 = new Main_Menu();
            fr1.Show();
            Close();
        }


        int n1;
        int m1;
        Matrix array1;
        

        int n2;
        int m2;
        Matrix array2;

        int n3;
        int m3;
        Matrix array3;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != ""  && textBox2.Text != "" && Convert.ToInt32(textBox1.Text) >0 && Convert.ToInt32(textBox2.Text)>0)
            {
                n1 = Convert.ToInt32(textBox1.Text);
                m1 = Convert.ToInt32(textBox2.Text);
               

                dataGridView1.Show();
                dataGridView1.RowCount = n1;
                dataGridView1.ColumnCount = m1;

                for (int i = 0; i < n1; i++)
                {
                    dataGridView1.Rows[i].HeaderCell.Value = string.Format((i).ToString(), "0");
                    
                }
                for (int i = 0; i < m1; i++)
                {
                    dataGridView1.Columns[i].HeaderCell.Value = string.Format((i).ToString(), "0");
                }
            }
            else
            {
                MessageBox.Show("Parameters set incorrectly");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            n1 = Convert.ToInt32(textBox1.Text);
            m1 = Convert.ToInt32(textBox2.Text);
            array1 = new Matrix();
            array1 = new Matrix(n1, m1);
           

            for (int i = 0; i < n1; i++)
                for (int j = 0; j < m1; j++)
                {
                    array1[i, j] = Convert.ToInt32(dataGridView1[j,i].Value);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            if (textBox3.Text != "" && textBox4.Text != "" && Convert.ToInt32(textBox3.Text) > 0 && Convert.ToInt32(textBox4.Text) > 0)
            {

                n2 = Convert.ToInt32(textBox3.Text);
                m2 = Convert.ToInt32(textBox4.Text);
                array2 = new Matrix(n2, m2);

                dataGridView2.Show();
                dataGridView2.RowCount = n2;
                dataGridView2.ColumnCount = m2;

                for (int i = 0; i < n2; i++)
                {
                    dataGridView2.Rows[i].HeaderCell.Value = string.Format((i).ToString(), "0");

                }
                for (int i = 0; i < m2; i++)
                {
                    dataGridView2.Columns[i].HeaderCell.Value = string.Format((i).ToString(), "0");
                }
            }
            else
            {
                MessageBox.Show("Parameters set incorrectly");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                int j = Convert.ToInt32(textBox5.Text);

                if (j >= 0 && j < m1)
                {


                    MessageBox.Show($"The sum of a column={array1.SumOfColumn(j)}");
                }
                else
                {
                    MessageBox.Show("Parameters set incorrectly");

                }
            }
            else
            {
                int j = Convert.ToInt32(textBox5.Text);

                if (j >= 0 && j < m2)
                {


                    MessageBox.Show($"The sum of a column={array2.SumOfColumn(j)}");
                }
                else
                {
                    MessageBox.Show("Parameters set incorrectly");

                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (array1.ZeroQuantity() == 0)
                {
                    MessageBox.Show($"There are no null elements");
                }
                else
                {
                    MessageBox.Show($"Number of null elements = { array1.ZeroQuantity()}");

                }

            }
            else 
            {
                if (array1.ZeroQuantity() == 0)
                {
                    MessageBox.Show($"There are no null elements");
                }
                else
                {
                    MessageBox.Show($"Number of null elements = { array2.ZeroQuantity()}");

                }
            }
                

        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                array1++;
                for (int i = 0; i < n1; i++)
                    for (int j = 0; j < m1; j++)
                    {
                        dataGridView1[j, i].Value = array1[i, j];
                    }
            }
            else
            {
                array2++;
                for (int i = 0; i < n1; i++)
                    for (int j = 0; j < m1; j++)
                    {
                        dataGridView2[j, i].Value = array2[i, j];
                    }
            }
               


        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                array1--;
                for (int i = 0; i < n1; i++)
                    for (int j = 0; j < m1; j++)
                    {
                        dataGridView1[j, i].Value = array1[i, j];
                    }
            }
            else
            {
                array2--;
                for (int i = 0; i < n1; i++)
                    for (int j = 0; j < m1; j++)
                    {
                        dataGridView2[j, i].Value = array2[i, j];
                    }
            }
        }

       

        

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (array1)
                {
                    MessageBox.Show($"The matrix is a square");
                }
                else
                {
                    MessageBox.Show($"The matrix is not square");
                }
            }
            else {
                if (array2)
                {
                    MessageBox.Show($"The matrix is a square");
                }
                else
                {
                    MessageBox.Show($"The matrix is not square");
                }
            }
                
        }

       

        private void button14_Click(object sender, EventArgs e)
        {
            if (n1 == n2 && m1 == m2)
            {

                array3 = array1 + array2;
                n3 = n1;
                m3 = m1;

                dataGridView3.Show();
                dataGridView3.RowCount = n3;
                dataGridView3.ColumnCount = m3;

                for (int i = 0; i < n3; i++)
                {
                    dataGridView3.Rows[i].HeaderCell.Value = string.Format((i).ToString(), "0");

                }
                for (int i = 0; i < m3; i++)
                {
                    dataGridView3.Columns[i].HeaderCell.Value = string.Format((i).ToString(), "0");
                }

                for (int i = 0; i < n3; i++)
                    for (int j = 0; j < m3; j++)
                    {
                        dataGridView3[j, i].Value = array3[i, j];
                    }
                label8.Visible = true;
            }
            else
            {
                MessageBox.Show($" Matrices of more than one dimension");
               
            }
        }

        
    }

   


}
