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
    public partial class UpdateLoanSlip : Form
    {
        public UpdateLoanSlip()
        {
            InitializeComponent();
            //cboReaderCode2.Items.Add("All");
        }

        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        cboDOCGIA.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        //        cboMASACH.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        //        txtSOPHIEU.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        //        mktNGAYMUON.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        //        mktNGAYTRA.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        //        cboXACNHAN.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        //        txtGHICHU.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        //        madg = cboDOCGIA.Text;
        //    }
        //    catch { };
        //}

        private void UpdateLoanSlip_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from tblPhieuMuon");
            //cls.LoadData2DataGridView(dataGridView1, "SELECT * FROM tblDocGia AS dg Left JOIN tblPhieuMuon AS pm ON dg.MADG = pm.MADG");
            //cls.LoadData2DataGridView(dataGridView1, "SELECT * FROM tblPhieuMuon AS pm Left JOIN tblDocGia AS dg ON dg.MADG = pm.MADG Left JOIN tblSach AS sa ON pm.MASACH = sa.MASACH ORDER BY pm.MADG");
            cls.LoadData2Combobox(cboDOCGIA, "select MADG from tblDocGia");
            cls.LoadData2Combobox(cboReaderCode2, "select MADG from tblDocGia");
            cboReaderCode2.Items.Add("All");
            dataGridView2.Hide();
            dataGridView1.Show();

            //cls.LoadData2Combobox(cboMAPHIEUMUON, "Select MAPHIEUMUON from tblPhieuMuon where idDocGia = cboDOCGIA.text");
        }

        private void add_Click(object sender, EventArgs e)
        {
            dataGridView2.Hide();
            dataGridView1.Show();
            string strInsert = "Insert Into tblPhieuMuon(MADG) values ('" + cboDOCGIA.Text + "')";
            cls.ThucThiSQLTheoPKN(strInsert);
            cls.LoadData2DataGridView(dataGridView1, "select * from tblPhieuMuon");
            //cls.LoadData2DataGridView(dataGridView1, "SELECT * FROM tblPhieuMuon AS pm Left JOIN tblDocGia AS dg ON dg.MADG = pm.MADG Left JOIN tblSach AS sa ON pm.MASACH = sa.MASACH ORDER BY pm.MADG");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Show();

            if (cboReaderCode2.Text == "All")
            {
                cls.LoadData2DataGridView(dataGridView2, "SELECT * FROM tblPhieuMuon AS pm Left JOIN tblDocGia AS dg ON dg.MADG = pm.MADG Left JOIN tblSach AS sa ON pm.MASACH = sa.MASACH ORDER BY pm.MADG");
            }
            else
            {
                cls.LoadData2DataGridView(dataGridView2, "SELECT * FROM tblPhieuMuon AS pm Left JOIN tblDocGia AS dg ON dg.MADG = pm.MADG Left JOIN tblSach AS sa ON pm.MASACH = sa.MASACH WHERE dg.MADG = "+ cboReaderCode2 .Text + " ORDER BY pm.MADG");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
        }
    }
}
