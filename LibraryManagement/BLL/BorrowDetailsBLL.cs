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
    public class BorrowDetailsBLL : EmployeesBLL
    {
        private static BorrowDetailsBLL _Instance;
        public static BorrowDetailsBLL Instance
        {
            get
            {
                if (_Instance == null) return new BorrowDetailsBLL();
                return _Instance;
            }
        }
        public DataTable LoadAllBorrowDetails(string id_borrow)
        {
            return BorrowDetailsDAL.Instance.LoadAllBorrowDetails(id_borrow);
        }
        public DataTable LoadAllBooks()
        {
            return BorrowDetailsDAL.Instance.LoadAllBooks();
        }

        public bool CompareDay(string Borrow_At, string Return_At)
        {
            DateTime Date1 = Convert.ToDateTime(SaveDate(Borrow_At));
            DateTime Date2 = Convert.ToDateTime(SaveDate(Return_At));
            if (Date1 > Date2) return false;
            else return true;
        }

        public bool CompareDay2(string Borrow_At, string Return_At)
        {
            DateTime Date1 = Convert.ToDateTime(Borrow_At);
            DateTime Date2 = Convert.ToDateTime(Return_At);
            if (Date1 > Date2) return false;
            else return true;
        }


        // SAVE 
        public bool NextBorrowDaySave(string return_at,string borrow_detail_id,string id_book)
        {
            try
            {
                string borrow_at = BorrowDetailsDAL.Instance.getNextBorrowDaySave(borrow_detail_id,id_book);
                if (borrow_at == "0") return true;
                else
                {
                    return_at = SaveDate(return_at);
                    DateTime borrowAt = Convert.ToDateTime(borrow_at);
                    DateTime returnAt = Convert.ToDateTime(return_at);
                    if (returnAt > borrowAt) return false;
                    return true;
                }
            }
            catch { return false; }
        }
        public bool PrevReturnDaySave(string borrow_at, string borrow_detail_id, string id_book)
        {
            try
            {
                string return_at = BorrowDetailsDAL.Instance.getPrevReturnDaySave(borrow_detail_id, id_book);
                if (return_at == "0") return true;
                else
                {
                    borrow_at = SaveDate(borrow_at);
                    DateTime borrowAt = Convert.ToDateTime(borrow_at);
                    DateTime returnAt = Convert.ToDateTime(return_at);
                    if (returnAt > borrowAt) return false;
                    return true;
                }
            }
            catch { return false; }
        }

        // NEW  
        public bool PrevReturnDayNew(string borrow_at, string id_book)
        {
            try
            {
                string return_at = BorrowDetailsDAL.Instance.PrevReturnDayNew(id_book);
                if (return_at == "0") return true;
                else
                {
                    borrow_at = SaveDate(borrow_at);
                    DateTime borrowAt = Convert.ToDateTime(borrow_at);
                    DateTime returnAt = Convert.ToDateTime(return_at);
                    if (returnAt > borrowAt) return false;
                    return true;
                }
            }
            catch { return false; }
        }
        public string AddBorrowDetails(BorrowDetails bor, string Borrow_at)
        {
            try
            {
                if (!CheckDate(Borrow_at))
                    return "Incorrect Borrow date format !!!";
                else if (!ExceedDate(Borrow_at))
                    return "Exceed the current Borrow date !!!";
                else if (!PrevReturnDayNew(Borrow_at, bor.book_id.ToString()))
                    return "Borrowing date exceeds the previous repayment date !!! ";
                else if (BorrowDetailsDAL.Instance.AddBorrowDetails(bor, SaveDate(Borrow_at)))
                    return "true";
                else
                    return "false";
            }
            catch { return "false"; }
        }
        public string EditBorrowDetails(string id_borrow_detail, BorrowDetails bor, string Borrow_at, string Return_at)
        {
            try
            {
                if (bor.book_id.ToString() == "")
                    return "Please select a Book !!!";
                else if (!CheckDate(Borrow_at))
                    return "Incorrect Borrow date format !!!";
                else if (!ExceedDate(Borrow_at))
                    return "Exceed the current Borrow date !!!";
                else if (!PrevReturnDaySave(Borrow_at,id_borrow_detail,bor.book_id.ToString()))
                    return "Borrowing date exceeds the previous repayment date !!! ";
                else if (Return_at == "")
                {
                    if (BorrowDetailsDAL.Instance.EditBorrowDetails(id_borrow_detail, bor, SaveDate(Borrow_at), ""))
                        return "true";
                    else
                        return "false";
                }
                else if (Return_at != "")
                {
                    if (!CheckDate(Return_at))
                        return "Incorrect Return date format !!!";
                    else if (!ExceedDate(Return_at))
                        return "Exceed the current Return date !!!";
                    else if (!CompareDay2(Borrow_at, Return_at))
                        return "Borrowing date cannot exceed repayment date";
                    else if (!NextBorrowDaySave(Return_at, id_borrow_detail, bor.book_id.ToString()))
                        return "The return date of the book exceeds the next borrowing date !!!";
                    else
                    {
                        if (BorrowDetailsDAL.Instance.EditBorrowDetails(id_borrow_detail, bor, SaveDate(Borrow_at), SaveDate(Return_at)))
                            return "true";
                        else
                            return "false";
                    }
                }
                else
                    return "false";
            }
            catch { return "false"; }
        }

        public string DeleteBorrowDetails(string id_borrow_detail)
        {
            try
            {
                if (id_borrow_detail == "")
                    return "Pleaser select a Borrow detail !!!";
                else if (BorrowDetailsDAL.Instance.DeleteBorrowDetails(id_borrow_detail))
                    return "true";
                else return "false";
            }
            catch { return "false"; }
        }

        public DataTable SearchBorrowDetails(string text,string id_borrow)
        {
            return BorrowDetailsDAL.Instance.SearchBorrowDetails(text,id_borrow);
        }

        public DataTable SearchBooks(string text)
        {
            return BorrowDetailsDAL.Instance.SearchBooks(text);
        }

        public string getCOUNT(string borrow_id)
        {
            try
            {
                return BorrowDetailsDAL.Instance.getCOUNT(borrow_id);
            }
            catch { return "0"; }
        }

        

    }
}
