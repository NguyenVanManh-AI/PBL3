using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace LibraryManagement
{
    public partial class UC_AddAccounts : UserControl
    {
        public UC_AddAccounts()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            if (EmployeesBLL.Instance.CreatedAcount(username,password,email) == "true")
            {
                FormMessageBoxSuccess formMessageBoxSuccess = new FormMessageBoxSuccess("Successful account creation, please update the account information !");
                formMessageBoxSuccess.Show();
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
            else if(EmployeesBLL.Instance.CreatedAcount(username, password, email) == "false")
            {
                FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                formMessageBoxError.Show();
            }
            else
            {
                FormMeessageBox formMeessageBox = new FormMeessageBox(EmployeesBLL.Instance.CreatedAcount(username, password, email));
                formMeessageBox.Show();
            }
            

        }

        private void buttoneyes1_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                //txtEmail.UseSystemPasswordChar = false;
                txtPassword.UseSystemPasswordChar = false;
                //txtUsername.UseSystemPasswordChar = false;
                //txtEmail.PasswordChar = '\0';
                txtPassword.PasswordChar = '\0';
                //txtUsername.PasswordChar = '\0';
                this.buttoneyes1.Image = global::LibraryManagement.Properties.Resources.eye_hide;
            }
            else
            {
                //txtEmail.UseSystemPasswordChar = true;
                txtPassword.UseSystemPasswordChar = true;
                //txtUsername.UseSystemPasswordChar = true;
                //txtEmail.PasswordChar = '●';
                txtPassword.PasswordChar = '●';
                //txtUsername.PasswordChar = '●';
                this.buttoneyes1.Image = global::LibraryManagement.Properties.Resources._103177_see_watch_view_eye_icon;
            }
        }
    }
}
