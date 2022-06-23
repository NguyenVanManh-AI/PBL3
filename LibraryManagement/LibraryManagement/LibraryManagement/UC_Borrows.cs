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
    public partial class UC_Borrows : UserControl
    {
        int id_employees;
        string name_employees;
        FormMain formMain; 
        public UC_Borrows(int _id, FormMain _formMain)
        {
            formMain = _formMain;
            id_employees = _id;
            name_employees = BorrowsBLL.Instance.getNameById(id_employees);
            InitializeComponent();
            dataGridView2.Hide();
            comboBox1.Text = "Borrows";
        }

        private void UC_Borrows_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = BorrowsBLL.Instance.LoadAllBorrows();
                dataGridView2.DataSource = BorrowsBLL.Instance.LoadAllReaders();
            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["Column9"].Index && e.RowIndex >= 0)
                {
                    formMain.AddUC_BorrowDetail_Panel1(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
                txtBorrow_id.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCreator_id.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCreator_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtReader_id.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtReader_Name.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtCreated_at.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtUpdated_at.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtReader_id.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtReader_Name.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + " "
                + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void combobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Borrows")
            {
                dataGridView2.Hide();
                dataGridView1.Show();
                dataGridView1.DataSource = BorrowsBLL.Instance.LoadAllBorrows();
            }
            else if(comboBox1.Text == "To Limit Time")
            {
                dataGridView2.Hide();
                dataGridView1.Show();
                dataGridView1.DataSource = BorrowsBLL.Instance.LoadReaderToLimitTime();
            }
            else
            {
                dataGridView1.Hide();
                dataGridView2.Show();
            }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(txtBorrow_id.Text != "")
                {
                    ReSet_txt();
                }
                else
                {
                    if(txtReader_id.Text == "")
                    {
                        FormMeessageBox formMeessageBox = new FormMeessageBox("Please select reader !!!");
                        formMeessageBox.Show();
                    }
                    else
                    {
                        Borrows bo = new Borrows(id_employees, name_employees, Int32.Parse(txtReader_id.Text), txtReader_Name.Text);
                        if (BorrowsBLL.Instance.AddBorrows(bo) == "true")
                        {
                            FormMessageBoxSuccess formMessageBoxSuccess = new FormMessageBoxSuccess("Add Success !");
                            formMessageBoxSuccess.Show();
                            ReSet_txt();
                        }
                        else if (BorrowsBLL.Instance.AddBorrows(bo) == "false")
                        {
                            FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                            formMessageBoxError.Show();
                        }
                        else
                        {
                            FormMeessageBox formMeessageBox = new FormMeessageBox(BorrowsBLL.Instance.AddBorrows(bo));
                            formMeessageBox.Show();
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                Borrows bo = new Borrows(id_employees, name_employees, Int32.Parse(txtReader_id.Text), txtReader_Name.Text);
                if (BorrowsBLL.Instance.EditBorrows(Int32.Parse(txtBorrow_id.Text), bo) == "true")
                {
                    FormMessageBoxSuccess formMessageBoxSuccess = new FormMessageBoxSuccess("Edit Success !");
                    formMessageBoxSuccess.Show();
                    ReSet_txt();
                }
                else if (BorrowsBLL.Instance.EditBorrows(Int32.Parse(txtBorrow_id.Text), bo) == "false")
                {
                    FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                    formMessageBoxError.Show();
                }
                else
                {
                    FormMeessageBox formMeessageBox = new FormMeessageBox(BorrowsBLL.Instance.EditBorrows(Int32.Parse(txtBorrow_id.Text), bo));
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
                if(txtBorrow_id.Text == "")
                {
                    FormMeessageBox formMeessageBox = new FormMeessageBox("Please select a Borrow to delete !!!");
                    formMeessageBox.Show();
                }
                else
                {
                    if (MessageBox.Show("Are you sure to delete borrow information " + txtBorrow_id.Text.ToUpper(), "Delete Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        if (BorrowsBLL.Instance.DeleteBorrows(Int32.Parse(txtBorrow_id.Text)) == "true")
                        {
                            FormMessageBoxSuccess formMessageBoxSuccess = new FormMessageBoxSuccess("Delete Success !");
                            formMessageBoxSuccess.Show();
                            ReSet_txt();
                        }
                        else if (BorrowsBLL.Instance.DeleteBorrows(Int32.Parse(txtBorrow_id.Text)) == "false")
                        {
                            FormMessageBoxError formMessageBoxError = new FormMessageBoxError("Error !!!");
                            formMessageBoxError.Show();
                        }
                        else
                        {
                            FormMeessageBox formMeessageBox = new FormMeessageBox(BorrowsBLL.Instance.DeleteBorrows(Int32.Parse(txtBorrow_id.Text)));
                            formMeessageBox.Show();
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
        public void ReSet_txt()
        {
            txtCreator_id.Text = "";
            txtCreator_Name.Text = "";
            txtBorrow_id.Text = "";
            txtReader_id.Text = "";
            txtReader_Name.Text = "";
            txtCreated_at.Text = "";
            txtUpdated_at.Text = "";
            txtSearch.Text = "";
            comboBox1.Text = "Borrows";
            dataGridView1.DataSource = BorrowsBLL.Instance.LoadAllBorrows();
            dataGridView2.DataSource = BorrowsBLL.Instance.LoadAllReaders();
            dataGridView1.Show();
            dataGridView2.Hide();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Borrows")
                    dataGridView1.DataSource = BorrowsBLL.Instance.SearchBorrows(txtSearch.Text);
                else if (comboBox1.Text == "To Limit Time")
                    dataGridView1.DataSource = BorrowsBLL.Instance.SearchBorrowsToLimitTime(txtSearch.Text);
                else
                    dataGridView2.DataSource = BorrowsBLL.Instance.SearchReader(txtSearch.Text);
            }
            catch { }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if(txtBorrow_id.Text == "")
            {
                FormMeessageBox formMeessageBox = new FormMeessageBox("Please slect a Borrow !!!");
                formMeessageBox.Show();
            }
            else
            {
                //string text = "\t\tLibrary Management\n" +
                //                "\tBorrow  ID   : " + txtBorrow_id.Text + "\n" +
                //                "\tReader  ID   : " + txtReader_id.Text + "\n" +
                //                "\tReader  Name : " + txtReader_Name.Text + "\n" +
                //                "\tCreator ID   : " + txtCreator_id.Text + "\n" +
                //                "\tCreator Name : " + txtCreator_Name.Text + "\n" +
                //                "\tCreate  At   : " + txtCreated_at.Text + "\n" +
                //                "\tUpdate  At   : " + txtUpdated_at.Text + "\n" +
                //                "\tPrint   At   : " + DateTime.Now.ToString() + "\n";

                FormPDF formPDF = new FormPDF(txtBorrow_id.Text);
                formPDF.Show();
            }
            
        }
    }




}
