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
    public partial class UC_Books : UserControl
    {
        public UC_Books(string id)
        {
            InitializeComponent();
            dataGridView1.DataSource = BooksBLL.Instance.LoadBooksFromIdTitle(id);
            ID = id;
            cbbS.SelectedItem = "All";
            cbbStatus.SelectedItem = "Intact";
            txtTitleId.Text = id;
            txtTitle.Text = BooksBLL.Instance.GetTitleByBookTitleID(id);
        }
        public string ID = "";
        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBookId.Text != "")
                {
                    SetTxt();
                }
                else if (txtBookId.Text == "")
                {
                    bool status;
                    if (cbbStatus.Text == "Intact") status = true;
                    else status = false;
                    if (txtImportAt.Text == "") new FormMeessageBox("Imported At cann't not be left blank!").Show();
                    else
                    {
                        Books b = new Books(int.Parse(txtTitleId.Text), Convert.ToDateTime(txtImportAt.Text), status);
                        if (BooksBLL.Instance.AddBook(b,txtNumber.Text) == "OK")
                        {
                            new FormMessageBoxSuccess("Add successfully!").Show();
                            dataGridView1.DataSource = BooksBLL.Instance.LoadBooksFromIdTitle(ID);
                            SetTxt();
                        }
                        else
                            new FormMeessageBox(BooksBLL.Instance.AddBook(b,txtNumber.Text)).Show();
                    }
                }
            }
            catch { }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBookId.Text == "")
                {
                    new FormMeessageBox("Please select a Book you want to edit!").Show();
                }
                else if (dataGridView1.SelectedRows.Count > 1)
                {
                    new FormMeessageBox("Please select only 1 Book you want to edit!").Show();
                }
                else
                {
                    bool status;
                    if (cbbStatus.Text == "Intact") status = true;
                    else status = false;
                    if (txtImportAt.Text == "") new FormMeessageBox("Imported At cann't not be left blank!");
                    else
                    {
                        Books b = new Books(int.Parse(txtTitleId.Text), Convert.ToDateTime(txtImportAt.Text), status);
                        if (BooksBLL.Instance.EditBook(b, txtBookId.Text) == "OK")
                        {
                            new FormMessageBoxSuccess("Edit successfully!").Show();
                            dataGridView1.DataSource = BooksBLL.Instance.LoadBooksFromIdTitle(ID);
                            SetTxt();
                        }
                        else
                        {
                            new FormMeessageBox(BooksBLL.Instance.EditBook(b, txtBookId.Text)).Show();
                        }
                    }
                }
            }
            catch { }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBookId.Text =="")
                {
                    new FormMeessageBox("Please select Books you want to delete !").Show();
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string id = row.Cells[0].Value.ToString();
                            BooksBLL.Instance.DeleteBook(id);
                        }
                        new FormMessageBoxSuccess("Delete successfully!!").Show();
                        dataGridView1.DataSource = BooksBLL.Instance.LoadBooksFromIdTitle(ID);
                        SetTxt();
                    }
                }
            }
            catch { }
        }

        private void txtS_TextChanged(object sender, EventArgs e)
        {
            if (cbbS.Text == "Intact") dataGridView1.DataSource = BooksBLL.Instance.SearchBooksWithStatus(txtSearch.Text, ID, true);
            else if (cbbS.Text == "Broken") dataGridView1.DataSource = BooksBLL.Instance.SearchBooksWithStatus(txtSearch.Text, ID, false);
            else dataGridView1.DataSource = BooksBLL.Instance.SearchAllBooks(txtSearch.Text, ID);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtBookId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTitleId.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtImportAt.Text = BooksBLL.Instance.ShowDate(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "True") cbbStatus.SelectedItem = "Intact";
                else cbbStatus.SelectedItem = "Broken";
                txtUpdate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtCreate.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch { }
        }

        private void cbbS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbS.Text == "Intact") dataGridView1.DataSource = BooksBLL.Instance.SearchBooksWithStatus(txtSearch.Text, ID, true);
            else if (cbbS.Text == "Broken") dataGridView1.DataSource = BooksBLL.Instance.SearchBooksWithStatus(txtSearch.Text, ID, false);
            else dataGridView1.DataSource = BooksBLL.Instance.SearchAllBooks(txtSearch.Text, ID);
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtImportAt.Text =BooksBLL.Instance.ShowDate( guna2DateTimePicker1.Value.ToString());
        }
        public void SetTxt()
        {
            txtBookId.Text = "";
            cbbStatus.Text = "";
            txtImportAt.Text = "";
            txtCreate.Text = "";
            txtUpdate.Text = "";
            dataGridView1.ClearSelection();
        }
    }
}
