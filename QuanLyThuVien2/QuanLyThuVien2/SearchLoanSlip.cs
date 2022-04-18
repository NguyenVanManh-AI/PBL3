using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien2
{
    public partial class SearchLoanSlip : Form
    {
        public SearchLoanSlip()
        {
            InitializeComponent();
        }

        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();

        private void SearchLoanSlip_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "SELECT * FROM tblPhieuMuon AS pm Left JOIN tblDocGia AS dg ON dg.MADG = pm.MADG Left JOIN tblSach AS sa ON pm.MASACH = sa.MASACH Left JOIN tblMuon AS m ON pm.MAPHIEUMUON = m.SOPHIEUMUON AND pm.MASACH = m.MASACH AND pm.MADG = m.MADG ORDER BY pm.MADG , pm.MAPHIEUMUON , pm.MASACH");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "SELECT * FROM tblPhieuMuon AS pm Left JOIN tblDocGia AS dg ON dg.MADG = pm.MADG Left JOIN tblSach AS sa ON pm.MASACH = sa.MASACH Left JOIN tblMuon AS m ON pm.MAPHIEUMUON = m.SOPHIEUMUON AND pm.MASACH = m.MASACH AND pm.MADG = m.MADG WHERE pm.MADG LIKE '%" + txtReaderCode.Text + "%' AND ( m.MASACH LIKE '%" + txtBookCode.Text + "%' OR m.MASACH IS NULL) AND pm.MAPHIEUMUON LIKE '%" + txtLoanCode.Text + "%' AND dg.HOTEN LIKE '%" + txtReaderName.Text + "%' AND dg.LOP LIKE '%" + txtClass.Text + "%' AND dg.DIACHI LIKE '%" + txtReaderAddress.Text + "%' AND dg.NGAYSINH LIKE '%" + txtReaderDateofbirth.Text +"%' AND dg.EMAIL LIKE '%"+ txtEmail.Text +"%' ORDER BY pm.MADG , pm.MAPHIEUMUON , pm.MASACH ");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
