namespace LibraryManagement
{
    partial class UC_BookStatistical
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title13 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title14 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btReaderStatis = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.DodgerBlue;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            this.chart1.BackSecondaryColor = System.Drawing.Color.SpringGreen;
            chartArea13.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea13);
            legend13.Name = "Legend1";
            this.chart1.Legends.Add(legend13);
            this.chart1.Location = new System.Drawing.Point(159, 183);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            series13.YValuesPerPoint = 3;
            this.chart1.Series.Add(series13);
            this.chart1.Size = new System.Drawing.Size(638, 645);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "Thống kê sách hư hỏng";
            title13.Name = "books";
            title13.Text = "Thống kê sách hư hỏng";
            this.chart1.Titles.Add(title13);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Green;
            this.chart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            this.chart2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.BottomLeft;
            this.chart2.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chart2.BackSecondaryColor = System.Drawing.Color.Cyan;
            this.chart2.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea14.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea14);
            legend14.Name = "Legend1";
            this.chart2.Legends.Add(legend14);
            this.chart2.Location = new System.Drawing.Point(862, 183);
            this.chart2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart2.Name = "chart2";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            series14.YValuesPerPoint = 3;
            this.chart2.Series.Add(series14);
            this.chart2.Size = new System.Drawing.Size(638, 645);
            this.chart2.TabIndex = 2;
            this.chart2.Text = "Thống kê sách đã mượn";
            title14.Name = "booksborow";
            title14.Text = "Thống kê sách đã mượn";
            this.chart2.Titles.Add(title14);
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.AutoSize = false;
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(550, 24);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(434, 49);
            this.guna2HtmlLabel10.TabIndex = 228;
            this.guna2HtmlLabel10.Text = "BOOKS STATISTICAL";
            // 
            // btReaderStatis
            // 
            this.btReaderStatis.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.btReaderStatis.Animated = true;
            this.btReaderStatis.AnimatedGIF = true;
            this.btReaderStatis.BorderColor = System.Drawing.Color.Gray;
            this.btReaderStatis.BorderRadius = 15;
            this.btReaderStatis.BorderThickness = 1;
            this.btReaderStatis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btReaderStatis.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btReaderStatis.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btReaderStatis.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btReaderStatis.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btReaderStatis.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btReaderStatis.FillColor = System.Drawing.Color.White;
            this.btReaderStatis.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btReaderStatis.FocusedColor = System.Drawing.Color.White;
            this.btReaderStatis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReaderStatis.ForeColor = System.Drawing.Color.White;
            this.btReaderStatis.Image = global::LibraryManagement.Properties.Resources.profits;
            this.btReaderStatis.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btReaderStatis.ImageSize = new System.Drawing.Size(25, 25);
            this.btReaderStatis.Location = new System.Drawing.Point(1221, 11);
            this.btReaderStatis.Margin = new System.Windows.Forms.Padding(2);
            this.btReaderStatis.Name = "btReaderStatis";
            this.btReaderStatis.PressedColor = System.Drawing.Color.DeepSkyBlue;
            this.btReaderStatis.Size = new System.Drawing.Size(352, 64);
            this.btReaderStatis.TabIndex = 229;
            this.btReaderStatis.Text = "Reader Statistical";
            this.btReaderStatis.Click += new System.EventHandler(this.btReaderStatis_Click);
            // 
            // UC_BookStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btReaderStatis);
            this.Controls.Add(this.guna2HtmlLabel10);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UC_BookStatistical";
            this.Size = new System.Drawing.Size(1396, 722);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2GradientButton btReaderStatis;
    }
}
