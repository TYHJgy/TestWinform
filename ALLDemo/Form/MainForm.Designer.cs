﻿namespace ALLDemo
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
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.DataGridView_Test);
            this.flowLayoutPanel1.Controls.Add(this.TabControl_Test);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1015, 575);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // DataGridView_Test
            // 
            this.DataGridView_Test.AutoSize = true;
            this.DataGridView_Test.Location = new System.Drawing.Point(3, 3);
            this.DataGridView_Test.Name = "DataGridView_Test";
            this.DataGridView_Test.Size = new System.Drawing.Size(153, 25);
            this.DataGridView_Test.TabIndex = 0;
            this.DataGridView_Test.Text = "DataGridView_Test";
            this.DataGridView_Test.UseVisualStyleBackColor = true;
            this.DataGridView_Test.Click += new System.EventHandler(this.DataGridView_Test_Click);
            // 
            // TabControl_Test
            // 
            this.TabControl_Test.AutoSize = true;
            this.TabControl_Test.Location = new System.Drawing.Point(162, 3);
            this.TabControl_Test.Name = "TabControl_Test";
            this.TabControl_Test.Size = new System.Drawing.Size(153, 25);
            this.TabControl_Test.TabIndex = 0;
            this.TabControl_Test.Text = "TabControl_Test";
            this.TabControl_Test.UseVisualStyleBackColor = true;
            this.TabControl_Test.Click += new System.EventHandler(this.TabControl_Test_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 575);
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
    }
}