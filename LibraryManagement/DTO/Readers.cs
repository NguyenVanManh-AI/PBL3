using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DTO
{
    public class Readers
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool gender { get; set; }
        public DateTime date_of_birth { get; set; }
        public string email { get; set; }
        public string identity_card_number { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Readers(string fname,string lname, bool gend,DateTime dob,string emai,string card, string phon,string addr)
        {
            first_name = fname;
            last_name = lname;
            gender = gend;
            date_of_birth = dob;
            email = emai;
            identity_card_number = card;
            phone = phon;
            address = addr;
        }
    }
}
