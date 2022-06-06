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
            EditData("insert into book_titles (title,author_id,category_id,publisher_id,description,publication_date,number_of_pages,created_at,updated_at) values (N'" + btt.title +"',"+ ChangeInt(btt.author_id)+","+ ChangeInt(btt.category_id)+","+ ChangeInt(btt.publisher_id)+",N'"+btt.description+"','"+ChangeDate(btt.publication_date.ToString(),false)+"',"+ ChangeInt(btt.number_of_pages)+",'"+ChangeDate(DateTime.Now.ToString(),true)+"','"+ ChangeDate(DateTime.Now.ToString(), true)+"')");
            //return "insert into book_titles (title,author_id,category_id,publisher_id,description,publication_date,number_of_pages,created_at,updated_at) values (N'" + btt.title + "'," + ChangeInt(btt.author_id) + "," + ChangeInt(btt.category_id) + "," + ChangeInt(btt.publisher_id) + ",N'" + btt.description + "','" + ChangeDate(btt.publication_date.ToString(), false) + "'," + ChangeInt(btt.number_of_pages) + ",'" + ChangeDate(DateTime.Now.ToString(), true) + "','" + ChangeDate(DateTime.Now.ToString(), true) + "')";
        }
        public void EditTitle(BookTitles btt, string id)
        {
            //return "update book_titles set title =N'" + btt.title + "',author_id=" + ChangeInt(btt.author_id) + ",category_id=" + ChangeInt(btt.category_id) + ",publisher_id=" + ChangeInt(btt.publisher_id) + ",description='" + btt.description + "',publication_date='" + ChangeDate(btt.publication_date.ToString(), false) + "',number_of_pages=" + ChangeInt(btt.number_of_pages) + ",updated_at='" + ChangeDate(DateTime.Now.ToString(), true) + "' where id='" + id + "'";
            EditData("update book_titles set title =N'"+btt.title+"',author_id="+ ChangeInt(btt.author_id)+",category_id="+ ChangeInt(btt.category_id)+",publisher_id="+ ChangeInt(btt.publisher_id)+",description=N'"+btt.description+"',publication_date='"+ ChangeDate(btt.publication_date.ToString(), false) + "',number_of_pages="+ ChangeInt(btt.number_of_pages)+",updated_at='"+ChangeDate(DateTime.Now.ToString(), true)+"' where id='"+id+"'");
        }
        public void DeleteTitle(string id)
        {
            EditData("update books set book_title_id = null where book_title_id ='" + id + "'");
            EditData("delete from book_titles where id='" + id + "'");
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
        public string ChangeInt(int x)
        {
            if (x == 0) return "null";
            else return x.ToString();
        }

        public string getNumberBooks(string book_title_id)
        {
            try
            {
                string query = "select COUNT(id) from books where book_title_id = '"+book_title_id+"'";
                return LoadData(query).Rows[0][0].ToString();
            }
            catch
            {
                return "0";
            }
        }
    }
}
