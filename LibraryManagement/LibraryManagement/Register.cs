using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// mã hóa mật khẩu 
using System.Security.Cryptography;
using System.Data.SqlClient; // + 


namespace LibraryManagement
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        // + 
        SqlCommand sqlCommand;
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

        SqlConnection Con;
        // + 

        Class.clsDatabase cls = new LibraryManagement.Class.clsDatabase();
        private void Register_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
            cls.KetNoi();

            // + 
            try
            {
                Con = new SqlConnection();
                Con.ConnectionString = @"Server =DESKTOP-QCOSLTK\VANMANH;" + "database=System_Library ; Integrated Security = true";
                Con.Open();
            }
            catch { }
            // + 

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length - 1 < 5)
                MessageBox.Show("Account name is too short");
            else
                if (textBox1.Text.Length - 1 > 30)
                MessageBox.Show("Account name is too long");
            else
                    if (textBox2.Text.Length - 1 < 5)
                MessageBox.Show("Password is too short");
            else
                        if (textBox3.Text.Length - 1 > 30)
                MessageBox.Show("Password is too long");
            else
                            if (textBox2.Text != textBox3.Text)
                MessageBox.Show("Passwords do not match");
            else
            {
                // kiểm tra tài khoản đã tồn tại hay chưa 
                object Q = layGiaTri("SELECT id FROM employees WHERE username = '" + textBox1.Text + "'");
                string id_employee = Convert.ToString(Q);

                if (id_employee != "")
                    MessageBox.Show("Username "+textBox1.Text+" already exists !!!");
                else
                {
                    try
                    {
                        byte[] temp = ASCIIEncoding.ASCII.GetBytes(textBox2.Text);
                        byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

                        string hasPass = "";

                        foreach (byte item in hasData)
                        {
                            hasPass += item;
                        }

                        // lưu 
                        string datetime = DateTime.Now.ToString();
                        // MessageBox.Show(datetime);

                        if (datetime.Contains("CH") || datetime.Contains("SA"))
                        {
                            datetime = datetime.Replace("CH", "PM");
                            datetime = datetime.Replace("SA", "AM");
                            string[] arrListStr = datetime.Split(' ');
                            string date = arrListStr[0];
                            string time = arrListStr[1];
                            string pm = arrListStr[2];

                            string[] arrListStr2 = date.Split('/');

                            string dd = arrListStr2[0];
                            string mm = arrListStr2[1];
                            string yyyy = arrListStr2[2];

                            datetime = mm + "/" + dd + "/" + yyyy + " " + time + " " + pm;
                        }

                        //MessageBox.Show(date);
                        cls.ThucThiSQLTheoPKN("insert into employees(username,password,role,created_at,updated_at)values('" + textBox1.Text + "','" + hasPass + "','user','" + datetime + "','" + datetime + "')");
                        MessageBox.Show("Successful account creation, please update the account information");
                        this.Close();
                    }
                    catch { MessageBox.Show("Unable to create an account"); }
                }
                
            }
        }

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox1.Checked)
        //    {
        //        textBox2.PasswordChar = '\0';
        //        textBox3.PasswordChar = '\0';
        //    }
        //    else
        //    {
        //        textBox2.PasswordChar = '*';
        //        textBox3.PasswordChar = '*';
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxEye_password_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
                this.pictureBoxEye_password.BackgroundImage = global::LibraryManagement.Properties.Resources.eye_hide;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;
                this.pictureBoxEye_password.BackgroundImage = global::LibraryManagement.Properties.Resources._103177_see_watch_view_eye_icon;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
