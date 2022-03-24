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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();
        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            cls.KetNoi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length - 1 < 5)//kiểm tra mật khẩu mới xem co lờn hơn 6 ký tụ ko
                MessageBox.Show("the new password is too short");
            else
                if (textBox2.Text.Length - 1 > 30)//kiểm tra mật khẩu mới xem có bé hơn 30 ký tụ ko
                MessageBox.Show("the new password is too long");
            else
                    if (textBox2.Text != textBox3.Text)//kiểm tra mật khẩu mới và xác nhận mk co trung nha
                MessageBox.Show("The new password does not match, please re-enter it");
            else
                        if (textBox1.Text != Main.MatKhau)//kiểm tra mật khẩu cũ
                MessageBox.Show("The old password is wrong, please re - enter the password");
            else
            {
                try//thục hiên cau lệnh để thay đổi mật khẩu
                {
                    string strUpdate = "Update tblNhanVien set MATKHAU='" + textBox2.Text + "'where MATKHAU='" + textBox1.Text + "'";
                    cls.ThucThiSQLTheoKetNoi(strUpdate);
                    MessageBox.Show("Change password successfully");
                }
                catch (Exception E)
                { MessageBox.Show("" + E.ToString()); }
            }
            //    string strUpdate = "Update tblNhanVien set MATKHAU='" + textBox2.Text + "'where MATKHAU='" + textBox1.Text + "'";
            //    cls.ThucThiSQLTheoKetNoi(strUpdate);
            //    MessageBox.Show("Đổi mật khẩu thành công");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.PasswordChar = '\0';
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox1.PasswordChar = '*';
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

    }
}
