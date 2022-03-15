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

namespace ALLDemo
{
    public partial class ChartTestForm : Form
    {
        double curValue;//模拟数据
        DateTime sDate;
        int xValue = 30;

        public ChartTestForm()
        {
            InitializeComponent();
            InitializeChart(chart1);
            InitializeChart2(chart2);
        }
        private void InitializeChart2(Chart chart)
        {
            //初始化XY轴-设置时间格式X坐标
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss"; //X轴显示的时间格式，HH为大写时是24小时制，hh小写时是12小时制
            chart.ChartAreas[0].AxisX.Minimum = DateTime.Parse(sDate.ToString("HH:mm:ss")).ToOADate();
            chart.ChartAreas[0].AxisX.Maximum = DateTime.Parse(sDate.AddSeconds(xValue).ToString("HH:mm:ss")).ToOADate();
            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;//如果是时间类型的数据，间隔方式可以是秒、分、时
            chart.ChartAreas[0].AxisX.Interval = DateTime.Parse("00:05:00").Millisecond;//间隔为5分钟

            //Series绘制
            chart.Series[0].LegendText = "瞬时速度";
            chart.Series[0].ChartType = SeriesChartType.Line;
            chart.Series[0].XValueType = ChartValueType.DateTime;
            chart.Series[0].IsValueShownAsLabel = true;//显示数据点的值       
            chart.Series[0].MarkerSize = 4;
            chart.Series[0].MarkerStyle = MarkerStyle.Circle;
            chart.Series[0].Points.AddXY(60, 60);
        }
        private void InitializeChart(Chart chart) {
            //初始化Title
            Title title = new Title();
            title.Text = "我是title";
            chart.Titles.Add(title);

            //初始化颜色
            chart.BackColor = Color.Gainsboro;
            chart.ChartAreas[0].BackColor = Color.DarkGray;
            chart.BorderlineColor = Color.Black;

            //初始化XY轴
            chart.ChartAreas[0].AxisX.Minimum = 0D;
            chart.ChartAreas[0].AxisX.Maximum = 100D;
            chart.ChartAreas[0].AxisX.Interval = 10D;

            chart.ChartAreas[0].AxisY.Minimum = 0D;
            chart.ChartAreas[0].AxisY.Maximum = 100D;

            //初始化副XY轴
            chart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chart.ChartAreas[0].AxisY2.Interval = 20D;
            chart.ChartAreas[0].AxisY2.Maximum = 200D;
            chart.ChartAreas[0].AxisY2.Minimum = 0D;

            //初始化series
            Series series = new Series
            {
                YAxisType = AxisType.Secondary,//数据点依赖辅助Y坐标
                ChartArea = "ChartArea1",
                ChartType = SeriesChartType.Line,
                Legend = "Legend1",
                LegendText = "Q2",
                Name = "Series2",
                BorderWidth = 1,
                MarkerSize = 4,
                MarkerStyle = MarkerStyle.Circle,
                ToolTip = "\"#VALX,#VALY\""
            };
            chart.Series.Add(series);

            //初始化legend
            Legend legend = chart.Legends[0];
            legend.DockedToChartArea = "ChartArea1";
            legend.Name = "Legend1";

            //添加假数据
            chart.Series[0].Points.Clear();
            chart.Series[0].Points.AddXY(10, 10);
            chart.Series[1].Points.Clear();
            chart.Series[1].Points.AddXY(20, 10);
        }

        //模拟数据
        private double testChartData()
        {
            //对curValue只取[0,360]之间的值
            curValue = curValue % 360;
            //对得到的正玄值，放大50倍，并上移50
            double value = (50 * Math.Sin(curValue * Math.PI / 180)) + 50;
            curValue = curValue + 10;
            return value;
        }

    }
}
