using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BooksBLL : Function
    {
        private static BooksBLL _Instance;
        public static BooksBLL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new BooksBLL();
                return _Instance;
            }
            set { }
        }
        public DataTable LoadBooksFromIdTitle(string id)
        {
            return BooksDAL.Instance.LoadBooksFromIdTitle(id);
        }
        public DataTable SearchBooksWithStatus(string s, string ID, bool status)
        { 
            return BooksDAL.Instance.SearchBooksWithStatus(s,ID,status);
        }
        public DataTable SearchAllBooks(string s, string ID)
        {
            return BooksDAL.Instance.SearchAllBooks(s,ID);
        }
        public string AddBook(Books b,string number)
        {
            //if (!CheckDate(b.imported_at.ToString())) return "Incorrect Imported Date format!!";
            if (number == "")
                return "Please Enter number books !!!";
            else if (!CheckNumberBook(number))
                return "Invaild Book Number !!!";
            else if (!ExceedDate(b.imported_at.ToString())) return "Exceed the current date !!!";
            BooksDAL.Instance.AddBook(b,int.Parse(number));
            return "OK";
        }
        public string EditBook(Books b, string id) 
        {
            //if (!CheckDate(b.imported_at.ToString())) return "Incorrect Imported Date format!!";
            if (!ExceedDate(b.imported_at.ToString())) return "Exceed the current date !!!";
            BooksDAL.Instance.EditBook(b, id);
            return "OK";
        }
        public void DeleteBook(string id)
        {
            BooksDAL.Instance.DeleteBook(id);
        }
        public string GetTitleByBookTitleID(string id)
        {
            return BooksDAL.Instance.GetTitleByBookTitleId(id);
        }
        public int GetGoodBooks()
        {
            return BooksDAL.Instance.GetGoodBooks();
        }
        public int GetBadBooks()
        {
            return BooksDAL.Instance.GetBadBooks();
        }
        public int GetAllBooks()
        {
            return BooksDAL.Instance.GetAllBooks();
        }
        public int GetBooksBorrow()
        {
            return BooksDAL.Instance.GetBooksBorrow();
        }
    }
}
