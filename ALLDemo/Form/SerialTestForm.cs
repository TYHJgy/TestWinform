using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALLDemo
{
    public partial class SerialTestForm : Form
    {
        private SerialPort ComDevice = new SerialPort();
        public SerialTestForm()
        {
            InitializeComponent();
            InitralConfig();
        }

        /// <summary>
        /// 配置初始化
        /// </summary>
        private void InitralConfig()
        {
            //查询主机上存在的串口
            comboBox_Port.Items.AddRange(SerialPort.GetPortNames());

            if (comboBox_Port.Items.Count > 0)
            {
                comboBox_Port.SelectedIndex = 0;
            }
            else
            {
                comboBox_Port.Text = "未检测到串口";
            }


            //向ComDevice.DataReceived（是一个事件）注册一个方法Com_DataReceived，当端口类接收到信息时时会自动调用Com_DataReceived方法
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
        }
        /// <summary>
        /// 一旦ComDevice.DataReceived事件发生，就将从串口接收到的数据显示到接收端对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("enter Com_DataReceived");
            //开辟接收缓冲区
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            //从串口读取数据
            ComDevice.Read(ReDatas, 0, ReDatas.Length);
            //实现数据的解码与显示
            AddData(ReDatas);
        }
        /// <summary>
        /// 解码过程
        /// </summary>
        /// <param name="data">串口通信的数据编码方式因串口而异，需要查询串口相关信息以获取</param>
        public void AddData(byte[] data)
        {
            AddContent(new UnicodeEncoding().GetString(data));
        }
        /// <summary>
        /// 接收端对话框显示消息
        /// </summary>
        /// <param name="content"></param>
        private void AddContent(string content)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                textBox_Receive.AppendText(content);
            }));
        }

        /// <summary>
        /// 串口开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Switch_Click(object sender, EventArgs e)
        {
            if (comboBox_Port.Items.Count <= 0)
            {
                MessageBox.Show("未发现可用串口，请检查硬件设备");
                return;
            }

            if (ComDevice.IsOpen == false)
            {
                //设置串口相关属性
                ComDevice.PortName = comboBox_Port.SelectedItem.ToString();
                try
                {
                    //开启串口
                    ComDevice.Open();
                    MessageBox.Show( "成功开启串口");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "未能成功开启串口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                try
                {
                    //关闭串口
                    ComDevice.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "串口关闭错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            comboBox_Port.Enabled = !ComDevice.IsOpen;
        }

        /// <summary>
        /// 将消息编码并发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Send_Click(object sender, EventArgs e)
        {
            if (textBox_Receive.Text.Length > 0)
            {
                textBox_Receive.AppendText("\n");
            }

            byte[] sendData = null;
            Console.WriteLine(textBox_Send.Text.Trim());
            sendData = Encoding.Unicode.GetBytes(textBox_Send.Text.Trim());
            SendData(sendData);
        }

        /// <summary>
        /// 此函数将编码后的消息传递给串口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SendData(byte[] data)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    //将消息传递给串口
                    ComDevice.Write(data, 0, data.Length);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("串口未开启", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


    }
}
