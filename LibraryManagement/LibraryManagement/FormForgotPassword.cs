using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace LibraryManagement
{
    public partial class FormForgotPassword : Form
    {
        public FormForgotPassword()
        {
            InitializeComponent();
            groupboxVeri.Hide();
            groupboxNewpassword.Hide();
            groupLogin.Hide();
            btnBack.Hide();
        }

        string email = "";
        int page = 1;
        private void btnSendCode_Click(object sender, EventArgs e)
        {
            email = txtEmail.Text;
            bool checkmail;
            checkmail = EmployeesBLL.Instance.CheckAndSendMailToReset(email);
            if(checkmail == true)
            {
                groupboxEmail.Hide();
                groupboxVeri.Show();
                page = 2;
                btnBack.Show();

            }
            else
            {
                MessageBox.Show("Invalid Email !!!");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(EmployeesBLL.Instance.CheckOTP(txtVericode.Text))
            {
                MessageBox.Show("Success !");
                txtVericode.Text = "";
                groupboxVeri.Hide();
                groupboxNewpassword.Show();
                page = 3;
            }
            else
                MessageBox.Show("Invalid Code !!!");
        }

        private void btnNewPassword_Click(object sender, EventArgs e)
        {
            if(EmployeesBLL.Instance.ConfirmPassword(txtNewPassword.Text,txtConfirm.Text))
            {
                if (EmployeesBLL.Instance.ChangePassword(email, txtNewPassword.Text))
                {
                    groupLogin.Show();
                    btnBack.Hide();
                    groupboxNewpassword.Hide();
                    txtNewPassword.Text = "";
                    txtConfirm.Text = "";
                }
                else
                    MessageBox.Show("Error !");
            }
            else
                MessageBox.Show("Password Incorrect");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (page == 2)
            {
                groupboxVeri.Hide();
                groupboxEmail.Show();
                page = 1;
                btnBack.Hide();
            }
            else
            {
                groupboxNewpassword.Hide();
                groupboxVeri.Show();
                page = 2;
            }
        }

        private void buttoneyes1_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.UseSystemPasswordChar == true)
            {
                txtNewPassword.UseSystemPasswordChar = false;
                txtConfirm.UseSystemPasswordChar = false;
                txtNewPassword.PasswordChar = '\0';
                txtConfirm.PasswordChar = '\0';
                this.buttoneyes1.Image = global::LibraryManagement.Properties.Resources.eye_hide;
            }
            else
            {
                txtNewPassword.UseSystemPasswordChar = true;
                txtConfirm.UseSystemPasswordChar = true;
                txtNewPassword.PasswordChar = '●';
                txtConfirm.PasswordChar = '●';
                this.buttoneyes1.Image = global::LibraryManagement.Properties.Resources._103177_see_watch_view_eye_icon;
            }
        }

        private void btnSingin_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            Hide();
        }
    }
}
