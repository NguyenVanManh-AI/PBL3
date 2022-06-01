using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BookTitlesBLL : Function
    {
        private static BookTitlesBLL _Instance;
        public static  BookTitlesBLL Instance
        {
            get
            {
                if(_Instance == null) return new BookTitlesBLL();
                return _Instance;
            }
        }
        public DataTable LoadAllTitles()
        {
            return BookTitlesDAL.Instance.LoadAllTitles();
        }
        public DataTable SearchTitles(string s)
        {
            return BookTitlesDAL.Instance.SearchTitles(s);
        }
        public string AddTitle(BookTitles btt)
        {
            if (btt.title == "") return "Title can't be left blank!";
            BookTitlesDAL.Instance.AddTitle(btt);
            return "OK";
        }
        public string EditTitle(BookTitles btt, string id)
        {
            if (btt.title == "") return "Title can't be left blank!";
            BookTitlesDAL.Instance.EditTitle(btt,id);
            return "OK";
        }
        public void DeleteTitle(string id)
        {
            BookTitlesDAL.Instance.DeleteTitle(id);
        }

        
    }
}
