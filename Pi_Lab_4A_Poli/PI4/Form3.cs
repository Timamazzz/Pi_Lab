using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;

            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;

            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;

        }
    }
}
