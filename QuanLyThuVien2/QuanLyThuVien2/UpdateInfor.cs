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
    public partial class UpdateInfor : Form
    {
        public UpdateInfor()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();
        private void capnhatnhanvien_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select TENNV,DIACHI,DIENTHOAI,EMAIL,ChucVu,Tuoi from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtSoDienThoai.Text.Length - 1 <= 0)
                MessageBox.Show("Phone number cannot be less than 0 digits");
            else
                if (txtSoDienThoai.Text.Length - 1 > 12)
                MessageBox.Show("Phone number cannot be more than 12 numbers");
            else
                    if (Convert.ToInt32(textTuoi.Text) <= 18 || Convert.ToInt32(textTuoi.Text) > 60)
                MessageBox.Show("wrong age");
            else
            {
                string strUpdate = "update tblNhanVien set TENNV='" + txtNHANVIEN.Text + "',DIACHI='" + txtDiaChi.Text + "',DIENTHOAI='" + txtSoDienThoai.Text + "',EMAIL='" + txtEmail.Text + "',ChucVu='" + textChhucVu.Text + "',Tuoi='" + textTuoi.Text + "' where TAIKHOAN='" + Main.TenDN + "'";
                cls.ThucThiSQLTheoKetNoi(strUpdate);
            }
            cls.LoadData2DataGridView(dataGridView1, "select TENNV,DIACHI,DIENTHOAI,EMAIL,ChucVu,Tuoi from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");
            MessageBox.Show("Successful fix");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNHANVIEN.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoDienThoai.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textChhucVu.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textTuoi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string strDelete = "delete from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'";
            //cls.ThucThiSQLTheoPKN(strDelete);
            //cls.LoadData2DataGridView(dataGridView1, "select * from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");
            //MessageBox.Show("Xóa thành công");
        }
    }
}
