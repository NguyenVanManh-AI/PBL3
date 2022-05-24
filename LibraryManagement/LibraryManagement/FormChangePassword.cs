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
    public partial class FormChangePassword : Form
    {
        string username;
        public FormChangePassword(string user_name)
        {
            username = user_name;
            InitializeComponent();
            groupBackHome.Hide();
        }

        private void btnbackHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMain formMain = new FormMain(username);
            formMain.Show();
        }

        private void btnNewPassword_Click(object sender, EventArgs e)
        {
            if (EmployeesBLL.Instance.ConfirmPassword(txtNewPassword.Text, txtConfirm.Text))
            {
                if (EmployeesBLL.Instance.CheckUsernamePass(txtNewPassword.Text))
                {
                    if (EmployeesBLL.Instance.CheckOldPassword(username,txtOldPassword.Text))
                    {
                        if (EmployeesBLL.Instance.ChangePasswordByUsername(username, txtNewPassword.Text))
                        {
                            btnbackHome.Hide();
                            groupboxNewpassword.Hide();
                            groupBackHome.Show();
                            txtNewPassword.Text = "";
                            txtConfirm.Text = "";
                            txtOldPassword.Text = "";
                        }
                        else
                        {
                            FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                            formMessageBoxError.Show();
                        }
                    }
                    else
                    {
                        FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Invalid Old Password !!!");
                        formMessageBoxError.Show();
                    }
                }
                else
                {
                    FormMeessageBox formMeessageBox = new FormMeessageBox("Password minimum 10 characters and maximum " +
                        "24 characters including letters and numbers !!!");
                    formMeessageBox.Show();
                }

            }
            else
            {
                FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Password Incorrect !!!");
                formMessageBoxError.Show();
            }
        }
        private void buttoneyes1_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.UseSystemPasswordChar == true)
            {
                txtNewPassword.UseSystemPasswordChar = false;
                txtConfirm.UseSystemPasswordChar = false;
                txtOldPassword.UseSystemPasswordChar = false;
                txtNewPassword.PasswordChar = '\0';
                txtConfirm.PasswordChar = '\0';
                txtOldPassword.PasswordChar = '\0';
                this.buttoneyes1.Image = global::LibraryManagement.Properties.Resources.eye_hide;
            }
            else
            {
                txtNewPassword.UseSystemPasswordChar = true;
                txtConfirm.UseSystemPasswordChar = true;
                txtOldPassword.UseSystemPasswordChar = true;
                txtNewPassword.PasswordChar = '●';
                txtConfirm.PasswordChar = '●';
                txtOldPassword.PasswordChar = '●';
                this.buttoneyes1.Image = global::LibraryManagement.Properties.Resources._103177_see_watch_view_eye_icon;
            }
        }

        private void FormChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the program ?", "FormClosing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                e.Cancel = false;
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
            }

            else
                e.Cancel = true;
        }
    }
}
