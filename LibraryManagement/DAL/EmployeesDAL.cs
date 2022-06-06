using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class EmployeesDAL : DataBase
    {
        private static EmployeesDAL _instance;
        public static EmployeesDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EmployeesDAL();
                return _instance;
            }
            set { }
        }

        public bool CheckLogin(string username, string password)
        {
            bool check = false;
            string query = "Select * from employees Where username = '" + username + "'and password = '" + password + "'";
            if (LoadData(query).Rows.Count > 0) check = true;
            return check;
        }
        public string CheckRole(string username)
        {
            string query = "Select role from employees where username = '" + username + "'";
            return LoadData(query).Rows[0][0].ToString();
        }

        public bool CheckMailToReset(string email)
        {
            string query = "Select * from employees where email = '" + email + "'";
            if (LoadData(query).Rows.Count == 0) return false;
            return true;
        }
        public bool ChangePassword(string email,string new_password)
        {
            try
            {
                string query = "UPDATE employees set password = '" + new_password + "' where email = '" + email + "'";
                EditData(query);
                return true;
            }
            catch { return false; }
            
        }

        public bool ChangePasswordByUsername(string username, string new_password)
        {
            try
            {
                string query = "UPDATE employees set password = '" + new_password + "' where username = '" + username + "'";
                EditData(query);
                return true;
            }
            catch { return false; }

        }

        public string getName(string username)
        {
            try
            {
                string query1 = "select first_name from employees where username = '" + username + "'";
                string query2 = "select last_name from employees where username = '" + username + "'";
                return LoadData(query2).Rows[0][0].ToString() + " " + LoadData(query1).Rows[0][0].ToString(); ;
            }
            catch { return "Error" ; }
        }

        public string getOldPassword(string username)
        {
            try
            {
                string query = "select password from employees where username = '" + username + "'";
                return LoadData(query).Rows[0][0].ToString();
            }
            catch { return "Error"; }
        }

        public DataTable LoadInforEmployee(string username)
        {
            string query = "select first_name ,last_name, address , phone , email , date_of_birth , created_at , " +
                "updated_at  from employees where username='" + username + "'" ;
            return LoadData(query);
        }

        public bool SaveInforAccount(string username , string first_name, string last_name, string phone, string email, string address, string date_of_birth,string date_now)
        {
            try
            {
                string query = "update employees set first_name=N'" + first_name + "',last_name=N'" + last_name + "',address=N'" + address 
                    + "',phone='" + phone + "',email='" + email + "',date_of_birth='" + date_of_birth + "',updated_at='" 
                    + date_now + "' where username='" + username + "'";
                EditData(query);
                return true;
            }
            catch { return false; }
        }

        public string getUsernamebyEmail(string email)
        {   try
            {
                string query = "select username from employees where email = '" + email + "'";
                return LoadData(query).Rows[0][0].ToString();
            }
            catch { return ""; }
        }

        public string getIdByUsername(string username)
        {
            try
            {
                string query = "select id from employees where username = '" + username + "'";
                return LoadData(query).Rows[0][0].ToString();
            }
            catch { return ""; }
        }

        public string getIdByEmail(string email)
        {
            try
            {
                string query = "select id from employees where email = '" + email + "'";
                return LoadData(query).Rows[0][0].ToString();
            }
            catch { return ""; }
        }

        public bool CreatedAcount(string username, string password , string email , string date_now)
        {
            try
            {
                string query = "insert into employees(username,password,email,role,created_at,updated_at) " +
                    "values('" + username + "','" + password+ "','" + email + "','user','" + date_now + "','" + date_now + "')";
                EditData(query);
                return true;
            }
            catch { return false; }
        }




















    }
}
