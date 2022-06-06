using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;

namespace LibraryManagement
{
    public partial class UC_BookStatistical : UserControl
    {

        FormMain formMain;
        public UC_BookStatistical(FormMain _formMain)
        {
            formMain = _formMain;
            InitializeComponent();
            SetBookChart();
            SetBooksBorrowChart();
        }
        public void SetBookChart()
        {
            double tl = 100* (double)BooksBLL.Instance.GetBadBooks() / (double)(BooksBLL.Instance.GetBadBooks() + BooksBLL.Instance.GetGoodBooks());
            tl=Math.Round(tl, 2);
            chart1.Series[0].Points.AddXY("Depravity Books (" + tl+"%)",BooksBLL.Instance.GetBadBooks());
            chart1.Series[0].Points.AddXY("Intact Books ("+(100-tl)+"%)", BooksBLL.Instance.GetGoodBooks());
            chart1.Series[0]["DrawingStyle"] = "Cylinder";
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        }
        public void SetBooksBorrowChart()
        {
            double tl = 100*(double)BooksBLL.Instance.GetBooksBorrow()/ (double)BooksBLL.Instance.GetAllBooks();
            tl=Math.Round(tl, 2);
            chart2.Series[0].Points.AddXY("Borowed Books ("+tl+"%)", BooksBLL.Instance.GetBooksBorrow());
            chart2.Series[0].Points.AddXY("Remaining Books ("+(100-tl)+"%)", BooksBLL.Instance.GetAllBooks()- BooksBLL.Instance.GetBooksBorrow());
            chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        }

        private void btnReaderStatis_Click(object sender, EventArgs e)
        {
            formMain.AddUC_ReaderStatis_Panel1();
        }
    }
}
