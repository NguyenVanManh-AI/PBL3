using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DTO
{
    public class Publishers
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Publishers (string namee, string dess, string countryy, string addr)
        {
            this.name = namee;
            this.description = dess;
            this.address = addr;
            this.country = countryy;
        }
    }
}
