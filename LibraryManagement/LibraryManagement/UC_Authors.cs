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
    public partial class UC_Authors : UserControl
    {
        public UC_Authors()
        {
            InitializeComponent();
            dataGridView1.DataSource = AuthorsBLL.Instance.LoadAllAuthors();
            cbbGender.SelectedItem = "Nam";
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text != "")
                {
                    txtId.Text = "";
                    txtFName.Text = "";
                    txtLName.Text = "";
                    txtDes.Text = "";
                    cbbGender.Text = "";
                    txtCreate.Text = "";
                    txtUpdate.Text = "";
                    dataGridView1.ClearSelection();
                }
                else if (txtId.Text == "")
                {
                    string datetime = DateTime.Now.ToString();
                    bool gender;
                    if (cbbGender.Text == "Nam") gender = true;
                    else gender = false;
                    Authors author = new Authors(txtFName.Text, txtLName.Text, gender, txtDes.Text);
                    if (AuthorsBLL.Instance.AddAuthors(author) == "OK")
                    {
                        new FormMessageBoxSuccess("Add successfully!").Show();
                        dataGridView1.DataSource = AuthorsBLL.Instance.LoadAllAuthors();
                        txtId.Text = "";
                        txtFName.Text = "";
                        txtLName.Text = "";
                        txtDes.Text = "";
                        cbbGender.Text = "";
                        txtCreate.Text = "";
                        txtUpdate.Text = "";
                        dataGridView1.ClearSelection();
                    }
                    else
                        new FormMeessageBox(AuthorsBLL.Instance.AddAuthors(author)).Show();
                }
            }
            catch { };

        }


        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    new FormMeessageBox("Please select Author you want to delete !").Show();
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string id = row.Cells[0].Value.ToString();
                            AuthorsBLL.Instance.DelAuthors(id);
                        }
                        new FormMessageBoxSuccess("Delete successfully!!").Show();
                        dataGridView1.DataSource = AuthorsBLL.Instance.LoadAllAuthors();
                        txtId.Text = "";
                        txtFName.Text = "";
                        txtLName.Text = "";
                        cbbGender.Text = "";
                        txtUpdate.Text = "";
                        txtCreate.Text = "";
                        txtDes.Text = "";
                        dataGridView1.ClearSelection();
                    }
                }
            }
            catch { };

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = AuthorsBLL.Instance.SearchAuthors(txtSearch.Text);

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtFName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "True") cbbGender.Text = "Nam";
                else cbbGender.Text = "Nữ";
                txtDes.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtCreate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtUpdate.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch { };
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    new FormMeessageBox("Please select a Author you want to edit!").Show();
                }
                else if (dataGridView1.SelectedRows.Count > 1)
                {
                    new FormMeessageBox("Please select only 1 Author you want to edit!").Show();
                }
                else
                {
                    bool gender;
                    if (cbbGender.Text == "Nam") gender = true;
                    else gender = false;
                    Authors author = new Authors(txtFName.Text, txtLName.Text, gender, txtDes.Text);
                    if (AuthorsBLL.Instance.EditAuthors(author, txtId.Text) == "OK")
                    {
                        new FormMessageBoxSuccess("Edit successfully!").Show();
                        dataGridView1.DataSource = AuthorsBLL.Instance.LoadAllAuthors();
                        txtId.Text = "";
                        txtFName.Text = "";
                        txtLName.Text = "";
                        txtDes.Text = "";
                        cbbGender.Text = "";
                        txtUpdate.Text = "";
                        txtCreate.Text = "";
                        dataGridView1.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show(AuthorsBLL.Instance.EditAuthors(author, txtId.Text));
                    }
                }

            }
            catch { };
        }
    }
}
