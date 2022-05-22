using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DTO
{
    public class BorrowDetails
    {
        public int id { get; set; }
        public int borrow_id { get; set; }
        public int book_id { get; set; }
        public DateTime borrow_at { get; set; }
        public DateTime return_at { get; set; }
        public string book_title { get; set; }
    }
}
