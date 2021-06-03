using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Assignment3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Username.Text))
            {
                MessageBox.Show("Please Enter Username");
            }
            else
            {
                this.Hide();
                Form1 form1 = new Form1(Username.Text);
                form1.Show();

            }
        }

      
    }
}
