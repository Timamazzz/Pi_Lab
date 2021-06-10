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
    public partial class Redact_ToolTip : UserControl
    {
        public Redact_ToolTip()
        {
            InitializeComponent();

        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
            richTextBox1.Text = toolTip1.GetToolTip(button1);
            button2.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            toolTip1.SetToolTip(button1, richTextBox1.Text);
            button2.Visible = false;
        }
    }
}
