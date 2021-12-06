namespace ALLDemo
{
    partial class TabPageDemoForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.shapeButton2 = new ALLDemo.CustomControl.ShapeButton();
            this.circleButton1 = new ALLDemo.CircleButton();
            this.shapeButton1 = new ALLDemo.CustomControl.ShapeButton();
            this.shapeButton3 = new ALLDemo.CustomControl.ShapeButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(30, 100);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 508);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.shapeButton3);
            this.tabPage1.Controls.Add(this.shapeButton1);
            this.tabPage1.Controls.Add(this.shapeButton2);
            this.tabPage1.Controls.Add(this.circleButton1);
            this.tabPage1.Location = new System.Drawing.Point(104, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(104, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 500);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // shapeButton2
            // 
            this.shapeButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.shapeButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shapeButton2.CustomClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.shapeButton2.CustomClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.shapeButton2.CustomDefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.shapeButton2.CustomDefaultTextColor = System.Drawing.Color.Cyan;
            this.shapeButton2.CustomDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.shapeButton2.CustomDisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.shapeButton2.Fillet = 20;
            this.shapeButton2.FlatAppearance.BorderSize = 0;
            this.shapeButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.shapeButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.shapeButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shapeButton2.Location = new System.Drawing.Point(393, 48);
            this.shapeButton2.Name = "shapeButton2";
            this.shapeButton2.Size = new System.Drawing.Size(97, 58);
            this.shapeButton2.TabIndex = 2;
            this.shapeButton2.Text = "shapeButton2";
            this.shapeButton2.UseVisualStyleBackColor = false;
            // 
            // circleButton1
            // 
            this.circleButton1.BackColor = System.Drawing.Color.Red;
            this.circleButton1.Location = new System.Drawing.Point(255, 250);
            this.circleButton1.Name = "circleButton1";
            this.circleButton1.Size = new System.Drawing.Size(75, 70);
            this.circleButton1.TabIndex = 0;
            this.circleButton1.Text = "0";
            this.circleButton1.UseVisualStyleBackColor = false;
            // 
            // shapeButton1
            // 
            this.shapeButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.shapeButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shapeButton1.CustomClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.shapeButton1.CustomClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.shapeButton1.CustomDefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.shapeButton1.CustomDefaultTextColor = System.Drawing.Color.Cyan;
            this.shapeButton1.CustomDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.shapeButton1.CustomDisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.shapeButton1.Fillet = 60;
            this.shapeButton1.FlatAppearance.BorderSize = 0;
            this.shapeButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.shapeButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.shapeButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shapeButton1.Location = new System.Drawing.Point(393, 220);
            this.shapeButton1.Name = "shapeButton1";
            this.shapeButton1.Size = new System.Drawing.Size(97, 58);
            this.shapeButton1.TabIndex = 2;
            this.shapeButton1.Text = "shapeButton2";
            this.shapeButton1.UseVisualStyleBackColor = false;
            // 
            // shapeButton3
            // 
            this.shapeButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.shapeButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shapeButton3.CustomClickColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.shapeButton3.CustomClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.shapeButton3.CustomDefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.shapeButton3.CustomDefaultTextColor = System.Drawing.Color.Cyan;
            this.shapeButton3.CustomDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.shapeButton3.CustomDisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.shapeButton3.Fillet = 40;
            this.shapeButton3.FlatAppearance.BorderSize = 0;
            this.shapeButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.shapeButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.shapeButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shapeButton3.Location = new System.Drawing.Point(393, 137);
            this.shapeButton3.Name = "shapeButton3";
            this.shapeButton3.Size = new System.Drawing.Size(97, 58);
            this.shapeButton3.TabIndex = 2;
            this.shapeButton3.Text = "shapeButton2";
            this.shapeButton3.UseVisualStyleBackColor = false;
            // 
            // TabPageDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.tabControl1);
            this.Name = "TabPageDemoForm";
            this.Text = "TabPageDemoForm";
            this.Load += new System.EventHandler(this.TabPageDemoForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private CircleButton circleButton1;
        private CustomControl.ShapeButton shapeButton2;
        private CustomControl.ShapeButton shapeButton3;
        private CustomControl.ShapeButton shapeButton1;
    }
}

