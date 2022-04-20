namespace QuanLyThuVien2
{
    partial class UpdateLoanSlip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateLoanSlip));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDOCGIA = new System.Windows.Forms.ComboBox();
            this.cboReaderCode2 = new System.Windows.Forms.ComboBox();
            this.btnShowDetail = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboPhieuMuonCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMASACH = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1a,
            this.Column2a,
            this.Column3a});
            this.dataGridView1.Location = new System.Drawing.Point(12, 319);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(577, 289);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1a
            // 
            this.Column1a.DataPropertyName = "MADG";
            this.Column1a.HeaderText = "Readers code";
            this.Column1a.MinimumWidth = 8;
            this.Column1a.Name = "Column1a";
            this.Column1a.Width = 90;
            // 
            // Column2a
            // 
            this.Column2a.DataPropertyName = "MAPHIEUMUON";
            this.Column2a.HeaderText = "Loan coupon code";
            this.Column2a.MinimumWidth = 8;
            this.Column2a.Name = "Column2a";
            this.Column2a.Width = 90;
            // 
            // Column3a
            // 
            this.Column3a.DataPropertyName = "MASACH";
            this.Column3a.HeaderText = "Book code";
            this.Column3a.MinimumWidth = 8;
            this.Column3a.Name = "Column3a";
            this.Column3a.Width = 90;
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.White;
            this.add.Location = new System.Drawing.Point(347, 28);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(98, 38);
            this.add.TabIndex = 1;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Reader code";
            // 
            // cboDOCGIA
            // 
            this.cboDOCGIA.FormattingEnabled = true;
            this.cboDOCGIA.Location = new System.Drawing.Point(126, 34);
            this.cboDOCGIA.Name = "cboDOCGIA";
            this.cboDOCGIA.Size = new System.Drawing.Size(199, 28);
            this.cboDOCGIA.TabIndex = 4;
            // 
            // cboReaderCode2
            // 
            this.cboReaderCode2.FormattingEnabled = true;
            this.cboReaderCode2.Location = new System.Drawing.Point(113, 40);
            this.cboReaderCode2.Name = "cboReaderCode2";
            this.cboReaderCode2.Size = new System.Drawing.Size(199, 28);
            this.cboReaderCode2.TabIndex = 5;
            this.cboReaderCode2.SelectedIndexChanged += new System.EventHandler(this.cboReaderCode2_SelectedIndexChanged);
            // 
            // btnShowDetail
            // 
            this.btnShowDetail.BackColor = System.Drawing.Color.White;
            this.btnShowDetail.Location = new System.Drawing.Point(204, 25);
            this.btnShowDetail.Name = "btnShowDetail";
            this.btnShowDetail.Size = new System.Drawing.Size(127, 38);
            this.btnShowDetail.TabIndex = 6;
            this.btnShowDetail.Text = "ShowDetail";
            this.btnShowDetail.UseVisualStyleBackColor = false;
            this.btnShowDetail.Click += new System.EventHandler(this.btnShowDetail_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Reader code";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column27,
            this.Column28,
            this.Column29});
            this.dataGridView2.Location = new System.Drawing.Point(12, 343);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1227, 306);
            this.dataGridView2.TabIndex = 10;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MADG";
            this.Column1.HeaderText = "Readers code";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 90;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MAPHIEUMUON";
            this.Column2.HeaderText = "Loan coupon code";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "MASACH";
            this.Column3.HeaderText = "Book code";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MADG1";
            this.Column4.HeaderText = "Reader Code";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 90;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "HOTEN";
            this.Column5.HeaderText = "Name";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.Width = 90;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NGAYSINH";
            this.Column6.HeaderText = "Date of birth";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.Width = 90;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "GIOITINH";
            this.Column7.HeaderText = "Gender";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            this.Column7.Width = 90;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "LOP";
            this.Column8.HeaderText = "Class";
            this.Column8.MinimumWidth = 8;
            this.Column8.Name = "Column8";
            this.Column8.Width = 90;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "DIACHI";
            this.Column9.HeaderText = "Address";
            this.Column9.MinimumWidth = 8;
            this.Column9.Name = "Column9";
            this.Column9.Width = 90;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "EMAIL";
            this.Column10.HeaderText = "Email";
            this.Column10.MinimumWidth = 8;
            this.Column10.Name = "Column10";
            this.Column10.Width = 90;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "GHICHU";
            this.Column11.HeaderText = "Notes";
            this.Column11.MinimumWidth = 8;
            this.Column11.Name = "Column11";
            this.Column11.Width = 90;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "MASACH1";
            this.Column12.HeaderText = "Book Code";
            this.Column12.MinimumWidth = 8;
            this.Column12.Name = "Column12";
            this.Column12.Width = 90;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "TENSACH";
            this.Column13.HeaderText = "Book Name";
            this.Column13.MinimumWidth = 8;
            this.Column13.Name = "Column13";
            this.Column13.Width = 90;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "MATG";
            this.Column14.HeaderText = "Author Code";
            this.Column14.MinimumWidth = 8;
            this.Column14.Name = "Column14";
            this.Column14.Width = 90;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "MANXB";
            this.Column15.HeaderText = "Publisher Code";
            this.Column15.MinimumWidth = 8;
            this.Column15.Name = "Column15";
            this.Column15.Width = 90;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "MaLv";
            this.Column16.HeaderText = "Field code";
            this.Column16.MinimumWidth = 8;
            this.Column16.Name = "Column16";
            this.Column16.Width = 90;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "NAMXB";
            this.Column17.HeaderText = "Publishing year";
            this.Column17.MinimumWidth = 8;
            this.Column17.Name = "Column17";
            this.Column17.Width = 90;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "SOTRANG";
            this.Column18.HeaderText = "Number of pages";
            this.Column18.MinimumWidth = 8;
            this.Column18.Name = "Column18";
            this.Column18.Width = 90;
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "SOLUONG";
            this.Column19.HeaderText = "Quantity";
            this.Column19.MinimumWidth = 8;
            this.Column19.Name = "Column19";
            this.Column19.Width = 90;
            // 
            // Column20
            // 
            this.Column20.DataPropertyName = "SOSACHHONG";
            this.Column20.HeaderText = "Number of broken books";
            this.Column20.MinimumWidth = 8;
            this.Column20.Name = "Column20";
            this.Column20.Width = 90;
            // 
            // Column21
            // 
            this.Column21.DataPropertyName = "NGAYNHAP";
            this.Column21.HeaderText = "Date Added";
            this.Column21.MinimumWidth = 8;
            this.Column21.Name = "Column21";
            this.Column21.Width = 90;
            // 
            // Column22
            // 
            this.Column22.DataPropertyName = "GHICHU1";
            this.Column22.HeaderText = "Notes";
            this.Column22.MinimumWidth = 8;
            this.Column22.Name = "Column22";
            this.Column22.Width = 90;
            // 
            // Column23
            // 
            this.Column23.DataPropertyName = "MADG2";
            this.Column23.HeaderText = "Readers Code";
            this.Column23.MinimumWidth = 6;
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            this.Column23.Width = 125;
            // 
            // Column24
            // 
            this.Column24.DataPropertyName = "MASACH2";
            this.Column24.HeaderText = "Books Code";
            this.Column24.MinimumWidth = 6;
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            this.Column24.Width = 125;
            // 
            // Column25
            // 
            this.Column25.DataPropertyName = "SOPHIEUMUON";
            this.Column25.HeaderText = "Borrowed votes";
            this.Column25.MinimumWidth = 6;
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            this.Column25.Width = 110;
            // 
            // Column26
            // 
            this.Column26.DataPropertyName = "NGAYMUON";
            this.Column26.HeaderText = "Borrowing date";
            this.Column26.MinimumWidth = 6;
            this.Column26.Name = "Column26";
            this.Column26.ReadOnly = true;
            this.Column26.Width = 125;
            // 
            // Column27
            // 
            this.Column27.DataPropertyName = "NGAYTRA";
            this.Column27.HeaderText = "Pay day";
            this.Column27.MinimumWidth = 6;
            this.Column27.Name = "Column27";
            this.Column27.ReadOnly = true;
            this.Column27.Width = 125;
            // 
            // Column28
            // 
            this.Column28.DataPropertyName = "XACNHANTRA";
            this.Column28.HeaderText = "Payment confirmation";
            this.Column28.MinimumWidth = 6;
            this.Column28.Name = "Column28";
            this.Column28.ReadOnly = true;
            this.Column28.Width = 125;
            // 
            // Column29
            // 
            this.Column29.DataPropertyName = "GHICHU2";
            this.Column29.HeaderText = "Notes";
            this.Column29.MinimumWidth = 6;
            this.Column29.Name = "Column29";
            this.Column29.ReadOnly = true;
            this.Column29.Width = 125;
            // 
            // cboPhieuMuonCode
            // 
            this.cboPhieuMuonCode.FormattingEnabled = true;
            this.cboPhieuMuonCode.Location = new System.Drawing.Point(465, 41);
            this.cboPhieuMuonCode.Name = "cboPhieuMuonCode";
            this.cboPhieuMuonCode.Size = new System.Drawing.Size(199, 28);
            this.cboPhieuMuonCode.TabIndex = 11;
            this.cboPhieuMuonCode.SelectedIndexChanged += new System.EventHandler(this.cboPhieuMuonCode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Loan coupon code";
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.White;
            this.btnShow.Location = new System.Drawing.Point(19, 25);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(114, 38);
            this.btnShow.TabIndex = 13;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(19, 148);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(127, 38);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(660, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "MASACH";
            // 
            // cboMASACH
            // 
            this.cboMASACH.FormattingEnabled = true;
            this.cboMASACH.Location = new System.Drawing.Point(754, 18);
            this.cboMASACH.Name = "cboMASACH";
            this.cboMASACH.Size = new System.Drawing.Size(199, 28);
            this.cboMASACH.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(111, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 38);
            this.button1.TabIndex = 21;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnShowDetail);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Location = new System.Drawing.Point(715, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 210);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Feature";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(204, 148);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(127, 38);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboReaderCode2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboPhieuMuonCode);
            this.groupBox2.Location = new System.Drawing.Point(26, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(683, 122);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Form Feature";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.cboDOCGIA);
            this.groupBox3.Controls.Add(this.add);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(26, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(464, 83);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Form Add";
            // 
            // UpdateLoanSlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyThuVien2.Properties.Resources.Backgroundmain;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1392, 679);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboMASACH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.Color.DodgerBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateLoanSlip";
            this.Text = "Update Loan Slip";
            this.Load += new System.EventHandler(this.UpdateLoanSlip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1a;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2a;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3a;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDOCGIA;
        private System.Windows.Forms.ComboBox cboReaderCode2;
        private System.Windows.Forms.Button btnShowDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column27;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column28;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column29;


        private System.Windows.Forms.ComboBox cboPhieuMuonCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMASACH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}