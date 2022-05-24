using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using BLL;
using DTO;

namespace LibraryManagement
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttoneyes1_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '\0';
                this.buttoneyes1.Image = global::LibraryManagement.Properties.Resources.eye_hide;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.PasswordChar = '●';
                this.buttoneyes1.Image = global::LibraryManagement.Properties.Resources._103177_see_watch_view_eye_icon;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (!EmployeesBLL.Instance.CheckLogin(username, password))
            {
                FormWrongAccount formWrongAccount = new FormWrongAccount();
                formWrongAccount.Show();
            }
            else
            {
                FormMain m = new FormMain(username);
                m.Show();
                Hide(); 
            }
        }
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the program ?", "FormClosing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void linkForgorpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormForgotPassword formForgotPassword = new FormForgotPassword();
            formForgotPassword.Show();
            Hide();
        }
    }
}
