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
using System.Net;
using System.Collections.Specialized;
using outlook = Microsoft.Office.Interop.Outlook;
using System;
using System.Net.Mail;
using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Text;
using EASendMail; //add EASendMail namespace

namespace BLL
{
    public class EmployeesBLL : Function
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
        public bool CheckEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
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

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public bool CheckAndSendMailToReset(string email)
        {
            if (!CheckEmail(email)) return false;
            bool check = EmployeesDAL.Instance.CheckMailToReset(email);
            if (check == true)
            {
                email_employee = email;
                codeText = RandomNumber(1000, 9999).ToString();
                check = SendEmail(email_employee, codeText, "Send Verification Code to change password");
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
        public bool SendEmail(string email, string codeText, string content)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");
                // Your email address
                oMail.From = from_email;
                // Set recipient email address
                // oMail.To = "102200024@sv1.dut.udn.vn";
                oMail.To = email;
                // Set email subject
                oMail.Subject = codeText;
                // Set email body
                oMail.TextBody = content;
                // Hotmail/Outlook SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.office365.com");
                // If your account is office 365, please change to Office 365 SMTP server
                // SmtpServer oServer = new SmtpServer("smtp.office365.com");
                // User authentication should use your
                // email address as the user name.
                oServer.User = from_email;
                // If you got authentication error, try to create an app password instead of your user password.
                // https://support.microsoft.com/en-us/account-billing/using-app-passwords-with-apps-that-don-t-support-two-step-verification-5896ed9b-4263-e681-128a-a6f2979a7944
                oServer.Password = password_from_email;
                // use 587 TLS port
                oServer.Port = 587;
                // detect SSL/TLS connection automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                Console.WriteLine("start to send email over TLS...");
                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                oSmtp.SendMail(oServer, oMail);
                Console.WriteLine("email was sent successfully!");
                return true;
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
                return false;
            }

            // gưi bằng outlook / Microsoft (bằng App trên máy hiện tại) 
            //outlook.Application app = new outlook.Application();
            //outlook.MailItem mail_lout_look = (outlook.MailItem)app.CreateItem(outlook.OlItemType.olMailItem);
            //mail_lout_look.To = email;
            //mail_lout_look.Subject = codeText;
            //mail_lout_look.Body = content;
            //mail_lout_look.Importance = outlook.OlImportance.olImportanceHigh;
            //((outlook.MailItem)mail_lout_look).Send();

            // gửi bằng Email của google 
            //MailMessage msg = new MailMessage();
            //msg.From = new MailAddress(from_email);
            //msg.To.Add(email);
            //msg.Subject = codeText;
            //msg.Body = content;
            ////msg.Priority = MailPriority.High;
            //using (SmtpClient client = new SmtpClient())
            //{
            //    client.EnableSsl = true;
            //    client.UseDefaultCredentials = false;
            //    client.Credentials = new NetworkCredential(from_email, password_from_email);
            //    client.Host = "smtp.gmail.com";
            //    client.Port = 587;
            //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    client.Send(msg);
            //}
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

        public bool ChangePasswordByUsername(string username, string new_password)
        {
            return EmployeesDAL.Instance.ChangePasswordByUsername(username, HashPass(new_password));
        }


        // getName để hiển thị ra trong bảng FormMain
        public string getName(string username)
        {
            return EmployeesDAL.Instance.getName(username);
        }

        public bool CheckOldPassword(string username,string oldpassword)
        {
            if (HashPass(oldpassword) == EmployeesDAL.Instance.getOldPassword(username)) return true;
            return false;
        }

        public DataTable LoadInforEmployee(string username)
        {
            return EmployeesDAL.Instance.LoadInforEmployee(username);
        }

        public bool VerifyEmail(string emailVerify) // kiểm tra tồn tại email  // k dùng hàm này vì lack 
        {
            using (WebClient webclient = new WebClient())
            {
                string url = "http://verify-email.org/";
                NameValueCollection formData = new NameValueCollection();
                formData["check"] = emailVerify;
                byte[] responseBytes = webclient.UploadValues(url, "POST", formData);
                string response = Encoding.ASCII.GetString(responseBytes);
                if (response.Contains("Result: Ok"))
                {
                    return true;
                }
                return false;
            }
        }

        public bool CheckEmailExist(string em) // kiểm tra tồn tại email
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
        public string SaveInforAccount(string username , string first_name,string last_name,string phone ,string email,string address,string date_of_birth)
        {
            if (first_name == "")
                return "First Name cannot be blank !!!";
            else if (!CheckName(first_name))
                return "Incorrect First Name format !!!";
            else if (last_name != "" && !CheckName(last_name))
                return "Incorrect Last Name fomat !!!";
            else if (!CheckPhoneNumber(phone))
                return "Invalid phone number !!!";
            else if (email == "")
                return "Email cannot be blank !!!";
            //else if (!VerifyEmail(email))     // => lack computer 
            //    return "Email not found !!!"; 
            //else if (!CheckEmailExist(email)) // => lack computer 
            //    return "Email not found !!!";  
            else if (!CheckEmail2(email))
                return "Invalid Email !!!";
            else if (address == "")
                return "Address cannot be blank !!!";
            else if (!CheckDate(date_of_birth))
                return "Incorrect date format !!!";
            else if (!ExceedDate(date_of_birth))
                return "Exceed the current date !!!";
            else
            {
                if (EmployeesDAL.Instance.SaveInforAccount(username, first_name, last_name, phone, email, address, SaveDate(date_of_birth), Date_Now()))
                    return "true";
                else return "Error !!!";
            }
        }



        

        // login by Email 
        public string getUsernamebyEmail(string email)
        {
            return EmployeesDAL.Instance.getUsernamebyEmail(email);
        }
        // get Id by Username 

        public string getIdByUsername(string username)
        {
            return EmployeesDAL.Instance.getIdByUsername(username);
        }

        public string getIdByEmail(string email)
        {
            return EmployeesDAL.Instance.getIdByEmail(email);
        }
        // created Account 

        public string CreatedAcount(string username , string password , string email)
        {
            try
            {
                if (!CheckUsernamePass(username))
                    return "Username minimum 10 characters and maximum 24 characters including letters and numbers !!!";
                else if (!CheckUsernamePass(password))
                    return "Username minimum 10 characters and maximum 24 characters including letters and numbers !!!";
                else if (getIdByUsername(username) != "")
                    return "Username already exists !!!";
                else if (!CheckEmail(email))
                    return "Bad format email !!!";
                else if (getUsernamebyEmail(email) != "")
                    return "Email has been used by another user !!!";
                else if (EmployeesDAL.Instance.CreatedAcount(username, HashPass(password), email, Date_Now()))
                    return "true";
                else
                    return "false";
            }
            catch
            {
                return "false";
            }
        }

        


















    }
}
