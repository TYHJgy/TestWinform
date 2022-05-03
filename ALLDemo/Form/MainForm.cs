using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//dev

/*
Ctrl-M-O   折叠所有方法
Ctrl-M-L   展开所有方法
Ctrl-M-P   展开所有方法并停止大纲显示（不可以再折叠了） 
Ctrl-M-M   折叠或展开当前方法 
批量注释： 先ctrl+k，然后ctrl+c
取消注释： 先ctrl+k，然后ctrl+u
*/

namespace ALLDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void DataGridView_Test_Click(object sender, EventArgs e)
        {
            DataGridViewForm form = new DataGridViewForm();
            form.ShowDialog();
        }

        private void TabControl_Test_Click(object sender, EventArgs e)
        {
            TabPageDemoForm form = new TabPageDemoForm();
            form.ShowDialog();

        }
        //串口测试
        private void button1_Click(object sender, EventArgs e)
        {
            SerialTestForm form = new SerialTestForm();
            form.ShowDialog();

        }

        //测试socket
        private void button2_Click(object sender, EventArgs e)
        {
            SocketTestForm  form = new SocketTestForm();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChartTestForm form = new ChartTestForm();
            form.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DateTestForm form = new DateTestForm();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileTestForm form = new FileTestForm();
            form.ShowDialog();
        }
    }
}
