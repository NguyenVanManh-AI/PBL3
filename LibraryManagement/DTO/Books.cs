using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DTO
{
    public class Books
    {
        public int id { get; set; }
        public int book_title_id { get; set; }
        public DateTime imported_at { get; set; }
        public bool status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Books(int title_id,DateTime import, bool statuss)
        {

            this.book_title_id = title_id;
            this.imported_at = import;
            this.status = statuss;
        }
    }
}

