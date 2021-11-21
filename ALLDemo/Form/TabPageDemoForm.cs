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
    public partial class TabPageDemoForm : Form
    {
        public TabPageDemoForm()
        {
            InitializeComponent();
            TabSet();
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
        }

        private void TabPageDemoForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 设定控件绘制模式
        /// </summary>
        private void TabSet()
        {
            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Alignment = TabAlignment.Left;
            this.tabControl1.SizeMode = TabSizeMode.Fixed;
            this.tabControl1.Multiline = true;
            this.tabControl1.ItemSize = new Size(50, 210);
        }

        /// <summary>
        /// 重绘控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = ((TabControl)sender).TabPages[e.Index].Text;
            SolidBrush brush = new SolidBrush(Color.Black);
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(text, SystemInformation.MenuFont, brush, e.Bounds, sf);
        }
    }
}
