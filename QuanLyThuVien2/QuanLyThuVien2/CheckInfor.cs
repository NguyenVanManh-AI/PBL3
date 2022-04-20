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
    public partial class CheckInfor : Form
    {
        public CheckInfor()
        {
            InitializeComponent();
        }

        private void KiemTraTTNVien_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView2, "select * from tblNhanVien");
        }
        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenTaiKhoan.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPass.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBoxAr.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTenNhanVien.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDiaChi.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDienThoai.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEmail.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtChucVu.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtTuoi.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        string TenTK;
        // int Dem = 0;





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
            if (txtTenNhanVien.Text == "")
                MessageBox.Show("Employee names cannot be left blank");
            else
                if (txtPass.Text.Length - 1 == 0 || txtPass.Text.Length - 1 == 0)
                MessageBox.Show("Password cannot be left blank");
            //else
            //        if (txtQuyen.Text.Length - 1 == 0)
            //    MessageBox.Show("Permissions cannot be left blank");
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
                string SQL = ("update tblNhanVien set MatKhau='" + txtPass.Text + "',QUYENHAN='" + comboBoxAr.Text
                    + "',TENNV='" + txtTenNhanVien.Text + "',DiaChi='" + txtDiaChi.Text + "',DIENTHOAI='"
                    + txtDienThoai.Text + "',EMAIL='" + txtEmail.Text + "',ChucVu='" + txtChucVu.Text + "',Tuoi='"
                    + txtTuoi.Text + "'where TaiKhoan='" + TenTK + "'");
                cls.ThucThiSQLTheoKetNoi(SQL);
                cls.LoadData2DataGridView(dataGridView2, "select*from tblNhanVien");
                MessageBox.Show("Fixed successfully");
            }

            //}
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string s = txtTenNhanVien.Text;
            if (comboBoxAr.Text == "admin")
                MessageBox.Show("Can't delete admin account");
            else
            {
                if (MessageBox.Show("Are you sure to delete employee information " + s, "Delete Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string SQL = ("delete from tblNhanVien where TaiKhoan='" + txtTenTaiKhoan.Text + "'");
                    cls.ThucThiSQLTheoKetNoi(SQL);
                    cls.LoadData2DataGridView(dataGridView2, "select*from tblNhanVien");
                    MessageBox.Show("Delete successfully");
                    txtTenTaiKhoan.Text = "";
                    txtPass.Text = "";
                    comboBoxAr.Text = "";
                    txtTenNhanVien.Text = "";
                    txtDiaChi.Text = "";
                    txtDienThoai.Text = "";
                    txtEmail.Text = "";
                    txtChucVu.Text = "";
                    txtTuoi.Text = "";
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenTaiKhoan.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPass.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBoxAr.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTenNhanVien.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDiaChi.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDienThoai.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEmail.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtChucVu.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtTuoi.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
