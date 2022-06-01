using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Employees
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public DateTime date_of_birth { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public Employees(int _id , string _username , string _first_name, string _last_name,string _email, string _phone, string _address)
        {
            id = _id;
            username = _username;
            first_name = _first_name;
            last_name = _last_name;
            email = _email;
            phone = _phone;
            address = _address;
        }
    }

    
}
