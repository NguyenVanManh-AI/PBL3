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


namespace QuanLyThuVien2
{
    public partial class BorrowDetails : Form
    {
        int id_borrow;

        public BorrowDetails(string id)
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

        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();
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
                     + " left join"
                     + " (select btt.id, btt.title, btt.publication_date, ca.name as name_category ,pu.name as name_publisher,pu.address,pu.country ,au.first_name,au.last_name from book_titles as btt"
                     + " left outer join categorys as ca on btt.category_id = ca.id"
                     + " left outer join publishers as pu on btt.publisher_id = pu.id"
                     + " left outer join authors as au on btt.author_id = au.id) as t1"
                     + " on b.book_title_id = t1.id";

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
            else
            {
                if(mkReturnAt.Text == "  /  /") // nếu để trống ngày trả 
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
                                string SQL = "insert into borrow_details(borrow_id, book_id, borrow_at,return_at, book_title) values('" + txtBorrowId.Text + "','" + txtBookId.Text + "','" + LuuNgay(mkBorrowAt.Text) + "','" + LuuNgay(mkReturnAt.Text) + "',N'" + tBook_Title + "')";
                                //MessageBox.Show(SQL);
                                cls.ThucThiSQLTheoKetNoi(SQL);
                                MessageBox.Show("Add successfully");
                                ReSet_Txt();
                            }
                            catch { MessageBox.Show("Erorr !!!"); }
                        }
                    }


                    
                }
                
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