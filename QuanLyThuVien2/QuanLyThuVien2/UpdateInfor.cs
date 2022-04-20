using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
<<<<<<< HEAD
using System.Windows.Forms;
=======
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;
>>>>>>> 15d612f1ceaf65821eedefa0f7945c906334bdd2

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
            cls.LoadData2DataGridView(dataGridView1, "select TENNV,DIACHI,DIENTHOAI,EMAIL,ChucVu,Tuoi from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtSoDienThoai.Text.Length - 1 <= 0)
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
=======
            cls.LoadData2DataGridView(dataGridView1, "select TENNV , DIACHI , DIENTHOAI , EMAIL , ChucVu , Tuoi  from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");

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
        private void button5_Click(object sender, EventArgs e)
        {
            if (txtSoDienThoai.Text.Length < 3)
                MessageBox.Show("Phone number cannot be less than 3 digits");
            else
            {
                if (txtSoDienThoai.Text.Length > 12)
                    MessageBox.Show("Phone number cannot be more than 12 numbers");
                else
                {
                    if (Convert.ToInt32(textTuoi.Text) < 18 || Convert.ToInt32(textTuoi.Text) > 60)
                        MessageBox.Show("Wrong age");
                    else
                    {
                        if (Checkso(textTuoi.Text))
                            MessageBox.Show("Invalid Age!");
                        else
                        {
                            if (CheckTen(txtNHANVIEN.Text))
                                MessageBox.Show("Invalid Name!");
                            else
                            {
                                if (Checkso(txtSoDienThoai.Text))
                                    MessageBox.Show("Invalid Phone Number!");
                                else
                                {
                                    if (!isValidEmail(txtEmail.Text) && !VerifyEmail(txtEmail.Text))
                                        MessageBox.Show("Invalid Email!");
                                    else
                                    {
                                        MessageBox.Show("Edit Successful");
                                    }
                                }
                            }
                        }
                    }
                    {
                        string strUpdate = "update tblNhanVien set TENNV='" + txtNHANVIEN.Text + "',DIACHI='" + txtDiaChi.Text + "',DIENTHOAI='" + txtSoDienThoai.Text + "',EMAIL='" + txtEmail.Text + "',ChucVu='" + textChhucVu.Text + "',Tuoi='" + textTuoi.Text + "' where TAIKHOAN='" + Main.TenDN + "'";
                        cls.ThucThiSQLTheoKetNoi(strUpdate);
                    }
                }
            }
            cls.LoadData2DataGridView(dataGridView1, "select TENNV , DIACHI , DIENTHOAI , EMAIL , ChucVu , Tuoi from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");

>>>>>>> 15d612f1ceaf65821eedefa0f7945c906334bdd2
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNHANVIEN.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoDienThoai.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textChhucVu.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textTuoi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
<<<<<<< HEAD
<<<<<<< HEAD
            
=======

>>>>>>> 15d612f1ceaf65821eedefa0f7945c906334bdd2
=======

>>>>>>> main
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string strDelete = "delete from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'";
            //cls.ThucThiSQLTheoPKN(strDelete);
            //cls.LoadData2DataGridView(dataGridView1, "select * from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");
            //MessageBox.Show("Xóa thành công");
        }
<<<<<<< HEAD
=======

        private void btExitupdate_Click(object sender, EventArgs e)
        {
            Close();
        }
>>>>>>> 15d612f1ceaf65821eedefa0f7945c906334bdd2
    }
}
