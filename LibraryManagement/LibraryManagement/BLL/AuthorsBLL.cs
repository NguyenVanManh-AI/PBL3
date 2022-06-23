using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    public class AuthorsBLL
    {
        private static AuthorsBLL _Instance;
        public static AuthorsBLL Instance
        {
            get
            {
                if (_Instance == null) _Instance= new AuthorsBLL();
                 return _Instance;
            }
            set { }
        }
        public DataTable LoadAllAuthors()
        {
            return AuthorsDAL.Instance.LoadAllAuthors();
        }
        public string AddAuthors(Authors au)
        {
            if (au.first_name == "") return "First Name cann't be left blank!";
            if (hasSpecialChar(au.first_name)) return "First Name cann't contain special char!";
            if (hasSpecialChar(au.last_name) && au.last_name != "") return "Last Name cann't contain special char!";
            AuthorsDAL.Instance.AddAuthors(au);
            return "OK";
        }
        public string EditAuthors(Authors au, string id)
        {   if (au.first_name == "") return "First Name cann't be left blank!";
            if (hasSpecialChar(au.first_name)) return "First Name cann't contain special char!";
            if(hasSpecialChar(au.last_name) && au.last_name != "") return "Last Name cann't contain special char!";
            AuthorsDAL.Instance.EditAuthors(au, id);
            return "OK";
        }
        public void DelAuthors(string id)
        {
            AuthorsDAL.Instance.DelAuthors(id);
        }
        public DataTable SearchAuthors(string s)
        {
            return AuthorsDAL.Instance.SearchAuthors(s);
        }
        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"~!@#$%^&*()_+`1234567890-=[]\{}|;':,./<>?";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
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
