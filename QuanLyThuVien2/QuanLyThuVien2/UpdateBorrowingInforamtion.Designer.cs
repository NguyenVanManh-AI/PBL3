﻿namespace QuanLyThuVien2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateBorrowingInforamtion));
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboXACNHAN = new System.Windows.Forms.ComboBox();
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
            this.Undo = new System.Windows.Forms.Button();
            this.Thoat = new System.Windows.Forms.Button();
            this.Sua = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboPhieuMuon = new System.Windows.Forms.ComboBox();
            this.cboMASACH = new System.Windows.Forms.ComboBox();
            this.cboDOCGIA = new System.Windows.Forms.ComboBox();
            this.txtGHICHU = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MADG";
            this.Column1.HeaderText = "Readers Code";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SOPHIEUMUON";
            this.Column3.HeaderText = "Borrowed votes";
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
            this.cboXACNHAN.Location = new System.Drawing.Point(456, 16);
            this.cboXACNHAN.Name = "cboXACNHAN";
            this.cboXACNHAN.Size = new System.Drawing.Size(136, 21);
            this.cboXACNHAN.TabIndex = 15;
            // 
            // mktNGAYTRA
            // 
            this.mktNGAYTRA.Location = new System.Drawing.Point(121, 114);
            this.mktNGAYTRA.Mask = "00/00/0000";
            this.mktNGAYTRA.Name = "mktNGAYTRA";
            this.mktNGAYTRA.Size = new System.Drawing.Size(186, 20);
            this.mktNGAYTRA.TabIndex = 9;
            this.mktNGAYTRA.ValidatingType = typeof(System.DateTime);
            // 
            // mktNGAYMUON
            // 
            this.mktNGAYMUON.Location = new System.Drawing.Point(121, 90);
            this.mktNGAYMUON.Mask = "00/00/0000";
            this.mktNGAYMUON.Name = "mktNGAYMUON";
            this.mktNGAYMUON.Size = new System.Drawing.Size(186, 20);
            this.mktNGAYMUON.TabIndex = 8;
            this.mktNGAYMUON.ValidatingType = typeof(System.DateTime);
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NGAYMUON";
            this.Column4.HeaderText = "Borrowing date";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NGAYTRA";
            this.Column5.HeaderText = "Pay day";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "XACNHANTRA";
            this.Column6.HeaderText = "Payment confirmation";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 125;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Pay day ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(326, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Payment confirmation";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(358, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Notes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Number of votes borrowed";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MASACH";
            this.Column2.HeaderText = "Books Code";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "GHICHU";
            this.Column7.HeaderText = "Notes";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 125;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Borrowing date ";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btSearch);
            this.groupBox3.Controls.Add(this.Xoa);
            this.groupBox3.Controls.Add(this.Them);
            this.groupBox3.Controls.Add(this.Undo);
            this.groupBox3.Controls.Add(this.Thoat);
            this.groupBox3.Controls.Add(this.Sua);
            this.groupBox3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox3.Location = new System.Drawing.Point(619, 62);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 156);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Feature";
            // 
            // Xoa
            // 
            this.Xoa.BackColor = System.Drawing.Color.White;
            this.Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xoa.Location = new System.Drawing.Point(26, 110);
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(75, 21);
            this.Xoa.TabIndex = 26;
            this.Xoa.Text = "Delete";
            this.Xoa.UseVisualStyleBackColor = false;
            this.Xoa.Click += new System.EventHandler(this.Xoa_Click);
            // 
            // Them
            // 
            this.Them.BackColor = System.Drawing.Color.White;
            this.Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Them.Location = new System.Drawing.Point(26, 37);
            this.Them.Name = "Them";
            this.Them.Size = new System.Drawing.Size(75, 21);
            this.Them.TabIndex = 24;
            this.Them.Text = "Add";
            this.Them.UseVisualStyleBackColor = false;
            this.Them.Click += new System.EventHandler(this.Them_Click);
            // 
            // Undo
            // 
            this.Undo.BackColor = System.Drawing.Color.White;
            this.Undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Undo.Location = new System.Drawing.Point(127, 110);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(75, 21);
            this.Undo.TabIndex = 25;
            this.Undo.Text = "Undo";
            this.Undo.UseVisualStyleBackColor = false;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // Thoat
            // 
            this.Thoat.BackColor = System.Drawing.Color.White;
            this.Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thoat.Location = new System.Drawing.Point(26, 70);
            this.Thoat.Name = "Thoat";
            this.Thoat.Size = new System.Drawing.Size(75, 21);
            this.Thoat.TabIndex = 25;
            this.Thoat.Text = "Close";
            this.Thoat.UseVisualStyleBackColor = false;
            this.Thoat.Click += new System.EventHandler(this.Thoat_Click);
            // 
            // Sua
            // 
            this.Sua.BackColor = System.Drawing.Color.White;
            this.Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sua.Location = new System.Drawing.Point(127, 37);
            this.Sua.Name = "Sua";
            this.Sua.Size = new System.Drawing.Size(75, 21);
            this.Sua.TabIndex = 25;
            this.Sua.Text = "Edit";
            this.Sua.UseVisualStyleBackColor = false;
            this.Sua.Click += new System.EventHandler(this.Sua_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Book code ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Readers Code ";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(821, 52);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(203, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update borrowing information books";
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 226);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(821, 204);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cboPhieuMuon);
            this.groupBox1.Controls.Add(this.cboMASACH);
            this.groupBox1.Controls.Add(this.cboDOCGIA);
            this.groupBox1.Controls.Add(this.txtGHICHU);
            this.groupBox1.Controls.Add(this.cboXACNHAN);
            this.groupBox1.Controls.Add(this.mktNGAYTRA);
            this.groupBox1.Controls.Add(this.mktNGAYMUON);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Location = new System.Drawing.Point(12, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 156);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fill in all the information";
            // 
            // cboPhieuMuon
            // 
            this.cboPhieuMuon.FormattingEnabled = true;
            this.cboPhieuMuon.Location = new System.Drawing.Point(185, 68);
            this.cboPhieuMuon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboPhieuMuon.Name = "cboPhieuMuon";
            this.cboPhieuMuon.Size = new System.Drawing.Size(122, 21);
            this.cboPhieuMuon.TabIndex = 18;
            // 
            // cboMASACH
            // 
            this.cboMASACH.FormattingEnabled = true;
            this.cboMASACH.Location = new System.Drawing.Point(121, 40);
            this.cboMASACH.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboMASACH.Name = "cboMASACH";
            this.cboMASACH.Size = new System.Drawing.Size(186, 21);
            this.cboMASACH.TabIndex = 17;
            // 
            // cboDOCGIA
            // 
            this.cboDOCGIA.FormattingEnabled = true;
            this.cboDOCGIA.Location = new System.Drawing.Point(121, 19);
            this.cboDOCGIA.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboDOCGIA.Name = "cboDOCGIA";
            this.cboDOCGIA.Size = new System.Drawing.Size(186, 21);
            this.cboDOCGIA.TabIndex = 17;
            this.cboDOCGIA.SelectedIndexChanged += new System.EventHandler(this.cboDOCGIA_SelectedIndexChanged);
            // 
            // txtGHICHU
            // 
            this.txtGHICHU.Location = new System.Drawing.Point(407, 47);
            this.txtGHICHU.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtGHICHU.Multiline = true;
            this.txtGHICHU.Name = "txtGHICHU";
            this.txtGHICHU.Size = new System.Drawing.Size(185, 105);
            this.txtGHICHU.TabIndex = 16;
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.Color.White;
            this.btSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSearch.Location = new System.Drawing.Point(127, 70);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 21);
            this.btSearch.TabIndex = 27;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = false;
            // 
            // UpdateBorrowingInforamtion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyThuVien2.Properties.Resources.Backgroundmain;
            this.ClientSize = new System.Drawing.Size(839, 447);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "UpdateBorrowingInforamtion";
            this.Text = "Update borrowing information books";
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
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button Thoat;
        private System.Windows.Forms.ComboBox cboPhieuMuon;
        private System.Windows.Forms.Button btSearch;
    }
}