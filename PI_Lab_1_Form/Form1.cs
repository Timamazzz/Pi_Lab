﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PI_Lab_1_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void goButton_Click(object sender, System.EventArgs e)
        {
            webBrowser1.Navigate(new Uri(comboBox1.SelectedItem.ToString()));
        }

        private void homeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void goForwardToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void goBackToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            webBrowser1.GoHome();
        }
    }
}
