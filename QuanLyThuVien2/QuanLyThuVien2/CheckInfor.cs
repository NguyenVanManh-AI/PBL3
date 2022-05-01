using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace QuanLyThuVien2
{
    public partial class CheckInfor : Form
    {
        public CheckInfor()
        {
            InitializeComponent();
        }
        public int numberUndo = 0;
        public string undoAN = "", undoSN = "", undoAdr = "", undoPN = "", undoEm = "", undoAge = "", undoPs = "", undoTK = "", undoAr = "", pass = "";


        private void KiemTraTTNVien_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select taikhoan,quyenhan,tennv,diachi,dienthoai,email,chucvu,tuoi from tblNhanVien");
        }
        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenTaiKhoan.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAr.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTenNhanVien.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDienThoai.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtChucVu.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtTuoi.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }
        string TenTK;
        // int Dem = 0;
        SqlConnection Con = new SqlConnection();
        public Object layGiaTri(string sql) //lay gia tri cua  cot dau tien trong bang 
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = Con;
            Con.Close();

            //CHi can lay ve gia tri cua mot truong thoi thi dung pt nao ? - ExecuteScalar
            Object obj = sqlCommand.ExecuteScalar(); //neu co loi thi phai xem lai cua lenh SQL o ben kia
            return obj;
            //Ket qua de dau ? - de trong obj
        }

        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from tblNhanVien where taikhoan like '%" + txtSearch2.Text + "%' OR QUYENHAN like '%" + txtSearch2.Text + "%' OR tennv like '%" + txtSearch2.Text + "%' OR diachi like '%" + txtSearch2.Text + "%' OR dienthoai like'%" + txtSearch2.Text + "%' OR email like '%" + txtSearch2.Text + "%' OR chucvu like '%" + txtSearch2.Text + "%' OR tuoi like '%" + txtSearch2.Text + "%'");
            txtTenTaiKhoan.Text = "";
            txtAr.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtChucVu.Text = "";
            txtTuoi.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from tblNhanVien where taikhoan like '%" + txtSearch2.Text + "%' OR QUYENHAN like '%" + txtSearch2.Text + "%' OR tennv like '%" + txtSearch2.Text + "%' OR diachi like '%" + txtSearch2.Text + "%' OR dienthoai like'%" + txtSearch2.Text + "%' OR email like '%" + txtSearch2.Text + "%' OR chucvu like '%" + txtSearch2.Text + "%' OR tuoi like '%" + txtSearch2.Text + "%'");
            txtTenTaiKhoan.Text = "";
            txtAr.Text = "";
            txtTenNhanVien.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtChucVu.Text = "";
            txtTuoi.Text = "";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        public bool VerifyEmail(string emailVerify)
        {
            using (WebClient webclient = new WebClient())
            {
                string url = "http://verify-email.org/";
                NameValueCollection formData = new NameValueCollection();
                formData["check"] = emailVerify;
                byte[] responseBytes = webclient.UploadValues(url, "POST", formData);
                string response = Encoding.ASCII.GetString(responseBytes);
                if (response.Contains("Result: Ok"))
                {
                    return true;
                }
                return false;
            }
        }
        public static bool Checkso(string input)
        {
            string specialChar = @"~!@#$%^&*()_+`qwertyuiopasdfghjklzxcvbnm-=[]\{}|;':,./<>?";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
        public static bool CheckTen(string input)
        {
            string specialChar = @"~!@#$%^&*()_+`1234567890-=[]\{}|;':,./<>?";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //if (Dem == 0)
            //{
            TenTK = txtTenTaiKhoan.Text;
            //btnSua.Enabled = false;
            //Dem = 1;
            //txtPass.Text = txtQuyen.Text = txtTenNhanVien.Text = txtDiaChi.Text
            //  = txtDienThoai.Text = txtEmail.Text = txtChucVu.Text = txtTuoi.Text = "";
            //}
            //else
            //{
            btnXoa.Enabled = true;
            undoSN = txtTenNhanVien.Text;
            undoAdr = txtDiaChi.Text;
            undoPN = txtDienThoai.Text;
            undoEm = txtEmail.Text;
            undoAge = txtTuoi.Text;
            undoPs = txtChucVu.Text;

            if (txtTenNhanVien.Text == "")
                MessageBox.Show("Employee names cannot be left blank");
            else
                 if (txtDiaChi.Text == "")
                MessageBox.Show("The address cannot be left blank");
            else
                            if (txtChucVu.Text == "")
                MessageBox.Show("Position cannot be left blank");
            else
                                if (txtTuoi.Text == "")
                MessageBox.Show("Age cannot be left blank");
            else
                                if (txtEmail.Text == "")
                MessageBox.Show("Email cannot be left blank");
            else
                                    if (txtDienThoai.Text.Length - 1 <= 0 || txtDienThoai.Text.Length - 1 > 12)
                MessageBox.Show("Phone number must be longer than 12 digits and less than 0 digits");
            else
                                        if (txtTuoi.Text.Length - 1 <= 0 || txtTuoi.Text.Length - 1 > 55)
                MessageBox.Show("Wrong age");
            else
            {
                string SQL = ("update tblNhanVien set QUYENHAN='" + txtAr.Text
                    + "',TENNV='" + txtTenNhanVien.Text + "',DiaChi='" + txtDiaChi.Text + "',DIENTHOAI='"
                    + txtDienThoai.Text + "',EMAIL='" + txtEmail.Text + "',ChucVu='" + txtChucVu.Text + "',Tuoi='"
                    + txtTuoi.Text + "'where TaiKhoan='" + TenTK + "'");
                cls.ThucThiSQLTheoKetNoi(SQL);
                cls.LoadData2DataGridView(dataGridView1, "select*from tblNhanVien");
                MessageBox.Show("Fixed successfully");
                numberUndo = 1;
            }

            //}
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Con = new SqlConnection();
            Con.ConnectionString = @"Server =DESKTOP-QCOSLTK\VANMANH;" + "database=Library2; Integrated Security = true";
            Con.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "select matkhau from tblnhanvien where taikhoan='" + txtTenTaiKhoan.Text + "'";
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = Con;

            //CHi can lay ve gia tri cua mot truong thoi thi dung pt nao ? - ExecuteScalar
            Object obj = sqlCommand.ExecuteScalar();
            //object Q = layGiaTri("select matkhau from tblnhanvien where taikhoan='" + txtTenTaiKhoan.Text+"'");
            Con.Close();
            pass = Convert.ToString(obj);
            undoTK = txtTenTaiKhoan.Text;
            undoAr = txtAr.Text;
            undoSN = txtTenNhanVien.Text;
            undoAdr = txtDiaChi.Text;
            undoPN = txtDienThoai.Text;
            undoEm = txtEmail.Text;
            undoAge = txtTuoi.Text;
            undoPs = txtChucVu.Text;
            string s = txtTenNhanVien.Text;
            if (txtAr.Text == "admin")
                MessageBox.Show("Can't delete admin account");
            else
            {
                if (MessageBox.Show("Are you sure to delete employee information " + s, "Delete Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string SQL = ("delete from tblNhanVien where TaiKhoan='" + txtTenTaiKhoan.Text + "'");
                    cls.ThucThiSQLTheoKetNoi(SQL);
                    cls.LoadData2DataGridView(dataGridView1, "select*from tblNhanVien");
                    MessageBox.Show("Delete successfully");
                    txtTenTaiKhoan.Text = "";
                    txtAr.Text = "";
                    txtTenNhanVien.Text = "";
                    txtDiaChi.Text = "";
                    txtDienThoai.Text = "";
                    txtEmail.Text = "";
                    txtChucVu.Text = "";
                    txtTuoi.Text = "";
                    numberUndo = 1;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

         

        private void btSearch_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from tblNhanVien where taikhoan like '%" + txtTenTaiKhoan.Text + "%' and tennv like '%" + txtTenNhanVien.Text + "%' and diachi like '%" + txtDiaChi.Text + "%' and dienthoai like'%" + txtDienThoai.Text + "%' and email like '%" + txtEmail.Text + "%' and chucvu like '%" + txtChucVu.Text + "%' and tuoi like '%" + txtTuoi.Text + "%'");
        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            if (numberUndo == 1)
            {
                //string strInsert = "Insert into tblNhanVien(taikhoan,matkhau,quyenhan,tennv,diachi,dienthoai,email,chucvu,tuoi) values ('vanmanhav','vanmanhr22','user','','','','','','')";
                string strInsert = "Insert into tblNhanVien(taikhoan,matkhau,quyenhan,tennv,diachi,dienthoai,email,chucvu,tuoi) values ('" + undoTK + "','" + pass + "','" + undoAr + "','" + undoSN + "','" + undoAdr + "','" + undoPN + "','" + undoEm + "','" + undoPs + "','" + undoAge + "')";
                cls.ThucThiSQLTheoPKN(strInsert);
                cls.LoadData2DataGridView(dataGridView1, "select * from tblNhanVien");
                MessageBox.Show("Hoàn tác thành công !");
                numberUndo = 0;
            }
        }
    }
}
