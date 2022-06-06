using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class CategorysDAL : DataBase
    {
        private static CategorysDAL _Instance;
        public static CategorysDAL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new CategorysDAL();
                return _Instance;
            }
            set { }
        }
        public DataTable LoadAllCategorys()
        {
            return LoadData("select * from categorys");
        }
        public void AddCategorys(Categorys cate)
        {
            EditData("Insert into categorys (name,description,created_at,updated_at) values (N'" + cate.name + "',N'" + cate.description + "','" + ChangeDate(DateTime.Now.ToString()) + "','" + ChangeDate(DateTime.Now.ToString()) + "')");
        }
        public void EditCategorys(Categorys cate, string id)

        {
            EditData("Update categorys set name =N'" + cate.name + "',description=N'" + cate.description + "',updated_at='" + ChangeDate(DateTime.Now.ToString()) + "' where id='" + id + "'");
        }
        public void DeleteCategorys(string id)
        {
            EditData("Update book_titles set category_id = NULL where category_id='" + id + "'");
            EditData("Delete from categorys where id ='" + id + "'");           
        }
        public DataTable SearchCategorys(string s)
        {
            return LoadData("Select * from categorys where name like N'%" + s + "%'");
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
