using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PublishersDAL : DataBase
    {
        private static PublishersDAL _Instance;
        public static PublishersDAL Instance
        {
            get
            {
                if(_Instance == null) return new PublishersDAL();
                return _Instance;
            }
            set { }
        }
        public DataTable LoadAllPublishers()
        {
            return LoadData("select * from publishers");
        }
        public void AddPublisher(Publishers pub)
        {
            EditData("insert into publishers (name,country,address,description,created_at,updated_at) values (N'" + pub.name + "',N'" + pub.country + "',N'" + pub.address + "',N'" + pub.description + "','" + ChangeDate(DateTime.Now.ToString()) + "','" + ChangeDate(DateTime.Now.ToString()) + "')");
        }
        public void EditPublisher(Publishers pub, string id)
        {
            EditData("update publishers set name =N'" + pub.name + "',country=N'" + pub.country + "',address=N'" + pub.address + "',description=N'" + pub.description + "',updated_at='" + ChangeDate(DateTime.Now.ToString()) + "' where id='"+id+"'");
        }
        public void DeletePublishers(string id)
        {
            EditData("Update book_titles set publisher_id = NULL where publisher_id = '" + id + "'");
            EditData("Delete from publishers where id='" + id + "'");
        }
        public DataTable SearchPublisher(string s)
        {
            return LoadData("select * from publishers where name like N'%" + s + "%' or country like N'%" + s + "%' or address like N'%" + s + "%'");
        }
        public string ChangeDate(string datetime)
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
