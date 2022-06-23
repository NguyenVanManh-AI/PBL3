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
    public partial class UC_Readers : UserControl
    {
        public UC_Readers()
        {
            InitializeComponent();
            dataGridView1.DataSource = ReadersBLL.Instance.LoadAllReaders();
            dataGridView1.ClearSelection();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtFName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "True") cbbGender.Text = "Male";
                else cbbGender.Text = "FeMale";
                if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() != "")
                {
                    txtDOB.Text = ReadersBLL.Instance.ShowDate(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
                else
                {
                    txtDOB.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                }

                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtCard.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                txtCreate.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtUpdate.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
            catch { };
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                bool gender;
                if (cbbGender.Text == "Male") gender = true;
                else gender = false;

                if (txtId.Text != "")
                {
                    SetTxt();
                }
                else
                {
                    if (txtDOB.Text == "") new FormMeessageBox("Date of Birth cann't be left blank").Show();
                    else
                    {
                        //MessageBox.Show(Convert.ToDateTime(txtDOB.Text).ToString());
                        Readers r = new Readers(txtFName.Text, txtLName.Text, gender, Convert.ToDateTime(txtDOB.Text), txtEmail.Text, txtCard.Text, txtPhone.Text, txtAddress.Text);
                        if (ReadersBLL.Instance.AddReader(r) == "OK")
                        {
                            new FormMessageBoxSuccess("Add successfully!").Show();
                            dataGridView1.DataSource = ReadersBLL.Instance.LoadAllReaders();
                            SetTxt();
                        }
                        else
                            new FormMeessageBox(ReadersBLL.Instance.AddReader(r)).Show();
                    }
                }
            }
            catch { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    new FormMeessageBox("Please select Readers you want to delete !").Show();
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string id = row.Cells[0].Value.ToString();
                            ReadersBLL.Instance.DeleteReader(id);
                        }
                        new FormMessageBoxSuccess("Delete successfully!!").Show();
                        SetTxt();
                    }
                }
            }
            catch { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //try
            //{
                bool gender;
                if (cbbGender.Text == "Male") gender = true;
                else gender = false;
                if (txtId.Text=="")
                {
                    new FormMeessageBox("Please select Reader you want to edit!").Show();
                }
                else if (dataGridView1.SelectedRows.Count > 1)
                {
                    new FormMeessageBox("Please select only 1 Reader you want to edit!").Show();
                }
                else
                {
                    if (txtDOB.Text == "") new FormMeessageBox("Date of Birth cann't be left blank").Show();
                    else
                    {
                        Readers r = new Readers(txtFName.Text, txtLName.Text, gender, Convert.ToDateTime(txtDOB.Text), txtEmail.Text, txtCard.Text, txtPhone.Text, txtAddress.Text);
                        if (ReadersBLL.Instance.EditReader(r, txtId.Text) == "OK")
                        {
                            new FormMessageBoxSuccess("Edit successfully!").Show();
                            dataGridView1.DataSource = ReadersBLL.Instance.LoadAllReaders();
                            SetTxt();
                        }
                        else
                        {
                            new FormMeessageBox(ReadersBLL.Instance.EditReader(r, txtId.Text)).Show();
                        }
                    }
                }
            //}
            //catch { }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ReadersBLL.Instance.SearchReaders(txtSearch.Text);
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtDOB.Text = ReadersBLL.Instance.ShowDate(guna2DateTimePicker1.Value.ToString());
        }
        public void SetTxt()
        {
            txtId.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            txtDOB.Text = "";
            cbbGender.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCard.Text = "";
            txtCreate.Text = "";
            txtUpdate.Text = "";
            dataGridView1.DataSource = ReadersBLL.Instance.LoadAllReaders();
            dataGridView1.ClearSelection();
        }

        private void UC_Readers_Load(object sender, EventArgs e)
        {

        }
    }
}
