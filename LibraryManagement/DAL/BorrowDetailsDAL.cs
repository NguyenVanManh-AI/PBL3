using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class BorrowDetailsDAL : DataBase
    {
        private static BorrowDetailsDAL _Instance;
        public static BorrowDetailsDAL Instance
        {
            get
            {
                if (_Instance == null) return new BorrowDetailsDAL();
                else return _Instance;
            }
            set { }
        }

        const string sql_borrowdetail = "select brrdt.*,t2.name_category,t2.name_publisher,t2.first_name,t2.last_name from borrow_details as brrdt"
                                                     + " left outer join borrows as brr on brrdt.borrow_id = brr.id"
                                                     + " left outer join"
                                                     + " (select b.id, t1.title, t1.name_category, t1.name_publisher, t1.first_name, t1.last_name from books as b"
                                                     + " left join"
                                                     + " (select btt.id, btt.title, ca.name as name_category, pu.name as name_publisher, au.first_name, au.last_name from book_titles as btt"
                                                     + " left outer join categorys as ca on btt.category_id = ca.id"
                                                     + " left outer join publishers as pu on btt.publisher_id = pu.id"
                                                     + " left outer join authors as au on btt.author_id = au.id) as t1"
                                                     + " on b.book_title_id = t1.id) as t2 on brrdt.book_id = t2.id";

        const string sql_book = "select b.id,t1.title as title ,t1.publication_date,t1.name_category,t1.name_publisher,t1.address,t1.country,t1.first_name,t1.last_name from books as b"
                      + " left join (select btt.id, btt.title, btt.publication_date, ca.name as name_category ,pu.name as name_publisher,pu.address,pu.country ,au.first_name,au.last_name from book_titles as btt"
                      + " left outer join categorys as ca on btt.category_id = ca.id"
                      + " left outer join publishers as pu on btt.publisher_id = pu.id"
                      + " left outer join authors as au on btt.author_id = au.id) as t1"
                      + " on b.book_title_id = t1.id"
                      + " where b.id not in (select t1.book_id from borrow_details as t1"
                      + " left join"
                      + " (select* from borrow_details where return_at is not null) as t2"
                      + " on t1.book_id = t2.book_id"
                      + " where t1.return_at is null )  and title is not null ";

        public DataTable LoadAllBorrowDetails(string id_borrow)
        {
            return LoadData(sql_borrowdetail + " where brrdt.borrow_id = '" + id_borrow + "'");
        }
        public DataTable LoadAllBooks()
        {
            return LoadData(sql_book);
        }


        // kểm tra ngày mượn , ngày trả 
        // SAVE
        public string getNextBorrowDaySave(string borrow_detail_id, string id_book)
        {
            try
            {
                string query = "SELECT TOP 1 borrow_at FROM borrow_details where book_id = '"+ id_book + "' and id > '"+ borrow_detail_id + "'";
                return LoadData(query).Rows[0][0].ToString();
            }
            catch { return "0"; }
        }
        public string getPrevReturnDaySave(string borrow_detail_id, string id_book)
        {
            try
            {
                string query = "SELECT TOP 1 return_at FROM borrow_details where book_id = '" + id_book + "' and id< '"+ borrow_detail_id + "' ORDER BY id DESC";
                return LoadData(query).Rows[0][0].ToString();
            }
            catch { return "0"; }
        }

        // NEW 
        public string PrevReturnDayNew(string id_book)
        {
            try
            {
                string query = "SELECT TOP 1 return_at FROM borrow_details where book_id = '" + id_book + "'  ORDER BY id DESC";
                return LoadData(query).Rows[0][0].ToString();
            }
            catch { return "0"; }
        }

        // kểm tra ngày mượn , ngày trả 
        public bool AddBorrowDetails(BorrowDetails bor, string Borrow_at)
        {
            try
            {
                string query = "insert into borrow_details(borrow_id, book_id, borrow_at, book_title) values('" +
                    bor.borrow_id + "','" + bor.book_id + "','" + Borrow_at + "',N'" + bor.book_title + "')";
                EditData(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditBorrowDetails(string id_borrow_detail,BorrowDetails bor, string Borrow_at, string Return_at)
        {
            try
            {
                if(Return_at == "")
                {
                    string query = ("update borrow_details set book_id = '" + bor.book_id + "',borrow_at='" + Borrow_at
                            + "',book_title=N'" + bor.book_title + "'where id='" + id_borrow_detail + "'");
                    EditData(query);
                    return true;
                }
                else
                {
                    string query = ("update borrow_details set book_id = '" + bor.book_id + "',borrow_at='" + Borrow_at
                                    + "',return_at='" + Return_at + "',book_title=N'" + bor.book_title
                                    + "'where id='" + id_borrow_detail + "'");
                    EditData(query);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBorrowDetails(string id_borrow_detail)
        {
            try
            {
                string query = "delete from borrow_details where id='" + id_borrow_detail + "'" ;
                EditData(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable SearchBorrowDetails(string text,string id_borrow)
        {
            try
            {
                return LoadData(sql_borrowdetail + " where brrdt.borrow_id = '" + id_borrow + "' and (book_title like N'%" + text + "%' or name_category like N'%" + text + "%' " +
                " or name_publisher like N'%" + text + "%' or first_name like N'%" + text + "%' or last_name like N'%" + text + "%')");
            }
            catch 
            { 
                return LoadData(sql_borrowdetail + " where brrdt.borrow_id = '" + id_borrow + "'");
            }
        }
        public DataTable SearchBooks(string text)
        {
            try
            {
                return LoadData(sql_book + " and(t1.title like N'%"+ text + "%' or t1.name_category like N'%"+ text + "%' or t1.name_publisher " +
                    "like N'%"+ text + "%' or t1.address like N'%"+ text + "%' or t1.country like N'%"+ text + "%' or t1.first_name " +
                    "like N'%"+ text + "%' or t1.last_name like N'%"+ text + "%')");
            }
            catch
            {
                return LoadData(sql_book);
            }
        }

        public string getCOUNT(string borrow_id)
        {
            try
            {
                string query = "select COUNT(id) from borrow_details where borrow_id = "+borrow_id;
                return LoadData(query).Rows[0][0].ToString();
            }
            catch
            {
                return "0";
            }
        }
    }
}
