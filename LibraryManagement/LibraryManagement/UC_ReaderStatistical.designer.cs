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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CbbYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnBookStatis = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            this.chart1.BackSecondaryColor = System.Drawing.Color.SpringGreen;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(4, 215);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.IsValueShownAsLabel = true;
            series3.LabelBackColor = System.Drawing.Color.DeepSkyBlue;
            series3.Legend = "Legend1";
            series3.MarkerBorderColor = System.Drawing.Color.White;
            series3.MarkerColor = System.Drawing.Color.White;
            series3.Name = "New Readers";
            series3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(1584, 671);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title3.Name = "Title1";
            title3.Text = "New Readers";
            this.chart1.Titles.Add(title3);
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
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(112, 49);
            this.guna2HtmlLabel1.TabIndex = 230;
            this.guna2HtmlLabel1.Text = "Year";
            // 
            // btnBookStatis
            // 
            this.btnBookStatis.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.btnBookStatis.Animated = true;
            this.btnBookStatis.AnimatedGIF = true;
            this.btnBookStatis.BorderColor = System.Drawing.Color.Gray;
            this.btnBookStatis.BorderRadius = 15;
            this.btnBookStatis.BorderThickness = 1;
            this.btnBookStatis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookStatis.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBookStatis.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBookStatis.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBookStatis.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBookStatis.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBookStatis.FillColor = System.Drawing.Color.White;
            this.btnBookStatis.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnBookStatis.FocusedColor = System.Drawing.Color.White;
            this.btnBookStatis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookStatis.ForeColor = System.Drawing.Color.White;
            this.btnBookStatis.Image = global::LibraryManagement.Properties.Resources.pie_chart;
            this.btnBookStatis.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBookStatis.ImageSize = new System.Drawing.Size(25, 25);
            this.btnBookStatis.Location = new System.Drawing.Point(1215, 23);
            this.btnBookStatis.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookStatis.Name = "btnBookStatis";
            this.btnBookStatis.PressedColor = System.Drawing.Color.DeepSkyBlue;
            this.btnBookStatis.Size = new System.Drawing.Size(328, 51);
            this.btnBookStatis.TabIndex = 231;
            this.btnBookStatis.Text = "Book Statistical";
            this.btnBookStatis.Click += new System.EventHandler(this.btnBookStatis_Click);
            // 
            // UC_ReaderStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnBookStatis);
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
        private Guna.UI2.WinForms.Guna2GradientButton btnBookStatis;
    }
}
