using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL
{
    public class BorrowsDAL : DataBase
    {
        private static BorrowsDAL _Instance;
        public static BorrowsDAL Instance
        {
            get
            {
                if (_Instance == null) return new BorrowsDAL();
                else return _Instance;
            }
            set { }
        }

        public DataTable LoadAllBorrows()
        {
            return LoadData("select *  from borrows");
        }
        public DataTable LoadReaderToLimitTime(string Date_Now_ToLimitTime)
        {
            try
            {
                return LoadData("select * from borrows where id in (select borrow_id from  borrow_details where return_at is null " +
                "and DATEDIFF(day, borrow_at, '" + Date_Now_ToLimitTime + "') > 90)");
            }
            
            catch
            {
                return LoadData("select *  from borrows where id = 0");
            }
        }

        public DataTable PrintPDF(int id_borrow)
        {
            return LoadData("select * from borrows where id = '"+id_borrow+"'");
        }

        public DataTable LoadAllReaders()
        {
            return LoadData("select *  from readers");
        }


        public bool AddBorrows(Borrows bo, string Date_Now)
        {
            try
            {
                string query = "Insert Into borrows(creator_id,creator_name,reader_id,reader_name,created_at,updated_at) values ('" 
                    + bo.creator_id + "',N'" + bo.creator_name + "','" + bo.reader_id + "',N'" + bo.reader_name  + "','" + Date_Now 
                    + "','" + Date_Now + "')";
                EditData(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditBorrows(int id_borrow , Borrows bo, string Date_Now)
        {
            try
            {
                string query = ("update borrows set reader_id='" + bo.reader_id + "',reader_name = N'" + bo.reader_name 
                    + "',updated_at='" + Date_Now + "'where id='" + id_borrow + "'");
                EditData(query);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public string CheckNotReturnList(int id_borrow)
        {
            try
            {
                string query = "select COUNT(id) from borrow_details where return_at is null and borrow_id = '"+id_borrow+"'";
                return LoadData(query).Rows[0][0].ToString();
            }
            catch { return "0";}
        }
        public bool DeleteBorrows(int id_borrow)
        {
            try
            {
                string query1 = ("update borrow_details set borrow_id = null where borrow_id = '" + id_borrow+"'");
                EditData(query1);
                string query2 = ("delete from borrows where id='" + id_borrow + "'");
                EditData(query2);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string getNameById(int id)
        {
            try
            {
                string query1 = "select first_name from employees where id = '" + id + "'";
                string query2 = "select last_name from employees where id = '" + id + "'";
                return LoadData(query2).Rows[0][0].ToString() + " " + LoadData(query1).Rows[0][0].ToString(); ;
            }
            catch { return "Error"; }
        }
        public string getUsernameById(int id)
        {
            try
            {
                string query = "select username from employees where id = '" + id + "'";
                return LoadData(query).Rows[0][0].ToString(); 
            }
            catch { return "Error"; }
        }
        

        public DataTable SearchBorrows(string text)
        {
            try
            {
                return LoadData("select * from borrows where creator_name like N'%" + text + "%' or reader_name like N'%" + text + "%'");
            }
            catch
            {
                return LoadData("select *  from borrows");
            }
        }

        public DataTable SearchBorrowsToLimitTime(string text , string Date_Now_TooLimitTime)
        {
            try
            { 
                return LoadData("select * from borrows where id in (select borrow_id from  borrow_details where return_at is null " +
                "and DATEDIFF(day, borrow_at, '" + Date_Now_TooLimitTime + "') > 90) and (creator_name like N'%" + text + "%' or reader_name like N'%" + text + "%')");
            }

            catch
            {
                return LoadData("select *  from borrows where id = 0");
            }
        }

        public DataTable SearchReader(string text)
        {
            try
            {
                return LoadData("select * from readers where first_name like N'%" + text + "%' or last_name like N'%" + text
                + "%' or email like '%" + text + "%' or phone like '%" + text + "%' or identity_card_number like '%"
                + text + "%' or address like N'%" + text + "%'");
            }
            catch
            {
                return LoadData("select *  from readers");
            }
        }










    }
}
