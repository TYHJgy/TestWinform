using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

//注释：     先ctrl+k，然后ctrl+c
//取消注释： 先ctrl+k，然后ctrl+u
/* 
 .NET版本必须使用.NETFramework,Version=v4.0,Profile=Client，否则会报错：未在本地计算机上注册“microsoft.ACE.oledb.12.0”提供程序
*/

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //private string strCon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=shop.accdb";
        private string strCon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\study\workspace\winform\TestWinform\shop.accdb;Jet OLEDB:Database Password=123456;";
        //private string strCon = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\study\workspace\winform\TestWinform\TestAccessAndDataGridView\LMS2.mdb;Jet OLEDB:Database Password=abc123;";
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("exe文件路径:"+Process.GetCurrentProcess().MainModule.FileName);
            Console.WriteLine("项目路径:" + Directory.GetCurrentDirectory());
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(strCon); //Jet OLEDB:Database Password=
            OleDbCommand cmd = conn.CreateCommand();
            string name, prince, date, adress;
            if (nameCheck.Checked)
                name = comboBox1.Text;
            else
                name = "";
            if (princeCheck.Checked)          
                prince = numericUpDown1.Value.ToString();          
            else
                prince = "-1";
            if (dateCheck.Checked)
            {
                date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            }
            else
                date = "0000-01-01";
            if (adressCheck.Checked)
                adress = textBox1.Text;
            else
                adress = "";
            //String sql = "select * from shop";
            String sql = $"select * from shop where (`name`='{name}' or '{name}'='')" +
                $"and (`prince`={prince} or '{prince}'='-1') " +            //{prince}不能加单引号，例如(`prince`='{prince}' or '{prince}'='0')
                $"and (`date`<#{date}# or '{date}'='0000-01-01') " +         
                $"and (`adress`='{adress}' or '{adress}'='');";
            
            Console.WriteLine("sql语句:"+sql);
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
            string name, prince, date, adress;
            OleDbConnection conn = new OleDbConnection(strCon); //Jet OLEDB:Database Password=
            OleDbCommand cmd; 
            conn.Open();
            if (nameCheck.Checked)
                name = comboBox1.Text;
            else
                name = "mz1";
            if (princeCheck.Checked)
                prince = numericUpDown1.Value.ToString();
            else
                prince = "21";
            if (dateCheck.Checked)
            {
                date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            }
            else
                date = "2018-01-01";
            if (adressCheck.Checked)
                adress = textBox1.Text;
            else
                adress = "成都市青羊区";
            String sql = $"INSERT INTO shop (`name`,`prince`,`date`,`adress`) VALUES ('{name}','{prince}','{date}','{adress}');";

            cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteReader();
            cmd.Dispose();
            conn.Close();
            btnSelect_Click(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(strCon); //Jet OLEDB:Database Password=
            OleDbCommand cmd = conn.CreateCommand();
            string name, prince, date, adress;
            if (nameCheck.Checked)
                name = comboBox1.Text;
            else
                name = "";
            if (princeCheck.Checked)
                prince = numericUpDown1.Value.ToString();
            else
                prince = "-1";
            if (dateCheck.Checked)
            {
                date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            }
            else
                date = "0000-01-01";
            if (adressCheck.Checked)
                adress = textBox1.Text;
            else
                adress = "";
            //String sql = "select * from shop";
            String sql = $"DELETE * from shop where (`name`='{name}' or '{name}'='')" +
                $"and (`prince`={prince} or '{prince}'='-1') " +            //{prince}不能加单引号，例如(`prince`='{prince}' or '{prince}'='0')
                $"and (`date`=#{date}# or '{date}'='0000-01-01') " +
                $"and (`adress`='{adress}' or '{adress}'='');";


            conn.Open();
            cmd.CommandText = sql;
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
        public void OutputAsExcelFile(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("无数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            string filePath = "";
            SaveFileDialog s = new SaveFileDialog
            {
                Title = "保存Excel文件",
                Filter = "Excel文件(*..xlsx)|*.xlsx",
                FilterIndex = 1
            };
            if (s.ShowDialog() == DialogResult.OK)
                filePath = s.FileName;
            else
                return;

            ////第一步：将dataGridView转化为dataTable,这样可以过滤掉dataGridView中的隐藏列  

            DataTable tmpDataTable = new DataTable("tmpDataTable");
            DataTable modelTable = new DataTable("ModelTable");
            for (int column = 0; column < dataGridView.Columns.Count; column++)
            {
                if (dataGridView.Columns[column].Visible == true)
                {
                    DataColumn tempColumn = new DataColumn(dataGridView.Columns[column].HeaderText, typeof(string));
                    tmpDataTable.Columns.Add(tempColumn);
                    DataColumn modelColumn = new DataColumn(dataGridView.Columns[column].Name, typeof(string));
                    modelTable.Columns.Add(modelColumn);
                }
            }
            for (int row = 0; row < dataGridView.Rows.Count; row++)
            {
                if (dataGridView.Rows[row].Visible == false)
                    continue;
                DataRow tempRow = tmpDataTable.NewRow();
                for (int i = 0; i < tmpDataTable.Columns.Count; i++)
                    tempRow[i] = dataGridView.Rows[row].Cells[modelTable.Columns[i].ColumnName].Value;
                tmpDataTable.Rows.Add(tempRow);
            }
            if (tmpDataTable == null)
            {
                return;
            }

            //第二步：导出dataTable到Excel  
            long rowNum = tmpDataTable.Rows.Count;//行数  
            int columnNum = tmpDataTable.Columns.Count;//列数  
            Excel.Application m_xlApp = new Excel.Application
            {
                DisplayAlerts = false,//不显示更改提示  
                Visible = true
            };
            

            Excel.Workbooks workbooks = m_xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

            try
            {
                string[,] datas = new string[rowNum + 1, columnNum];
                for (int i = 0; i < columnNum; i++) //写入字段  
                    datas[0, i] = tmpDataTable.Columns[i].Caption;
                //Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, columnNum]);  
                Excel.Range range = m_xlApp.Range[worksheet.Cells[1, 1], worksheet.Cells[1, columnNum]];
                range.Interior.ColorIndex = 15;//15代表灰色  
                range.Font.Bold = true;
                range.Font.Size = 10;

                int r = 0;
                for (r = 0; r < rowNum; r++)
                {
                    for (int i = 0; i < columnNum; i++)
                    {
                        object obj = tmpDataTable.Rows[r][tmpDataTable.Columns[i].ToString()];
                        datas[r + 1, i] = obj == null ? "" : "'" + obj.ToString().Trim();//在obj.ToString()前加单引号是为了防止自动转化格式  
                    }
                    System.Windows.Forms.Application.DoEvents();
                    //添加进度条  
                }
                //Excel.Range fchR = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rowNum + 1, columnNum]);  
                Excel.Range fchR = m_xlApp.Range[worksheet.Cells[1, 1], worksheet.Cells[rowNum + 1, columnNum]];
                fchR.Value2 = datas;

                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。  
                                                         //worksheet.Name = "dd";  

                //m_xlApp.WindowState = Excel.XlWindowState.xlMaximized;  
                m_xlApp.Visible = false;

                // = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rowNum + 1, columnNum]);  
                range = m_xlApp.Range[worksheet.Cells[1, 1], worksheet.Cells[rowNum + 1, columnNum]];

                //range.Interior.ColorIndex = 15;//15代表灰色  
                range.Font.Size = 9;
                range.RowHeight = 14.25;
                range.Borders.LineStyle = 1;
                range.HorizontalAlignment = 1;
                workbook.Saved = true;
                workbook.SaveCopyAs(filePath);
                workbook.Close(true, Missing.Value, Missing.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出异常：" + ex.Message, "导出异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                //EndReport();
            }

            m_xlApp.Workbooks.Close();
            m_xlApp.Workbooks.Application.Quit();
            m_xlApp.Application.Quit();
            m_xlApp.Quit();
            MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ToExcel(DataGridView dataGridView1)
        {
            try
            {
                //没有数据的话就不往下执行  
                if (dataGridView1.Rows.Count == 0)
                    return;
                //实例化一个Excel.Application对象  
                Excel.Application excel = new Excel.Application();

                //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写  
                excel.Visible = true;

                //新增加一个工作簿，Workbook是直接保存，不会弹出保存对话框，加上Application会弹出保存对话框，值为false会报错  
                excel.Workbooks.Add();
                //生成Excel中列头名称  
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (this.dataGridView1.Columns[i].Visible == true)
                    {
                        excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                    }

                }
                //把DataGridView当前页的数据保存在Excel中  
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Application.DoEvents();
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (this.dataGridView1.Columns[j].Visible == true)
                        {
                            if (dataGridView1[j, i].ValueType == typeof(string))
                            {
                                excel.Cells[i + 2, j + 1] = "'" + dataGridView1[j, i].Value.ToString();
                            }
                            else
                            {
                                excel.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                            }
                        }

                    }
                }

                //设置禁止弹出保存和覆盖的询问提示框  
                excel.DisplayAlerts = false;
                excel.AlertBeforeOverwriting = false;

                //保存工作簿  
                //excel.Application.Workbooks.Add(true).Save();
                //保存excel文件  
                //excel.Save(@"E:\02Development\winform\TestWinform\" + "KKHMD.xlsx");

                //确保Excel进程关闭  
                excel.Quit();
                excel = null;
                GC.Collect();//如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出
                MessageBox.Show(this, "文件已经成功导出！", "信息提示");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示");
            }

        }
        private void export_Click(object sender, EventArgs e)
        {
            OutputAsExcelFile(dataGridView1);
            //ToExcel(dataGridView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
