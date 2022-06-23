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
    public partial class UC_BookTitles : UserControl
    {
        //public delegate void AddPanel(UserControl uc);
        //public AddPanel AP { get; set; }

        FormMain formMain;
        public UC_BookTitles(FormMain _formMain)
        {
            formMain = _formMain;
            InitializeComponent();
            dataGridView1.DataSource = BookTitlesBLL.Instance.LoadAllTitles();
            cbbS.SelectedItem = "Book Title";
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text != "")
                {
                    ResetTxt();
                }
                else if (txtId.Text == "")
                {

                    if (BooksBLL.Instance.CheckPhone(txtPage.Text)) new FormMeessageBox("Page's Number only contain number").Show();
                    else if (txtPDate.Text == "") new FormMeessageBox("Publication Date cann't be left blank!").Show();
                    else
                    {
                        BookTitles btt = new BookTitles(txtTitle.Text, BooksBLL.Instance.CheckInt(txtAuId.Text), BooksBLL.Instance.CheckInt(txtCateId.Text), BooksBLL.Instance.CheckInt(txtPubId.Text), txtDes.Text, Convert.ToDateTime(txtPDate.Text), BooksBLL.Instance.CheckInt(txtPage.Text));
                        //MessageBox.Show(BookTitlesDAL.Instance.AddTitle(btt));
                        if (BookTitlesBLL.Instance.AddTitle(btt) == "OK")
                        {
                            new FormMessageBoxSuccess("Add successfully!").Show();
                            dataGridView1.DataSource = BookTitlesBLL.Instance.LoadAllTitles();
                            ResetTxt();
                        }
                        else
                            new FormMeessageBox(BookTitlesBLL.Instance.AddTitle(btt)).Show();
                    }
                }
            }
            catch { }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            //        string strUpdate = "Update book_titles set title ='"+txtTitle.Text+"',author_id ='"+txtAu.Text+"',category_id='"+txtCate.Text+"',publisher_id='"+txtPub.Text+"',description='"+txtDes.Text+"',publication_date='"+txtDate.Text+"',number_of_pages ='"+txtPage.Text+"',updated_at='"+ChangeDate(DateTime.Now.ToString())+"'" + "where id='"+txtId.Text+"'";
            try
            {
                if (txtId.Text=="")
                {
                    new FormMeessageBox("Please select a Book Title you want to edit!").Show();
                }
                else if (dataGridView1.SelectedRows.Count > 1)
                {
                    new FormMeessageBox("Please select only 1 Book Title you want to edit!").Show();
                }
                else
                {
                    if (BooksBLL.Instance.CheckPhone(txtPage.Text)) new FormMeessageBox("Page's Number only contain number").Show();
                    else if (txtPDate.Text == "") new FormMeessageBox("Publication Date cann't be left blank!").Show();
                    else
                    {
                        BookTitles btt = new BookTitles(txtTitle.Text, BooksBLL.Instance.CheckInt(txtAuId.Text), BooksBLL.Instance.CheckInt(txtCateId.Text), BooksBLL.Instance.CheckInt(txtPubId.Text), txtDes.Text, Convert.ToDateTime(txtPDate.Text), BooksBLL.Instance.CheckInt(txtPage.Text));
                        //MessageBox.Show(BookTitlesDAL.Instance.EditTitle(btt, txtId.Text));
                        if (BookTitlesBLL.Instance.EditTitle(btt, txtId.Text) == "OK")
                        {
                            new FormMessageBoxSuccess("Edit successfully!").Show();
                            dataGridView1.DataSource = BookTitlesBLL.Instance.LoadAllTitles();
                            ResetTxt();
                        }
                        else
                        {
                            new FormMeessageBox(BookTitlesBLL.Instance.EditTitle(btt, txtId.Text)).Show();
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
                if (txtId.Text == "")
                {
                    new FormMeessageBox("Please select Book Titles you want to delete !").Show();
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string id = row.Cells[1].Value.ToString();
                            BookTitlesBLL.Instance.DeleteTitle(id);
                        }
                        new FormMessageBoxSuccess("Delete successfully!!").Show();
                        dataGridView1.DataSource = BookTitlesBLL.Instance.LoadAllTitles();
                        ResetTxt();
                    }
                }
            }
            catch { };
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cbbS.Text == "Book Title")
            {
                dataGridView1.DataSource = BookTitlesBLL.Instance.SearchTitles(txtSearch.Text);
            }
            else if (cbbS.Text == "Author")
            {
                dataGridView3.DataSource = AuthorsBLL.Instance.SearchAuthors(txtSearch.Text);
            }
            else if (cbbS.Text == "Publisher")
            {
                dataGridView2.DataSource = PublishersBLL.Instance.SearchPublishers(txtSearch.Text);
            }
            else if (cbbS.Text == "Category")
            {
                dataGridView4.DataSource = CategorysBLL.Instance.SearchCategorys(txtSearch.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbS.Text == "Book Title")
            {
                dataGridView1.Show();
                dataGridView1.DataSource = BookTitlesBLL.Instance.LoadAllTitles();
                dataGridView3.Hide();
                dataGridView4.Hide();
                dataGridView2.Hide();
            }
            else if (cbbS.Text == "Author")
            {
                dataGridView1.Hide();
                dataGridView3.Show();
                dataGridView3.DataSource = AuthorsBLL.Instance.LoadAllAuthors();
                dataGridView2.Hide();
                dataGridView4.Hide();
            }
            else if (cbbS.Text == "Publisher")
            {
                dataGridView1.Hide();
                dataGridView3.Hide();
                dataGridView2.Show();
                dataGridView2.DataSource = PublishersBLL.Instance.LoadAllPublishers();
                dataGridView4.Hide();
            }
            else if (cbbS.Text == "Category")
            {
                dataGridView1.Hide();
                dataGridView2.Hide();
                dataGridView3.Hide();
                dataGridView4.Show();
                dataGridView4.DataSource = CategorysBLL.Instance.LoadAllCategorys();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns["Column14"].Index && e.RowIndex >= 0)
                {
                    formMain.AddUC_Books_Panel1(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtAu.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString() + dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                txtPub.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                txtCate.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                txtPDate.Text = BookTitlesBLL.Instance.ShowDate(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                txtPage.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtDes.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtPubId.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtCateId.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAuId.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtUpdate.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtCreate.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtQuantity.Text = BookTitlesBLL.Instance.getNumberBooks(txtId.Text);
            }
            catch
            {
            };
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtPubId.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPub.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            } 
            catch { }
            
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtAuId.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtAu.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCateId.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCate.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
        }

        private void DTP_ValueChanged(object sender, EventArgs e)
        {
            txtPDate.Text = BookTitlesBLL.Instance.ShowDate (guna2DateTimePicker1.Value.ToString());
        }
        public void ResetTxt()
        {
            txtId.Text = "";
            txtTitle.Text = "";
            txtAu.Text = "";
            txtAuId.Text = "";
            txtPub.Text = "";
            txtPubId.Text = "";
            txtCate.Text = "";
            txtCateId.Text = "";
            txtPDate.Text = "";
            txtPage.Text = "";
            txtUpdate.Text = "";
            txtCreate.Text = "";
            txtDes.Text = "";
            txtQuantity.Text = "";
            dataGridView1.ClearSelection();
        }
    }
}
