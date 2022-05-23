﻿namespace LibraryManagement
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dropdownSystemManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCheckEmployeeInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolUpdateStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCreateAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.dropdownReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBookStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolReadersStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolBook2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.toolReader2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAuthor2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolField2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPublisher2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLibrary2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dropdownSystemManagement,
            this.dropdownReport,
            this.buttonHelp,
            this.buttonExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(982, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dropdownSystemManagement
            // 
            this.dropdownSystemManagement.BackColor = System.Drawing.Color.White;
            this.dropdownSystemManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCheckEmployeeInformation,
            this.toolStripSeparator7,
            this.toolUpdateStaff,
            this.toolStripSeparator1,
            this.toolCreateAccount,
            this.toolStripSeparator2,
            this.toolChangePassword,
            this.toolStripSeparator3,
            this.toolLogout});
            this.dropdownSystemManagement.Enabled = false;
            this.dropdownSystemManagement.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownSystemManagement.ForeColor = System.Drawing.SystemColors.Highlight;
            this.dropdownSystemManagement.Image = global::LibraryManagement.Properties.Resources.system;
            this.dropdownSystemManagement.Name = "dropdownSystemManagement";
            this.dropdownSystemManagement.Size = new System.Drawing.Size(231, 29);
            this.dropdownSystemManagement.Text = "System Management";
            this.dropdownSystemManagement.Visible = false;
            // 
            // toolCheckEmployeeInformation
            // 
            this.toolCheckEmployeeInformation.Enabled = false;
            this.toolCheckEmployeeInformation.ForeColor = System.Drawing.Color.DodgerBlue;
            this.toolCheckEmployeeInformation.Name = "toolCheckEmployeeInformation";
            this.toolCheckEmployeeInformation.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.toolCheckEmployeeInformation.Size = new System.Drawing.Size(427, 34);
            this.toolCheckEmployeeInformation.Text = "Check Employee Information";
            this.toolCheckEmployeeInformation.Click += new System.EventHandler(this.KiemTraThongTinNguoiDung);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(424, 6);
            // 
            // toolUpdateStaff
            // 
            this.toolUpdateStaff.Enabled = false;
            this.toolUpdateStaff.ForeColor = System.Drawing.Color.DodgerBlue;
            this.toolUpdateStaff.Name = "toolUpdateStaff";
            this.toolUpdateStaff.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.toolUpdateStaff.Size = new System.Drawing.Size(427, 34);
            this.toolUpdateStaff.Text = "Update Staff";
            this.toolUpdateStaff.Click += new System.EventHandler(this.CapNhatThongTin);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(424, 6);
            // 
            // toolCreateAccount
            // 
            this.toolCreateAccount.ForeColor = System.Drawing.Color.DodgerBlue;
            this.toolCreateAccount.Name = "toolCreateAccount";
            this.toolCreateAccount.Size = new System.Drawing.Size(427, 34);
            this.toolCreateAccount.Text = "Create Account";
            this.toolCreateAccount.Click += new System.EventHandler(this.TaoTaiKhoan);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(424, 6);
            // 
            // toolChangePassword
            // 
            this.toolChangePassword.Enabled = false;
            this.toolChangePassword.ForeColor = System.Drawing.Color.DodgerBlue;
            this.toolChangePassword.Name = "toolChangePassword";
            this.toolChangePassword.Size = new System.Drawing.Size(427, 34);
            this.toolChangePassword.Text = "Change Password";
            this.toolChangePassword.Click += new System.EventHandler(this.DoiMatKhau);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(424, 6);
            // 
            // toolLogout
            // 
            this.toolLogout.Enabled = false;
            this.toolLogout.ForeColor = System.Drawing.Color.DodgerBlue;
            this.toolLogout.Name = "toolLogout";
            this.toolLogout.Size = new System.Drawing.Size(427, 34);
            this.toolLogout.Text = "Log out";
            this.toolLogout.Click += new System.EventHandler(this.DangXuat);
            // 
            // dropdownReport
            // 
            this.dropdownReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBookStatus,
            this.toolStripSeparator6,
            this.toolReadersStatus});
            this.dropdownReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropdownReport.ForeColor = System.Drawing.SystemColors.Highlight;
            this.dropdownReport.Image = global::LibraryManagement.Properties.Resources.report;
            this.dropdownReport.Name = "dropdownReport";
            this.dropdownReport.Size = new System.Drawing.Size(111, 29);
            this.dropdownReport.Text = "Report";
            // 
            // toolBookStatus
            // 
            this.toolBookStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.toolBookStatus.Name = "toolBookStatus";
            this.toolBookStatus.Size = new System.Drawing.Size(240, 34);
            this.toolBookStatus.Text = "Book Status";
            this.toolBookStatus.Click += new System.EventHandler(this.BaoCaoTinhTrangSach);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(237, 6);
            // 
            // toolReadersStatus
            // 
            this.toolReadersStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.toolReadersStatus.Name = "toolReadersStatus";
            this.toolReadersStatus.Size = new System.Drawing.Size(240, 34);
            this.toolReadersStatus.Text = "Readers Status";
            this.toolReadersStatus.Click += new System.EventHandler(this.BaoCaoDocGia);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHelp.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonHelp.Image = global::LibraryManagement.Properties.Resources.help;
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(92, 29);
            this.buttonHelp.Text = "Help";
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonExit.Image = global::LibraryManagement.Properties.Resources.exit;
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(84, 29);
            this.buttonExit.Text = "Exit";
            this.buttonExit.Click += new System.EventHandler(this.ThoatChuongTrinh);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 26);
            this.label1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(351, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(466, 55);
            this.label4.TabIndex = 4;
            this.label4.Text = "Library Management";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(10, 69);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(960, 63);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(0, 526);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(982, 30);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.White;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBook2,
            this.toolReader2,
            this.toolAuthor2,
            this.toolField2,
            this.toolPublisher2,
            this.toolLibrary2});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(155, 267);
            this.menuStrip2.TabIndex = 9;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolBook2
            // 
            this.toolBook2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator18});
            this.toolBook2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolBook2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.toolBook2.Image = global::LibraryManagement.Properties.Resources.open_book;
            this.toolBook2.Name = "toolBook2";
            this.toolBook2.Size = new System.Drawing.Size(146, 29);
            this.toolBook2.Text = "Book Titles";
            this.toolBook2.Click += new System.EventHandler(this.toolStripMenuItem21_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(87, 6);
            // 
            // toolReader2
            // 
            this.toolReader2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolReader2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.toolReader2.Image = global::LibraryManagement.Properties.Resources._4213477;
            this.toolReader2.Name = "toolReader2";
            this.toolReader2.Size = new System.Drawing.Size(146, 29);
            this.toolReader2.Text = "Readers";
            this.toolReader2.Click += new System.EventHandler(this.toolStripMenuItem24_Click);
            // 
            // toolAuthor2
            // 
            this.toolAuthor2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolAuthor2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.toolAuthor2.Image = global::LibraryManagement.Properties.Resources._1995562;
            this.toolAuthor2.Name = "toolAuthor2";
            this.toolAuthor2.Size = new System.Drawing.Size(146, 29);
            this.toolAuthor2.Text = "Authors";
            this.toolAuthor2.Click += new System.EventHandler(this.toolStripMenuItem25_Click);
            // 
            // toolField2
            // 
            this.toolField2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolField2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.toolField2.Image = global::LibraryManagement.Properties.Resources._126795;
            this.toolField2.Name = "toolField2";
            this.toolField2.Size = new System.Drawing.Size(146, 29);
            this.toolField2.Text = "Categorys";
            this.toolField2.Click += new System.EventHandler(this.toolStripMenuItem26_Click);
            // 
            // toolPublisher2
            // 
            this.toolPublisher2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolPublisher2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.toolPublisher2.Image = global::LibraryManagement.Properties.Resources.printer;
            this.toolPublisher2.Name = "toolPublisher2";
            this.toolPublisher2.Size = new System.Drawing.Size(146, 29);
            this.toolPublisher2.Text = "Publishers";
            this.toolPublisher2.Click += new System.EventHandler(this.toolStripMenuItem27_Click);
            // 
            // toolLibrary2
            // 
            this.toolLibrary2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolLibrary2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.toolLibrary2.Image = global::LibraryManagement.Properties.Resources.images;
            this.toolLibrary2.Name = "toolLibrary2";
            this.toolLibrary2.Size = new System.Drawing.Size(146, 29);
            this.toolLibrary2.Text = "Borrows";
            this.toolLibrary2.Click += new System.EventHandler(this.libraryCardToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(0, 267);
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.menuStrip2);
            this.toolStripContainer1.Location = new System.Drawing.Point(8, 132);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(150, 292);
            this.toolStripContainer1.TabIndex = 129;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.Color.Transparent;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::LibraryManagement.Properties.Resources.Backgroundmain;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 564);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dropdownSystemManagement;
        private System.Windows.Forms.ToolStripMenuItem toolUpdateStaff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolCreateAccount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolChangePassword;
        private System.Windows.Forms.ToolStripMenuItem dropdownReport;
        private System.Windows.Forms.ToolStripMenuItem buttonHelp;
        private System.Windows.Forms.ToolStripMenuItem buttonExit;
        private System.Windows.Forms.ToolStripMenuItem toolBookStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolReadersStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
        //b private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        //b private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripMenuItem toolCheckEmployeeInformation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripMenuItem toolLogout;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolBook2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripMenuItem toolReader2;
        private System.Windows.Forms.ToolStripMenuItem toolAuthor2;
        private System.Windows.Forms.ToolStripMenuItem toolField2;
        private System.Windows.Forms.ToolStripMenuItem toolPublisher2;
        private System.Windows.Forms.ToolStripMenuItem toolLibrary2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        //b  private System.Windows.Forms.GroupBox groupBox3;
    }
}

