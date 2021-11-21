using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MysqlOperation
{
    public partial class Form1 : Form
    {
        private MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            ConnectMysql();
        }


        //连接mysql
        private void ConnectMysql() {

            /** server = 127.0.0.1或者localhost 代表本机地址; port = 3306 端口号; **/
            /** user 用户名; password 密码; database 数据库名称; **/
            string connstr = "server = 127.0.0.1; port = 3306; user = root ; password = 123456; " +
                "database = db_example";
            this.conn = new MySqlConnection(connstr);

            try
            {
                //可能出现异常
                conn.Open();
                MessageBox.Show("链接成功!");
            }
            catch (MySqlException ex)
            {
                //异常则提示异常信息
                MessageBox.Show(ex.Message);
            }
        }

        //查询
        private void queryMysql() {
            string sql = "select * from student;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
            while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
            {
                //Console.WriteLine(reader[0].ToString() + reader[1].ToString() + reader[2].ToString());
                //Console.WriteLine(reader.GetInt32(0)+reader.GetString(1)+reader.GetString(2));
                Console.WriteLine(reader.GetInt32("_num") + reader.GetString("_name"));//"userid"是数据库对应的列名，推荐这种方式
            }
            reader.Close();
        }
        private void queryMysql2()
        {
            //string sql = "select * from user where username='"+username+"' and password='"+password+"'"; //我们自己按照查询条件去组拼
            string sql = "select * from student where _num=@para1";//在sql语句中定义parameter，然后再给parameter赋值
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("para1",1);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())//如果用户名和密码正确则能查询到一条语句，即读取下一行返回true
            {
                Console.WriteLine(reader.GetInt32("_num") + reader.GetString("_name"));//"userid"是数据库对应的列名，推荐这种方式
            }
        }



        private void insertData() {
            string sql = "insert into student(_name,_year) values('gygygy',12)";
            //string sql = "delete from user where userid='9'";
            //string sql = "update user set username='啊哈',password='123' where userid='8'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();//3.执行插入、删除、更改语句。执行成功返回受影响的数据的行数，返回1可做true判断。执行失败不返回任何数据，报错，下面代码都不执行

        }
        private void select_Click(object sender, EventArgs e)
        {
            queryMysql();
            queryMysql2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertData();
        }
    }
}
