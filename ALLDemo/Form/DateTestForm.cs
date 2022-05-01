using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALLDemo
{
    public partial class DateTestForm : Form
    {
        public DateTestForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString(((Button)sender).Text);        // 2008-09-04
        }

        private void button_Click2(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.Hour.ToString();
        }

    }
}
