using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DTO
{
    public class Borrows
    {
        public int id { get; set; }
        public int creator_id { get; set; }
        public string creator_name { get; set; }
        public int reader_id { get; set; }
        public string reader_name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Borrows(int _creator_id,string _creator_name,int _reader_id,string _reader_name)
        {
            creator_id = _creator_id;
            creator_name = _creator_name;
            reader_id = _reader_id;
            reader_name = _reader_name;
        }
    }
}
