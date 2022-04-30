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
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.cboPhieuMuon = new System.Windows.Forms.ComboBox();
            this.cboMASACH = new System.Windows.Forms.ComboBox();
            this.cboDOCGIA = new System.Windows.Forms.ComboBox();
            this.txtGHICHU = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch2 = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.cboXACNHAN.Location = new System.Drawing.Point(684, 25);
            this.cboXACNHAN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboXACNHAN.Name = "cboXACNHAN";
            this.cboXACNHAN.Size = new System.Drawing.Size(202, 28);
            this.cboXACNHAN.TabIndex = 15;
            // 
            // mktNGAYTRA
            // 
            this.mktNGAYTRA.Location = new System.Drawing.Point(182, 175);
            this.mktNGAYTRA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mktNGAYTRA.Mask = "00/00/0000";
            this.mktNGAYTRA.Name = "mktNGAYTRA";
            this.mktNGAYTRA.Size = new System.Drawing.Size(277, 26);
            this.mktNGAYTRA.TabIndex = 9;
            this.mktNGAYTRA.ValidatingType = typeof(System.DateTime);
            // 
            // mktNGAYMUON
            // 
            this.mktNGAYMUON.Location = new System.Drawing.Point(182, 138);
            this.mktNGAYMUON.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mktNGAYMUON.Mask = "00/00/0000";
            this.mktNGAYMUON.Name = "mktNGAYMUON";
            this.mktNGAYMUON.Size = new System.Drawing.Size(277, 26);
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
            this.label6.Location = new System.Drawing.Point(28, 182);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Pay day ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(489, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Payment confirmation";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(537, 75);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Notes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 20);
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
            // Column8
            // 
            this.Column8.DataPropertyName = "HOTEN";
            this.Column8.HeaderText = "Name";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 125;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "LOP";
            this.Column9.HeaderText = "Class name";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 125;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "DIACHI";
            this.Column10.HeaderText = "Address";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 125;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "EMAIL";
            this.Column11.HeaderText = "Email";
            this.Column11.MinimumWidth = 6;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 125;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Borrowing date ";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.Xoa);
            this.groupBox3.Controls.Add(this.Them);
            this.groupBox3.Controls.Add(this.Sua);
            this.groupBox3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox3.Location = new System.Drawing.Point(928, 95);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(186, 240);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Feature";
            // 
            // Xoa
            // 
            this.Xoa.BackColor = System.Drawing.Color.White;
            this.Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xoa.Location = new System.Drawing.Point(39, 169);
            this.Xoa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(112, 32);
            this.Xoa.TabIndex = 26;
            this.Xoa.Text = "Delete";
            this.Xoa.UseVisualStyleBackColor = false;
            this.Xoa.Click += new System.EventHandler(this.Xoa_Click);
            // 
            // Them
            // 
            this.Them.BackColor = System.Drawing.Color.White;
            this.Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Them.Location = new System.Drawing.Point(39, 57);
            this.Them.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Them.Name = "Them";
            this.Them.Size = new System.Drawing.Size(112, 32);
            this.Them.TabIndex = 24;
            this.Them.Text = "New";
            this.Them.UseVisualStyleBackColor = false;
            this.Them.Click += new System.EventHandler(this.Them_Click);
            // 
            // Sua
            // 
            this.Sua.BackColor = System.Drawing.Color.White;
            this.Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sua.Location = new System.Drawing.Point(39, 117);
            this.Sua.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Sua.Name = "Sua";
            this.Sua.Size = new System.Drawing.Size(112, 32);
            this.Sua.TabIndex = 25;
            this.Sua.Text = "Save";
            this.Sua.UseVisualStyleBackColor = false;
            this.Sua.Click += new System.EventHandler(this.Sua_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Book code ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Readers Code ";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(18, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1232, 80);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(304, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(590, 38);
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
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dataGridView1.Location = new System.Drawing.Point(13, 453);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1232, 314);
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
            this.groupBox1.Location = new System.Drawing.Point(18, 95);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(900, 240);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fill in all the information";
            // 
            // cboPhieuMuon
            // 
            this.cboPhieuMuon.FormattingEnabled = true;
            this.cboPhieuMuon.Location = new System.Drawing.Point(278, 105);
            this.cboPhieuMuon.Name = "cboPhieuMuon";
            this.cboPhieuMuon.Size = new System.Drawing.Size(181, 28);
            this.cboPhieuMuon.TabIndex = 18;
            // 
            // cboMASACH
            // 
            this.cboMASACH.FormattingEnabled = true;
            this.cboMASACH.Location = new System.Drawing.Point(182, 62);
            this.cboMASACH.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboMASACH.Name = "cboMASACH";
            this.cboMASACH.Size = new System.Drawing.Size(277, 28);
            this.cboMASACH.TabIndex = 17;
            // 
            // cboDOCGIA
            // 
            this.cboDOCGIA.FormattingEnabled = true;
            this.cboDOCGIA.Location = new System.Drawing.Point(182, 29);
            this.cboDOCGIA.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboDOCGIA.Name = "cboDOCGIA";
            this.cboDOCGIA.Size = new System.Drawing.Size(277, 28);
            this.cboDOCGIA.TabIndex = 17;
            this.cboDOCGIA.SelectedIndexChanged += new System.EventHandler(this.cboDOCGIA_SelectedIndexChanged);
            // 
            // txtGHICHU
            // 
            this.txtGHICHU.Location = new System.Drawing.Point(610, 72);
            this.txtGHICHU.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtGHICHU.Multiline = true;
            this.txtGHICHU.Name = "txtGHICHU";
            this.txtGHICHU.Size = new System.Drawing.Size(276, 159);
            this.txtGHICHU.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.btnSearch);
            this.groupBox4.Controls.Add(this.txtSearch2);
            this.groupBox4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox4.Location = new System.Drawing.Point(20, 356);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1228, 78);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(947, 27);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 32);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch2
            // 
            this.txtSearch2.Location = new System.Drawing.Point(30, 34);
            this.txtSearch2.Name = "txtSearch2";
            this.txtSearch2.Size = new System.Drawing.Size(854, 26);
            this.txtSearch2.TabIndex = 0;
            // 
            // UpdateBorrowingInforamtion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyThuVien2.Properties.Resources.Backgroundmain;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1258, 804);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "UpdateBorrowingInforamtion";
            this.Text = "Update borrowing information books";
            this.Load += new System.EventHandler(this.UpdateBorrowingInforamtion_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
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
        private System.Windows.Forms.ComboBox cboPhieuMuon;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch2;
    }
}