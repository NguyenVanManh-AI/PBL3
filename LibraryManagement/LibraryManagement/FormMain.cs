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
    public partial class FormMain : Form
    {
        string username;
        public FormMain(string user_name)
        {
            username = user_name;
            InitializeComponent();
        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
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


        private void Main_Load(object sender, EventArgs e)
        {
            btnInforUser.Text = EmployeesBLL.Instance.getName(username);
            groupInforUser.Visible = false;
            guna2Panel1.Visible = false;
        }

        private void LogOut(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void btnInforUser_Click(object sender, EventArgs e)
        {
            if (groupInforUser.Visible == true)
            {
                groupInforUser.Visible = false;
                if (guna2Panel1.Visible == false)
                {
                    guna2Panel1.Visible = true;
                }
            }
            else
            {
                groupInforUser.Visible = true;
                if(guna2Panel1.Visible == true)
                {
                    guna2Panel1.Visible = false;
                }
            }
        }

        private void FormMain_Click(object sender, EventArgs e)
        {
            if (groupInforUser.Visible == true)
            {
                groupInforUser.Visible = false;
            }
            if (guna2Panel1.Visible == false)
            {
                guna2Panel1.Visible = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormChangePassword formChangePassword = new FormChangePassword(username);
            formChangePassword.Show();
        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInformationUser formInformationUser = new FormInformationUser(username);
            formInformationUser.Show();
        }





        // load UC 
        public void AddUCPanel1(UserControl uc)
        {
            guna2Panel1.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            guna2Panel1.Controls.Add(uc);
        }
        public void AddUCPanel2(UserControl uc)
        {
            guna2Panel2.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            guna2Panel2.Controls.Add(uc);
        }

        private void btnManaEmployees_Click(object sender, EventArgs e)
        {
            UC_Employees uC_Employees = new UC_Employees();
            AddUCPanel1(uC_Employees);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            UC_Help uC_Help = new UC_Help();
            AddUCPanel2(uC_Help);
            if(guna2Panel1.Visible == true)
            {
                guna2Panel2.Visible = false;
            }
        }
    }
}
