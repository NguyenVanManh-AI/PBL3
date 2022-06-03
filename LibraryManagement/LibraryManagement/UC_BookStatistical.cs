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
            chart1.Series[0].Points.AddXY("Hư hỏng", BooksBLL.Instance.GetBadBooks());
            chart1.Series[0].Points.AddXY("Nguyên vẹn", BooksBLL.Instance.GetGoodBooks());
        }
        public void SetBooksBorrowChart()
        {
            chart2.Series[0].Points.AddXY("Sách đã mượn", BooksBLL.Instance.GetBooksBorrow());
            chart2.Series[0].Points.AddXY("Sách còn lại", BooksBLL.Instance.GetAllBooks()- BooksBLL.Instance.GetBooksBorrow());
        }


        private void btReaderStatis_Click(object sender, EventArgs e)
        {
            formMain.AddUC_ReaderStatis_Panel1();
        }
    }
}
