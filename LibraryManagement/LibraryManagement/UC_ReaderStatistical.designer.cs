namespace LibraryManagement
{
    partial class UC_ReaderStatistical
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CbbYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            this.chart1.BackSecondaryColor = System.Drawing.Color.SpringGreen;
            chartArea10.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chart1.Legends.Add(legend10);
            this.chart1.Location = new System.Drawing.Point(28, 192);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart1.Name = "chart1";
            series10.ChartArea = "ChartArea1";
            series10.LabelBackColor = System.Drawing.Color.DeepSkyBlue;
            series10.Legend = "Legend1";
            series10.Name = "Số lượng đọc giả mới";
            this.chart1.Series.Add(series10);
            this.chart1.Size = new System.Drawing.Size(1584, 671);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // CbbYear
            // 
            this.CbbYear.AutoRoundedCorners = true;
            this.CbbYear.BackColor = System.Drawing.Color.Transparent;
            this.CbbYear.BorderColor = System.Drawing.Color.Blue;
            this.CbbYear.BorderRadius = 17;
            this.CbbYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CbbYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.CbbYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CbbYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CbbYear.ItemHeight = 30;
            this.CbbYear.Items.AddRange(new object[] {
            "2022",
            "2021",
            "2020",
            "2019",
            "2018"});
            this.CbbYear.Location = new System.Drawing.Point(141, 108);
            this.CbbYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CbbYear.Name = "CbbYear";
            this.CbbYear.Size = new System.Drawing.Size(240, 36);
            this.CbbYear.TabIndex = 1;
            this.CbbYear.SelectedIndexChanged += new System.EventHandler(this.CbbYear_SelectedIndexChanged);
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.AutoSize = false;
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(544, 26);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(434, 49);
            this.guna2HtmlLabel10.TabIndex = 229;
            this.guna2HtmlLabel10.Text = "Reader Statistical";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(21, 108);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(113, 49);
            this.guna2HtmlLabel1.TabIndex = 230;
            this.guna2HtmlLabel1.Text = "Year";
            // 
            // UC_ReaderStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.guna2HtmlLabel10);
            this.Controls.Add(this.CbbYear);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UC_ReaderStatistical";
            this.Size = new System.Drawing.Size(1394, 720);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Guna.UI2.WinForms.Guna2ComboBox CbbYear;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}
