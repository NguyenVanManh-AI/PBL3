﻿using System;
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
            }
            else
            {
                groupInforUser.Visible = true;
            }
        }

        private void FormMain_Click(object sender, EventArgs e)
        {
            if (groupInforUser.Visible == true)
            {
                groupInforUser.Visible = false;
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
            FormInformationUser formInformationUser = new FormInformationUser(username);
            formInformationUser.Show();
        }
    }
}
