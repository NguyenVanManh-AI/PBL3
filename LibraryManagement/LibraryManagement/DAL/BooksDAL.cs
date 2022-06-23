using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class BooksDAL : DataBase
    {
        private static BooksDAL _Instance;
        public static BooksDAL Instance
        {
            get
            {
                if (_Instance == null) return new BooksDAL();
                return _Instance;
            }
            set { }
        }
        public DataTable LoadBooksFromIdTitle(string id)
        {
            return LoadData("select b.*,btt.title from books as b left outer join book_titles as btt on b.book_title_id = btt.id where b.book_title_id='"+id+"'");
        }
        public DataTable SearchBooksWithStatus(string s,string ID,bool status)
        {   if(s!="") return LoadData("select b.*,btt.title from books as b left outer join book_titles as btt on b.book_title_id = btt.id where b.id like '%" + s + "%' and status ='" + status + "' and book_title_id='" + ID + "'");
            else return LoadData("select b.*,btt.title from books as b left outer join book_titles as btt on b.book_title_id = btt.id where status ='" + status+"' and book_title_id='"+ID+"'" );
        }
        public DataTable SearchAllBooks(string s, string ID)
        {
            if (s != "") return LoadData("select b.*,btt.title from books as b left outer join book_titles as btt on b.book_title_id = btt.id where b.id like '%" + s + "%' and book_title_id ='" + ID + "'");
            else return LoadData("select b.*,btt.title from books as b left outer join book_titles as btt on b.book_title_id = btt.id where book_title_id='" + ID + "'");
        }

        public void DeleteBook(string id)
        {
            EditData("update borrow_details set book_id=null where book_id ='" + id + "'");
            EditData("delete from books where id ='" + id +"'");
        }
        public void AddBook(Books b, int number)
        {
            for (int i = 1; i <= number; i++)
            {
                EditData("insert into books (book_title_id, imported_at, status,created_at,updated_at) values ('" + b.book_title_id + "','" + ChangeDate(b.imported_at.ToString(), false) + "','" + b.status + "','" + ChangeDate(DateTime.Now.ToString(), true) + "','" + ChangeDate(DateTime.Now.ToString(), true) + "')");
            }
        }

        public void EditBook(Books b, string id)
        {
            EditData("update books  set book_title_id = '" + b.book_title_id + "',imported_at = '"+ChangeDate(b.imported_at.ToString(),false)+"',status='"+b.status+"',updated_at='"+ChangeDate(DateTime.Now.ToString(),true)+"'where id ='"+id+"'");
        }
        public string GetTitleByBookTitleId(string id)
        {
            return Convert.ToString(GetValue("select title from book_titles where id='" + id + "'"));
        }
        public string ChangeDate(string datetime, bool check)
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
                if (check) datetime = mm + "/" + dd + "/" + yyyy + " " + time + " " + pm;
                else datetime = mm + "/" + dd + "/" + yyyy;
            }
            return datetime;
        }
        public int  GetGoodBooks()
        {
            return LoadData("select * from books where status ='true'").Rows.Count;
        }
        public int GetBadBooks()
        {
            return LoadData("select * from books where status ='false'").Rows.Count;
        }
        public int GetAllBooks()
        {
            return LoadData("select * from books").Rows.Count;
        }
        public int GetBooksBorrow()
        {
            return LoadData("select * from borrow_details where return_at is null").Rows.Count;
        }

        
    }
}
