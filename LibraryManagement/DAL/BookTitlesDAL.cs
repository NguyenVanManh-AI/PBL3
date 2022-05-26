using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class BookTitlesDAL : DataBase
    {
        private static BookTitlesDAL _Instance;
        public static BookTitlesDAL Instance
        {
            get
            {
                if (_Instance == null) return new BookTitlesDAL();
                return _Instance;
            }
            set { }
        }
        public DataTable LoadAllTitles()
        {
            return LoadData("select btt.*,au.first_name AS authorfname,au.last_name AS authorlname,pub.name AS tennxb ,ca.name AS tenlinhvuc from book_titles as btt left outer JOIN authors as au on btt.author_id = au.id left outer join publishers as pub on btt.publisher_id = pub.id left outer join categorys as ca on btt.category_id = ca.id WHERE 1 = 1");
        }
        public DataTable SearchTitles(string s)
        {
            return LoadData("select btt.*,au.first_name AS authorfname,au.last_name AS authorlname,pub.name AS tennxb ,ca.name AS tenlinhvuc from book_titles as btt left outer JOIN authors as au on btt.author_id = au.id left outer join publishers as pub on btt.publisher_id = pub.id left outer join categorys as ca on btt.category_id = ca.id WHERE title like N'%" + s + "%'"); //or authorfname like N'%"+s+"%'or authorlname like N'%"+s+"%' or tennxb like N'%"+s+"%' or tenlinhvuc like N'%"+s+"%'
        }
        public void AddTitle(BookTitles btt)
        {
            EditData("");
        }
        public void EditTitle(BookTitles btt, string id)
        {
            EditData("");
        }
        public void DeleteTitle(string id)
        {
            EditData("Update books set book_title_id = NULL where book_title_id ='" + id + "'");
            EditData("delete from book_titles where id='" + id + "'");
        }
    }
}
