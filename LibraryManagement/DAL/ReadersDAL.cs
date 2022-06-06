using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ReadersDAL : DataBase
    {
        private static ReadersDAL _Instance;
        public static ReadersDAL Instance
        {
            get
            {
                if (_Instance == null) return new ReadersDAL();
                return _Instance;
            }
            set { }
        }
        public DataTable LaodAllReaders()
        {
            return LoadData("select * from readers");
        }
        public DataTable SearchReaders(string s)
        {
            return LoadData("select * from readers where first_name like N'%" + s + "%' or last_name like N'%"+s+"%' or address like N'%"+s+"%' or email like '%"+s+"%' or phone like '%"+s+"%'");
        }
        public void AddReader(Readers r)
        {
            EditData("insert into readers (first_name,last_name,gender,date_of_birth,address,email,phone,identity_card_number,created_at,updated_at) values (N'"+r.first_name+"',N'"+r.last_name+"','"+r.gender+"','"+ ChangeDate(r.date_of_birth.ToString(),false) + "',N'"+r.address+"',N'"+r.email+"','"+r.phone+"','"+r.identity_card_number+"','"+ChangeDate(DateTime.Now.ToString(),true)+"','" + ChangeDate(DateTime.Now.ToString(),true)+"')");
        }
        public void EditReader(Readers r, string id)
        {
            EditData("update readers set first_name = N'" + r.first_name + "',last_name=N'" + r.last_name + "',gender='" + r.gender + "',date_of_birth='" + ChangeDate(r.date_of_birth.ToString(), false) + "',address=N'" + r.address + "',phone='" + r.phone + "',identity_card_number='" + r.identity_card_number + "',updated_at='" + ChangeDate(DateTime.Now.ToString(),true) + "' where id='" + id + "'");
        }
        public void DeleteReader(string id)
        {
            EditData("Update borrows set reader_id = NULL where reader_id='"+id+"'");
            EditData("Delete from readers where id ='" + id + "'");
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
    }
}
