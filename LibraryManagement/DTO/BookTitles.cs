using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DTO
{
    public class BookTitles
    {
        public int id { get; set; }
        public string title { get; set; }
        public int author_id { get; set; }
        public int category_id { get; set; }
        public int publisher_id { get; set; }
        public string description { get; set; }
        public DateTime publication_date { get; set; }
        public int number_of_pages { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
