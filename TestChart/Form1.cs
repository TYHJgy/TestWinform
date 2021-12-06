using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TestChart
{
    public partial class Form1 : Form
    {

        private Queue<double> dataQueue = new Queue<double>(100);

        private int curValue = 0;

        private int num = 5;//每次删除增加几个点
        public Form1()
        {
            InitializeComponent();
            InitChart();
        }

        /// <summary>
        /// 初始化图表
        /// </summary>
        private void InitChart()
        {
            //定义图表区域
            this.chart1.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            this.chart1.ChartAreas.Add(chartArea1);

            ChartArea chartArea2 = new ChartArea("C2");
            this.chart1.ChartAreas.Add(chartArea2);

            ChartArea chartArea3 = new ChartArea("C3");
            this.chart1.ChartAreas.Add(chartArea3);

            ChartArea chartArea4 = new ChartArea("C4");
            this.chart1.ChartAreas.Add(chartArea4);

            ChartArea chartArea5 = new ChartArea("C5");
            this.chart1.ChartAreas.Add(chartArea5);

            //图表区域样式
            chartArea1.BackColor = Color.AliceBlue;                      //背景色
            chartArea1.BackSecondaryColor = Color.White;                 //渐变背景色
            chartArea1.BackGradientStyle = GradientStyle.TopBottom;      //渐变方式
            chartArea1.BackHatchStyle = ChartHatchStyle.None;            //背景阴影
            chartArea1.BorderDashStyle = ChartDashStyle.NotSet;          //边框线样式
            chartArea1.BorderWidth = 1;                                  //边框宽度
            chartArea1.BorderColor = Color.Black;

            //定义存储和显示点的容器
            this.chart1.Series.Clear();
            Series series1 = new Series("S1");
            series1.ChartArea = "C1";
            this.chart1.Series.Add(series1);

            Series series2 = new Series("S2");
            series2.ChartArea = "C2";
            this.chart1.Series.Add(series2);

            Series series3 = new Series("S3");
            series3.ChartArea = "C3";
            this.chart1.Series.Add(series3);

            Series series4 = new Series("S4");
            series4.ChartArea = "C4";
            this.chart1.Series.Add(series4);

            Series series5 = new Series("S5");
            series5.ChartArea = "C5";
            this.chart1.Series.Add(series5);

            //设置AxisY样式
            this.chart1.ChartAreas[0].AxisY.Title = @"Value";
            this.chart1.ChartAreas[0].AxisY.LabelAutoFitMinFontSize = 5;
            this.chart1.ChartAreas[0].AxisY.LineWidth = 5;
            this.chart1.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            this.chart1.ChartAreas[0].AxisY.LineColor = Color.Black;
            this.chart1.ChartAreas[0].AxisY.Minimum = 0;
            this.chart1.ChartAreas[0].AxisY.Maximum = 100;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;


            this.chart1.ChartAreas[0].AxisX.Title = @"Time";
            this.chart1.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            this.chart1.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 5;
            this.chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -15;


            this.chart1.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;        //show the last label
            this.chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            this.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.NotSet;
            this.chart1.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Auto;
            this.chart1.ChartAreas[0].AxisX.LineWidth = 2;
            this.chart1.ChartAreas[0].AxisX.LineColor = Color.Black;
            this.chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            this.chart1.ChartAreas[0].AxisX.ScaleView.MinSizeType = DateTimeIntervalType.Months;
            this.chart1.ChartAreas[0].AxisX.Crossing = 0;


            //this.chart1.ChartAreas[0].AxisX.Minimum = 0;
            this.chart1.ChartAreas[0].AxisX.Maximum = 105;
            //this.chart1.ChartAreas[0].AxisX.Interval = 5;
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;

            //设置标题
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("S01");
            this.chart1.Titles[0].Text = string.Format("XXX {0} 显示", "1");
            this.chart1.Titles[0].ForeColor = Color.RoyalBlue;
            this.chart1.Titles[0].Font = new Font("Microsoft Sans Serif", 12F);

            this.chart1.Titles.Add("S02");
            this.chart1.Titles[1].Text = string.Format("XXX {0} 显示", "2");
            this.chart1.Titles[1].ForeColor = Color.RoyalBlue;
            this.chart1.Titles[1].Font = new Font("Microsoft Sans Serif", 12F);

            //设置图表显示样式
            this.chart1.Series[0].Color = Color.Red;
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[0].ChartType = SeriesChartType.Line;

            this.chart1.Series[1].ChartType = SeriesChartType.Area;
            this.chart1.Series[2].ChartType = SeriesChartType.Bar;
            this.chart1.Series[3].ChartType = SeriesChartType.FastLine;
            this.chart1.Series[4].ChartType = SeriesChartType.Radar;

        }

        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateQueueValue();
            this.chart1.Series[0].Points.Clear();
            for (int i = 0; i < dataQueue.Count; i++)
            {
                this.chart1.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));
                this.chart1.Series[1].Points.AddXY((i + 1), dataQueue.ElementAt(i));
                this.chart1.Series[2].Points.AddXY((i + 1), dataQueue.ElementAt(i));
                this.chart1.Series[3].Points.AddXY((i + 1), dataQueue.ElementAt(i));
                this.chart1.Series[4].Points.AddXY((i + 1), dataQueue.ElementAt(i));
            }
        }
        //更新队列中的值
        private void UpdateQueueValue()
        {

            if (dataQueue.Count > 100)
            {
                //先出列
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Dequeue();
                }
            }
            for (int i = 0; i < num; i++)
            {
                //对curValue只取[0,360]之间的值
                curValue = curValue % 360;
                //对得到的正玄值，放大50倍，并上移50
                dataQueue.Enqueue((50 * Math.Sin(curValue * Math.PI / 180)) + 50);
                curValue = curValue + 10;
            }
        }
    }
}
