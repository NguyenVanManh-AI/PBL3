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
    public partial class UC_Publishers : UserControl
    {
        public UC_Publishers()
        {
            InitializeComponent();
            dataGridView1.DataSource = PublishersBLL.Instance.LoadAllPublishers();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            Publishers pub = new Publishers(txtName.Text, txtDes.Text, txtCountry.Text, txtAddress.Text);
            if (txtId.Text != "")
            {
                SetTxt();
            }
            else if (txtId.Text == "")
            {
                if (PublishersBLL.Instance.AddPublisher(pub) == "OK")
                {
                    new FormMessageBoxSuccess("Add successfully!").Show();
                    dataGridView1.DataSource = PublishersBLL.Instance.LoadAllPublishers();
                    SetTxt();
                }
                else
                    new FormMeessageBox(PublishersBLL.Instance.AddPublisher(pub)).Show();
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PublishersBLL.Instance.SearchPublishers(txtSearch.Text);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                new FormMeessageBox("Please select Publishers you want to delete !").Show();
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        string id = row.Cells[0].Value.ToString();
                        PublishersBLL.Instance.DeletePublisher(id);
                    }
                    new FormMessageBoxSuccess("Delete successfully!!").Show();
                    dataGridView1.DataSource = PublishersBLL.Instance.LoadAllPublishers();
                    SetTxt();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCountry.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDes.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCreate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtUpdate.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch { };
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                new FormMeessageBox("Please select a Publisher you want to edit!").Show();
            }
            else if (dataGridView1.SelectedRows.Count > 1)
            {
                new FormMeessageBox("Please select only 1 Publisher you want to edit!").Show();
            }
            else
            {
                Publishers pub = new Publishers(txtName.Text, txtDes.Text, txtCountry.Text, txtAddress.Text);
                if (PublishersBLL.Instance.EditPublisher(pub, txtId.Text) == "OK")
                {
                    new FormMessageBoxSuccess("Edit successfully!").Show();
                    dataGridView1.DataSource = PublishersBLL.Instance.LoadAllPublishers();
                    SetTxt();
                }
                else
                {
                    new FormMeessageBox(PublishersBLL.Instance.EditPublisher(pub, txtId.Text));
                }
            }
        }
        public void SetTxt()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtCountry.Text = "";
            txtDes.Text = "";
            txtAddress.Text = "";
            txtCreate.Text = "";
            txtUpdate.Text = "";
            dataGridView1.ClearSelection();
        }
    }
}
