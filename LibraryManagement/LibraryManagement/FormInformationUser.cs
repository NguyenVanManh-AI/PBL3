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
    public partial class FormInformationUser : Form
    {
        string username;
        public FormInformationUser(string user_name)
        {
            username = user_name;
            InitializeComponent();
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMain formMain = new FormMain(username);
            formMain.Show();
        }

        private void FormInformationUser_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = EmployeesBLL.Instance.LoadInforEmployee(username);
            txtFirstName.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            txtLastName.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            txtPhone.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            txtDateOfBirth.Text = EmployeesBLL.Instance.ShowDate(dataGridView1.Rows[0].Cells[5].Value.ToString());
            txtCreatedAt.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            txtUpdatedAt.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (EmployeesBLL.Instance.SaveInforAccount(username, txtFirstName.Text,txtLastName.Text,txtPhone.Text,txtEmail.Text,
                txtAddress.Text,txtDateOfBirth.Text) == "true")
            {
                FormMessageBoxSuccess formMessageBoxSuccess = new FormMessageBoxSuccess("Edit Information Success !!!");
                formMessageBoxSuccess.Show();
                this.FormInformationUser_Load(sender, e);
            }
            else
            {
                FormMeessageBox formMeessageBox = new FormMeessageBox(EmployeesBLL.Instance.SaveInforAccount(username, txtFirstName.Text, txtLastName.Text, txtPhone.Text, txtEmail.Text,
                txtAddress.Text, txtDateOfBirth.Text));
                formMeessageBox.Show();
                this.FormInformationUser_Load(sender, e);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtDateOfBirth.Text = EmployeesBLL.Instance.ShowDate(dateTimePicker2.Value.ToString());
        }
    }
}
