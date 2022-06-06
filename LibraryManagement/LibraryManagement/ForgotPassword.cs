using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


// gửi Mail 
using System.Net;
using System.Net.Mail;
using System.IO;

// mã hóa mật khẩu 
using System.Security.Cryptography;


namespace LibraryManagement
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        SqlCommand sqlCommand;
        string passwordText = "strongtech2908"; // 1 
        public Object layGiaTri(string sql) //lay gia tri cua  cot dau tien trong bang 
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = Con;

            //CHi can lay ve gia tri cua mot truong thoi thi dung pt nao ? - ExecuteScalar
            Object obj = sqlCommand.ExecuteScalar(); //neu co loi thi phai xem lai cua lenh SQL o ben kia
            return obj;
            //Ket qua de dau ? - de trong obj
        }
        public static string EmailUser;

        Class.clsDatabase cls = new LibraryManagement.Class.clsDatabase();
        private void QuenMatKhau_Load(object sender, EventArgs e)
        {
            cls.KetNoi();
        }

        string fromText = "strongtechmaster@gmail.com"; // 2 
       
         

        public string codeText;


        string[] str2 = new string[30];

        Random _random = new Random();
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        private void SEND_Click(object sender, EventArgs e)
        {
            if(username.Text == "")
            {
                MessageBox.Show("Please enter Username !!!");
            }
            else if (newpassword.Text == "")
            {
                MessageBox.Show("Please enter Password !!!");
            }
            else
            {
                Main mn = new Main();

                object strForgot = layGiaTri("select email from employees where username='" + username.Text + "'");
                EmailUser = Convert.ToString(strForgot);

                if(EmailUser == "")
                {
                    MessageBox.Show("Username does not exist or User has not updated email !!!");
                }
                else
                {
                    //MessageBox.Show("Gửi đến Mail : "+ EmailUser);
                    MessageBox.Show("Gửi đến Mail : " + EmailUser.Substring(0, (EmailUser.Length - 10) / 3) + "*********" + EmailUser.Substring((EmailUser.Length - 10) * 2 / 3));

                    codeText = Convert.ToString(RandomNumber(1000, 9999));

                    // tạo một tin nhắn và thêm những thông tin cần thiết như: ai gửi, người nhận, tên tiêu đề, và có đôi lời gì cần nhắn nhủ
                    MailMessage mail = new MailMessage(fromText, EmailUser, codeText, "Send Verification Code to change password"); //
                    mail.IsBodyHtml = true;
                    //gửi tin nhắn
                    SmtpClient client = new SmtpClient("smtp.gmail.com");
                    client.Host = "smtp.gmail.com";
                    //ta không dùng cái mặc định đâu, mà sẽ dùng cái của riêng mình
                    client.UseDefaultCredentials = false;
                    client.Port = 587; //vì sử dụng Gmail nên mình dùng port 587
                                       // thêm vào credential vì SMTP server cần nó để biết được email + password của email đó mà bạn đang dùng
                    client.Credentials = new System.Net.NetworkCredential(fromText, passwordText);
                    client.EnableSsl = true; //vì ta cần thiết lập kết nối SSL với SMTP server nên cần gán nó bằng true
                    client.Send(mail);
                    MessageBox.Show("Message sent successfully !", "Success", MessageBoxButtons.OK);

                    verification.Enabled = true;
                    btOK.Enabled = true;
                }

                
            }
            
        }

        SqlConnection Con;
        private void Forgot_Load(object sender, EventArgs e)
        {
            try
            {
                Con = new SqlConnection();
                Con.ConnectionString = @"Server =DESKTOP-QCOSLTK\VANMANH;" + "database=System_Library; Integrated Security = true"; // 3 
                Con.Open();
            }
            catch {   }
             
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if(verification.Text == codeText)
            {
                byte[] temp2 = ASCIIEncoding.ASCII.GetBytes(newpassword.Text);
                byte[] hasData2 = new MD5CryptoServiceProvider().ComputeHash(temp2);

                string hasPass2 = "";

                foreach (byte item in hasData2)
                {
                    hasPass2 += item;
                }
                string strUpdate = "Update employees set password='" + hasPass2 + "'where username ='" + username.Text + "'";
                cls.ThucThiSQLTheoKetNoi(strUpdate);

                username.Text = "";
                newpassword.Text = "";
                verification.Text = "";
                MessageBox.Show("Verification code correct ! You have changed your password !!! :)) ");
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect code !!! ");
            }
        }
    }
}
