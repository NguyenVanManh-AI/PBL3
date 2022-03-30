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
<<<<<<< HEAD
<<<<<<< HEAD
            cls.LoadData2DataGridView(dataGridView1, "select TENNV , DIACHI , DIENTHOAI , EMAIL , ChucVu , Tuoi  from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");

=======
            cls.LoadData2DataGridView(dataGridView1, "select TENNV,DIACHI,DIENTHOAI,EMAIL,ChucVu,Tuoi from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");
>>>>>>> main
=======
            cls.LoadData2DataGridView(dataGridView1, "select TENNV , DIACHI , DIENTHOAI , EMAIL , ChucVu , Tuoi  from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");

>>>>>>> aeada7609291a07fc93389c96bc5cc05f4583939
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select TENNV , DIACHI , DIENTHOAI , EMAIL , ChucVu , Tuoi from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");
            if (txtSoDienThoai.Text.Length - 1 <= 0)
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> aeada7609291a07fc93389c96bc5cc05f4583939
                MessageBox.Show("Phone number cannot be less than 0 digits");
            else
            {
                if (txtSoDienThoai.Text.Length - 1 > 12)
                    MessageBox.Show("Phone number cannot be more than 12 numbers");
                else
                {
                    if (Convert.ToInt32(textTuoi.Text) <= 18 || Convert.ToInt32(textTuoi.Text) > 60)
                        MessageBox.Show("wrong age");
                    if (txtNHANVIEN.Text == "")
                        MessageBox.Show("Staff's Name can't be left bank");
                    else
                        if (txtDiaChi.Text == "")
                        MessageBox.Show("Address can't be left bank");
                    else
                        if (txtEmail.Text == "")
                        MessageBox.Show("Email can't be left bank");
                    else
                        if (textChhucVu.Text == "")
                        MessageBox.Show("Position can't be left bank");
                    else
                        {
                            string strUpdate = "update tblNhanVien set TENNV='" + txtNHANVIEN.Text + "',DIACHI='" + txtDiaChi.Text + "',DIENTHOAI='" + txtSoDienThoai.Text + "',EMAIL='" + txtEmail.Text + "',ChucVu='" + textChhucVu.Text + "',Tuoi='" + textTuoi.Text + "' where TAIKHOAN='" + Main.TenDN + "'";
                            cls.ThucThiSQLTheoKetNoi(strUpdate);
                            MessageBox.Show("Edit Successful");
                        }
                }         
            }
<<<<<<< HEAD
            cls.LoadData2DataGridView(dataGridView1, "select TENNV , DIACHI , DIENTHOAI , EMAIL , ChucVu , Tuoi from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");
            MessageBox.Show("Edit Successful");
=======
                MessageBox.Show("Số điện thoại không thể nhỏ hơn 0 số");
            else
                if (txtSoDienThoai.Text.Length - 1 > 12)
                MessageBox.Show("Số điện thoại không thể lớn hơn 12 số");
            else
                    if (textTuoi.Text.Length - 1 <= 18 && textTuoi.Text.Length - 1 > 55)
                MessageBox.Show("sai tuổi");
            else
            {
                string strUpdate = "update tblNhanVien set TENNV='" + txtNHANVIEN.Text + "',DIACHI='" + txtDiaChi.Text + "',DIENTHOAI='" + txtSoDienThoai.Text + "',EMAIL='" + txtEmail.Text + "',ChucVu='" + textChhucVu.Text + "',Tuoi='" + textTuoi.Text + "' where TAIKHOAN='" + Main.TenDN + "'";
                cls.ThucThiSQLTheoKetNoi(strUpdate);
            }
            cls.LoadData2DataGridView(dataGridView1, "select TENNV,DIACHI,DIENTHOAI,EMAIL,ChucVu,Tuoi from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");
            MessageBox.Show("Sửa thành công");
>>>>>>> main
=======
>>>>>>> aeada7609291a07fc93389c96bc5cc05f4583939
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
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> aeada7609291a07fc93389c96bc5cc05f4583939

        private void btExitupdate_Click(object sender, EventArgs e)
        {
            Close();
        }
<<<<<<< HEAD
=======
>>>>>>> main
=======
>>>>>>> aeada7609291a07fc93389c96bc5cc05f4583939
    }
}
