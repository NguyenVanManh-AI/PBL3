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


using System.Data.SqlClient; // + 


namespace LibraryManagement
{
    public partial class BorrowDetails2 : Form
    {
        int id_borrow;

        public BorrowDetails2(string id)
        {
            id_borrow = Int32.Parse(id);
            InitializeComponent();
        }


        // + 
        SqlCommand sqlCommand;
        public Object layGiaTri(string sql) 
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = Con;
            Object obj = sqlCommand.ExecuteScalar(); 
            return obj;
        }

        SqlConnection Con;
        // + 

        Class.clsDatabase cls = new LibraryManagement.Class.clsDatabase();
        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"1234567890";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        string tBook_Title = "";
        string mBorrow_At = "";
        string mReturn_At = "";

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBorrowDetailId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtBookId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtBookTitle.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtCategoryName.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtPublisherName.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtAuthorName.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() +" "+ dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() != "")
            {
                mkBorrowAt.Text = HienThiNgay(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() != "")
            {
                mkReturnAt.Text = HienThiNgay(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }


            tBook_Title = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() != "")
            {
                mBorrow_At = HienThiNgay(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() != "")
            {
                mReturn_At = HienThiNgay(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }

        }

        string sql_borrowdetail = "";
        string sql_book = "";
        private void UpdateBorrowingInforamtion_Load(object sender, EventArgs e)
        {
            txtBorrowId.Text = id_borrow.ToString() ;
            dataGridView1.Show();
            dataGridView2.Hide();
            dataGridView1.Show();
            try
            {
                Con = new SqlConnection();
                Con.ConnectionString = @"Server =DESKTOP-QCOSLTK\VANMANH;" + "database=System_Library; Integrated Security = true";
                Con.Open();
            }
            catch { }
            sql_borrowdetail = "select brrdt.*,t2.name_category,t2.name_publisher,t2.first_name,t2.last_name from borrow_details as brrdt"
                                                     + " left outer join borrows as brr on brrdt.borrow_id = brr.id"
                                                     + " left outer join"
                                                     + " (select b.id, t1.title, t1.name_category, t1.name_publisher, t1.first_name, t1.last_name from books as b"
                                                     + " left join"
                                                     + " (select btt.id, btt.title, ca.name as name_category, pu.name as name_publisher, au.first_name, au.last_name from book_titles as btt"
                                                     + " left outer join categorys as ca on btt.category_id = ca.id"
                                                     + " left outer join publishers as pu on btt.publisher_id = pu.id"
                                                     + " left outer join authors as au on btt.author_id = au.id) as t1"
                                                     + " on b.book_title_id = t1.id) as t2 on brrdt.book_id = t2.id";

            cls.LoadData2DataGridView(dataGridView1, sql_borrowdetail + " where brrdt.borrow_id = " + id_borrow);

            sql_book = "select b.id,t1.title,t1.publication_date,t1.name_category,t1.name_publisher,t1.address,t1.country,t1.first_name,t1.last_name from books as b"
                      + " left join (select btt.id, btt.title, btt.publication_date, ca.name as name_category ,pu.name as name_publisher,pu.address,pu.country ,au.first_name,au.last_name from book_titles as btt"
                      + " left outer join categorys as ca on btt.category_id = ca.id"
                      + " left outer join publishers as pu on btt.publisher_id = pu.id"
                      + " left outer join authors as au on btt.author_id = au.id) as t1"
                      + " on b.book_title_id = t1.id"
                      + " where b.id not in (select t1.book_id from borrow_details as t1"
                      + " left join"
                      + " (select* from borrow_details where return_at is not null) as t2"
                      + " on t1.book_id = t2.book_id"
                      + " where t1.return_at is null)";

            cls.LoadData3DataGridView(dataGridView2, sql_book );

        }

        public static string LuuNgay(string input)
        {
            string dd = input.Substring(0, 2);
            string mm = input.Substring(3, 2);
            string yyyy = input.Substring(6, 4);
            input = mm + "/" + dd + "/" + yyyy;
            return input;
        }

        public static bool QuaNgay(string input)
        {
            input = LuuNgay(input);
            DateTime oDate = Convert.ToDateTime(input);
            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString("MM/dd/yyyy");
            DateTime oDate2 = Convert.ToDateTime(date);
            if (oDate > oDate2) return false;
            else return true;
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

        public static bool CheckNgay(string input)
        {
            try
            {
                DateTime.ParseExact(input, "dd/MM/yyyy", null); 
                if (!QuaNgay(input)) return false;
                else return true;

            }
            catch{ return false;}
        }

        public bool CheckSach(string input)
        {
            object Q = layGiaTri("SELECT id FROM borrow_details WHERE book_id = '" + input + "' and return_at is null ");
            string id = Convert.ToString(Q);
            MessageBox.Show("/"+id+"/");
            if (id == "") return true;
            return false; 
        }

        public bool NgayMuonSomNhat(string borrow_at,string id_book)
        {
            // đếm số dòng nếu >1 (2 dòng trở lên => có sách được mượn trước đó 
            object Q = layGiaTri("SELECT COUNT(id) FROM borrow_details WHERE book_id = '" + id_book + "'");
            string number_count = Convert.ToString(Q);

            if(Int32.Parse(number_count) < 2) // nếu chỉ có 1 dòng hoặc không dòng thì không cần kiểm tra ngày tháng 
            { 
                return true;
            }
            else
            {
                //cùng muột cuốn sách thì ngày mượn phải lớn hơn ngày trả của lần mượn gần nhất

                // lấy ra id của lần mượn gần nhất 
                //lúc mà lưu => thì sẽ có 2 giá trị nên ta phải lấy giá trị gần nhất trước đó để lấy ngày trả, chứ không lấy giá
                //trị hiện tại vì nó mới mượn chưa có ngày trả


                Q = layGiaTri("SELECT MAX(s.id) FROM(SELECT s1.id FROM borrow_details AS s1 WHERE s1.id < (SELECT MAX(s2.id) " +
                    " FROM borrow_details AS s2 where s2.book_id = "+id_book+") and s1.book_id = "+id_book+") AS s");
                string max_id = Convert.ToString(Q);
                MessageBox.Show(max_id);
                // lấy ra ngày trả của lần mượn gần nhất 
                Q = layGiaTri("SELECT return_at FROM borrow_details WHERE id = '" + max_id + "'");
                string return_at = Convert.ToString(Q);

                // đưa ngày mượn về dạng lưu 
                borrow_at = LuuNgay(borrow_at);
                DateTime borrowAt = Convert.ToDateTime(borrow_at);
                DateTime returnAt = Convert.ToDateTime(return_at);

                //MessageBox.Show(" borrow : " + borrow_at + " return : " + return_at);

                // so sánh nếu như ngày trả mà lớn hơn ngày mượn => vô lí vì chưa trả đã mượn 
                if (returnAt > borrowAt) return false; // nên false 
                return true;
            }
            
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBookId.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            tBook_Title     = txtBookTitle.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCategoryName.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPublisherName.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtAuthorName.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString() + " " + dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
        }
        
        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            object Q = layGiaTri("SELECT MADG FROM tblDocGia  WHERE HOTEN like '%" + txtSearch2.Text + "%' OR LOP like '%" + txtSearch2.Text + "%' OR DIACHI like '%" + txtSearch2.Text + "%' OR EMAIL like '%" + txtSearch2.Text + "%'");
            string NguoiDoc = Convert.ToString(Q);

            Q = layGiaTri("Select s.MASACH from tblSach as s left join tblLinhVuc as lv on s.MaLv = lv.MaLv left join tblTacGia as tg on s.MATG = tg.MATG  where s.TENSACH like '%" + txtSearch2.Text + "%' OR lv.TenLv like '%" + txtSearch2.Text + "%' OR tg.TENTG like '%" + txtSearch2.Text + "%'");
            string Sach = Convert.ToString(Q);
        }

        

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            mkBorrowAt.Text = HienThiNgay(dateTimePicker2.Value.ToString());
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            mkReturnAt.Text = HienThiNgay(dateTimePicker1.Value.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Borrow Details")
            {
                dataGridView1.Show();
                dataGridView2.Hide();
            }
            else
            {
                dataGridView2.Show();
                dataGridView1.Hide();
            }
        }

        public void ReSet_Txt()
        {
            txtBorrowDetailId.Text = "";
            txtBookId.Text = "";
            txtBookTitle.Text = "";
            txtCategoryName.Text = "";
            txtAuthorName.Text = "";
            txtPublisherName.Text = "";
            mkBorrowAt.Text = "";
            mkReturnAt.Text = "";
            cls.LoadData2DataGridView(dataGridView1, sql_borrowdetail + " where brrdt.borrow_id = " + id_borrow);
            cls.LoadData3DataGridView(dataGridView2, sql_book);
            dataGridView1.Show();
            dataGridView2.Hide();
            comboBox1.Text = "Borrow Details";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtBookId.Text == "")
                MessageBox.Show("Please select a Book !!!");
            else if (mkBorrowAt.Text == "  /  /")
                MessageBox.Show("Please select a Borrow Date !!!");
            else if (!mkBorrowAt.MaskFull || !CheckNgay(mkBorrowAt.Text)) 
                // ngày mượn phải nhập đầy đủ - đúng ngày - không vượt quá ngày hiện tại là được 
                MessageBox.Show("Invalid Borrow At Date !");
            else if (!CheckSach(txtBookId.Text))
                MessageBox.Show("Book not available !!!");
            else if (!NgayMuonSomNhat(mkBorrowAt.Text, txtBookId.Text))
                MessageBox.Show("Invalid Borrow At Date !");
            else
            {
                try
                {
                    string SQL = "insert into borrow_details(borrow_id, book_id, borrow_at, book_title) values('" + txtBorrowId.Text + "','" + txtBookId.Text + "','" + LuuNgay(mkBorrowAt.Text) + "',N'" + tBook_Title + "')";
                    //MessageBox.Show(SQL);
                    cls.ThucThiSQLTheoKetNoi(SQL);
                    MessageBox.Show("Add successfully");
                    ReSet_Txt();
                }
                catch { MessageBox.Show("Erorr !!!"); }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBorrowDetailId.Text == "")
                MessageBox.Show("Pleaser select a Borrow detail !!!");
            else if (txtBookId.Text == "")
                MessageBox.Show("Please select a Book !!!");
            else if (mkBorrowAt.Text == "  /  /")
                MessageBox.Show("Please select a Borrow Date !!!");
            else if (!mkBorrowAt.MaskFull || !CheckNgay(mkBorrowAt.Text))
                // ngày mượn phải nhập đầy đủ - đúng ngày - không vượt quá ngày hiện tại là được 
                MessageBox.Show("Invalid Borrow At Date !");
            else if(!NgayMuonSomNhat(mkBorrowAt.Text,txtBookId.Text))
                MessageBox.Show("Invalid Borrow At Date !");
            else
            {
                if (mkReturnAt.Text == "  /  /") // nếu để trống ngày trả 
                {
                    try
                    {
                        string SQL = ("update borrow_details set book_id = '" + txtBookId.Text + "',borrow_at='" + LuuNgay(mkBorrowAt.Text) 
                            + "',book_title=N'" + tBook_Title + "'where id='" + txtBorrowDetailId.Text + "'");
                        cls.ThucThiSQLTheoKetNoi(SQL);
                        MessageBox.Show("Edit successfully");
                        ReSet_Txt();
                    }
                    catch { MessageBox.Show("Erorr !!!"); }
                }


                else  // nếu không để trống ngày trả 
                {
                    if (!mkReturnAt.MaskFull || !CheckNgay(mkReturnAt.Text))
                        // thì ngày trả phải nhập đầy đủ - đúng ngày - không vượt quá ngày hiện tại là được 
                        MessageBox.Show("Invalid Return At Date !");
                    else
                    {
                        DateTime Date1 = Convert.ToDateTime(LuuNgay(mkBorrowAt.Text));
                        DateTime Date2 = Convert.ToDateTime(LuuNgay(mkReturnAt.Text));
                        if (Date1 > Date2) // ngày mượn không được lớn hơn ngày trả 
                            MessageBox.Show("Invalid Return At Date !");
                        else
                        {
                            try
                            {
                                string SQL = ("update borrow_details set book_id = '" + txtBookId.Text + "',borrow_at='" + LuuNgay(mkBorrowAt.Text) 
                                    + "',return_at='" + LuuNgay(mkReturnAt.Text) + "',book_title=N'" + tBook_Title 
                                    + "'where id='" + txtBorrowDetailId.Text + "'");
                                cls.ThucThiSQLTheoKetNoi(SQL);
                                MessageBox.Show("Edit successfully");
                                ReSet_Txt();
                            }
                            catch { MessageBox.Show("Erorr !!!"); }
                        }
                    }



                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtBorrowDetailId.Text == "")
                MessageBox.Show("Pleaser select a Borrow detail !!!");
            else
            {
                try
                {
                    if (MessageBox.Show("Are you sure to delete Borrow Details information " + txtBorrowDetailId.Text.ToUpper() , "Delete Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string SQL = ("delete from borrow_details where id='" + txtBorrowDetailId.Text + "'");
                        cls.ThucThiSQLTheoKetNoi(SQL);
                        MessageBox.Show("Delete successfully");
                        ReSet_Txt();
                    }
                }
                catch { MessageBox.Show("Erorr !!!"); }

            }
        }
    }

}