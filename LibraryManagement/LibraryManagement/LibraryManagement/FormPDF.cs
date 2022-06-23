using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;
using Microsoft.Reporting.WinForms;
using BLL;


namespace LibraryManagement
{
    public partial class FormPDF : Form
    {
        public int id_borrow { get; set; }
        public FormPDF(string _id_borrow)
        {
            InitializeComponent();
            id_borrow = Int32.Parse(_id_borrow);
        }
        private void FormPDF_Load(object sender, EventArgs e)
        {
            reportViewer2.LocalReport.ReportEmbeddedResource = "LibraryManagement.PrintPDF.Report1.rdlc";
            ReportDataSource dataSource = new ReportDataSource();

            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.DataSources.Add(dataSource);
            this.reportViewer2.RefreshReport();

            dataSource.Name = "DataSet1";
            dataSource.Value = BorrowsBLL.Instance.PrintPDF(id_borrow);
            reportViewer2.LocalReport.DataSources.Add(dataSource);
            this.reportViewer2.RefreshReport();
        }
    } 
}
