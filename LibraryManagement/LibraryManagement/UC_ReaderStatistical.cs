using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace LibraryManagement
{
    public partial class UC_ReaderStatistical : UserControl
    {
        FormMain formMain;
        public UC_ReaderStatistical(FormMain _formMain)
        {
            formMain = _formMain;
            InitializeComponent();
            GetCBB();
            MonthChart(ReadersBLL.Instance.GetYear(DateTime.Now.ToString()));
        }
        public void MonthChart(int yy)
        {
            chart1.Series[0].Points.Clear();
            DataTable dt = ReadersBLL.Instance.LoadAllReaders();
            int[] arr = new int[13];
            for (int i = 1; i <= 12; i++)
            {
                arr[i] = 0;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (ReadersBLL.Instance.GetYear(dt.Rows[i]["created_at"].ToString()) == yy)
                {
                    arr[ReadersBLL.Instance.GetMonth(dt.Rows[i]["created_at"].ToString())]++;
                }
            }
            for (int i = 1; i <= 12; i++)
            {
                chart1.Series[0].Points.AddXY("Tháng" + i, arr[i]);
            }
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.Series[0]["DrawingStyle"] = "Cylinder";
        }
        public void GetCBB()
        {
            DataTable dt = ReadersBLL.Instance.LoadAllReaders();
            List<string> list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(ReadersBLL.Instance.GetYear(dt.Rows[i]["created_at"].ToString()).ToString());
            }
            foreach(string  i in list.Distinct())
            {
                CbbYear.Items.Add(i);
            }
        }

        private void CbbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            MonthChart(int.Parse(CbbYear.Text));
        }

        private void btnBookStatis_Click(object sender, EventArgs e)
        {
            formMain.AddUC_BookStatis_Panel1();
        }
    }
}
