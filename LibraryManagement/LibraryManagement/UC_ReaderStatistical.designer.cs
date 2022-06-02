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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CbbYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            this.chart1.BackSecondaryColor = System.Drawing.Color.SpringGreen;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(19, 125);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.LabelBackColor = System.Drawing.Color.DeepSkyBlue;
            series1.Legend = "Legend1";
            series1.Name = "Số lượng đọc giả mới";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1056, 436);
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
            this.CbbYear.Location = new System.Drawing.Point(94, 70);
            this.CbbYear.Name = "CbbYear";
            this.CbbYear.Size = new System.Drawing.Size(161, 36);
            this.CbbYear.TabIndex = 1;
            this.CbbYear.SelectedIndexChanged += new System.EventHandler(this.CbbYear_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(26, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(359, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reader Statistical";
            // 
            // UC_ReaderStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbbYear);
            this.Controls.Add(this.chart1);
            this.Name = "UC_ReaderStatistical";
            this.Size = new System.Drawing.Size(1094, 611);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Guna.UI2.WinForms.Guna2ComboBox CbbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
