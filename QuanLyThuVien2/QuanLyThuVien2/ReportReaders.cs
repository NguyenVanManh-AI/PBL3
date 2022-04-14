using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien2
{
    public partial class ReportReaders : Form
    {
        public ReportReaders()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();
        private void BCDocGia_Load(object sender, EventArgs e)
        {
            cls.KetNoi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cls.LoadData2DataGridView(dataGridView1, "select a.MADG,HOTEN, COUNT(*) as SoLanMuon from tblMuon a inner join tblDocGia b on a.MADG=b.MADG group by a.MADG,HOTEN ");
            }
            if (radioButton2.Checked)
            {

                cls.LoadData2DataGridView(dataGridView2, "select * from tblDocGia where MADG not in (select MADG from tblMuon)");
            }
        }
    }
}
