using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class ReportBookStatus : Form
    {
        public ReportBookStatus()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new LibraryManagement.Class.clsDatabase();
        private void BCTinhTrangSach_Load(object sender, EventArgs e)
        {
            //cls.LoadData2DataGridView(dataGridView1,"Select*from tblSach where SOSACHHONG<=0");
            //cls.LoadData2DataGridView(dataGridView2, "select*from tblSach where SOSACHHONG>0");
            //cls.LoadData2Label(lb1, "select sum(SOSACHHONG) from tblSach");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cls.LoadData2DataGridView(dataGridView2, "select * from tblSach where SOSACHHONG > 0");
                //cls.LoadData2Label(lb1, "select sum(SOSACHHONG) from tblSach");
            }
            if (radioButton3.Checked)
            {
                cls.LoadData2DataGridView(dataGridView2, "select a.MASACH,TENSACH, COUNT(*) as SoLanMuon from tblMuon a inner join tblSach b on a.MASACH=b.MASACH group by a.MASACH,TENSACH ");
            }
            if (radioButton4.Checked)
            {
                cls.LoadData2DataGridView(dataGridView2, "select * from tblSach where MASACH not in (select MASACH from tblMuon)");
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lb1.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
