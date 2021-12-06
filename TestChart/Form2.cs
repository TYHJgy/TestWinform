using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;          //使用串口
using System.Threading.Tasks;   //线程
using System.Runtime.InteropServices;

namespace TestChart
{
    public partial class Form2 : Form
    {


        /*泛型集合用于图表显示*/
        private List<int> List_ia = new List<int>();    //电流ia
        private List<int> List_ic = new List<int>();    //电流ic
        private List<int> List_udc = new List<int>();    //母线电压dc
        private List<int> List_vel = new List<int>();    //速度

        Random random = new Random();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)   //界面初始化
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            int num1 = random.Next(0, 99);   //随机数
            int num2 = random.Next(0, 99);
            int num3 = random.Next(0, 99);
            int num4 = random.Next(0, 99);

            List_ia.Add(num1); ListRemove(List_ia);
            List_ic.Add(num2); ListRemove(List_ic);
            List_udc.Add(num3); ListRemove(List_udc);
            List_vel.Add(num4); ListRemove(List_vel);

            DrawChart(List_ia, List_ic, List_udc, List_vel);
        }


        private void DrawChart(List<int> List_ia, List<int> List_ic, List<int> List_udc, List<int> List_vel)
        {
            chart1.Series[0].Points.Clear();    //清除所有点
            chart1.Series[1].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();

            for (int i = 0; i < List_ia.Count; i++)
            {
                chart1.Series[0].Points.AddXY(i + 1, List_ia[i]);   //添加点
            }
            for (int i = 0; i < List_ic.Count; i++)
            {
                chart1.Series[1].Points.AddXY(i + 1, List_ic[i]);
            }
            for (int i = 0; i < List_udc.Count; i++)
            {
                chart2.Series[0].Points.AddXY(i + 1, List_udc[i]);
            }
            for (int i = 0; i < List_vel.Count; i++)
            {
                chart3.Series[0].Points.AddXY(i + 1, List_vel[i]);
            }
        }

        //清除所有的列表
        private void ClearAllList()
        {
            List_ia.Clear();
            List_ic.Clear();
            List_udc.Clear();
            List_vel.Clear();
        }



        //当大于80时移除list头部
        private void ListRemove(List<int> list)
        {
            if (list.Count >= 80)
            {
                list.RemoveAt(0);
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (button_start.Text == "开始")
            {
                timer1.Start();
                button_start.Text = "暂停";
            }
            else
            {
                timer1.Stop();
                button_start.Text = "开始";
            }
        }
    }
}