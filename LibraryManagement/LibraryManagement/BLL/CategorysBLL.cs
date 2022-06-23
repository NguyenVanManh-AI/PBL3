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
    public class CategorysBLL
    {
        private static CategorysBLL _Instance;
        public static CategorysBLL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new CategorysBLL();
                return _Instance;
            }
            set { }
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
        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"~!@#$%^&*()_+`1234567890-=[]\{}|;':,./<>?";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
        public DataTable LoadAllCategorys()
        {
            return 
                CategorysDAL.Instance.LoadAllCategorys();
        }

        public string AddCategorys(Categorys cate)
        {
            if (cate.name == "") return "Category's Name cann't be left blank!";
            if (hasSpecialChar(cate.name)) return "Category's Name cann't contain special Char or Number";
            CategorysDAL.Instance.AddCategorys(cate);
            return "OK";
        }
        public void DeleteCategorys(string id)
        {
            CategorysDAL.Instance.DeleteCategorys(id);
        }
        public DataTable SearchCategorys(string s)
        {
            return CategorysDAL.Instance.SearchCategorys(s);
        }
        public string EditCategorys(Categorys cate, string id)
        {
            if (cate.name == "") return "Category's Name cann't be left blank!";
            if (hasSpecialChar(cate.name)) return "Category's Name cann't contain special Char or Number";
            CategorysDAL.Instance.EditCategorys(cate, id);
            return "OK";
        }
    }
}
