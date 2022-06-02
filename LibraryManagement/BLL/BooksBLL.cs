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
        public string AddBook(Books b)
        {
            BooksDAL.Instance.AddBook(b);
            return "OK";
        }
        public string EditBook(Books b, string id) 
        {
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
