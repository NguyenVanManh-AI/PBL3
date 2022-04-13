namespace QuanLyThuVien2
{
    partial class UpdateAuthorInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateAuthorInformation));
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TenTacGia = new System.Windows.Forms.TextBox();
            this.MaTacGia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btUndo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.BackColor = System.Drawing.Color.White;
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nu"});
            this.cboGioiTinh.Location = new System.Drawing.Point(104, 101);
            this.cboGioiTinh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(224, 24);
            this.cboGioiTinh.TabIndex = 3;
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
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(11, 91);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(728, 539);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MATG";
            this.Column1.HeaderText = "Author code";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 90;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TENTG";
            this.Column2.HeaderText = "Name";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "GIOITINH";
            this.Column3.HeaderText = "Gender";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DIACHI";
            this.Column4.HeaderText = "Address";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.Width = 90;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "GHICHU";
            this.Column5.HeaderText = "Note";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.Width = 90;
            // 
            // DiaChi
            // 
            this.DiaChi.Location = new System.Drawing.Point(104, 133);
            this.DiaChi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DiaChi.Multiline = true;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Size = new System.Drawing.Size(224, 22);
            this.DiaChi.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboGioiTinh);
            this.groupBox1.Controls.Add(this.DiaChi);
            this.groupBox1.Controls.Add(this.TenTacGia);
            this.groupBox1.Controls.Add(this.MaTacGia);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Location = new System.Drawing.Point(759, 91);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(365, 320);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import information";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(104, 162);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(224, 130);
            this.txtNote.TabIndex = 5;
            this.txtNote.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Address :";
            // 
            // TenTacGia
            // 
            this.TenTacGia.Location = new System.Drawing.Point(104, 71);
            this.TenTacGia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TenTacGia.Name = "TenTacGia";
            this.TenTacGia.Size = new System.Drawing.Size(224, 22);
            this.TenTacGia.TabIndex = 2;
            // 
            // MaTacGia
            // 
            this.MaTacGia.Location = new System.Drawing.Point(104, 41);
            this.MaTacGia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaTacGia.Name = "MaTacGia";
            this.MaTacGia.Size = new System.Drawing.Size(224, 22);
            this.MaTacGia.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 106);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Gender :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 168);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Note :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Author code :";
            // 
            // btAdd
            // 
            this.btAdd.BackColor = System.Drawing.Color.White;
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Location = new System.Drawing.Point(33, 36);
            this.btAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(88, 26);
            this.btAdd.TabIndex = 23;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.White;
            this.btDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelete.Location = new System.Drawing.Point(33, 109);
            this.btDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(88, 26);
            this.btDelete.TabIndex = 25;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btEdit
            // 
            this.btEdit.BackColor = System.Drawing.Color.White;
            this.btEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEdit.Location = new System.Drawing.Point(224, 36);
            this.btEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(88, 26);
            this.btEdit.TabIndex = 24;
            this.btEdit.Text = "Edit";
            this.btEdit.UseVisualStyleBackColor = false;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(320, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "Update Author Information";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(11, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(1024, 64);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btClose);
            this.groupBox3.Controls.Add(this.btUndo);
            this.groupBox3.Controls.Add(this.btAdd);
            this.groupBox3.Controls.Add(this.btEdit);
            this.groupBox3.Controls.Add(this.btDelete);
            this.groupBox3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox3.Location = new System.Drawing.Point(762, 415);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(363, 171);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Feature";
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.White;
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(127, 74);
            this.btClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(88, 26);
            this.btClose.TabIndex = 27;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btUndo
            // 
            this.btUndo.BackColor = System.Drawing.Color.White;
            this.btUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUndo.Location = new System.Drawing.Point(224, 109);
            this.btUndo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btUndo.Name = "btUndo";
            this.btUndo.Size = new System.Drawing.Size(88, 26);
            this.btUndo.TabIndex = 26;
            this.btUndo.Text = "Undo";
            this.btUndo.UseVisualStyleBackColor = false;
            this.btUndo.Click += new System.EventHandler(this.btUndo_Click);
            // 
            // UpdateAuthorInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyThuVien2.Properties.Resources.Backgroundmain;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1183, 645);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UpdateAuthorInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Author Information";
            this.Load += new System.EventHandler(this.capnhatTG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox DiaChi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TenTacGia;
        private System.Windows.Forms.TextBox MaTacGia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btUndo;
        private System.Windows.Forms.Button btClose;
    }
}