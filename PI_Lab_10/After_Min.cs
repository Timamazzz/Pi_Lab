using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_Lab_10
{
    public partial class After_Min : UserControl
    {
        public After_Min()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
        int i = 20;
       
        private void button1_Click(object sender, EventArgs e)
        {
            i = 20;
            timer1.Enabled = true;
            button1.Size = new Size(135, 48);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;
                label1.Text = i.ToString();
            }
            else
            {
                timer1.Enabled = false;
                button1.Size = new Size(135, 30);

            }
        }
    }
}
