using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient; // + 


namespace LibraryManagement
{
    public partial class UpdateBooks : Form
    {
        public UpdateBooks(string id)
        {
            InitializeComponent();
            if (id == "")
            {
                cls.LoadData2DataGridView(dataGridView1, "select b.*,btt.title from books as b left outer join book_titles as btt on b.book_title_id = btt.id where 1 = 1");
            }
            else
            {
                cls.LoadData2DataGridView(dataGridView1, "select b.*,btt.title from books as b left outer join book_titles as btt on b.book_title_id = btt.id where book_title_id = '" + id + "'");
            }
        }
        Class.clsDatabase cls = new LibraryManagement.Class.clsDatabase();
        public string ChangeDate(string datetime)
        {
            if (datetime.Contains("CH") || datetime.Contains("SA"))
            {
                datetime = datetime.Replace("CH", "PM");
                datetime = datetime.Replace("SA", "AM");
                string[] arrListStr = datetime.Split(' ');
                string date = arrListStr[0];
                string time = arrListStr[1];
                string pm = arrListStr[2];

                string[] arrListStr2 = date.Split('/');

                string dd = arrListStr2[0];
                string mm = arrListStr2[1];
                string yyyy = arrListStr2[2];

                datetime = mm + "/" + dd + "/" + yyyy + " " + time + " " + pm;
            }
            return datetime;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            int bug = 0;
            string status = "";
            if (txtStatus.Text == "Da tra") status = "True";
            else status = "False";
            if (txtIdtitle.Text == "")
            {
                MessageBox.Show("Book Title Id cann't be left blank!");
                bug++;
            }
            else if (txtStatus.Text == "")
            {
                MessageBox.Show("Status cann't be left blank!");
                bug++;
            }
            if (bug == 0)
            {
                try
                {
                    string strInsert = "Insert into books (book_title_id,imported_at,status,created_at,updated_at) values ('" + txtIdtitle.Text + "','" + txtImport.Text + "','" + status + "','" + ChangeDate(DateTime.Now.ToString()) + "','" + ChangeDate(DateTime.Now.ToString()) + "')";
                    //MessageBox.Show(strInsert);
                    cls.ThucThiSQLTheoPKN(strInsert);
                    MessageBox.Show("Add successfully!");
                    cls.LoadData2DataGridView(dataGridView1, "select b.*,btt.title from books as b left outer join book_titles as btt on b.book_title_id = btt.id where 1 = 1");
                    txtid.Text = "";
                    txtIdtitle.Text = "";
                    txtImport.Text = "";
                    txtCreate.Text = "";
                    txtUpdate.Text = "";
                    txtStatus.Text = "";
                }
                catch
                {
                    MessageBox.Show("Add Fail");
                }
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            int bug = 0;
            string status = "";
            if (txtStatus.Text == "Da tra") status = "True";
            else status = "False";
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row of data you want to edit!");
            }
            else
            if (txtIdtitle.Text == "")
            {
                MessageBox.Show("Book Title Id cann't be left blank!");
                bug++;
            }
            else if (txtStatus.Text == "")
            {
                MessageBox.Show("Status cann't be left blank!");
                bug++;
            }
            if (bug == 0)
            {
                try
                {
                    string strUpdate = "Update books set book_title_id ='" + txtIdtitle.Text + "',status='" + status + "',imported_at='" + txtImport.Text + "',updated_at='" + ChangeDate(DateTime.Now.ToString()) + "' where id='" + txtid.Text + "'";
                    //MessageBox.Show(strUpdate);
                    cls.ThucThiSQLTheoPKN(strUpdate);
                    cls.LoadData2DataGridView(dataGridView1, "select b.*,btt.title from books as b left outer join book_titles as btt on b.book_title_id = btt.id where 1 = 1");
                    MessageBox.Show("Edit successfully!");
                    txtid.Text = "";
                    txtIdtitle.Text = "";
                    txtImport.Text = "";
                    txtCreate.Text = "";
                    txtUpdate.Text = "";
                    txtStatus.Text = "";
                }
                catch
                {
                    MessageBox.Show("Edit fail!");
                }
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row of data you want to delete !");
            }
            else if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string id = row.Cells[0].Value.ToString();
                            string strDelete = "Delete from books where id='" + id + "'";
                            cls.ThucThiSQLTheoKetNoi(strDelete);
                        }
                        cls.LoadData2DataGridView(dataGridView1, "select b.*,btt.title from books as b left outer join book_titles as btt on b.book_title_id = btt.id where 1 = 1");

                        MessageBox.Show("Delete successfully");
                        txtid.Text = "";
                        txtIdtitle.Text = "";
                        txtImport.Text = "";
                        txtCreate.Text = "";
                        txtUpdate.Text = "";
                        txtStatus.Text = "";
                    }
                    catch
                    {
                        MessageBox.Show("Delete Fail");
                    };
                }
            }
        }

        private void txtS_TextChanged(object sender, EventArgs e)

        {
            if (cbbS.Text == "Book")
            {
                cls.LoadData2DataGridView(dataGridView1, "select b.*,btt.title from books as b left outer join book_titles as btt on b.book_title_id = btt.id where book_title_id like '%" + txtS.Text + "%'");
            }
            else if (cbbS.Text == "Book Title")
            {
                cls.LoadData2DataGridView(dataGridView2, "select btt.*,au.first_name AS authorfname,au.last_name AS authorlname,pub.name AS tennxb ,ca.name AS tenlinhvuc from book_titles as btt left outer JOIN authors as au on btt.author_id = au.id left outer join publishers as pub on btt.publisher_id = pub.id left outer join categorys as ca on btt.category_id = ca.id WHERE title like '%" + txtS.Text + "%'");
            }
        }

        private void cbbS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbS.Text == "Book")
            {
                dataGridView1.Show();
                cls.LoadData2DataGridView(dataGridView1, "select b.*,btt.title from books as b left outer join book_titles as btt on b.book_title_id = btt.id where 1 = 1");
                dataGridView2.Hide();
            }
            else if (cbbS.Text == "Book Title")
            {
                dataGridView2.Show();
                cls.LoadData2DataGridView(dataGridView2, "select btt.*,au.first_name AS authorfname,au.last_name AS authorlname,pub.name AS tennxb ,ca.name AS tenlinhvuc from book_titles as btt left outer JOIN authors as au on btt.author_id = au.id left outer join publishers as pub on btt.publisher_id = pub.id left outer join categorys as ca on btt.category_id = ca.id WHERE 1 = 1");
                dataGridView1.Hide();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtIdtitle.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtImport.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "True") txtStatus.Text = "Da tra";
            else txtStatus.Text = "Chua tra";
            txtUpdate.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtCreate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
