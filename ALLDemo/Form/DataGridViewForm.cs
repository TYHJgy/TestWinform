using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALLDemo
{
    public partial class DataGridViewForm : Form
    {
        public DataGridViewForm()
        {
            InitializeComponent();
            insertRecord(dataGridView2);
            getdataGridViewInfo(dataGridView2);
            getdataGridViewInfo(dataGridView3);
        }

        private void DataGridViewForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“db_exampleDataSet.student”中。您可以根据需要移动或删除它。
            this.studentTableAdapter.Fill(this.db_exampleDataSet.student);

        }

        //添加数据到dataGridView
        private void insertRecord(DataGridView dataGridView)
        {
            int columns = 5;
            int rows = 3;
            DataTable dt = new DataTable();
            //添加列
            dt.Columns.Clear();
            for (int i = 1; i <= columns; i++)
            {
                dt.Columns.Add("第" + i + "列");
            }

            //添加行数据
            dt.Rows.Clear();
            for (int i = 0; i < rows; i++)
            {
                DataRow row = dt.NewRow();
                for (int j = 0; j < columns; j++)
                {
                    row[j] = j;
                }
                dt.Rows.Add(row);
            }

            dataGridView.DataSource = dt;
        }
        //读dataGridView的信息
        private void getdataGridViewInfo(DataGridView dataGridView)
        {
            Console.WriteLine(dataGridView.ColumnCount);
            Console.WriteLine(dataGridView.Columns);
            Console.WriteLine(dataGridView.Rows);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
