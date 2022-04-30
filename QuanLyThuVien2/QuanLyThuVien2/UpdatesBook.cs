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
    public partial class UpdatesBook : Form
    {
        public UpdatesBook()
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
            string specialChar = @"123456789";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        public static bool hasSpecialChar2(string input)
        {
            string specialChar = @"0123456789";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        

        public int numberUndo = 0;

        string masach;
        private void Sua_Click(object sender, EventArgs e)
        {

            if (txtMASACH.Text != "")
            {
                if (txtTENSACH.Text != "")

                {
                    if (txtNAMXB.Text != "")
                    {
                        if (!hasSpecialChar(txtNAMXB.Text))
                        {
                            MessageBox.Show("Năm xuất bản chỉ được chứa ký tự số");
                        }
                        else
                        {

                            if (txtSOTRANG.Text != "")
                            {
                                if (!hasSpecialChar(txtSOTRANG.Text))
                                {
                                    MessageBox.Show("Số trang chỉ được chứa ký tự số");

                                }
                                else
                                {
                                    if (txtSOLUONG.Text != "")
                                    {
                                        if (!hasSpecialChar(txtSOLUONG.Text))
                                        {
                                            MessageBox.Show("Số lượng chỉ được chứa ký tự số");
                                        }
                                        else
                                        {
                                            if (txtsachhong.Text != "")
                                            {
                                                if (!hasSpecialChar2(txtsachhong.Text))
                                                {
                                                    MessageBox.Show("Số sách hỏng chỉ được chứa ký tự số");
                                                }
                                                else
                                                {
                                                    if (maskedTextBox1.Text != "")
                                                    {

                                                        try
                                                        {
                                                            string strUpdate = "Update tblSach set MASACH='" + txtMASACH.Text + "',TENSACH= N'" + txtTENSACH.Text + "',MATG='" + cboMATG.Text + "',MANXB='" + cboMANXB.Text + "',MaLv='" + cboMALv.Text + "',NAMXB='" + txtNAMXB.Text + "',SOTRANG='" + txtSOTRANG.Text + "',SOLUONG='" + txtSOLUONG.Text + "',SOSACHHONG='" + txtsachhong.Text + "',NGAYNHAP='" + maskedTextBox1.Text + "',GHICHU='" + txtGHICHU.Text + "' where MASACH='" + masach + "'";
                                                            cls.ThucThiSQLTheoPKN(strUpdate);
                                                            cls.LoadData2DataGridView(dataGridView1, "select s.MASACH,s.TENSACH,s.MATG,s.MANXB,s.MaLv,lv.TenLv,nxb.TENNXB,tg.TENTG,s.NAMXB,s.SOTRANG,s.SOLUONG,s.SOSACHHONG,s.NGAYNHAP,s.GHICHU from tblSach as s left join tblLinhVuc as lv on s.MaLv = lv.MaLv left join tblNXB as nxb on s.MANXB = nxb.MANXB left join tblTacGia as tg on s.MATG = tg.MATG ");
                                                            MessageBox.Show("Sửa thành công");
                                                            txtMASACH.Text = "";
                                                            txtTENSACH.Text = "";
                                                            txtNAMXB.Text = "";
                                                            txtSOTRANG.Text = "";
                                                            txtSOLUONG.Text = "";
                                                            txtsachhong.Text = "";
                                                            maskedTextBox1.Text = "";
                                                            txtGHICHU.Text = "";
                                                            cboMALv.Text = "";
                                                            //cbotenLV.Text = "";
                                                            cboMATG.Text = "";
                                                            //cbotenTG.Text = "";
                                                            cboMANXB.Text = "";
                                                            //cbotenNXB.Text = "";
                                                            txtTenLV.Text = "";
                                                            txtTenTG.Text = "";
                                                            txtTenNXB.Text = "";

                                                            numberUndo = 0;

                                                        }
                                                        catch { }
                                                    }
                                                    else { MessageBox.Show("Ngày nhập không được để trống"); }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Số sách hỏng không được để trống");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Số lượng sách không được bỏ trống");
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show("Số trang không được để trống");
                            }
                        }
                    }
                    else { MessageBox.Show("Năm xuất bản không được để trống"); }


                }
                else
                {
                    MessageBox.Show("Tên sách không được để trống");
                }
            }
            else
            {
                MessageBox.Show("Mã sách không được để trống ");
            }

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMASACH.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTENSACH.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboMATG.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cboMANXB.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                cboMALv.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNAMXB.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtSOTRANG.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtSOLUONG.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtsachhong.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                txtGHICHU.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                masach = txtMASACH.Text;
                //cls.LoadData2Combobox(cbotenNXB, "select DISTINCT TENNXB from tblNXB where MANXB = " + cboMANXB.Text);
                //cls.LoadData2Combobox(cbotenTG, "select DISTINCT TenTG from tblTacGia where MATG = " + cboMATG.Text);
                //cls.LoadData2Combobox(cbotenLV, "select DISTINCT TenLv from tblLinhVuc where MaLv = " + cbotenLV.Text);
                object Q = layGiaTri("select TENNXB from tblNXB where MANXB = '" + cboMANXB.Text + "'");
                string giatri = Convert.ToString(Q);
                txtTenNXB.Text = giatri;

                Q = layGiaTri("select TenTG from tblTacGia where MATG = '" + cboMATG.Text + "'");
                giatri = Convert.ToString(Q);
                txtTenTG.Text = giatri;

                Q = layGiaTri("select TenLv from tblLinhVuc where MaLv = '" + cboMALv.Text + "'");
                giatri = Convert.ToString(Q);
                txtTenLV.Text = giatri;
            }
            catch { };
        }

        private void txtsachhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void cbotenLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboMALv.SelectedIndex = cbotenLV.SelectedIndex;
        }

        private void cboMALv_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbotenLV.SelectedIndex = cboMALv.SelectedIndex;
        }

        private void cbotenTG_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboMATG.SelectedIndex = cbotenTG.SelectedIndex;
        }

        private void cboMATG_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbotenTG.SelectedIndex = cboMATG.SelectedIndex;
        }

        private void cbotenNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboMANXB.SelectedIndex = cbotenNXB.SelectedIndex;
        }

        private void cboMANXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbotenNXB.SelectedIndex = cboMANXB.SelectedIndex;
        }

        private void UpdatesBook_Load(object sender, EventArgs e)
        {
            try
            {
                Con = new SqlConnection();
                Con.ConnectionString = @"Server =DESKTOP-QCOSLTK\VANMANH;" + "database=Library2; Integrated Security = true";
                Con.Open();
            }
            catch { }

            cls.LoadData2DataGridView(dataGridView1, "select s.MASACH,s.TENSACH,s.MATG,s.MANXB,s.MaLv,lv.TenLv,nxb.TENNXB,tg.TENTG,s.NAMXB,s.SOTRANG,s.SOLUONG,s.SOSACHHONG,s.NGAYNHAP,s.GHICHU from tblSach as s left join tblLinhVuc as lv on s.MaLv = lv.MaLv left join tblNXB as nxb on s.MANXB = nxb.MANXB left join tblTacGia as tg on s.MATG = tg.MATG ");
            cls.LoadData2Combobox(cboMATG, "select MATG from tblTacGia");
            cls.LoadData2Combobox(cboMANXB, "select MANXB from tblNXB");
            cls.LoadData2Combobox(cboMALv, "select MaLv from tblLinhVuc");
            //cls.LoadData2Combobox(cbotenLV, "select TenLv from tblLinhVuc");
            //cls.LoadData2Combobox(cbotenTG, "Select TENTG from tblTacGia");
            //cls.LoadData2Combobox(cbotenNXB, "Select TENNXB from tblNXB");
        }

        private void Them_Click(object sender, EventArgs e)
        {
            if (txtMASACH.Text != "")
            {
                if (txtTENSACH.Text != "")

                {
                    if (txtNAMXB.Text != "")
                    {
                        if (!hasSpecialChar(txtNAMXB.Text))
                        {
                            MessageBox.Show("Năm xuất bản chỉ được chứa ký tự số");
                        }
                        else
                        {

                            if (txtSOTRANG.Text != "")
                            {
                                if (!hasSpecialChar(txtSOTRANG.Text))
                                {
                                    MessageBox.Show("Số trang chỉ được chứa ký tự số");

                                }
                                else
                                {
                                    if (txtSOLUONG.Text != "")
                                    {
                                        if (!hasSpecialChar(txtSOLUONG.Text))
                                        {
                                            MessageBox.Show("Số lượng chỉ được chứa ký tự số");
                                        }
                                        else
                                        {
                                            if (txtsachhong.Text != "")
                                            {
                                                if (!hasSpecialChar2(txtsachhong.Text))
                                                {
                                                    MessageBox.Show("Số sách hỏng chỉ được chứa ký tự số");
                                                }
                                                else
                                                {
                                                    if (maskedTextBox1.Text != "")
                                                    {

                                                        try
                                                        {
                                                            string strInsert = "Insert Into tblSach(MASACH,TENSACH,MATG,MANXB,MALv,NAMXB,SOTRANG,SOLUONG,SOSACHHONG,NGAYNHAP,GHICHU) values ('" + txtMASACH.Text
                                                        + "',N'" + txtTENSACH.Text + "','" + cboMATG.Text + "','" + cboMANXB.Text + "','"
                                                        + cboMALv.Text + "','" + txtNAMXB.Text + "','" + txtSOTRANG.Text + "','" + txtSOLUONG.Text
                                                         + "','" + txtsachhong.Text + "','" + maskedTextBox1.Text + "','" + txtGHICHU.Text + "')";

                                                            cls.ThucThiSQLTheoPKN(strInsert);
                                                            cls.LoadData2DataGridView(dataGridView1, "select s.MASACH,s.TENSACH,s.MATG,s.MANXB,s.MaLv,lv.TenLv,nxb.TENNXB,tg.TENTG,s.NAMXB,s.SOTRANG,s.SOLUONG,s.SOSACHHONG,s.NGAYNHAP,s.GHICHU from tblSach as s left join tblLinhVuc as lv on s.MaLv = lv.MaLv left join tblNXB as nxb on s.MANXB = nxb.MANXB left join tblTacGia as tg on s.MATG = tg.MATG ");
                                                            MessageBox.Show("Bạn đã thêm thành công");
                                                            txtMASACH.Text = "";
                                                            txtTENSACH.Text = "";
                                                            txtNAMXB.Text = "";
                                                            txtSOTRANG.Text = "";
                                                            txtSOLUONG.Text = "";
                                                            txtsachhong.Text = "";
                                                            maskedTextBox1.Text = "";
                                                            txtGHICHU.Text = "";
                                                            cboMALv.Text = "";
                                                            //cbotenLV.Text = "";
                                                            cboMATG.Text = "";
                                                            //cbotenTG.Text = "";
                                                            cboMANXB.Text = "";
                                                            //cbotenNXB.Text = "";
                                                            txtTenLV.Text = "";
                                                            txtTenTG.Text = "";
                                                            txtTenNXB.Text = "";
                                                            numberUndo = 0;

                                                        }
                                                        catch { }
                                                    }
                                                    else { MessageBox.Show("Ngày nhập không được để trống"); }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Số sách hỏng không được để trống");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Số lượng sách không được bỏ trống");
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show("Số trang không được để trống");
                            }
                        }
                    }
                    else { MessageBox.Show("Năm xuất bản không được để trống"); }


                }
                else
                {
                    MessageBox.Show("Tên sách không được để trống");
                }
            }
            else
            {
                MessageBox.Show("Mã sách không được để trống ");
            }

        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    undoMS = txtMASACH.Text;
                    undoTS = txtTENSACH.Text;
                    undoMaLV = cboMALv.Text;
                    undoNXB = txtNAMXB.Text;
                    undoST = txtSOTRANG.Text;
                    undoSL = txtSOLUONG.Text;
                    undoSSH = txtsachhong.Text;
                    undoGHICHU = txtGHICHU.Text;
                    undoNN = maskedTextBox1.Text;
                    undoMaNXB = cboMANXB.Text;
                    undoMaTG = cboMATG.Text;
                    string strDelete = "Delete from tblSach where MASACH='" + txtMASACH.Text + "'";
                    cls.ThucThiSQLTheoKetNoi(strDelete);
                    cls.LoadData2DataGridView(dataGridView1, "select s.MASACH,s.TENSACH,s.MATG,s.MANXB,s.MaLv,lv.TenLv,nxb.TENNXB,tg.TENTG,s.NAMXB,s.SOTRANG,s.SOLUONG,s.SOSACHHONG,s.NGAYNHAP,s.GHICHU from tblSach as s left join tblLinhVuc as lv on s.MaLv = lv.MaLv left join tblNXB as nxb on s.MANXB = nxb.MANXB left join tblTacGia as tg on s.MATG = tg.MATG ");
                    MessageBox.Show("Xóa thành công !!!");
                    txtMASACH.Text = "";
                    txtTENSACH.Text = "";
                    txtNAMXB.Text = "";
                    txtSOTRANG.Text = "";
                    txtSOLUONG.Text = "";
                    txtsachhong.Text = "";
                    maskedTextBox1.Text = "";
                    txtGHICHU.Text = "";
                    cboMALv.Text = "";
                    //cbotenLV.Text = "";
                    cboMATG.Text = "";
                    //cbotenTG.Text = "";
                    cboMANXB.Text = "";
                    //cbotenNXB.Text = "";
                    txtTenLV.Text = "";
                    txtTenTG.Text = "";
                    txtTenNXB.Text = "";

                    numberUndo = 1;
                }
            }
            catch { }

        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        public string undoMS, undoTS, undoMaLV, undoNXB, undoST, undoSL, undoSSH, undoGHICHU, undoNN, undoMaNXB, undoMaTG;

        private void cboMANXB_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            object Q = layGiaTri("select TENNXB from tblNXB where MANXB = '" + cboMANXB.Text + "'");
            string giatri = Convert.ToString(Q);
            txtTenNXB.Text = giatri;
        }

        private void cboMATG_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            object Q = layGiaTri("select TenTG from tblTacGia where MATG = '" + cboMATG.Text + "'");
            string giatri = Convert.ToString(Q);
            txtTenTG.Text = giatri;
        }

        private void cboMALv_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            object Q = layGiaTri("select TenLv from tblLinhVuc where MaLv = '" + cboMALv.Text + "'");
            string giatri = Convert.ToString(Q);
            txtTenLV.Text = giatri;
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select s.MASACH,s.TENSACH,s.MATG,s.MANXB,s.MaLv,lv.TenLv,nxb.TENNXB,tg.TENTG,s.NAMXB,s.SOTRANG,s.SOLUONG,s.SOSACHHONG,s.NGAYNHAP,s.GHICHU from tblSach as s left join tblLinhVuc as lv on s.MaLv = lv.MaLv left join tblNXB as nxb on s.MANXB = nxb.MANXB left join tblTacGia as tg on s.MATG = tg.MATG where s.MaLv like '%" + txtSearch2.Text + "%' OR s.TENSACH like '%" + txtSearch2.Text + "%'  OR lv.TenLv like '%" + txtSearch2.Text + "%' OR tg.TENTG like '%" + txtSearch2.Text + "%' OR nxb.TENNXB like '%" + txtSearch2.Text + "%'");
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            //SearchBooks sb = new SearchBooks();
            //sb.Show();
            cls.LoadData2DataGridView(dataGridView1, "select * from tblSach where MASACH like '%" + txtMASACH.Text + "%' AND TENSACH like '%" + txtTENSACH.Text + "%' AND NAMXB like '%" + txtNAMXB.Text + "%' AND SOLUONG like '%" + txtSOLUONG.Text + "%' AND MATG like '%" + cboMATG.Text + "%' AND MANXB like '%" + cboMANXB.Text + "%' AND MaLV like '%" + cboMALv.Text + "%'");
            //  "%' AND NGAYNHAP like '%" + maskedTextBox1.Text + "%'");
            txtMASACH.Text = "";
            txtTENSACH.Text = "";
            txtNAMXB.Text = "";
            txtSOTRANG.Text = "";
            txtSOLUONG.Text = "";
            txtsachhong.Text = "";
            maskedTextBox1.Text = "";
            txtGHICHU.Text = "";
            cboMALv.Text = "";
            //cbotenLV.Text = "";
            txtTenLV.Text = "";
            cboMATG.Text = "";
            //cbotenTG.Text = "";
            txtTenTG.Text = "";
            cboMANXB.Text = "";
            //cbotenNXB.Text = "";
            txtTenNXB.Text = "";


        }

        private void Undo_Click(object sender, EventArgs e)
        {
            if (numberUndo == 1)
            {
                string strInsert = "Insert Into tblSach(MASACH,TENSACH,MATG,MANXB,MALv,NAMXB,SOTRANG,SOLUONG,SOSACHHONG,NGAYNHAP,GHICHU) values ('" + undoMS
                                                        + "',N'" + undoTS + "','" + undoMaTG + "','" + undoMaNXB + "','"
                                                        + undoMaLV + "','" + undoNXB + "','" + undoST + "','" + undoSL
                                                         + "','" + undoSSH + "','" + undoNN + "','" + undoGHICHU + "')";
                cls.ThucThiSQLTheoPKN(strInsert);
                cls.LoadData2DataGridView(dataGridView1, "select * from tblSach");
                MessageBox.Show("Hoàn tác thành công !");
                numberUndo = 0;
            }
        }
    }
}
