using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient; // + 


namespace QuanLyThuVien2
{
    public partial class UpdateBorrowingInforamtion : Form
    {
        public UpdateBorrowingInforamtion()
        {
            InitializeComponent();
        }

        // + 
        SqlCommand sqlCommand;
        public Object layGiaTri(string sql) //lay gia tri cua  cot dau tien trong bang 
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = Con;

            //CHi can lay ve gia tri cua mot truong thoi thi dung pt nao ? - ExecuteScalar
            Object obj = sqlCommand.ExecuteScalar(); //neu co loi thi phai xem lai cua lenh SQL o ben kia
            return obj;
            //Ket qua de dau ? - de trong obj
        }

        SqlConnection Con;
        // + 

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
                txtReadercode.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtBookcode.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
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

            dataGridView1.Show();
            dataGridView2.Hide();
            dataGridView3.Hide();
            dataGridView4.Hide();

            try
            {
                Con = new SqlConnection();
                Con.ConnectionString = @"Server =DESKTOP-QCOSLTK\VANMANH;" + "database=Library2; Integrated Security = true";
                Con.Open();
            }
            catch { }

            //cls.LoadData2DataGridView(dataGridView1, "select DISTINCT MADG , MASACH , SOPHIEUMUON , NGAYMUON , NGAYTRA , XACNHANTRA , GHICHU from tblMuon");
            cls.LoadData2DataGridView(dataGridView1, "select m.*, dg.HOTEN, dg.LOP, dg.DIACHI, dg.EMAIL from tblMuon as m left join tblDocGia as dg on m.MADG = dg.MADG");
            //cls.LoadData2Combobox(cboDOCGIA, "select MADG from tblDocGia");
            //cls.LoadData2Combobox(cboMASACH, "Select MASACH from tblSach");
            cls.LoadData2Combobox(cboPhieuMuon, "Select MAPHIEUMUON from tblPhieuMuon");
            //cls.LoadData2Combobox(cboMAPHIEUMUON, "Select MAPHIEUMUON from tblPhieuMuon where idDocGia = cboDOCGIA.text");
        }

        private void Them_Click(object sender, EventArgs e)
        {
            object Q = layGiaTri("SELECT MADG FROM tblDocGia  WHERE MADG like '%" + txtReadercode.Text + "%'");
            string MaDocGia = Convert.ToString(Q);

            Q = layGiaTri("SELECT MASACH FROM tblSach  WHERE MASACH like '%" + txtBookcode.Text + "%'");
            string MaSach = Convert.ToString(Q);

            if (MaDocGia == "")
            {
                MessageBox.Show("Người đọc không tồn tại !!!");
            }

            else if (MaSach == "")
            {
                MessageBox.Show("Sách không tồn tại !!!");
            }
            else
            {
                if (txtReadercode.Text != "")
                {
                    if (txtBookcode.Text != "")
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
                                                string strInsert = "Insert Into tblMuon(MADG,MASACH,SOPHIEUMUON,NGAYMUON,NGAYTRA,XACNHANTRA,GHICHU) values ('" + txtReadercode.Text + "','" +
                                                    txtBookcode.Text + "','" + cboPhieuMuon.Text + "','" + mktNGAYMUON.Text + "','" +
                                                    mktNGAYTRA.Text + "','" + cboXACNHAN.Text + "','" + txtGHICHU.Text + "')";
                                                cls.ThucThiSQLTheoPKN(strInsert);

                                                //strInsert = "UPDATE tblPhieuMuon SET MASACH = " + cboMASACH.Text + " WHERE MADG =  "+ cboDOCGIA.Text + " AND MAPHIEUMUON = "+ cboPhieuMuon.Text + "; ";
                                                strInsert = "Insert Into tblPhieuMuon(MASACH, MADG, MAPHIEUMUON) values('" + txtBookcode.Text + "','" + txtReadercode.Text + "','" + cboPhieuMuon.Text + "')";
                                                cls.ThucThiSQLTheoPKN(strInsert);

                                                // để xóa cái hàng null mới lần đầu tạo đi 
                                                strInsert = "DELETE FROM tblPhieuMuon WHERE MASACH IS NULL AND MADG = '" + txtReadercode.Text + "' AND MAPHIEUMUON = '" + cboPhieuMuon.Text + "'";
                                                cls.ThucThiSQLTheoPKN(strInsert);



                                                //cls.LoadData2DataGridView(dataGridView1, "select DISTINCT MADG , MASACH , SOPHIEUMUON , NGAYMUON , NGAYTRA , XACNHANTRA , GHICHU from tblMuon");
                                                cls.LoadData2DataGridView(dataGridView1, "select m.*, dg.HOTEN, dg.LOP, dg.DIACHI, dg.EMAIL from tblMuon as m left join tblDocGia as dg on m.MADG = dg.MADG");
                                                MessageBox.Show("Thêm thành công");

                                                dataGridView1.Show();
                                                dataGridView2.Hide();
                                                dataGridView3.Hide();
                                                dataGridView4.Hide();

                                                txtBookcode.Text = "";
                                                txtReadercode.Text = "";
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
            

        }

        private void Sua_Click(object sender, EventArgs e)
        {

            if (txtReadercode.Text != "")
            {
                if (txtBookcode.Text != "")
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
                                            string strUpdate = "Update tblMuon set MADG = " + txtReadercode.Text + " , MASACH = " + txtBookcode.Text + " , SOPHIEUMUON = " + cboPhieuMuon.Text
                                               + " , NGAYMUON = '" + mktNGAYMUON.Text + "' , NGAYTRA = '" + mktNGAYTRA.Text
                                                + "' , XACNHANTRA = '" + cboXACNHAN.Text + "' , GHICHU = '" + txtGHICHU.Text
                                                + "' WHERE MADG =  " + madg + " AND SOPHIEUMUON = " + maphieumuon + " AND MASACH = " + masach;

                                            cls.ThucThiSQLTheoPKN(strUpdate);

                                            MessageBox.Show("Sửa thành công1");
                                            //cls.LoadData2DataGridView(dataGridView1, "select DISTINCT MADG , MASACH , SOPHIEUMUON , NGAYMUON , NGAYTRA , XACNHANTRA , GHICHU from tblMuon");
                                            cls.LoadData2DataGridView(dataGridView1, "select m.*, dg.HOTEN, dg.LOP, dg.DIACHI, dg.EMAIL from tblMuon as m left join tblDocGia as dg on m.MADG = dg.MADG");
                                            strUpdate = "Update tblPhieuMuon set MADG = " + txtReadercode.Text + " , MASACH = " + txtBookcode.Text + " , MAPHIEUMUON = " + cboPhieuMuon.Text
                                               + " WHERE MADG =  " + madg + " AND MAPHIEUMUON = " + maphieumuon + " AND MASACH = " + masach;
                                            cls.ThucThiSQLTheoPKN(strUpdate);

                                            //thêm vào là phải xóa null đi nếu có  
                                            string strInsert = "DELETE FROM tblPhieuMuon WHERE MASACH IS NULL AND MADG = " + txtReadercode.Text + " AND MAPHIEUMUON = " + cboPhieuMuon.Text;
                                            cls.ThucThiSQLTheoPKN(strInsert);

                                            MessageBox.Show("Sửa thành công 2");
                                            txtBookcode.Text = "";
                                            txtReadercode.Text = "";
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
                    undoMDG = txtReadercode.Text;
                    undoMS = txtBookcode.Text;
                    undoSPM = cboPhieuMuon.Text;
                    undoNM = mktNGAYMUON.Text;
                    undoNT = mktNGAYTRA.Text;
                    undoXN = cboXACNHAN.Text;
                    undoGHICHU = txtGHICHU.Text;
                    string strDelete = "Delete from tblMuon where MADG = " + txtReadercode.Text + " AND MASACH = " + txtBookcode.Text + " AND SOPHIEUMUON = " + cboPhieuMuon.Text;
                    cls.ThucThiSQLTheoKetNoi(strDelete);
                    strDelete = "Delete from tblPhieuMuon where MADG = " + txtReadercode.Text + " AND MASACH = " + txtBookcode.Text + " AND MAPHIEUMUON = " + cboPhieuMuon.Text;
                    cls.ThucThiSQLTheoKetNoi(strDelete);
                    cls.LoadData2DataGridView(dataGridView1, "select m.*, dg.HOTEN, dg.LOP, dg.DIACHI, dg.EMAIL from tblMuon as m left join tblDocGia as dg on m.MADG = dg.MADG");
                    //cls.LoadData2DataGridView(dataGridView1, "select DISTINCT MADG , MASACH , SOPHIEUMUON , NGAYMUON , NGAYTRA , XACNHANTRA , GHICHU from tblMuon");
                    MessageBox.Show("Xóa thành công !!!");
                    txtBookcode.Text = "";
                    txtReadercode.Text = "";
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtReadercode.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBookcode.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString() != "")
            {
                txtReadercode.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            if(dataGridView4.Rows[e.RowIndex].Cells[5].Value.ToString() != ""){
                txtBookcode.Text = dataGridView4.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void txtReadercode_TextChanged(object sender, EventArgs e)
        {
            cboPhieuMuon.Text = "";
            cls.LoadData2Combobox(cboPhieuMuon, "Select DISTINCT MAPHIEUMUON from tblPhieuMuon WHERE MADG = '" + txtReadercode.Text + "'");
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            object Q = layGiaTri("SELECT MADG FROM tblDocGia  WHERE HOTEN like '%" + txtSearch2.Text + "%' OR LOP like '%" + txtSearch2.Text + "%' OR DIACHI like '%" + txtSearch2.Text + "%' OR EMAIL like '%" + txtSearch2.Text + "%'");
            string NguoiDoc = Convert.ToString(Q);
            //MessageBox.Show(NguoiDoc);

            Q = layGiaTri("Select s.MASACH from tblSach as s left join tblLinhVuc as lv on s.MaLv = lv.MaLv left join tblTacGia as tg on s.MATG = tg.MATG  where s.TENSACH like '%" + txtSearch2.Text + "%' OR lv.TenLv like '%" + txtSearch2.Text + "%' OR tg.TENTG like '%" + txtSearch2.Text + "%'");
            string Sach = Convert.ToString(Q);
            //MessageBox.Show(Sach);

            if (NguoiDoc == "" && Sach == "")
            {

                //MessageBox.Show("Không có nội dung liên quan đến cụm từ tìm kiếm !!!");

            }
            else if (NguoiDoc != "" && Sach == "")
            {
                dataGridView2.Show();
                dataGridView1.Hide();
                dataGridView3.Hide();
                dataGridView4.Hide();
                cls.LoadData3DataGridView(dataGridView2, "SELECT MADG,HOTEN,LOP,DIACHI,EMAIL FROM tblDocGia WHERE HOTEN like '%" + txtSearch2.Text + "%' OR LOP like '%" + txtSearch2.Text + "%' OR DIACHI like '%" + txtSearch2.Text + "%' OR EMAIL like '%" + txtSearch2.Text + "%'");
            }
            else if (NguoiDoc == "" && Sach != "")
            {
                dataGridView3.Show();
                dataGridView1.Hide();
                dataGridView2.Hide();
                dataGridView4.Hide();
                cls.LoadData4DataGridView(dataGridView3, "Select s.MASACH,s.TENSACH,lv.TenLv,tg.TENTG from tblSach as s left join tblLinhVuc as lv on s.MaLv = lv.MaLv left join tblTacGia as tg on s.MATG = tg.MATG  where s.TENSACH like '%" + txtSearch2.Text + "%' OR lv.TenLv like '%" + txtSearch2.Text + "%' OR tg.TENTG like '%" + txtSearch2.Text + "%'");
            }
            else
            {
                dataGridView4.Show();
                dataGridView1.Hide();
                dataGridView2.Hide();
                dataGridView3.Hide();
                cls.LoadData5DataGridView(dataGridView4, "select dg.MADG,dg.HOTEN,dg.LOP,dg.DIACHI,dg.EMAIL,s.MASACH,s.TENSACH,lv.TenLv,tg.TENTG from tblDocGia as dg full outer JOIN tblSach as s on 2=1 left join tblLinhVuc as lv on s.MaLv = lv.MaLv left join tblTacGia as tg on s.MATG = tg.MATG WHERE dg.HOTEN like '%" + txtSearch2.Text + "%' OR dg.LOP like '%" + txtSearch2.Text + "%' OR dg.DIACHI like '%" + txtSearch2.Text + "%' OR dg.EMAIL like '%" + txtSearch2.Text + "%'  OR s.TENSACH like '%" + txtSearch2.Text + "%' OR s.TENSACH like '%" + txtSearch2.Text + "%' OR lv.TenLv like '%" + txtSearch2.Text + "%' OR tg.TENTG like '%" + txtSearch2.Text + "%'");
            }

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboPhieuMuon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // kiểm tra search có không để hiển thị 
            object Q = layGiaTri("SELECT MADG FROM tblDocGia  WHERE HOTEN like '%" + txtSearch2.Text + "%' OR LOP like '%" + txtSearch2.Text + "%' OR DIACHI like '%" + txtSearch2.Text + "%' OR EMAIL like '%" + txtSearch2.Text + "%'");
            string NguoiDoc = Convert.ToString(Q);
            //MessageBox.Show(NguoiDoc);

            Q = layGiaTri("Select s.MASACH from tblSach as s left join tblLinhVuc as lv on s.MaLv = lv.MaLv left join tblTacGia as tg on s.MATG = tg.MATG  where s.TENSACH like '%" + txtSearch2.Text + "%' OR lv.TenLv like '%" + txtSearch2.Text + "%' OR tg.TENTG like '%" + txtSearch2.Text + "%'");
            string Sach = Convert.ToString(Q);
            //MessageBox.Show(Sach);

            if (NguoiDoc == "" && Sach == "")
            {

                MessageBox.Show("Không có nội dung liên quan đến cụm từ tìm kiếm !!!");

            }
            else if (NguoiDoc != "" && Sach == "")
            {
                dataGridView2.Show();
                dataGridView1.Hide();
                dataGridView3.Hide();
                dataGridView4.Hide();
                cls.LoadData3DataGridView(dataGridView2, "SELECT MADG,HOTEN,LOP,DIACHI,EMAIL FROM tblDocGia WHERE HOTEN like '%" + txtSearch2.Text + "%' OR LOP like '%" + txtSearch2.Text + "%' OR DIACHI like '%" + txtSearch2.Text + "%' OR EMAIL like '%" + txtSearch2.Text + "%'");
            }
            else if(NguoiDoc == "" && Sach != "")
            {
                dataGridView3.Show();
                dataGridView1.Hide();
                dataGridView2.Hide();
                dataGridView4.Hide();
                cls.LoadData4DataGridView(dataGridView3, "Select s.MASACH,s.TENSACH,lv.TenLv,tg.TENTG from tblSach as s left join tblLinhVuc as lv on s.MaLv = lv.MaLv left join tblTacGia as tg on s.MATG = tg.MATG  where s.TENSACH like '%" + txtSearch2.Text + "%' OR lv.TenLv like '%" + txtSearch2.Text + "%' OR tg.TENTG like '%" + txtSearch2.Text + "%'");
            }
            else
            {
                dataGridView4.Show();
                dataGridView1.Hide();
                dataGridView2.Hide();
                dataGridView3.Hide();
                cls.LoadData5DataGridView(dataGridView4, "select dg.MADG,dg.HOTEN,dg.LOP,dg.DIACHI,dg.EMAIL,s.MASACH,s.TENSACH,lv.TenLv,tg.TENTG from tblDocGia as dg full outer JOIN tblSach as s on 2=1 left join tblLinhVuc as lv on s.MaLv = lv.MaLv left join tblTacGia as tg on s.MATG = tg.MATG WHERE dg.HOTEN like '%" + txtSearch2.Text + "%' OR dg.LOP like '%" + txtSearch2.Text + "%' OR dg.DIACHI like '%" + txtSearch2.Text + "%' OR dg.EMAIL like '%" + txtSearch2.Text + "%'  OR s.TENSACH like '%" + txtSearch2.Text + "%' OR s.TENSACH like '%" + txtSearch2.Text + "%' OR lv.TenLv like '%" + txtSearch2.Text + "%' OR tg.TENTG like '%" + txtSearch2.Text + "%'");
            }

            //cls.LoadData2DataGridView(dataGridView1, "select m.*, dg.HOTEN, dg.LOP, dg.DIACHI, dg.EMAIL from tblMuon as m left join tblDocGia as dg on m.MADG = dg.MADG where dg.HOTEN like '%" + txtSearch2.Text + "%' OR dg.DIACHI like '%" + txtSearch2.Text + "%' OR dg.LOP like '%" + txtSearch2.Text + "%' OR dg.EMAIL like '%" + txtSearch2.Text + "%'");
            //cls.LoadData3DataGridView(dataGridView2, "select dg.MADG,dg.HOTEN,dg.LOP,dg.DIACHI,dg.EMAIL,s.MASACH,s.TENSACH,lv.TenLv,tg.TENTG from tblDocGia as dg full outer JOIN tblSach as s on 2=1 full outer join tblLinhVuc as lv on s.MaLv = lv.MaLv full outer join tblTacGia as tg on s.MATG = tg.MATG WHERE dg.HOTEN like '%" + txtSearch2.Text + "%' OR dg.LOP like '%" + txtSearch2.Text + "%' OR dg.DIACHI like '%" + txtSearch2.Text + "%' OR dg.EMAIL like '%" + txtSearch2.Text + "%'  OR s.TENSACH like '%" + txtSearch2.Text + "%' OR s.TENSACH like '%" + txtSearch2.Text + "%' OR lv.TenLv like '%" + txtSearch2.Text + "%' OR tg.TENTG like '%" + txtSearch2.Text + "%'");
        }
        
        private void btSearch_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select*from tblmuon where madg like'%" + txtReadercode.Text + "%'and masach like'%" + txtBookcode.Text + "%'and sophieumuon like'%" + cboPhieuMuon.Text + "%'and ngaymuon like'%" + mktNGAYMUON.Text + "%'and ngaytra like'%" + mktNGAYTRA.Text + "%'and xacnhantra like '%" + cboXACNHAN.Text + "%'");
        }

        private void cboDOCGIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cboDOCGIA.Text);
            cls.LoadData2Combobox(cboPhieuMuon, "Select DISTINCT MAPHIEUMUON from tblPhieuMuon WHERE MADG = '" + txtReadercode.Text +"'");
            // lọc để không lặp MAPHIEUMUON
            cboPhieuMuon.Text = "";
            txtBookcode.Text = "";
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