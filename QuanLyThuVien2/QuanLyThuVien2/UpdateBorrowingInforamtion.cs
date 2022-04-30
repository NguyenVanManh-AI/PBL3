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
    public partial class UpdateBorrowingInforamtion : Form
    {
        public UpdateBorrowingInforamtion()
        {
            InitializeComponent();
        }


        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();
        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"1234567890";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
        public int numberUndo = 0;

        string madg;
        string maphieumuon;
        string masach;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cboDOCGIA.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                cboMASACH.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboPhieuMuon.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                mktNGAYMUON.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                mktNGAYTRA.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                cboXACNHAN.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtGHICHU.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                madg = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                maphieumuon = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                masach = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
            catch { };
        }




        private void UpdateBorrowingInforamtion_Load(object sender, EventArgs e)
        {
            //cls.LoadData2DataGridView(dataGridView1, "select DISTINCT MADG , MASACH , SOPHIEUMUON , NGAYMUON , NGAYTRA , XACNHANTRA , GHICHU from tblMuon");
            cls.LoadData2DataGridView(dataGridView1, "select m.*, dg.HOTEN, dg.LOP, dg.DIACHI, dg.EMAIL from tblMuon as m left join tblDocGia as dg on m.MADG = dg.MADG");
            cls.LoadData2Combobox(cboDOCGIA, "select MADG from tblDocGia");
            cls.LoadData2Combobox(cboMASACH, "Select MASACH from tblSach");
            cls.LoadData2Combobox(cboPhieuMuon, "Select MAPHIEUMUON from tblPhieuMuon");
            //cls.LoadData2Combobox(cboMAPHIEUMUON, "Select MAPHIEUMUON from tblPhieuMuon where idDocGia = cboDOCGIA.text");
        }

        private void Them_Click(object sender, EventArgs e)
        {
            if (cboDOCGIA.Text != "")
            {
                if (cboMASACH.Text != "")
                {
                    if (cboPhieuMuon.Text != "")
                    {
                        if (!hasSpecialChar(cboPhieuMuon.Text))
                        {
                            MessageBox.Show("Số phiếu mượn chỉ được chứa ký tự số");
                        }
                        else
                        {
                            if (mktNGAYMUON.Text != "")
                            {
                                if (mktNGAYTRA.Text != "")
                                {
                                    if (cboXACNHAN.Text != "")
                                    {
                                        try
                                        {
                                            string strInsert = "Insert Into tblMuon(MADG,MASACH,SOPHIEUMUON,NGAYMUON,NGAYTRA,XACNHANTRA,GHICHU) values ('" + cboDOCGIA.Text + "','" +
                                                cboMASACH.Text + "','" + cboPhieuMuon.Text + "','" + mktNGAYMUON.Text + "','" +
                                                mktNGAYTRA.Text + "','" + cboXACNHAN.Text + "','" + txtGHICHU.Text + "')";
                                            cls.ThucThiSQLTheoPKN(strInsert);

                                            //strInsert = "UPDATE tblPhieuMuon SET MASACH = " + cboMASACH.Text + " WHERE MADG =  "+ cboDOCGIA.Text + " AND MAPHIEUMUON = "+ cboPhieuMuon.Text + "; ";
                                            strInsert = "Insert Into tblPhieuMuon(MASACH, MADG, MAPHIEUMUON) values(" + cboMASACH.Text + "," + cboDOCGIA.Text + "," + cboPhieuMuon.Text + ")";
                                            cls.ThucThiSQLTheoPKN(strInsert);

                                            // để xóa cái hàng null mới lần đầu tạo đi 
                                            strInsert = "DELETE FROM tblPhieuMuon WHERE MASACH IS NULL AND MADG = " + cboDOCGIA.Text + " AND MAPHIEUMUON = " + cboPhieuMuon.Text;
                                            cls.ThucThiSQLTheoPKN(strInsert);



                                            //cls.LoadData2DataGridView(dataGridView1, "select DISTINCT MADG , MASACH , SOPHIEUMUON , NGAYMUON , NGAYTRA , XACNHANTRA , GHICHU from tblMuon");
                                            cls.LoadData2DataGridView(dataGridView1, "select m.*, dg.HOTEN, dg.LOP, dg.DIACHI, dg.EMAIL from tblMuon as m left join tblDocGia as dg on m.MADG = dg.MADG");
                                            MessageBox.Show("Thêm thành công");
                                            cboMASACH.Text = "";
                                            cboDOCGIA.Text = "";
                                            txtGHICHU.Text = "";
                                            cboPhieuMuon.Text = "";
                                            mktNGAYMUON.Text = "";
                                            mktNGAYTRA.Text = "";
                                            cboXACNHAN.Text = "";
                                            numberUndo = 0;
                                        }
                                        catch { MessageBox.Show("Trùng Mã"); };
                                    }
                                    else { MessageBox.Show("Thanh xác nhận không được để trống"); }
                                }
                                else { MessageBox.Show("Ngày trả không được để trống"); }
                            }
                            else { MessageBox.Show("Ngày mượn kh được để trống"); }
                        }
                    }
                    else { MessageBox.Show("Số phiếu mượn không được để trống"); }
                }
                else { MessageBox.Show("Mã sách không được để trống"); }
            }
            else { MessageBox.Show("Mã độc giả không được để trống"); }

        }

        private void Sua_Click(object sender, EventArgs e)
        {

            if (cboDOCGIA.Text != "")
            {
                if (cboMASACH.Text != "")
                {
                    if (cboPhieuMuon.Text != "")
                    {
                        if (!hasSpecialChar(cboPhieuMuon.Text))
                        {
                            MessageBox.Show("Số phiếu mượn chỉ được chứa ký tự số");
                        }
                        else
                        {
                            if (mktNGAYMUON.Text != "")
                            {
                                if (mktNGAYTRA.Text != "")
                                {
                                    if (cboXACNHAN.Text != "")
                                    {

                                        try
                                        {
                                            string strUpdate = "Update tblMuon set MADG = " + cboDOCGIA.Text + " , MASACH = " + cboMASACH.Text + " , SOPHIEUMUON = " + cboPhieuMuon.Text
                                               + " , NGAYMUON = '" + mktNGAYMUON.Text + "' , NGAYTRA = '" + mktNGAYTRA.Text
                                                + "' , XACNHANTRA = '" + cboXACNHAN.Text + "' , GHICHU = '" + txtGHICHU.Text
                                                + "' WHERE MADG =  " + madg + " AND SOPHIEUMUON = " + maphieumuon + " AND MASACH = " + masach;

                                            cls.ThucThiSQLTheoPKN(strUpdate);

                                            MessageBox.Show("Sửa thành công1");
                                            //cls.LoadData2DataGridView(dataGridView1, "select DISTINCT MADG , MASACH , SOPHIEUMUON , NGAYMUON , NGAYTRA , XACNHANTRA , GHICHU from tblMuon");
                                            cls.LoadData2DataGridView(dataGridView1, "select m.*, dg.HOTEN, dg.LOP, dg.DIACHI, dg.EMAIL from tblMuon as m left join tblDocGia as dg on m.MADG = dg.MADG");
                                            strUpdate = "Update tblPhieuMuon set MADG = " + cboDOCGIA.Text + " , MASACH = " + cboMASACH.Text + " , MAPHIEUMUON = " + cboPhieuMuon.Text
                                               + " WHERE MADG =  " + madg + " AND MAPHIEUMUON = " + maphieumuon + " AND MASACH = " + masach;
                                            cls.ThucThiSQLTheoPKN(strUpdate);

                                            //thêm vào là phải xóa null đi nếu có  
                                            string strInsert = "DELETE FROM tblPhieuMuon WHERE MASACH IS NULL AND MADG = " + cboDOCGIA.Text + " AND MAPHIEUMUON = " + cboPhieuMuon.Text;
                                            cls.ThucThiSQLTheoPKN(strInsert);

                                            MessageBox.Show("Sửa thành công 2");
                                            cboMASACH.Text = "";
                                            cboDOCGIA.Text = "";
                                            txtGHICHU.Text = "";
                                            cboPhieuMuon.Text = "";
                                            mktNGAYMUON.Text = "";
                                            mktNGAYTRA.Text = "";
                                            cboXACNHAN.Text = "";
                                            numberUndo = 0;

                                        }
                                        catch { MessageBox.Show("Không thể sửa !!!"); };


                                    }
                                    else { MessageBox.Show("Thanh xác nhận không được để trống"); }
                                }
                                else { MessageBox.Show("Ngày trả không được để trống"); }
                            }
                            else { MessageBox.Show("Ngày mượn kh được để trống"); }
                        }
                    }
                    else { MessageBox.Show("Số phiếu mượn không được để trống"); }
                }
                else { MessageBox.Show("Mã sách không được để trống"); }
            }
            else { MessageBox.Show("Mã độc giả không được để trống"); }



        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    undoMDG = cboDOCGIA.Text;
                    undoMS = cboMASACH.Text;
                    undoSPM = cboPhieuMuon.Text;
                    undoNM = mktNGAYMUON.Text;
                    undoNT = mktNGAYTRA.Text;
                    undoXN = cboXACNHAN.Text;
                    undoGHICHU = txtGHICHU.Text;
                    string strDelete = "Delete from tblMuon where MADG = " + cboDOCGIA.Text + " AND MASACH = " + cboMASACH.Text + " AND SOPHIEUMUON = " + cboPhieuMuon.Text;
                    cls.ThucThiSQLTheoKetNoi(strDelete);
                    strDelete = "Delete from tblPhieuMuon where MADG = " + cboDOCGIA.Text + " AND MASACH = " + cboMASACH.Text + " AND MAPHIEUMUON = " + cboPhieuMuon.Text;
                    cls.ThucThiSQLTheoKetNoi(strDelete);
                    cls.LoadData2DataGridView(dataGridView1, "select m.*, dg.HOTEN, dg.LOP, dg.DIACHI, dg.EMAIL from tblMuon as m left join tblDocGia as dg on m.MADG = dg.MADG");
                    //cls.LoadData2DataGridView(dataGridView1, "select DISTINCT MADG , MASACH , SOPHIEUMUON , NGAYMUON , NGAYTRA , XACNHANTRA , GHICHU from tblMuon");
                    MessageBox.Show("Xóa thành công !!!");
                    cboMASACH.Text = "";
                    cboDOCGIA.Text = "";
                    txtGHICHU.Text = "";
                    cboPhieuMuon.Text = "";
                    mktNGAYMUON.Text = "";
                    mktNGAYTRA.Text = "";
                    cboXACNHAN.Text = "";
                    numberUndo = 1;
                }
            }
            catch { }
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        public string undoMDG, undoMS, undoSPM, undoNM, undoNT, undoXN, undoGHICHU;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select m.*, dg.HOTEN, dg.LOP, dg.DIACHI, dg.EMAIL from tblMuon as m left join tblDocGia as dg on m.MADG = dg.MADG where dg.HOTEN like '%" + txtSearch2.Text + "%' OR dg.DIACHI like '%" + txtSearch2.Text + "%' OR dg.LOP like '%" + txtSearch2.Text + "%' OR dg.EMAIL like '%" + txtSearch2.Text + "%'");
        }
        
        private void btSearch_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select*from tblmuon where madg like'%" + cboDOCGIA.Text + "%'and masach like'%" + cboMASACH.Text + "%'and sophieumuon like'%" + cboPhieuMuon.Text + "%'and ngaymuon like'%" + mktNGAYMUON.Text + "%'and ngaytra like'%" + mktNGAYTRA.Text + "%'and xacnhantra like '%" + cboXACNHAN.Text + "%'");
        }

        private void cboDOCGIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cboDOCGIA.Text);
            cls.LoadData2Combobox(cboPhieuMuon, "Select DISTINCT MAPHIEUMUON from tblPhieuMuon WHERE MADG = " + cboDOCGIA.Text);
            // lọc để không lặp MAPHIEUMUON
            cboPhieuMuon.Text = "";
            cboMASACH.Text = "";
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            if (numberUndo == 1)
            {
                string strInsert = "Insert Into tblMuon(MADG,MASACH,SOPHIEUMUON,NGAYMUON,NGAYTRA,XACNHANTRA,GHICHU) values ('" + undoMDG + "','" +
                                                undoMS + "','" + undoSPM + "','" + undoNM + "','" +
                                                undoNT + "','" + undoXN + "','" + undoGHICHU + "')";
                cls.ThucThiSQLTheoPKN(strInsert);

                strInsert = "Insert Into tblPhieuMuon(MASACH, MADG, MAPHIEUMUON) values(" + undoMS + "," + undoMDG + "," + undoSPM + ")";
                cls.ThucThiSQLTheoPKN(strInsert);

                cls.LoadData2DataGridView(dataGridView1, "select DISTINCT MADG , MASACH , SOPHIEUMUON , NGAYMUON , NGAYTRA , XACNHANTRA , GHICHU from tblMuon");

                MessageBox.Show("Hoàn tác thành công !");
                numberUndo = 0;
            }
        }
    }

}