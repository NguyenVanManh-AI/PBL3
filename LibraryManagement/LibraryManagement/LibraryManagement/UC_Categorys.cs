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
    public partial class UC_Categorys : UserControl
    {
        public UC_Categorys()
        {
            InitializeComponent();
            dataGridView1.DataSource = CategorysBLL.Instance.LoadAllCategorys();
            dataGridView1.ClearSelection();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            Categorys cate = new Categorys(txtName.Text, txtDes.Text);
            if (txtId.Text != "")
            {
                SetTxt();
            }
            else
            {
                if (CategorysBLL.Instance.AddCategorys(cate) == "OK")
                {
                    new FormMessageBoxSuccess("Add successfully!").Show();
                    dataGridView1.DataSource = CategorysBLL.Instance.LoadAllCategorys();
                    SetTxt();
                }
                else
                {
                    new FormMeessageBox(CategorysBLL.Instance.AddCategorys(cate)).Show();
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                new FormMeessageBox("Please select Category you want to delete !").Show();
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        string id = row.Cells[0].Value.ToString();
                        CategorysBLL.Instance.DeleteCategorys(id);
                    }
                    new FormMessageBoxSuccess("Delete successfully!!").Show();
                    dataGridView1.DataSource = CategorysBLL.Instance.LoadAllCategorys();
                    SetTxt();
                }
            }

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CategorysBLL.Instance.SearchCategorys(txtSearch.Text);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDes.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCreate.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtUpdate.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch { };
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                new FormMeessageBox("Please select a Category you want to edit!").Show();
            }
            else if (dataGridView1.SelectedRows.Count > 1)
            {
                new FormMeessageBox("Please select only 1 Category you want to edit!").Show();
            }
            else
            {
                Categorys cate = new Categorys(txtName.Text, txtDes.Text);
                if (CategorysBLL.Instance.EditCategorys(cate, txtId.Text) == "OK")
                {
                    new FormMessageBoxSuccess("Edit successfully!").Show();
                    dataGridView1.DataSource = CategorysBLL.Instance.LoadAllCategorys();
                    SetTxt();
                }
                else
                {
                    new FormMeessageBox(CategorysBLL.Instance.EditCategorys(cate, txtId.Text)).Show();
                }
            }
        }
        public void SetTxt()
        {
            txtCreate.Text = "";
            txtDes.Text = "";
            txtId.Text = "";
            txtName.Text = "";
            txtUpdate.Text = "";
            dataGridView1.ClearSelection();
        }
    }
}
