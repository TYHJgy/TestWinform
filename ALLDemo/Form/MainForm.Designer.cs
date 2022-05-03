namespace ALLDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DataGridView_Test = new System.Windows.Forms.Button();
            this.TabControl_Test = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.DataGridView_Test);
            this.flowLayoutPanel1.Controls.Add(this.TabControl_Test);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Controls.Add(this.button5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1117, 575);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // DataGridView_Test
            // 
            this.DataGridView_Test.AutoSize = true;
            this.DataGridView_Test.Location = new System.Drawing.Point(3, 3);
            this.DataGridView_Test.Name = "DataGridView_Test";
            this.DataGridView_Test.Size = new System.Drawing.Size(180, 40);
            this.DataGridView_Test.TabIndex = 0;
            this.DataGridView_Test.Text = "DataGridView_Test";
            this.DataGridView_Test.UseVisualStyleBackColor = true;
            this.DataGridView_Test.Click += new System.EventHandler(this.DataGridView_Test_Click);
            // 
            // TabControl_Test
            // 
            this.TabControl_Test.AutoSize = true;
            this.TabControl_Test.Location = new System.Drawing.Point(189, 3);
            this.TabControl_Test.Name = "TabControl_Test";
            this.TabControl_Test.Size = new System.Drawing.Size(180, 40);
            this.TabControl_Test.TabIndex = 0;
            this.TabControl_Test.Text = "TabControl_Test";
            this.TabControl_Test.UseVisualStyleBackColor = true;
            this.TabControl_Test.Click += new System.EventHandler(this.TabControl_Test_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Serial_test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(561, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Socket_test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(747, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "chart_test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(933, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 40);
            this.button4.TabIndex = 4;
            this.button4.Text = "date_test";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 49);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(180, 40);
            this.button5.TabIndex = 5;
            this.button5.Text = "file_test";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 575);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button DataGridView_Test;
        private System.Windows.Forms.Button TabControl_Test;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}