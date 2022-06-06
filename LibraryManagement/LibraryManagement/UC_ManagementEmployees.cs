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
    public partial class UC_ManagementEmployees : UserControl
    {
        FormMain formMain;
        string _username;
        string _new_username;
        public UC_ManagementEmployees(FormMain _formMain)
        {
            formMain = _formMain;
            InitializeComponent();
        }

        private void UC_ManagementEmployees_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ManaEmployeesBLL.Instance.LoadAllEmployees();
        }

        int id ;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                _username = txtUserName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtDateOfBirth.Text = EmployeesBLL.Instance.ShowDate(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                txtCreatedAt.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtUpdatedAt.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
            catch { }
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtDateOfBirth.Text = EmployeesBLL.Instance.ShowDate(dateTimePicker2.Value.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text == "")
            {
                FormMeessageBox formMeessageBox = new FormMeessageBox("Please select a Employees to Edit !!!");
                formMeessageBox.Show();
            }
            else
            {
                string _new_username = txtUserName.Text;
                Employees employees = new Employees(id, txtUserName.Text, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text, txtAddress.Text);
                if (ManaEmployeesBLL.Instance.EditEmployees(employees, txtDateOfBirth.Text) == "true")
                {
                    FormMessageBoxSuccess formMessageBoxSuccess = new FormMessageBoxSuccess("Edit Success !");
                    formMessageBoxSuccess.Show();
                    formMain.ChangeUsername(_username, _new_username);
                    Reset_txt();
                }
                else if (ManaEmployeesBLL.Instance.EditEmployees(employees, txtDateOfBirth.Text) == "false")
                {
                    FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                    formMessageBoxError.Show();
                }
                else
                {
                    FormMeessageBox formMeessageBox = new FormMeessageBox(ManaEmployeesBLL.Instance.EditEmployees(employees, txtDateOfBirth.Text));
                    formMeessageBox.Show();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text == "")
            {
                FormMeessageBox formMeessageBox = new FormMeessageBox("Please select a Employees to Delete !!!");
                formMeessageBox.Show();
            }
            else
            {
                if (ManaEmployeesBLL.Instance.CheckRole(txtUserName.Text) == "admin")
                {
                    FormMeessageBox formMeessageBox = new FormMeessageBox("Can not Delete Account Admin !!!");
                    formMeessageBox.Show();
                }
                else
                {
                    if (MessageBox.Show("Are you sure to delete employee information " + txtUserName.Text.ToUpper(), "Delete Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        if (ManaEmployeesBLL.Instance.DeleteEmployees(id) == "true")
                        {
                            FormMessageBoxSuccess formMessageBoxSuccess = new FormMessageBoxSuccess("Delete Success !");
                            formMessageBoxSuccess.Show();
                            Reset_txt();
                        }
                        else if (ManaEmployeesBLL.Instance.DeleteEmployees(id) == "false")
                        {
                            FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                            formMessageBoxError.Show();
                        }
                        else
                        {
                            FormMeessageBox formMeessageBox = new FormMeessageBox(ManaEmployeesBLL.Instance.DeleteEmployees(id));
                            formMeessageBox.Show();
                        }
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ManaEmployeesBLL.Instance.SearchEmployees(txtSearch.Text);
        }

        public void Reset_txt()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUserName.Text = "";
            txtEmail.Text = "";
            txtDateOfBirth.Text = "";
            txtAddress.Text = "";
            txtCreatedAt.Text = "";
            txtUpdatedAt.Text = "";
            txtPhone.Text = "";
            _username = "";
            _new_username = "";
            dataGridView1.DataSource = ManaEmployeesBLL.Instance.LoadAllEmployees();
        }
    }
}
