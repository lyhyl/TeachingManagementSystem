﻿namespace TeachingManagementSystem.UI
{
    partial class TeacherClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherClient));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.classDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addClassToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.updateClassToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.deleeteClassToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 261);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "个人信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Controls.Add(this.toolStrip1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(276, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "课程";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.classDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(270, 204);
            this.splitContainer1.SplitterDistance = 90;
            this.splitContainer1.TabIndex = 1;
            // 
            // classDataGridView
            // 
            this.classDataGridView.AllowUserToAddRows = false;
            this.classDataGridView.AllowUserToDeleteRows = false;
            this.classDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classDataGridView.Location = new System.Drawing.Point(0, 0);
            this.classDataGridView.Name = "classDataGridView";
            this.classDataGridView.ReadOnly = true;
            this.classDataGridView.Size = new System.Drawing.Size(90, 204);
            this.classDataGridView.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripSeparator1,
            this.addClassToolStripButton,
            this.deleeteClassToolStripButton,
            this.updateClassToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(270, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel1.Text = "学期";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // addClassToolStripButton
            // 
            this.addClassToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addClassToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addClassToolStripButton.Image")));
            this.addClassToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addClassToolStripButton.Name = "addClassToolStripButton";
            this.addClassToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addClassToolStripButton.Text = "新增课程";
            this.addClassToolStripButton.Click += new System.EventHandler(this.addClassToolStripButton_Click);
            // 
            // updateClassToolStripButton
            // 
            this.updateClassToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.updateClassToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("updateClassToolStripButton.Image")));
            this.updateClassToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateClassToolStripButton.Name = "updateClassToolStripButton";
            this.updateClassToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.updateClassToolStripButton.Text = "修改课程";
            this.updateClassToolStripButton.Click += new System.EventHandler(this.updateClassToolStripButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(276, 235);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "登记分数";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // deleeteClassToolStripButton
            // 
            this.deleeteClassToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleeteClassToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleeteClassToolStripButton.Image")));
            this.deleeteClassToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleeteClassToolStripButton.Name = "deleeteClassToolStripButton";
            this.deleeteClassToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleeteClassToolStripButton.Text = "删除课程";
            this.deleeteClassToolStripButton.Click += new System.EventHandler(this.deleeteClassToolStripButton_Click);
            // 
            // TeacherClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tabControl1);
            this.Name = "TeacherClient";
            this.Text = "TeacherClient";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.classDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton addClassToolStripButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView classDataGridView;
        private System.Windows.Forms.ToolStripButton updateClassToolStripButton;
        private System.Windows.Forms.ToolStripButton deleeteClassToolStripButton;
    }
}