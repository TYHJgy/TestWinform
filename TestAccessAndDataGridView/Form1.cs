using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//注释：     先ctrl+k，然后ctrl+c
//取消注释： 先ctrl+k，然后ctrl+u

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string strCon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=shop.accdb";
        //private string strCon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\02Development\winform\TestWinform\shop.accdb";
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("exe文件路径:"+Process.GetCurrentProcess().MainModule.FileName);
            Console.WriteLine("项目路径:" + Directory.GetCurrentDirectory());
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            string name,prince,date,adress;
            OleDbConnection conn = new OleDbConnection(strCon); //Jet OLEDB:Database Password=
            OleDbCommand cmd = conn.CreateCommand();
            if (nameCheck.Checked)
                name = comboBox1.Text;
            else
                name = "";
            if (princeCheck.Checked)          
                prince = numericUpDown1.Value.ToString();          
            else
                prince = "-1";
            if (dateCheck.Checked)
                date = dateTimePicker1.CustomFormat;
            else
                date = "2000-01-01";
            if (adressCheck.Checked)
                adress = textBox1.Text;
            else
                adress = "";
            //String sql = "select * from shop";
            String sql = $"select * from shop where (`name`='{name}' or '{name}'='')" +
                $"and (`prince`={prince} or '{prince}'='-1') " +            //{prince}不能加单引号，例如(`prince`='{prince}' or '{prince}'='0')
                $"and (`date`={date} or '{date}'='2000-01-01') " +          //{date}不能加单引号，例如(`date`='{date}' or '{date}'='2000-01-01')
                $"and (`adress`='{adress}' or '{adress}'='');";

            Console.WriteLine(sql);
            cmd.CommandText = sql;
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (dr.HasRows)
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    dt.Columns.Add(dr.GetName(i));
                }
                dt.Rows.Clear();
            }
            while (dr.Read())
            {
                DataRow row = dt.NewRow();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row[i] = dr[i];
                }
                dt.Rows.Add(row);
            }
            cmd.Dispose();
            conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(strCon); //Jet OLEDB:Database Password=
            OleDbCommand cmd; 
            conn.Open();
            
            cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO shop (`name`,`prince`,`date`,`adress`) VALUES ('mz1','21','2018-09-01','成都市青羊区');";
            cmd.ExecuteReader();
            cmd.Dispose();

            cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO shop (`name`,`prince`,`date`,`adress`) VALUES ('mz2','22','2018-09-02','成都市青羊区');";
            cmd.ExecuteReader();
            cmd.Dispose();

            cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO shop (`name`,`prince`,`date`,`adress`) VALUES ('mz3','23','2018-09-03','成都市青羊区');";
            cmd.ExecuteReader();
            cmd.Dispose();

            cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO shop (`name`,`prince`,`date`,`adress`) VALUES ('mz4','24','2018-09-04','成都市青羊区');";
            cmd.ExecuteReader();
            cmd.Dispose();

            cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO shop (`name`,`prince`,`date`,`adress`) VALUES ('mz5','25','2018-09-05','成都市青羊区');";
            cmd.ExecuteReader();
            cmd.Dispose();

            conn.Close();
            btnSelect_Click(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(strCon); //Jet OLEDB:Database Password=
            OleDbCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "DELETE FROM `shop` WHERE `adress`='成都市青羊区';";
            cmd.ExecuteReader();
            cmd.Dispose();
            conn.Close();
            btnSelect_Click(null, null);
        }

        
        private void butUpdate_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(strCon); //Jet OLEDB:Database Password=
            OleDbCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = "UPDATE `shop` SET `name`='gy' WHERE  `name`='bg';";
            cmd.ExecuteReader();
            cmd.Dispose();
            conn.Close();
            btnSelect_Click(null, null);
        }
    }
}
