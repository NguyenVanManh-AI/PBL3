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
    public class ManaEmployeesBLL : EmployeesBLL
    {
        private static ManaEmployeesBLL _Instance;
        public static ManaEmployeesBLL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new ManaEmployeesBLL();
                return _Instance;
            }
            set { }
        }

        public DataTable LoadAllEmployees()
        {
            return ManaEmployeesDAL.Instance.LoadAllEmployees();
        }


        public string EditEmployees(Employees em, string dateOfBirth)
        {
            if (em.first_name == "")
                return "First Name cannot be blank !!!";
            else if (!CheckName(em.first_name))
                return "Incorrect First Name format !!!";
            else if (em.last_name != "" && !CheckName(em.last_name))
                return "Incorrect Last Name fomat !!!";
            else if (!CheckPhoneNumber(em.phone))
                return "Invalid phone number !!!";
            else if (!CheckUsernamePass(em.username))
                return "Username minimum 10 characters and maximum 24 characters including letters and numbers !!!";
            else if (em.email == "")
                return "Email cannot be blank !!!";
            else if (!CheckEmail2(em.email))
                return "Invalid Email !!!";
            else if (getIdByUsername(em.username) != "" && getIdByUsername(em.username) != em.id.ToString())
                return "Username already exists !!!";
            else if (getIdByEmail(em.email) != "" && getIdByEmail(em.email) != em.id.ToString())
                return "Email already exists !!!";
            else if (em.address == "")
                return "Address cannot be blank !!!";
            else if (!CheckDate(dateOfBirth))
                return "Incorrect date format !!!";
            else if (!ExceedDate(dateOfBirth))
                return "Exceed the current date !!!";
            else if (ManaEmployeesDAL.Instance.EditEmployees(em, SaveDate(dateOfBirth), Date_Now()))
                return "true";
            else
                return "false";
        }

        public string DeleteEmployees(int id)
        {
            if (id.ToString() == "")
                return "Please select a data line !!!";
            else if (ManaEmployeesDAL.Instance.DeleteEmployees(id))
                return "true";
            else 
                return "false";
        }

        public DataTable SearchEmployees(string text)
        {
            return ManaEmployeesDAL.Instance.SearchEmployees(text);
        }
    }
}
