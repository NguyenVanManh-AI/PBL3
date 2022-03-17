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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();
        private void Register_Load(object sender, EventArgs e)
        {
            cls.KetNoi();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length - 1 < 5)
                MessageBox.Show("Account name is too short");
            else
                if (textBox1.Text.Length - 1 > 30)
                MessageBox.Show("Account name is too long");
            else
                    if (textBox2.Text.Length - 1 < 5)
                MessageBox.Show("Password is too short");
            else
                        if (textBox3.Text.Length - 1 > 30)
                MessageBox.Show("Password is too long");
            else
                            if (textBox2.Text != textBox3.Text)
                MessageBox.Show("Passwords do not match");
            else
            {
                try
                {
                    cls.ThucThiSQLTheoPKN("insert into tblNhanVien(TAIKHOAN,MATKHAU,QUYENHAN)values('" + textBox1.Text + "','" + textBox2.Text + "','user')");
                    MessageBox.Show("Successful account creation, please update the account information");
                }
                catch { MessageBox.Show("Unable to create an account"); }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
