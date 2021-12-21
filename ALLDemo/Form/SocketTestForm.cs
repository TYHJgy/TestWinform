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
                try
                {
                    this.Invoke(new Action(() =>
                    {
                        textBox5.Text = "开始监听";
                    }));

                    //监听
                    Socket ClientSocket = serverSocket.Accept();
                    byte[] buffer = Encoding.Default.GetBytes("成功连接到服务器！");
                    //发送数据
                    ClientSocket.Send(buffer);
                }
                catch (Exception ex)
                {
                    listenThread.Abort(ex.Message);
                }
            }
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
    }
}
