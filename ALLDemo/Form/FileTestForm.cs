using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALLDemo
{
    public partial class FileTestForm : Form
    {
        public FileTestForm()
        {
            InitializeComponent();
        }

        //创建文件
        private void button1_Click(object sender, EventArgs e)
        {
            FileStream F = new FileStream("log\\test.txt",FileMode.OpenOrCreate, FileAccess.ReadWrite);

            for (int i = 1; i <= 20; i++)
            {
                F.WriteByte((byte)i);
            }

            F.Position = 0;

            for (int i = 0; i <= 20; i++)
            {
                Console.Write(F.ReadByte() + " ");
            }
            F.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = ReadTxtLine("log\\test1.txt");
        }
        //读取txt文件内容
        private string ReadTxtLine(string file) {
            try
            {
                // 创建一个 StreamReader 的实例来读取文件 
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    string lines = "";

                    // 从文件读取并显示行，直到文件的末尾 
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        lines = lines + line + "\r\n";
                    }
                    return lines;
                }
            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                MessageBox.Show(e.Message,"提示");
                return null;
            }
        }
        //写入txt文件内容
        private void WriteTxtLine(string file)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine(textBox1.Text);
                    sw.Flush();
                    sw.Close();

                }
            }
            catch(Exception e) {
                MessageBox.Show(e.Message,"异常");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            WriteTxtLine("log\\test1.txt");
        }

        //创建目录
        private void button4_Click(object sender, EventArgs e)
        {
            //jin
            string sPath = @"D:\study\project\winform\TestWinform\ALLDemo\bin\Debug\log";
            if (Directory.Exists(sPath))
            {
                MessageBox.Show("目录："+sPath+"已存在","提示");
            }
            else
            {
                Directory.CreateDirectory(sPath);//创建路径
                MessageBox.Show("目录：" + sPath + "创建成功", "提示");
            }
        }

        //日志文件
        /// <summary>
        /// 每日新建一个日志文件，解决c#读写LOG文件提示被其他进程占用问题
        /// </summary>
        private object o = new object();
        private string pathStr = @"D:\study\project\winform\TestWinform\ALLDemo\bin\Debug\log";

        private void writeLog(string logType, string msgStr)
        {
            //输出日志
            bool showLog = true;
            //输出日志
            if (showLog)
            {
                CreateDirectory(pathStr);
                string logPath = pathStr + "\\log_" + logType + "_" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt";
                ThreadPool.QueueUserWorkItem(new WaitCallback(obj =>//线程池，在线程池有线程变得可用时执行
                {
                    lock (o)
                    {
                        using (var sw = new StreamWriter(logPath, true))
                        {
                            string dataStr = "【" + DateTime.Now.ToLongTimeString().ToString() + "】:";
                            dataStr += msgStr;
                            sw.WriteLine(dataStr);
                            sw.Flush();
                            sw.Close();
                        }
                    }
                }));
            }
        }

        private static void CreateDirectory(string path)
        {
            if (Directory.Exists(path) == false)//如果不存在就创建file文件夹
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        //记录日志
        private void button10_Click(object sender, EventArgs e)
        {
            writeLog("test",textBox1.Text);
        }

        //获取当前目录
        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = System.IO.Directory.GetCurrentDirectory();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            //string info;

            ////源码的源文件名
            //info = new StackTrace(new StackFrame(true)).GetFrame(0).GetFileName()+ "\r\n\r\n";
            ////源码的哪一行
            //info = info + new StackTrace(new StackFrame(true)).GetFrame(0).GetFileLineNumber().ToString() + "\r\n\r\n";
            ////源码的哪一个方法
            //info = info + new StackTrace(new StackFrame(true)).GetFrame(0).GetMethod() + "\r\n\r\n";
            ////源码的哪一个方法
            //info = info + new StackTrace(new StackFrame(true)).GetFrame(0).GetMethod().Name + "\r\n\r\n";
            ////所有信息
            //info = info + (new StackTrace(new StackFrame(true)).GetFrame(0));

            //textBox1.Text = info;
            test();
        }
        private void test() {
            string info;
            //StackTrace st = new StackTrace(new StackFrame(true));
            StackTrace st = new StackTrace(true);
            info = st.GetFrame(1).ToString()+ "\r\n\r\n";
            info = info + st.GetFrame(1).GetFileLineNumber().ToString();
            textBox2.Text = info;
        }
        //读取日志信息
        private void button9_Click(object sender, EventArgs e)
        {
            string logPath = pathStr + "\\log_" + "test" + "_" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt";
            textBox2.Text = ReadTxtLine(logPath);
        }
    }
}
