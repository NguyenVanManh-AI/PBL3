using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class ReadersBLL : Function
    {
        private static ReadersBLL _Instance;
        public static ReadersBLL Instance
        {
            get
            {
                if (_Instance == null) return new ReadersBLL();
                return _Instance;
            }
            set { }
        }
        public DataTable LoadAllReaders()
        {
            return ReadersDAL.Instance.LaodAllReaders();
        }
        public DataTable SearchReaders(string s)
        {
            return ReadersDAL.Instance.SearchReaders(s);
        }
        public string AddReader(Readers r)
        {
            if (r.first_name == "") return "First Name cann't be left blank!";
            if (r.phone == "") return "Phone Number cann't be left blank!";
            if (hasSpecialChar(r.first_name)) return "First Name cann't contain special char!";
            if (hasSpecialChar(r.last_name)) return "Last Name cann't contain special char or number!";
            if (!CheckEmail2(r.email) && r.email !="") return "Invalid Email!";
            if (CheckPhone(r.phone)) return "Phone Number only contain number!";
            if (r.phone.Length != 10) return "Phone Number must contain 10 number ";
            //if (!CheckDate(r.date_of_birth.ToString())) return "Incorrect Date Of Birth format!!";
            if (!ExceedDate(r.date_of_birth.ToString())) return "Exceed the current date !!!";
            ReadersDAL.Instance.AddReader(r);
            return "OK";
        }
        public string EditReader(Readers r, string id)
        {
            if (r.first_name == "") return "First Name cann't be left blank!";
            if (r.phone == "") return "Phone Number cann't be left blank!";
            if (hasSpecialChar(r.first_name)) return "First Name cann't contain special char!";
            if (hasSpecialChar(r.last_name) && r.last_name != "") return "Last Name cann't contain special char or number!";
            if (!CheckEmail2(r.email) && r.email != "") return "Invalid Email!";
            if (CheckPhone(r.phone)) return "Phone Number only contain number!";
            if (r.phone.Length != 10) return "Phone Number must contain 10 number ";
            //if (!CheckDate(r.date_of_birth.ToString())) return "Incorrect Date Of Birth format!!";
            if (!ExceedDate(r.date_of_birth.ToString())) return "Exceed the current date !!!";
            ReadersDAL.Instance.EditReader(r,id);
            return "OK";
        }
        public void DeleteReader(string id)
        {
            ReadersDAL.Instance.DeleteReader(id);
        }
        
    }
}
