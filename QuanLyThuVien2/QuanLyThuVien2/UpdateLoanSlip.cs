﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


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
        string undoMADG = "", undoMAPHIEUMUON = "";
        int numberUndo = 0;
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
            cls.LoadData2DataGridView(dataGridView1, "select DISTINCT MADG , MAPHIEUMUON , MASACH  from tblPhieuMuon ORDER BY MADG , MAPHIEUMUON , MASACH");
            //cls.LoadData2DataGridView(dataGridView1, "SELECT * FROM tblDocGia AS dg Left JOIN tblPhieuMuon AS pm ON dg.MADG = pm.MADG");
            //cls.LoadData2DataGridView(dataGridView1, "SELECT * FROM tblPhieuMuon AS pm Left JOIN tblDocGia AS dg ON dg.MADG = pm.MADG Left JOIN tblSach AS sa ON pm.MASACH = sa.MASACH ORDER BY pm.MADG");
            cls.LoadData2Combobox(cboDOCGIA, "select MADG from tblDocGia");
            cls.LoadData2Combobox(cboReaderCode2, "select DISTINCT MADG from tblPhieuMuon");
            cboReaderCode2.Items.Add("All");
            dataGridView2.Hide();
            dataGridView1.Show();

            label4.Hide();
            cboMASACH.Hide();

            //cls.LoadData2Combobox(cboMAPHIEUMUON, "Select MAPHIEUMUON from tblPhieuMuon where idDocGia = cboDOCGIA.text");
        }

        private void add_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            numberUndo = 0;
            cls.LoadData3DataGridView(dataGridView1, "select DISTINCT MADG , MAPHIEUMUON , MASACH  from tblPhieuMuon ORDER BY MADG , MAPHIEUMUON , MASACH");
            dataGridView2.Hide();
            dataGridView1.Show();
            cls.LoadData3DataGridView(dataGridView1, "select DISTINCT MADG , MAPHIEUMUON , MASACH  from tblPhieuMuon ORDER BY MADG , MAPHIEUMUON , MASACH");
            if (cboDOCGIA.Text == "")
            {
                MessageBox.Show("Hãy chọn mã người đọc !!!");
            }
            else
            {
                string strInsert = "Insert Into tblPhieuMuon(MADG,MAPHIEUMUON) values (" + cboDOCGIA.Text + ",(SELECT MAX(MAPHIEUMUON)FROM tblPhieuMuON)+1)";
                cls.ThucThiSQLTheoPKN(strInsert);
                //cls.LoadData2DataGridView(dataGridView1, "SELECT * FROM tblPhieuMuon AS pm Left JOIN tblDocGia AS dg ON dg.MADG = pm.MADG Left JOIN tblSach AS sa ON pm.MASACH = sa.MASACH ORDER BY pm.MADG");
            }
            cls.LoadData3DataGridView(dataGridView1, "select DISTINCT MADG , MAPHIEUMUON , MASACH  from tblPhieuMuon ORDER BY MADG , MAPHIEUMUON , MASACH");
            cls.LoadData2Combobox(cboReaderCode2, "select DISTINCT MADG from tblPhieuMuon");
            cboReaderCode2.Items.Add("All");

            MessageBox.Show("Thêm phiếu mượn sách thành công !!!");




        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            numberUndo = 0;
            dataGridView1.Hide();
            dataGridView2.Show();

            if (cboReaderCode2.Text == "")
            {
                MessageBox.Show("Hãy chọn mã người đọc !!!");
            }
            else
            {
                if (cboReaderCode2.Text == "All")
                {
                    cls.LoadData2DataGridView(dataGridView2, "SELECT * FROM tblPhieuMuon AS pm Left JOIN tblDocGia AS dg ON dg.MADG = pm.MADG Left JOIN tblSach AS sa ON pm.MASACH = sa.MASACH Left JOIN tblMuon AS m ON pm.MAPHIEUMUON = m.SOPHIEUMUON AND pm.MASACH = m.MASACH AND pm.MADG = m.MADG ORDER BY pm.MADG , pm.MAPHIEUMUON , pm.MASACH");
                }
                else
                {
                    //MessageBox.Show(cboPhieuMuonCode.Items.Count.ToString());
                    if (cboPhieuMuonCode.Items.Count > 0 && cboPhieuMuonCode.Text == "")
                    {
                        MessageBox.Show("Hãy chọn mã phiếu mượn của người đọc " + cboReaderCode2.Text);
                    }
                    //else if (cboPhieuMuonCode.Items.Count == 0)
                    //{
                    //    MessageBox.Show("Người đọc " + cboReaderCode2.Text + " Chưa mua phiếu !!!");
                    //}
                    else
                    {
                        cls.LoadData2DataGridView(dataGridView2, "SELECT * FROM tblPhieuMuon AS pm Left JOIN tblDocGia AS dg ON dg.MADG = pm.MADG Left JOIN tblSach AS sa ON pm.MASACH = sa.MASACH Left JOIN tblMuon AS m ON pm.MAPHIEUMUON = m.SOPHIEUMUON AND pm.MASACH = m.MASACH AND pm.MADG = m.MADG WHERE dg.MADG = " + cboReaderCode2.Text + " AND pm.MAPHIEUMUON = " + cboPhieuMuonCode.Text + " ORDER BY pm.MADG , pm.MAPHIEUMUON , pm.MASACH");
                    }
                }
            }
            //cls.LoadData2DataGridView(dataGridView1, "select DISTINCT MADG , MAPHIEUMUON , MASACH  from tblPhieuMuon ORDER BY MADG , MAPHIEUMUON , MASACH");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            numberUndo = 0;
            dataGridView2.Hide();
            dataGridView1.Show();
            cls.LoadData3DataGridView(dataGridView1, "select DISTINCT MADG , MAPHIEUMUON , MASACH  from tblPhieuMuon ORDER BY MADG , MAPHIEUMUON , MASACH");
        }





        private void cboReaderCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPhieuMuonCode.Text = "";
            if(cboReaderCode2.Text == "All")
            {

            }
            else
            {
                cls.LoadData2Combobox(cboPhieuMuonCode, "Select DISTINCT MAPHIEUMUON from tblPhieuMuon WHERE MADG = " + cboReaderCode2.Text);
            }
        }

        
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboReaderCode2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cboPhieuMuonCode.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cboMASACH.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            undoMADG = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); 
            undoMAPHIEUMUON = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void cboPhieuMuonCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            cls.LoadData2Combobox(cboMASACH, "Select DISTINCT MASACH from tblPhieuMuon WHERE MADG = " + cboReaderCode2.Text + " AND MAPHIEUMUON = " + cboPhieuMuonCode.Text);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(cboMASACH.Items.Count.ToString());
            //MessageBox.Show(cboMASACH.Items[0].ToString());
            if (cboMASACH.Items[0].ToString() == "")
            {
                string strInsert = "DELETE FROM tblPhieuMuon WHERE MADG = "+ cboReaderCode2.Text + " AND MAPHIEUMUON = " + cboPhieuMuonCode.Text;
                cls.ThucThiSQLTheoPKN(strInsert);
                numberUndo = 1;
                MessageBox.Show("Đã xóa phiếu mượn sách !!!");
            }
            else
            {
                if (MessageBox.Show("Phiếu mượn sách đang được sử dụng!!! Bạn có muốn xóa không ??? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strdelete = "DELETE FROM tblPhieuMuon WHERE MADG = " + cboReaderCode2.Text + " AND MAPHIEUMUON = " + cboPhieuMuonCode.Text;
                    cls.ThucThiSQLTheoPKN(strdelete);

                    strdelete = "DELETE FROM tblMuon WHERE MADG = " + cboReaderCode2.Text + " AND SOPHIEUMUON = " + cboPhieuMuonCode.Text;
                    cls.ThucThiSQLTheoPKN(strdelete);

                    numberUndo = 1;
                }

            }

            // load lại 
            cls.LoadData3DataGridView(dataGridView1, "select DISTINCT MADG , MAPHIEUMUON , MASACH  from tblPhieuMuon ORDER BY MADG , MAPHIEUMUON , MASACH");
            cboReaderCode2.Text = "";
            cboPhieuMuonCode.Text = "";
            cls.LoadData2Combobox(cboReaderCode2, "select DISTINCT MADG from tblPhieuMuon");
            cboReaderCode2.Items.Add("All");
            cls.LoadData2DataGridView(dataGridView2, "SELECT * FROM tblPhieuMuon AS pm Left JOIN tblDocGia AS dg ON dg.MADG = pm.MADG Left JOIN tblSach AS sa ON pm.MASACH = sa.MASACH Left JOIN tblMuon AS m ON pm.MAPHIEUMUON = m.SOPHIEUMUON AND pm.MASACH = m.MASACH AND pm.MADG = m.MADG ORDER BY pm.MADG , pm.MAPHIEUMUON , pm.MASACH");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            numberUndo = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if(numberUndo == 1)
            {
                string strInsert = "Insert Into tblPhieuMuon(MADG,MAPHIEUMUON) values (" + undoMADG + ","+ undoMAPHIEUMUON +")";
                cls.ThucThiSQLTheoPKN(strInsert);
                undoMADG = "";
                undoMAPHIEUMUON = "";

                // load lại 
                cls.LoadData3DataGridView(dataGridView1, "select DISTINCT MADG , MAPHIEUMUON , MASACH  from tblPhieuMuon ORDER BY MADG , MAPHIEUMUON , MASACH");
                cboReaderCode2.Text = "";
                cboPhieuMuonCode.Text = "";
                cls.LoadData2Combobox(cboReaderCode2, "select DISTINCT MADG from tblPhieuMuon");
                cboReaderCode2.Items.Add("All");
                cls.LoadData2DataGridView(dataGridView2, "SELECT * FROM tblPhieuMuon AS pm Left JOIN tblDocGia AS dg ON dg.MADG = pm.MADG Left JOIN tblSach AS sa ON pm.MASACH = sa.MASACH Left JOIN tblMuon AS m ON pm.MAPHIEUMUON = m.SOPHIEUMUON AND pm.MASACH = m.MASACH AND pm.MADG = m.MADG ORDER BY pm.MADG , pm.MAPHIEUMUON , pm.MASACH");
                MessageBox.Show("Hoàn tác thành công !!!");

            }
            else
            {

            }
        }
        //object Q = layGiaTri("select QuyenHan from tblNhanVien where TaiKhoan='" + TenDN + "' and MatKhau='" + hasPass + "'");

    }
}