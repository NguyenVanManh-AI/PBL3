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
            guna2Panel2.Visible = false;
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
            ShowHome();
            Step(page);
        }

        private void LogOut(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }



        // load UC 
        public void AddUCPanel1(UserControl uc)
        {
            guna2Panel1.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            guna2Panel1.Controls.Add(uc);
        }

        // load UC 


        // Event Show Hide when click Button  

        public void ShowHome()
        {
            groupInforUser.Visible = false;
            guna2Panel1.Visible = false;
        }


        public void ShowPanel1()
        {
            groupInforUser.Visible = false;
            guna2Panel1.Visible = true;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowHome();
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            UC_Help uC_Help = new UC_Help();
            AddUCPanel1(uC_Help);
            ShowPanel1();
        }
        private void btnInforUser_Click(object sender, EventArgs e)
        {
            if (groupInforUser.Visible == true)
                groupInforUser.Visible = false;
            else
                groupInforUser.Visible = true;
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

        private void FormMain_Click(object sender, EventArgs e)
        {
            if (groupInforUser.Visible == true)
                groupInforUser.Visible = false;
        }

        private void btnManaEmployees_Click(object sender, EventArgs e)
        {
            UC_Employees uC_Employees = new UC_Employees();
            AddUCPanel1(uC_Employees);
            ShowPanel1();
        }

        int page = 1;
        public void Step(int page)
        {
            this.step1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.step1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.text1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.text1.ForeColor = System.Drawing.Color.White;

            this.step2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.text2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.text2.ForeColor = System.Drawing.Color.White;

            this.step3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.text3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            this.text3.ForeColor = System.Drawing.Color.White;

            if (page == 1)
            {
                this.step1.BackColor = System.Drawing.Color.White;
                this.text1.BackColor = System.Drawing.Color.White;
                this.text1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            }
            else if (page == 2)
            {
                this.step2.BackColor = System.Drawing.Color.White;
                this.text2.BackColor = System.Drawing.Color.White;
                this.text2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            }
            else
            {
                this.step3.BackColor = System.Drawing.Color.White;
                this.text3.BackColor = System.Drawing.Color.White;
                this.text3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(162)))), ((int)(((byte)(251)))));
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (page == 1)
                page = 3;
            else page--;
            Step(page);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (page == 3)
                page = 1;
            else page++;
            Step(page);
        }

        private void btnAuhtor_Click(object sender, EventArgs e)
        {
            UC_Authors uC_Authors = new UC_Authors();
            AddUCPanel1(uC_Authors);
            ShowPanel1();
        }

        private void btnPubliser_Click(object sender, EventArgs e)
        {
            UC_Publishers uC_Publishers = new UC_Publishers();
            AddUCPanel1(uC_Publishers);
            ShowPanel1();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            UC_Categorys uC_Categorys = new UC_Categorys();
            AddUCPanel1(uC_Categorys);
            ShowPanel1();
        }
    }
}
