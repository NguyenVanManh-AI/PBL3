using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL
{
    public class ManaEmployeesDAL : DataBase
    {
        private static ManaEmployeesDAL _Instance;
        public static ManaEmployeesDAL Instance
        {
            get
            {
                if (_Instance == null) return new ManaEmployeesDAL();
                else return _Instance;
            }
            set { }
        }

        public DataTable LoadAllEmployees()
        {
            return LoadData("select id,username,role,first_name,last_name,phone,email,address,date_of_birth,created_at,updated_at from employees");
        }

        public bool EditEmployees(Employees em, string dateOfBirth, string Date_Now)
        {
            try
            {
                string query = ("update employees set username = '" + em.username
                            + "',first_name=N'" + em.first_name + "',last_name=N'" + em.last_name + "',address=N'" + em.address + "',phone='"
                            + em.phone + "',email='" + em.email + "',date_of_birth='" + dateOfBirth + "',updated_at='" + Date_Now
                             + "'where id='" + em.id + "'");
                EditData(query);
                return true;
            }
            catch { return false; }
        }

        public bool DeleteEmployees(int id)
        {
            try
            {
                string query1 = ("update borrows set creator_id = null where creator_id = '"+id+"'");
                EditData(query1);
                string query2 = ("delete from employees where id ='" + id + "'");
                EditData(query2);
                return true;
            }
            catch { return false; }
        }

        public DataTable SearchEmployees(string text)
        {
            try
            {
                return LoadData("select id,username,role,first_name,last_name,phone,email,address,date_of_birth,created_at,updated_at" +
                    " from employees where username like '%" + text + "%' OR role like '%"
                + text + "%' OR first_name like N'%" + text + "%' OR last_name like N'%"
                + text + "%' OR address like N'%" + text + "%' OR phone like'%" + text
                + "%' OR email like '%" + text + "%' OR date_of_birth like '%" + text + "%' OR created_at like '%"
                + text + "%' OR updated_at like '%" + text + "%'");
            }
            catch { return LoadData("slect * from employees "); }
            
        }
    }
}
