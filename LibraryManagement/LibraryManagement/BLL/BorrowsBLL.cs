using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    public class BorrowsBLL : Function
    {
        private static BorrowsBLL _Instance;
        public static BorrowsBLL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new BorrowsBLL();
                return _Instance;
            }
            set { }
        }

        public DataTable LoadAllBorrows()
        {
            return BorrowsDAL.Instance.LoadAllBorrows();
        }

        public DataTable LoadReaderToLimitTime()
        {
            return BorrowsDAL.Instance.LoadReaderToLimitTime(Date_Now_ToLimitTime());
        }

        public DataTable PrintPDF(int id_borrow)
        {
            return BorrowsDAL.Instance.PrintPDF(id_borrow);
        }
        public DataTable LoadAllReaders()
        {
            return BorrowsDAL.Instance.LoadAllReaders();
        }

        public string AddBorrows(Borrows bo)
        {
            try
            {
                if (BorrowsDAL.Instance.AddBorrows(bo, Date_Now()))
                    return "true";
                else
                    return "false";
            }
            catch { return "false"; }
        }
        public string EditBorrows(int id_borrow, Borrows bo)
        {
            try
            {
                if (id_borrow.ToString() == "" || bo.reader_id.ToString() == "")
                    return "Please select a Borrow !!!";
                else if (BorrowsDAL.Instance.EditBorrows(id_borrow, bo, Date_Now()))
                    return "true";
                else
                    return "false";
            }
            catch { return "false"; }
            
        }
        
        public bool CheckNotReturnList(int id_borrow)
        {
            if (Int32.Parse(BorrowsDAL.Instance.CheckNotReturnList(id_borrow)) > 0) return false;
            else return true;
        }
        public string DeleteBorrows(int id_borrow)
        {
            try
            {
                if (id_borrow.ToString() == "")
                    return "Please select a Borrow !!!";
                else if (!CheckNotReturnList(id_borrow))
                    return "You can't delete the loan slip because there are some unpaid books !!!";
                else if (BorrowsDAL.Instance.DeleteBorrows(id_borrow))
                    return "true";
                else
                    return "false";
            }
            catch { return "false"; }
        }

        public DataTable SearchBorrows(string text)
        {
            return BorrowsDAL.Instance.SearchBorrows(text);
        }
        public DataTable SearchBorrowsToLimitTime(string text)
        {
            return BorrowsDAL.Instance.SearchBorrowsToLimitTime(text,Date_Now_ToLimitTime());
        }

        public DataTable SearchReader(string text)
        {
            return BorrowsDAL.Instance.SearchReader(text);
        }

        public string getNameById(int id)
        {
            return BorrowsDAL.Instance.getNameById(id);
        }
        public string getUsernameById(int id)
        {
            return BorrowsDAL.Instance.getUsernameById(id);
        }









    }
}
