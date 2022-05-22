using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class UpdateBookTitle : Form
    {
        public UpdateBookTitle()
        {
            InitializeComponent();
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
        public static string LuuNgay(string input)
        {
            string dd = input.Substring(0, 2);
            string mm = input.Substring(3, 2);
            string yyyy = input.Substring(6, 4);
            input = mm + "/" + dd + "/" + yyyy;
            return input;
        }

        public static string HienThiNgay(string input)
        {
            string[] arrListStr = input.Split('/');
            string mm = arrListStr[0];
            string dd = arrListStr[1];
            string yyyy = arrListStr[2];
            if (mm.Length == 1) mm = "0" + mm;
            if (dd.Length == 1) dd = "0" + dd;
            input = dd + "/" + mm + "/" + yyyy;
            return input;
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            int bug = 0;
            if (txtTitle.Text == "")
            {
                MessageBox.Show("Title cann't be left blank!");
                bug++;
            }
            else if (txtPub.Text == "")
            {
                MessageBox.Show("Publish Id cann't be left blank!");
                bug++;
            }
            else if (txtAu.Text == "")
            {
                MessageBox.Show("Author Id cann't be left blank!");
                bug++;
            }
            else if (txtCate.Text == "")
            {
                MessageBox.Show("Category Id cann't be left blank!");
                bug++;
            }
            if (bug == 0)
            {
                try
                {
                    string strInsert = "Insert into book_titles (title,author_id,category_id,publisher_id,description,publication_date,number_of_pages,created_at,updated_at) values ('"+ txtTitle.Text +"','"+txtAu.Text+"','"+txtCate.Text+"','"+txtPub.Text+"','"+txtDes.Text+"','"+txtDate.Text+"','"+txtPage.Text+"','"+ChangeDate(DateTime.Now.ToString())+"','"+ ChangeDate(DateTime.Now.ToString())+"')";
                    //MessageBox.Show(strInsert);
                    cls.ThucThiSQLTheoPKN(strInsert);
                    MessageBox.Show("Add successfully!");
                    cls.LoadData2DataGridView(dataGridView2, "select btt.*,au.first_name AS authorfname,au.last_name AS authorlname,pub.name AS tennxb ,ca.name AS tenlinhvuc from book_titles as btt left outer JOIN authors as au on btt.author_id = au.id left outer join publishers as pub on btt.publisher_id = pub.id left outer join categorys as ca on btt.category_id = ca.id WHERE 1 = 1");
                    txtId.Text = "";
                    txtTitle.Text = "";
                    txtAu.Text = "";
                    txtPub.Text = "";
                    txtCate.Text = "";
                    txtDes.Text = "";
                    txtUpdate.Text = "";
                    txtCreate.Text = "";
                    txtDate.Text = "";
                    txtPage.Text = "";
                }
                catch {
                    MessageBox.Show("Add fail");
                }
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            int bug = 0;
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row of data you want to edit!");
            }
            else if (txtTitle.Text == "")
            {
                MessageBox.Show("Title cann't be left blank!");
                bug++;
            }
            else if (txtPub.Text == "")
            {
                MessageBox.Show("Publish Id cann't be left blank!");
                bug++;
            }
            else if (txtAu.Text == "")
            {
                MessageBox.Show("Author Id cann't be left blank!");
                bug++;
            }
            else if (txtCate.Text == "")
            {
                MessageBox.Show("Category Id cann't be left blank!");
                bug++;
            }
            if (bug == 0)
            {
                try
                {
                    string strUpdate = "Update book_titles set title ='"+txtTitle.Text+"',author_id ='"+txtAu.Text+"',category_id='"+txtCate.Text+"',publisher_id='"+txtPub.Text+"',description='"+txtDes.Text+"',publication_date='"+txtDate.Text+"',number_of_pages ='"+txtPage.Text+"',updated_at='"+ChangeDate(DateTime.Now.ToString())+"'" + "where id='"+txtId.Text+"'";
                    //MessageBox.Show(strUpdate);
                    cls.ThucThiSQLTheoPKN(strUpdate);
                    cls.LoadData2DataGridView(dataGridView2, "select btt.*,au.first_name AS authorfname,au.last_name AS authorlname,pub.name AS tennxb ,ca.name AS tenlinhvuc from book_titles as btt left outer JOIN authors as au on btt.author_id = au.id left outer join publishers as pub on btt.publisher_id = pub.id left outer join categorys as ca on btt.category_id = ca.id WHERE 1 = 1");
                    MessageBox.Show("Edit successfully!");
                    txtId.Text = "";
                    txtTitle.Text = "";
                    txtAu.Text = "";
                    txtPub.Text = "";
                    txtCate.Text = "";
                    txtDes.Text = "";
                    txtUpdate.Text = "";
                    txtCreate.Text = "";
                    txtDate.Text = "";
                    txtPage.Text = "";
                }
                catch {
                    MessageBox.Show("Edit fail!");
                }
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row of data you want to delete !");
            }
            else if (dataGridView2.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                        {
                            string id = row.Cells[0].Value.ToString();
                            string strDelete = "Delete from book_titles where id='" + id + "'";
                            cls.ThucThiSQLTheoKetNoi(strDelete);
                        }
                        cls.LoadData2DataGridView(dataGridView2, "select btt.*,au.first_name AS authorfname,au.last_name AS authorlname,pub.name AS tennxb ,ca.name AS tenlinhvuc from book_titles as btt left outer JOIN authors as au on btt.author_id = au.id left outer join publishers as pub on btt.publisher_id = pub.id left outer join categorys as ca on btt.category_id = ca.id WHERE 1 = 1");
                        txtId.Text = "";
                        txtTitle.Text = "";
                        txtAu.Text = "";
                        txtPub.Text = "";
                        txtCate.Text = "";
                        txtDes.Text = "";
                        txtUpdate.Text = "";
                        txtCreate.Text = "";
                        txtDate.Text = "";
                        txtPage.Text = "";
                        MessageBox.Show("Delete successfully");
                    }
                    catch
                    {
                        MessageBox.Show("Delete fail");
                    };
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(cbbS.Text=="Book Title")
            {
                cls.LoadData2DataGridView(dataGridView2, "select btt.*,au.first_name AS authorfname,au.last_name AS authorlname,pub.name AS tennxb ,ca.name AS tenlinhvuc from book_titles as btt left outer JOIN authors as au on btt.author_id = au.id left outer join publishers as pub on btt.publisher_id = pub.id left outer join categorys as ca on btt.category_id = ca.id WHERE title like '%"+txtSearch.Text+"%'");
            }
            else if (cbbS.Text == "Author")
            {
                cls.LoadData2DataGridView(dataGridView3, "select * from authors where first_name like '%" + txtSearch.Text + "%' or last_name like '%" + txtSearch.Text + "%'");
            }
            else if (cbbS.Text == "Publisher")
                {
                cls.LoadData2DataGridView(dataGridView4, "select * from publishers where name like'%" + txtSearch.Text + "%' OR address like'%" + txtSearch.Text + "%' OR country like'%" + txtSearch.Text + "%'");
                }
            else if (cbbS.Text == "Category")
                {
                cls.LoadData2DataGridView(dataGridView5, "select * from categorys where name like '%" + txtSearch.Text + "%'");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbS.Text=="Book Title")
            {
                dataGridView2.Show();
                cls.LoadData2DataGridView(dataGridView2, "select btt.*,au.first_name AS authorfname,au.last_name AS authorlname,pub.name AS tennxb ,ca.name AS tenlinhvuc from book_titles as btt left outer JOIN authors as au on btt.author_id = au.id left outer join publishers as pub on btt.publisher_id = pub.id left outer join categorys as ca on btt.category_id = ca.id WHERE 1 = 1");
                dataGridView3.Hide();
                dataGridView4.Hide();
                dataGridView5.Hide();
            }
            else if (cbbS.Text == "Author")
            {
                dataGridView2.Hide();
                dataGridView3.Show();
                cls.LoadData3DataGridView(dataGridView3, "select * from authors");
                dataGridView4.Hide();
                dataGridView5.Hide();
            }
            else if (cbbS.Text == "Publisher")
            {
                dataGridView2.Hide();
                dataGridView3.Hide();
                dataGridView4.Show();
                cls.LoadData4DataGridView(dataGridView4, "select * from publishers");
                dataGridView5.Hide();
            }
            else if (cbbS.Text == "Category")
            {
                dataGridView2.Hide();
                dataGridView3.Hide();
                dataGridView4.Hide();
                dataGridView5.Show();
                cls.LoadData5DataGridView(dataGridView5, "select * from categorys");
            }
        }

        private void UpdateBookTitle_Load_1(object sender, EventArgs e)
        {
                cls.LoadData2DataGridView(dataGridView2, "select btt.*,au.first_name AS authorfname,au.last_name AS authorlname,pub.name AS tennxb ,ca.name AS tenlinhvuc from book_titles as btt left outer JOIN authors as au on btt.author_id = au.id left outer join publishers as pub on btt.publisher_id = pub.id left outer join categorys as ca on btt.category_id = ca.id WHERE 1 = 1");
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView2.Columns["Book"].Index && e.RowIndex >= 0)
            {
                UpdateBooks book = new UpdateBooks(dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString());
                book.Show();
            }
            txtId.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTitle.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAu.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPub.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtCate.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDes.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtUpdate.Text = dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtCreate.Text = dataGridView2.Rows[e.RowIndex].Cells[9].Value.ToString();
            if (dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString() == "") txtDate.Text = "";
            else txtDate.Text = HienThiNgay(dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString());
            txtPage.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

    }
}
