namespace QuanLyThuVien2
{
    partial class UpdateBorrowingInforamtion
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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboXACNHAN = new System.Windows.Forms.ComboBox();
            this.txtSOPHIEU = new System.Windows.Forms.TextBox();
            this.mktNGAYTRA = new System.Windows.Forms.MaskedTextBox();
            this.mktNGAYMUON = new System.Windows.Forms.MaskedTextBox();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Xoa = new System.Windows.Forms.Button();
            this.Them = new System.Windows.Forms.Button();
            this.Sua = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGHICHU = new System.Windows.Forms.TextBox();
            this.cboDOCGIA = new System.Windows.Forms.ComboBox();
            this.cboMASACH = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MADG";
            this.Column1.HeaderText = "Mã độc giả";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SOPHIEUMUON";
            this.Column3.HeaderText = "Số phiếu mượn";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 110;
            // 
            // cboXACNHAN
            // 
            this.cboXACNHAN.FormattingEnabled = true;
            this.cboXACNHAN.Items.AddRange(new object[] {
            "Da Tra",
            "Chua Tra"});
            this.cboXACNHAN.Location = new System.Drawing.Point(543, 19);
            this.cboXACNHAN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboXACNHAN.Name = "cboXACNHAN";
            this.cboXACNHAN.Size = new System.Drawing.Size(245, 24);
            this.cboXACNHAN.TabIndex = 15;
            // 
            // txtSOPHIEU
            // 
            this.txtSOPHIEU.Location = new System.Drawing.Point(143, 81);
            this.txtSOPHIEU.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSOPHIEU.Name = "txtSOPHIEU";
            this.txtSOPHIEU.Size = new System.Drawing.Size(247, 22);
            this.txtSOPHIEU.TabIndex = 12;
            // 
            // mktNGAYTRA
            // 
            this.mktNGAYTRA.Location = new System.Drawing.Point(143, 141);
            this.mktNGAYTRA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mktNGAYTRA.Mask = "00/00/0000";
            this.mktNGAYTRA.Name = "mktNGAYTRA";
            this.mktNGAYTRA.Size = new System.Drawing.Size(247, 22);
            this.mktNGAYTRA.TabIndex = 9;
            this.mktNGAYTRA.ValidatingType = typeof(System.DateTime);
            // 
            // mktNGAYMUON
            // 
            this.mktNGAYMUON.Location = new System.Drawing.Point(143, 111);
            this.mktNGAYMUON.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mktNGAYMUON.Mask = "00/00/0000";
            this.mktNGAYMUON.Name = "mktNGAYMUON";
            this.mktNGAYMUON.Size = new System.Drawing.Size(247, 22);
            this.mktNGAYMUON.TabIndex = 8;
            this.mktNGAYMUON.ValidatingType = typeof(System.DateTime);
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NGAYMUON";
            this.Column4.HeaderText = "Ngày mượn";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NGAYTRA";
            this.Column5.HeaderText = "Ngày trả";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "XACNHANTRA";
            this.Column6.HeaderText = "Xác nhận trả";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 125;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 147);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ngày trả :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(435, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Xác nhận trả :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(468, 55);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ghi chú :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số phiếu mượn :";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MASACH";
            this.Column2.HeaderText = "Mã sách";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "GHICHU";
            this.Column7.HeaderText = "Ghi chú";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 125;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ngày mượn :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Xoa);
            this.groupBox3.Controls.Add(this.Them);
            this.groupBox3.Controls.Add(this.Sua);
            this.groupBox3.Location = new System.Drawing.Point(826, 77);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(213, 192);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // Xoa
            // 
            this.Xoa.Location = new System.Drawing.Point(53, 152);
            this.Xoa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(100, 26);
            this.Xoa.TabIndex = 26;
            this.Xoa.Text = "Xóa";
            this.Xoa.UseVisualStyleBackColor = true;
            this.Xoa.Click += new System.EventHandler(this.Xoa_Click);
            // 
            // Them
            // 
            this.Them.Location = new System.Drawing.Point(53, 37);
            this.Them.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Them.Name = "Them";
            this.Them.Size = new System.Drawing.Size(100, 26);
            this.Them.TabIndex = 24;
            this.Them.Text = "Thêm";
            this.Them.UseVisualStyleBackColor = true;
            this.Them.Click += new System.EventHandler(this.Them_Click);
            // 
            // Sua
            // 
            this.Sua.Location = new System.Drawing.Point(53, 93);
            this.Sua.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Sua.Name = "Sua";
            this.Sua.Size = new System.Drawing.Size(100, 26);
            this.Sua.TabIndex = 25;
            this.Sua.Text = "Sửa";
            this.Sua.UseVisualStyleBackColor = true;
            this.Sua.Click += new System.EventHandler(this.Sua_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã sách :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã độc giả :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(16, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(1024, 64);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(267, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cập Nhật Thông Tin Mượn Sách";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(16, 278);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1024, 347);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboMASACH);
            this.groupBox1.Controls.Add(this.cboDOCGIA);
            this.groupBox1.Controls.Add(this.txtGHICHU);
            this.groupBox1.Controls.Add(this.cboXACNHAN);
            this.groupBox1.Controls.Add(this.txtSOPHIEU);
            this.groupBox1.Controls.Add(this.mktNGAYTRA);
            this.groupBox1.Controls.Add(this.mktNGAYMUON);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 77);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(800, 192);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập đầy đủ các thông tin";
            // 
            // txtGHICHU
            // 
            this.txtGHICHU.Location = new System.Drawing.Point(543, 58);
            this.txtGHICHU.Multiline = true;
            this.txtGHICHU.Name = "txtGHICHU";
            this.txtGHICHU.Size = new System.Drawing.Size(245, 128);
            this.txtGHICHU.TabIndex = 16;
            // 
            // cboDOCGIA
            // 
            this.cboDOCGIA.FormattingEnabled = true;
            this.cboDOCGIA.Location = new System.Drawing.Point(143, 21);
            this.cboDOCGIA.Name = "cboDOCGIA";
            this.cboDOCGIA.Size = new System.Drawing.Size(247, 24);
            this.cboDOCGIA.TabIndex = 17;
            // 
            // cboMASACH
            // 
            this.cboMASACH.FormattingEnabled = true;
            this.cboMASACH.Location = new System.Drawing.Point(143, 51);
            this.cboMASACH.Name = "cboMASACH";
            this.cboMASACH.Size = new System.Drawing.Size(247, 24);
            this.cboMASACH.TabIndex = 17;
            // 
            // UpdateBorrowingInforamtion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 641);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UpdateBorrowingInforamtion";
            this.Text = "UpdateBorrowingInforamtion";
            this.Load += new System.EventHandler(this.UpdateBorrowingInforamtion_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ComboBox cboXACNHAN;
        private System.Windows.Forms.TextBox txtSOPHIEU;
        private System.Windows.Forms.MaskedTextBox mktNGAYTRA;
        private System.Windows.Forms.MaskedTextBox mktNGAYMUON;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Xoa;
        private System.Windows.Forms.Button Them;
        private System.Windows.Forms.Button Sua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGHICHU;
        private System.Windows.Forms.ComboBox cboMASACH;
        private System.Windows.Forms.ComboBox cboDOCGIA;
    }
}