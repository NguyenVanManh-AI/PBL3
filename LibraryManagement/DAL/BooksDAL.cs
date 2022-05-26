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
        public DataTable LoadAllBooks()
        {
            return LoadData("select * from books");
        }
        public DataTable LoadBooksFromIdTitle(string id)
        {
            return LoadData("select * from books where book_title_id ='"+id+"'");
        }
        public DataTable SearchBooksWithStatus(string s,string ID,bool status)
        {   if(s!="") return LoadData("select * from books where id ='" + s + "' and status ='" + status + "' and book_title_id='" + ID + "'");
            else return LoadData("select * from books where status ='"+status+"' and book_title_id='"+ID+"'" );
        }
        public DataTable SearchAllBooks(string s, string ID)
        {
            if (s != "") return LoadData("select * from books where id ='" + s + "' and book_title_id='" + ID + "'");
            else return LoadData("select * from books where book_title_id='" + ID + "'");
        }
        public void DeleteBook(string id)
        {
            EditData("update borrow_details set book_id=null where book_id ='" + id + "'");
            EditData("delete from books where id ='" + id +"'");
        }
        public void AddBook(Books b)
        {
            
        }
        public void EditBook(Books b, string id)
        {

        }
        public string GetTitleByBookTitleId(string id)
        {
            return Convert.ToString(GetValue("select title from book_titles where id='" + id + "'"));
        }
    }
}
