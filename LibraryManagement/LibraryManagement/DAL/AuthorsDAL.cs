using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class AuthorsDAL : DataBase
    {
        private static AuthorsDAL _Instance;
        public static AuthorsDAL Instance
        {
            get
            {
                if (_Instance == null) return new AuthorsDAL();
                else return _Instance;
            }
            set { }
        }
        public DataTable LoadAllAuthors()
        {            
            return LoadData("select * from authors");
        }
        public void AddAuthors(Authors au)
        {            
            EditData("Insert into authors (first_name, last_name,gender,description,created_at,updated_at) values (N'" + au.first_name + "',N'" + au.last_name + "','" + au.gender + "',N'" + au.description + "','" + ChangeDate(DateTime.Now.ToString()) + "','" + ChangeDate(DateTime.Now.ToString()) + "')");
        }
        public void EditAuthors(Authors au, string id)
        {
            string datetime = ChangeDate(DateTime.Now.ToString());
            EditData("Update authors set first_name =N'" + au.first_name + "',last_name=N'" + au.last_name + "',gender='" + au.gender + "',description=N'" + au.description + "',updated_at='" + datetime + "' where id='" + id + "'");
        }
        public void DelAuthors(string id)
        {
            EditData("Update book_titles set author_id = NULL where author_id='" + id + "'");
            EditData("delete from authors where id ='" + id +"'");
        }
        public DataTable SearchAuthors(string s)
        {
            return LoadData("select * from authors where first_name like N'%" + s + "%' or last_name like N'%" + s + "%'");
        }
        public static string ChangeDate(string datetime)
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
    }
}
