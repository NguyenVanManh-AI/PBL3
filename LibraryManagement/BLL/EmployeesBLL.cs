using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EmailValidation;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Security.Cryptography;
using DAL;
using DTO;

namespace BLL
{
    public class EmployeesBLL
    {
        private static EmployeesBLL _instance;
        public static EmployeesBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EmployeesBLL();
                return _instance;
            }
            set { }
        }

        public bool CheckUsernamePass(string un)
        {
            // username và password phải từ 10 đến 24 kí tự chỉ bao gồm kí tự chữ thường hoặc chữ hoa hoặc chữ số 
            return Regex.IsMatch(un, "^[a-zA-Z0-9]{10,24}$");
        }

        public bool CheckLogin(string username, string password)
        {
            if (!(CheckUsernamePass(username) && CheckUsernamePass(password))) return false;
            return EmployeesDAL.Instance.CheckLogin(username, HashPass(password));
        }
        public bool CheckEmail(string em)
        {
            return Regex.IsMatch(em, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        public string CheckRole(string username)
        {
            return EmployeesDAL.Instance.CheckRole(username);
        }
        public string HashPass(string password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] password_bytes = Encoding.ASCII.GetBytes(password);
            byte[] encrypted_bytes = sha1.ComputeHash(password_bytes);
            return Convert.ToBase64String(encrypted_bytes);
        }

        public bool CheckAndSendMailToReset(string email)
        {
            if (!CheckEmail(email)) return false;
            bool check = EmployeesDAL.Instance.CheckMailToReset(email);
            if (check == true)
            {
                email_employee = email;
                codeText = RandomNumber(1000, 9999).ToString();
                SendEmail(email_employee, codeText, "Send Verification Code to change password");
            }
            return check;
        }
        
        public bool CheckOTP(string otp)
        {
            if (otp == codeText) return true;
            return false;
        }

        public string email_employee { get; set; }
        private static string codeText;
        private static readonly string from_email = "strongtechmaster@gmail.com"; // Email của Sender (của bạn)
        private static readonly string password_from_email = "strongtech2908"; // Mật khẩu Email của Sender (của bạn)
        public void SendEmail(string email, string codeText, string content)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(from_email);
            mail.To.Add(email_employee);
            mail.IsBodyHtml = true;
            mail.Body = content;
            mail.Subject = codeText;
            mail.Priority = MailPriority.High;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(from_email, password_from_email);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        public bool ConfirmPassword(string new_password,string confirm)
        {
            if (new_password == confirm) return true;
            else return false;
        }

        public bool ChangePassword(string email,string new_password)
        {
            return EmployeesDAL.Instance.ChangePassword(email, HashPass(new_password));
        }

























        //private static string email_reset;
       
        
        
        public bool CheckChangePass(string username)
        {
            return EmployeesDAL.Instance.CheckChangePass(username);
        }
        public bool CheckPhoneNumber(string pn)
        {
            return Regex.IsMatch(pn, "^[0-9]{10}$");
        }
        public bool CheckEmailExist(string em)
        {
            EmailValidator emailValidator = new EmailValidator();
            EmailValidationResult result;

            emailValidator.Validate(em, out result);
            switch (result)
            {
                case EmailValidationResult.OK:
                    return true;
                case EmailValidationResult.MailboxUnavailable:
                    return false;
                default:
                    return false;
            }
        }

        //public string CheckAccount(Employees account)
        //{
        //    if (account.Fullname == "") return "Invalid Fullname. Please enter your fullname.";
        //    if (!CheckUsernamePass(account.Username)) return "Invalid Username! Minimum 10 characters.\nMust not contain symbols.";
        //    if (!CheckPhoneNumber(account.Phone)) return "Invalid phone number! Your phone number.\nmust contain 10 characters.";
        //    if (!CheckEmail(account.Email)) return "Invalid Email!\nThe format of the email address is:username@gmail.com.\nUsername must not contain symbols";
        //    if (!CheckEmailExist(account.Email)) return "Email address does not exist!";
        //    return "OK";
        //}
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
        
        //public string Add(Employees account)
        //{
        //    string check = CheckAccount(account);
        //    if (check != "OK") return check;

        //    string pwd = RandomPassword();
        //    account.Password = HashPass(pwd);

        //    check = EmployeesDAL.Instance.Add(account);
        //    if (check == "OK")
        //    {
        //        email_employee = account.Email;
        //        content = "Welcome to CINESTAR CINEMA.<br>We create a new account for you.<br>Username: " + account.Username + "<br>Password: " + pwd;
        //        SendEmail(email_employee, content, "YOUR NEW ACCOUNT AT CINESTAR CINEMA.");
        //    }
        //    return check;
        //}
        public string GetEmailByUsername(string username)
        {
            email_employee = EmployeesDAL.Instance.GetEmailByUsername(username);
            return email_employee;
        }
        //public string Update(Employees account)
        //{
        //    string check = CheckAccount(account);
        //    if (check != "OK") return check;
        //    return EmployeesDAL.Instance.Update(account);
        //}
        public DataTable LoadAllAccount()
        {
            return EmployeesDAL.Instance.LoadAllAccount();
        }
        public DataTable LoadSearchAccount(string txt)
        {
            return EmployeesDAL.Instance.LoadSearchAccount(txt);
        }
        public DataRow LoadAccountByID(int id)
        {
            return EmployeesDAL.Instance.LoadAccountByID(id);
        }
        
        
        public void CheckAndSendMailToFirstLogin(string username)
        {
            codeText = RandomNumber(99999, 1000000).ToString();
            SendEmail(GetEmailByUsername(username), codeText, "FIRST LOGIN");
        }
        

        
        //public string ResetPass(string newpass, string confirmpass)
        //{
        //    string check;
        //    if (CheckUsernamePass(newpass))
        //    {
        //        if (confirmpass == newpass)
        //        {
        //            EmployeesDAL.Instance.ResetPass(HashPass(newpass), email_employee);
        //            check = "OK";
        //        }
        //        else check = "Your confirm password doesn't match your new password";

        //    }
        //    else check = "Invalid Password! Minimum 10 characters.\r\nMust not contain symbols.";
        //    return check;
        //}
        //public void Delete(List<int> id)
        //{
        //    foreach (int i in id)
        //    {
        //        AccountDAL.Instance.Delete(i);
        //    }
        //}
    }
}
