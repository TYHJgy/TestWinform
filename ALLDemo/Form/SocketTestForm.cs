using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALLDemo
{
    public partial class SocketTestForm : Form
    {
        //创建用来专门作为监听来电等待工作的线程
        Thread listenThread = null;
        Thread clientThread = null;
        Socket clientSocket = null;
        Socket serverSocket = null;
        public SocketTestForm()
        {
            InitializeComponent();
        }
        //连接socket。监听
        private void button1_Click(object sender, EventArgs e)
        {
            //创建socket
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //配置地址和端口
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(textBox1.Text),int.Parse(textBox2.Text));
            //绑定
            s.Bind(ipe);
            //监听
            s.Listen(10); //参数为最大监听的用户数
            //创建线程
            serverSocket = s;
            listenThread = new Thread(ListenConnectSocket);
            listenThread.IsBackground = true; //关闭后天线程
            listenThread.Start();

        }
        //3.4 监听用户来电 等待
        void ListenConnectSocket()
        {
            while (true)
            {
                //监听
                Socket ClientSocket = serverSocket.Accept();
                byte[] buffer = Encoding.Default.GetBytes("成功连接到服务器！");
                ClientSocket.Send(buffer);
                Thread.Sleep(1000);
                this.Invoke(new Action(() =>
                {
                    textBox5.Text = "开始监听";
                }));
                try
                {
                    //发送数据
                    while (true)
                    {
                        byte[] buffer1 = genSMVdata();
                        //byte[] buffer1 = Encoding.Default.GetBytes("我是服务端循环发送！");
                        ClientSocket.Send(buffer1);
                        Thread.Sleep(2000);
                        Console.WriteLine(ClientSocket);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("出现异常");
                    //listenThread.Abort(ex.Message);
                }
            }
        }
        //生成SMV模拟数据
        private byte[] genSMVdata() {
            Random rd = new Random();
            byte[] buffer1 = new byte[38];
            buffer1[0] = 0xAA;//帧头
            buffer1[1] = 0x55;//帧头            
            buffer1[2] = 0x26;//帧长度
            buffer1[3] = 0x56;//识别码
            buffer1[4] = 0xFF;//发送帧计数，帧计数值M，从255~1，循环递减计数。
            buffer1[5] = 0x00;//接收帧计数，SMV收到上位机CAN的帧计数值，回传，未收到时为0；
            buffer1[6] = 0xAA;//控制命令回传，接收到上位机的CAN总线对应值
            buffer1[7] = 0xAA;//回传，接收到上位机的CAN总线对应值
            buffer1[8] = 0x01;//仅当开环为时间值时，返回已执行时间值（1~99秒）；

            buffer1[9] = (byte)rd.Next(1, 255); //备用
            buffer1[10] = (byte)rd.Next(1, 20);//电机转速高8位
            buffer1[11] = (byte)rd.Next(1, 255);//电机转速低8位

            buffer1[12] = (byte)rd.Next(1, 255); //母线电压UM
            buffer1[13] = (byte)rd.Next(1, 255); //电压输入1 阀前压力 PF  
            buffer1[14] = (byte)rd.Next(1, 255);//电流输入1 阀前流量 QF
            buffer1[15] = (byte)rd.Next(1, 255);//电阻输入1 阀前温度 RF
            buffer1[16] = (byte)rd.Next(1, 255);//母线电流C
            buffer1[17] = (byte)rd.Next(1, 255);//电压输入2 阀后压力 P 
            buffer1[18] = (byte)rd.Next(1, 255);//电流输入2 阀后流量 Q 
            buffer1[19] = (byte)rd.Next(1, 255);//电阻输入2 阀后温度 R

            buffer1[20] = (byte)rd.Next(1, 255);//A相电流CA 
            buffer1[21] = (byte)rd.Next(1, 255);//B相电流CB 
            buffer1[22] = (byte)rd.Next(1, 255);//C相电流CC 
            buffer1[23] = (byte)rd.Next(1, 255);//15V电压UF 
            buffer1[24] = (byte)rd.Next(1, 255);//3.3V电压US  
            buffer1[25] = (byte)rd.Next(1, 255);//2V基准UR 
            buffer1[26] = (byte)rd.Next(1, 255);//阀板开度VR 
            buffer1[27] = (byte)rd.Next(1, 255);//绕组电阻MR 

            buffer1[28] = (byte)rd.Next(1, 255);//驱动状态SM
            buffer1[29] = (byte)rd.Next(1, 255);//电源状态 S
            buffer1[30] = (byte)rd.Next(1, 255);//传感器状态
            buffer1[31] = (byte)rd.Next(1, 255);//阀门状态
            buffer1[32] = (byte)rd.Next(1, 255);//驱动故障码
            buffer1[33] = (byte)rd.Next(1, 255);//电源故障
            buffer1[34] = (byte)rd.Next(1, 255);//传感器故障
            buffer1[35] = 0xFF;//备用
            buffer1[36] = 0xFF;//备用


            //异或
            byte temp = (byte)(buffer1[0] ^ buffer1[1]);            
            for (int i=2;i<buffer1.Length-1;i++)
            {
                temp ^= buffer1[i];
            }

            Console.WriteLine("取反前temp:" + Convert.ToString(temp,2).PadLeft(8, '0'));
            //取反
            temp = (byte)~temp;
            Console.WriteLine("取反后temp:" + Convert.ToString(temp, 2).PadLeft(8, '0'));
            buffer1[37] = temp;//校验码
            return buffer1;
        }

        //生成smv模拟数据-维护模式
        private byte[] genSMVdata2()
        {
            Random rd = new Random();
            byte[] buffer1 = new byte[44];
            buffer1[0] = 0xAA;//帧头
            buffer1[1] = 0x55;//帧头            
            buffer1[2] = 0x56;//识别码
            buffer1[3] = 0xFF;//发送帧计数，帧计数值M，从255~1，循环递减计数。
            buffer1[4] = 0x00;//接收帧计数，SMV收到上位机CAN的帧计数值，回传，未收到时为0；
            buffer1[5] = 0xFD;//控制命令

            buffer1[6] = (byte)rd.Next(250, 256); ;//完成块操作前回传FLASH块地址，完成块操作后，变为 0XFF；
            buffer1[7] = 0;//每块下面 64*1kWord 帧完成状态值，完成前0x39，完成后为 0；
            buffer1[8] = 0;//为 FLASH 内的帧顺序号低8位【组合最大计数 4096 帧（每帧 16 个 Word）；】
            buffer1[9] = 0;//为 FLASH 内的帧顺序号高8位【组合最大计数 4096 帧（每帧 16 个 Word）；】
            buffer1[10] = 0x39;//备用
            buffer1[11] = 0x39;//备用
            /*
             * AF0~AF2 时间轴低/中/高 8 位，组合后循环递增计数
             * 最大计数 224个值（实际使用 0~409600），也就是帧最大值
             */
            buffer1[12] = 0x39;
            buffer1[13] = 0x39;
            buffer1[14] = 0x39;
            buffer1[15] = 0x39;//固定值


            buffer1[16] = 0x26;//帧长度
            buffer1[17] = 0x56;//识别码
            buffer1[18] = 0xFF;//发送帧计数，帧计数值M，从255~1，循环递减计数。
            buffer1[19] = 0x00;//接收帧计数，SMV收到上位机CAN的帧计数值，回传，未收到时为0；
            buffer1[20] = 0xAA;//控制命令回传，接收到上位机的CAN总线对应值
            buffer1[21] = 0xAA;//回传，接收到上位机的CAN总线对应值
            buffer1[22] = 0x01;//仅当开环为时间值时，返回已执行时间值（1~99秒）；
            buffer1[23] = (byte)rd.Next(1, 255); //备用
            buffer1[24] = (byte)rd.Next(1, 255);//电机转速高8位
            buffer1[25] = (byte)rd.Next(1, 255);//电机转速低8位
            buffer1[26] = (byte)rd.Next(1, 255); //母线电压UM
            buffer1[27] = (byte)rd.Next(1, 255); //电压输入1 阀前压力 PF  
            buffer1[28] = (byte)rd.Next(1, 255);//电流输入1 阀前流量 QF
            buffer1[29] = (byte)rd.Next(1, 255);//电阻输入1 阀前温度 RF
            buffer1[30] = (byte)rd.Next(1, 255);//母线电流C
            buffer1[31] = (byte)rd.Next(1, 255);//电压输入2 阀后压力 P 

            buffer1[32] = (byte)rd.Next(1, 255);//电流输入2 阀后流量 Q 
            buffer1[33] = (byte)rd.Next(1, 255);//电阻输入2 阀后温度 R

            buffer1[34] = (byte)rd.Next(1, 255);//A相电流CA 
            buffer1[35] = (byte)rd.Next(1, 255);//B相电流CB 
            buffer1[36] = (byte)rd.Next(1, 255);//C相电流CC 
            buffer1[37] = (byte)rd.Next(1, 255);//15V电压UF 
            buffer1[38] = (byte)rd.Next(1, 255);//3.3V电压US  
            buffer1[39] = (byte)rd.Next(1, 255);//2V基准UR 
            buffer1[40] = (byte)rd.Next(1, 255);//阀板开度VR 
            buffer1[41] = (byte)rd.Next(1, 255);//绕组电阻MR 

            buffer1[42] = 0x2C;//长度


            //异或
            byte temp = (byte)(buffer1[0] ^ buffer1[1]);
            for (int i = 2; i < buffer1.Length - 1; i++)
            {
                temp ^= buffer1[i];
            }

            Console.WriteLine("取反前temp:" + Convert.ToString(temp, 2).PadLeft(8, '0'));
            //取反
            temp = (byte)~temp;
            Console.WriteLine("取反后temp:" + Convert.ToString(temp, 2).PadLeft(8, '0'));
            buffer1[43] = temp;//校验码
            return buffer1;
        }
        public void connectSocket() {
            //创建socket
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //配置地址和端口
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(textBox3.Text), int.Parse(textBox4.Text));
            //连接
            try
            {
                s.Connect(ipe);
                clientSocket = s;
                //4.接收或发送消息 使用线程来实现
                clientThread = new Thread(ReceiveMsg);
                clientThread.IsBackground = true; //开启后台线程
                clientThread.Start();
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine("ArgumentNullException : {0}", ae.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }
        private void ReceiveMsg()
        {
            while (true)
            {
                byte[] recBuffer = new byte[1024 * 1024 * 2];//声明最大字符内存
                int length = -1; //字节长度
                try
                {
                    length = clientSocket.Receive(recBuffer);//返回接收到的实际的字节数量
                    //将byte转化为十六进制字符串
                    Console.WriteLine(string.Format("{0:X2} ", recBuffer[0]));
                }
                catch (SocketException ex)
                {
                    break;
                }
                catch (Exception ex)
                {
                    break;
                }
                //接收到消息
                if (length > 0)
                {
                    //按照
                    string msg = Encoding.Default.GetString(recBuffer, 0, length);//转译字符串(字符串，开始的索引，字符串长度)
                    string str = $"{DateTime.Now}【接收】{msg}{Environment.NewLine}";//接收的时间，内容，换行
                    this.Invoke(new Action(() =>
                    {
                        textBox6.AppendText(str);//添加到文本
                    }));
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            connectSocket();
        }

        //关闭窗口时关闭线程
        private void formClosed(object sender, FormClosedEventArgs e)
        {
            clientThread.Abort();
        }
    }
}
