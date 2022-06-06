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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea25 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend25 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title25 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea26 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend26 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title26 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnReaderStatis = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.DodgerBlue;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            this.chart1.BackSecondaryColor = System.Drawing.Color.SpringGreen;
            chartArea25.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea25);
            legend25.Name = "Legend1";
            this.chart1.Legends.Add(legend25);
            this.chart1.Location = new System.Drawing.Point(159, 183);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series25.ChartArea = "ChartArea1";
            series25.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series25.IsValueShownAsLabel = true;
            series25.IsXValueIndexed = true;
            series25.Legend = "Legend1";
            series25.Name = "Series1";
            series25.YValuesPerPoint = 3;
            this.chart1.Series.Add(series25);
            this.chart1.Size = new System.Drawing.Size(638, 645);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "Books status statistics";
            title25.Name = "books";
            title25.Text = "Books status statistics";
            this.chart1.Titles.Add(title25);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Green;
            this.chart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            this.chart2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.BottomLeft;
            this.chart2.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chart2.BackSecondaryColor = System.Drawing.Color.Cyan;
            this.chart2.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea26.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea26);
            legend26.Name = "Legend1";
            this.chart2.Legends.Add(legend26);
            this.chart2.Location = new System.Drawing.Point(822, 183);
            this.chart2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart2.Name = "chart2";
            series26.ChartArea = "ChartArea1";
            series26.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series26.IsValueShownAsLabel = true;
            series26.IsXValueIndexed = true;
            series26.Legend = "Legend1";
            series26.Name = "Series1";
            series26.YValuesPerPoint = 3;
            this.chart2.Series.Add(series26);
            this.chart2.Size = new System.Drawing.Size(638, 645);
            this.chart2.TabIndex = 2;
            this.chart2.Text = "Thống kê sách đã mượn";
            title26.Name = "booksborow";
            title26.Text = "Books quantity statistics";
            this.chart2.Titles.Add(title26);
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.AutoSize = false;
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(544, 26);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(391, 49);
            this.guna2HtmlLabel10.TabIndex = 228;
            this.guna2HtmlLabel10.Text = "Books Statistical";
            // 
            // btnReaderStatis
            // 
            this.btnReaderStatis.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.btnReaderStatis.Animated = true;
            this.btnReaderStatis.AnimatedGIF = true;
            this.btnReaderStatis.BorderColor = System.Drawing.Color.Gray;
            this.btnReaderStatis.BorderRadius = 15;
            this.btnReaderStatis.BorderThickness = 1;
            this.btnReaderStatis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReaderStatis.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReaderStatis.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReaderStatis.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReaderStatis.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReaderStatis.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReaderStatis.FillColor = System.Drawing.Color.White;
            this.btnReaderStatis.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnReaderStatis.FocusedColor = System.Drawing.Color.White;
            this.btnReaderStatis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReaderStatis.ForeColor = System.Drawing.Color.White;
            this.btnReaderStatis.Image = global::LibraryManagement.Properties.Resources.profits;
            this.btnReaderStatis.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReaderStatis.ImageSize = new System.Drawing.Size(25, 25);
            this.btnReaderStatis.Location = new System.Drawing.Point(1215, 23);
            this.btnReaderStatis.Margin = new System.Windows.Forms.Padding(2);
            this.btnReaderStatis.Name = "btnReaderStatis";
            this.btnReaderStatis.PressedColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReaderStatis.Size = new System.Drawing.Size(328, 51);
            this.btnReaderStatis.TabIndex = 230;
            this.btnReaderStatis.Text = "Reader Statistical";
            this.btnReaderStatis.Click += new System.EventHandler(this.btnReaderStatis_Click);
            // 
            // UC_BookStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnReaderStatis);
            this.Controls.Add(this.guna2HtmlLabel10);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UC_BookStatistical";
            this.Size = new System.Drawing.Size(1407, 722);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2GradientButton btnReaderStatis;
    }
}
