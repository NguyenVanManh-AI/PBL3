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
        public bool CheckRole(string username)
        {
            string query = "Select role from TBStaff where username = '" + username + "'";
            return Convert.ToBoolean(LoadData(query).Rows[0][0].ToString().Trim());

        }
        public bool CheckChangePass(string check)// by email or username
        {
            string query = "Select changepwd from TBStaff where username = '" + check + "' or email = '" + check + "'";
            return Convert.ToBoolean(LoadData(query).Rows[0][0].ToString().Trim());

        }
        public string CheckAdd(Employees account)
        {
            string query = "Select email from TBStaff where email = '" + account.Email + "'";
            if (LoadData(query).Rows.Count != 0) return "Email address is already registered!";
            query = "Select username from TBStaff where username = '" + account.Username + "'";
            if (LoadData(query).Rows.Count != 0) return "Username is already being used!";
            return "OK";
        }
        public string CheckUpdate(Employees account)
        {
            string query = "Select email from TBStaff where email = '" + account.Email + "' and id_number != " + account.ID;
            if (LoadData(query).Rows.Count != 0) return "Email address is already registered!";
            query = "Select username from TBStaff where username = '" + account.Username + "' and id_number != " + account.ID;
            if (LoadData(query).Rows.Count != 0) return "Username is already being used!";
            return "OK";
        }
        public string Add(Employees account)
        {
            string check = CheckAdd(account);
            if (check != "OK") return check;

            // add
            string query = "Insert into TBStaff(fullname, username, pwd, phone_number, email,role) values('"
                          + account.Fullname + "','" + account.Username + "','" + account.Password + "','" + account.Phone + "','"
                          + account.Email + "','" + account.Role + "')";
            EditData(query);
            return "OK";
        }
        public string GetEmailByUsername(string username)
        {
            string query = "SELECT email FROM TBStaff where username = '" + username + "';";
            return LoadData(query).Rows[0][0].ToString();
        }
        //public string GetUsernameByEmail(string email)
        //{
        //    string query = "SELECT username  FROM TBStaff where email = '" + email + "';";
        //    return LoadData(query).Rows[0][0].ToString();
        //}
        public void ChangedPass(string email)
        {
            string query = "UPDATE TBStaff set changepwd = 'false' where email = '" + email + "'";
            EditData(query);
        }
        public string Update(Employees account)
        {
            string check = CheckUpdate(account);
            if (check != "OK") return check;

            // ud  
            string query = "UPDATE TBStaff set fullname = '" + account.Fullname + "', username = '" + account.Username +
              "', phone_number = '" + account.Phone + "', email = '" + account.Email + "', role = '" + account.Role + "' where id_number = " + account.ID;
            EditData(query);
            return "OK";
        }
        public DataTable LoadAllAccount()
        {
            string query = "SELECT id_number,fullname,username,phone_number,email,role FROM TBStaff";
            return LoadData(query);
        }
        public DataTable LoadSearchAccount(string txt)
        {
            string query = "Select  id_number,fullname,username,phone_number,email,role from TBStaff where username = '" + txt + "' or fullname like '%" + txt
                + "%' or phone_number = '" + txt + "' or email = '" + txt + "';"; ;
            return LoadData(query);
        }
        public DataRow LoadAccountByID(int id)
        {
            string query = "SELECT id_number,fullname,username,phone_number,email,role FROM TBStaff WHERE id_number = " + id + ";";
            return LoadData(query).Rows[0];
        }
        public bool CheckLogin(string username, string password)
        {
            bool check = false;
            string query = "Select * from TBStaff Where username = '" + username + "'and pwd = '" + password + "'";
            if (LoadData(query).Rows.Count > 0) check = true;
            return check;
        }
        public string CheckMailToReset(string email)
        {
            string query = "Select * from TBStaff where email = '" + email + "'";
            if (LoadData(query).Rows.Count == 0) return "Invalid Email! Email address is not registered!";
            return "OK";

        }
        public void ResetPass(string newpass, string email)
        {
            if (CheckChangePass(email)) ChangedPass(email);
            string query = "Update TBStaff Set pwd = '" + newpass + "' Where email = '" + email + "';";
            EditData(query);
        }
        public void Delete(int id)
        {
            string query = "DELETE FROM TBStaff WHERE id_number = " + id + ";";
            EditData(query);
        }

    }
}
