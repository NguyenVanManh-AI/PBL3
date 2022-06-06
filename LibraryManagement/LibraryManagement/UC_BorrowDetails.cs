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
using DAL;

namespace LibraryManagement
{
    public partial class UC_BorrowDetails : UserControl
    {
        string id_borrow;
        public UC_BorrowDetails(string _id_borrow)
        {
            id_borrow = _id_borrow;
            InitializeComponent();
            dataGridView1.Hide();
            comboBox1.Text = "Borrow Details";
            txtId_Borrow.Text = id_borrow;
        }

        private void UC_BorrowDetails_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = BorrowDetailsBLL.Instance.LoadAllBorrowDetails(id_borrow);
                dataGridView2.DataSource = BorrowDetailsBLL.Instance.LoadAllBooks();
            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId_Borrow_Detail.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtId_Borrow.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtId_Book.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtBook_Title.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtCategory_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtPublisher_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtAuthor_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtBorrow_At.Text = EmployeesBLL.Instance.ShowDate(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                txtReturn_At.Text = EmployeesBLL.Instance.ShowDate(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch { }
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId_Book.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtBook_Title.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCategory_Name.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPublisher_Name.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAuthor_Name.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString() + " " + dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Borrow Details")
            {
                dataGridView2.Hide();
                dataGridView1.Show();
            }
            else
            {
                dataGridView1.Hide();
                dataGridView2.Show();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId_Borrow_Detail.Text != "")
                {
                    ReSet_txt();
                }
                else
                {
                    if (txtId_Book.Text == "")
                    {
                        FormMeessageBox formMeessageBox = new FormMeessageBox("Please select a Book!!!");
                        formMeessageBox.Show();
                    }
                    else
                    {
                        if (Int32.Parse(BorrowDetailsBLL.Instance.getCOUNT(id_borrow)) == 10)
                        {
                            FormMeessageBox formMeessageBox = new FormMeessageBox("Borrowing voucher has reached the maximum number of borrowings !!!");
                            formMeessageBox.Show();
                        }
                        else
                        {
                            BorrowDetails bor = new BorrowDetails(Int32.Parse(id_borrow), Int32.Parse(txtId_Book.Text), txtBook_Title.Text);
                            if (BorrowDetailsBLL.Instance.AddBorrowDetails(bor, txtBorrow_At.Text) == "true")
                            {
                                FormMessageBoxSuccess formMessageBoxSuccess = new FormMessageBoxSuccess("Add Success !");
                                formMessageBoxSuccess.Show();
                                ReSet_txt();
                            }
                            else if (BorrowDetailsBLL.Instance.AddBorrowDetails(bor, txtBorrow_At.Text) == "false")
                            {
                                FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                                formMessageBoxError.Show();
                            }
                            else
                            {
                                FormMeessageBox formMeessageBox = new FormMeessageBox(BorrowDetailsBLL.Instance.AddBorrowDetails(bor, txtBorrow_At.Text));
                                formMeessageBox.Show();
                            }
                        }
                    }
                }
            }
            catch
            {
                FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                formMessageBoxError.Show();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtId_Borrow_Detail.Text != "")
                {
                    BorrowDetails bor = new BorrowDetails(Int32.Parse(id_borrow), Int32.Parse(txtId_Book.Text), txtBook_Title.Text);
                    if (BorrowDetailsBLL.Instance.EditBorrowDetails(txtId_Borrow_Detail.Text, bor, txtBorrow_At.Text, txtReturn_At.Text) == "true")
                    {
                        FormMessageBoxSuccess formMessageBoxSuccess = new FormMessageBoxSuccess("Edit Success !");
                        formMessageBoxSuccess.Show();
                        ReSet_txt();
                    }
                    else if (BorrowDetailsBLL.Instance.EditBorrowDetails(txtId_Borrow_Detail.Text, bor, txtBorrow_At.Text, txtReturn_At.Text) == "false")
                    {
                        FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                        formMessageBoxError.Show();
                    }
                    else
                    {
                        FormMeessageBox formMeessageBox = new FormMeessageBox(BorrowDetailsBLL.
                            Instance.EditBorrowDetails(txtId_Borrow_Detail.Text, bor, txtBorrow_At.Text, txtReturn_At.Text));
                        formMeessageBox.Show();
                    }
                }
                else
                {
                    FormMeessageBox formMeessageBox = new FormMeessageBox("Please select a Borrow Details to Edit !!!");
                    formMeessageBox.Show();
                }
                
            }
            catch
            {
                FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                formMessageBoxError.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (BorrowDetailsBLL.Instance.DeleteBorrowDetails(txtId_Borrow_Detail.Text) == "true")
                {
                    FormMessageBoxSuccess formMessageBoxSuccess = new FormMessageBoxSuccess("Delete Success !");
                    formMessageBoxSuccess.Show();
                    ReSet_txt();
                }
                else if (BorrowDetailsBLL.Instance.DeleteBorrowDetails(txtId_Borrow_Detail.Text) == "false")
                {
                    FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                    formMessageBoxError.Show();
                }
                else
                {
                    FormMeessageBox formMeessageBox = new FormMeessageBox(BorrowDetailsBLL.Instance.DeleteBorrowDetails(txtId_Borrow_Detail.Text));
                    formMeessageBox.Show();
                }
            }
            catch
            {
                FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                formMessageBoxError.Show();
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Borrow Details")
                    dataGridView1.DataSource = BorrowDetailsBLL.Instance.SearchBorrowDetails(txtSearch.Text,id_borrow);
                else
                    dataGridView2.DataSource = BorrowDetailsBLL.Instance.SearchBooks(txtSearch.Text);
            }
            catch { }
        }

        public void ReSet_txt()
        {
            txtId_Borrow_Detail.Text = "";
            txtId_Book.Text = "";
            txtBook_Title.Text = "";
            txtCategory_Name.Text = "";
            txtPublisher_Name.Text = "";
            txtAuthor_Name.Text = "";
            txtBorrow_At.Text = "";
            txtReturn_At.Text = "";
            txtSearch.Text = "";
            comboBox1.Text = "Borrow Details";
            dataGridView1.DataSource = BorrowDetailsBLL.Instance.LoadAllBorrowDetails(id_borrow);
            dataGridView2.DataSource = BorrowDetailsBLL.Instance.LoadAllBooks();
            dataGridView1.Show();
            dataGridView2.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtBorrow_At.Text = EmployeesBLL.Instance.ShowDate(dateTimePicker1.Value.ToString());
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            txtReturn_At.Text = EmployeesBLL.Instance.ShowDate(dateTimePicker2.Value.ToString());
        }
    }
}
