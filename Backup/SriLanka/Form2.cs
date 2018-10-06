using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SriLanka
{
    public partial class Form2 : Form
    {
        public Form2(String ID)
        {
            InitializeComponent();
            label1.Text = ID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cloudDesktopButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
