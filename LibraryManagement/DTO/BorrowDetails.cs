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
        public BorrowDetails (int _borrow_id, int _book_id, string _book_title)
        {
            this.borrow_id = _borrow_id;
            this.book_id = _book_id;
            this.book_title = _book_title;
        }
    }

    
}
