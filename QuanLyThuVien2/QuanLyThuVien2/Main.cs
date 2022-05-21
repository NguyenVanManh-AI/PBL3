using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

// mã hóa mật khẩu 
using System.Security.Cryptography;
//abc
namespace QuanLyThuVien2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public static string TenDN, MatKhau, Quyen, checkMatKhau; // TenDN = tên đăng nhập 
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
        private void button1_Click(object sender, EventArgs e)
        {
            TenDN = textBox1.Text;
            MatKhau = textBox2.Text;

            byte[] temp = ASCIIEncoding.ASCII.GetBytes(textBox2.Text);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            // MessageBox.Show(hasPass);

            checkMatKhau = hasPass;
            if (TenDN != "")
            {
                object Q = layGiaTri("select role from employees where username='" + TenDN + "' and password='" + hasPass + "'");
                if (Q == null)
                {
                    MessageBox.Show("Wrong account !!!");
                }
                else
                {
                    MessageBox.Show("Logged in successfully !");
                    Quyen = Convert.ToString(Q);

                    menuStrip2.Show();

                    if (Quyen == "user")
                    {
                        dropdownSystemManagement.Enabled = true;
                        dropdownReport.Enabled = true;
                        toolCreateAccount.Enabled = false;
                        toolUpdateStaff.Enabled = true;
                        toolChangePassword.Enabled = true;
                        toolLogout.Enabled = true;
                        toolCreateAccount.Visible = false;
                        toolCheckEmployeeInformation.Visible = false;


                    }
                    if (Quyen == "admin")
                    {
                        dropdownSystemManagement.Enabled = true;
                        toolCheckEmployeeInformation.Enabled = true;
                        dropdownReport.Enabled = true;
                        toolCreateAccount.Enabled = true;
                        toolUpdateStaff.Enabled = true;
                        toolChangePassword.Enabled = true;
                        toolLogout.Enabled = true;
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    groupBox1.Enabled = false;
                    groupBox1.Visible = false;
                    btSI.Visible = false;
                    menuStrip1.Visible = true;
                    label4.Text = "Welcome to Library Management";
                    dropdownSystemManagement.Visible = true;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the program ?", "FormClosing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void ThoatChuongTrinh(object sender, EventArgs e)
        {
            this.Close();
        }
        string A, B, C, D, E, F;
        SqlConnection Con;
        private void Main_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            menuStrip2.Hide();
            try
            {
                Con = new SqlConnection();
                Con.ConnectionString = @"Server =DESKTOP-QCOSLTK\VANMANH;" + "database=System_Library; Integrated Security = true";
                Con.Open();
            }
            catch { MessageBox.Show("Unable to connect !!! "); }
            A = label1.Text;
            B = label5.Text;
            C = label6.Text;
            D = label7.Text;
            E = label8.Text;
            F = label9.Text;
            label9.Text = "";
            label8.Text = "";
            label7.Text = "";
            label6.Text = "";
            label5.Text = "";
            label1.Text = "";
            timer1.Start();
        }


        private void KiemTraThongTinNguoiDung(object sender, EventArgs e)
        {
            CheckInfor K = new CheckInfor();
            K.Show();
        }

        private void CapNhatThongTin(object sender, EventArgs e)
        {
            UpdateInfor cnnhanvien = new UpdateInfor();
            cnnhanvien.Show();
        }

        private void TaoTaiKhoan(object sender, EventArgs e)
        {
            Register TAO = new Register();
            TAO.Show();
        }

        private void DoiMatKhau(object sender, EventArgs e)
        {
            ChangePassword doimatkhau = new ChangePassword();
            doimatkhau.Show();
        }

        private void DangXuat(object sender, EventArgs e)
        {
            this.Hide();
            Main x = new Main();
            x.Show();
        }

        private void CapNhatThongTinTacGia(object sender, EventArgs e)
        {
            UpdateAuthors CNTG = new UpdateAuthors();
            CNTG.Show();
        }

        private void CapNhatLinhVuc(object sender, EventArgs e)
        {
            UpdateCategorys cnLV = new UpdateCategorys();
            cnLV.Show();
        }

        private void CapNhatNhaXuatBan(object sender, EventArgs e)
        {
            UpdatePublishers cnNXB = new UpdatePublishers();
            cnNXB.Show();
        }


        

        private void CapNhatNguoiDoc(object sender, EventArgs e)
        {
            UpdateReaders cndocgia = new UpdateReaders();
            cndocgia.Show();

        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CapnhatPhieuMuon(object sender, EventArgs e)
        {
            Borrows library = new Borrows();
            library.Show();
        }
        private void BaoCaoTinhTrangSach(object sender, EventArgs e)
        {
            ReportBookStatus reportBookStatus = new ReportBookStatus();
            reportBookStatus.Show();
        }

        private void BaoCaoDocGia(object sender, EventArgs e)
        {
            ReportReaders reportReaders = new ReportReaders();
            reportReaders.Show();
        }

        

       
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Help hl = new Help();
            hl.Show();
        }

       
        private void NguoiDoc(object sender, EventArgs e)
        {
            UpdateReaders rd = new UpdateReaders();
            rd.Show();
        }

        private void toolTacGia_Click(object sender, EventArgs e)
        {
            UpdateAuthors updateAuthorInformation = new UpdateAuthors();
            updateAuthorInformation.Show();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            
            UpdateBookTitle updateBookTitle = new UpdateBookTitle();
            updateBookTitle.Show();
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            UpdateReaders rd = new UpdateReaders();
            rd.Show();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            UpdateAuthors updateAuthorInformation = new UpdateAuthors();
            updateAuthorInformation.Show();
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            UpdateCategorys f = new UpdateCategorys();
            f.Show();
        }

        

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            UpdatePublishers updatePublisherInformation = new UpdatePublishers();
            updatePublisherInformation.Show();
        }

        

        //private void pictureBoxEye_MouseDown(object sender, MouseEventArgs e)
        //{
        //    textBox2.UseSystemPasswordChar = false;
        //    this.pictureBoxEye.BackgroundImage = global::QuanLyThuVien2.Properties.Resources._103177_see_watch_view_eye_icon;
        //}

        //private void pictureBoxEye_MouseUp(object sender, MouseEventArgs e)
        //{
        //    textBox2.UseSystemPasswordChar = true;
        //    this.pictureBoxEye.BackgroundImage = global::QuanLyThuVien2.Properties.Resources.eye_hide;
        //}

        private void pictureBoxEye_Click(object sender, EventArgs e)
        {
            if(textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
                this.pictureBoxEye.BackgroundImage = global::QuanLyThuVien2.Properties.Resources.eye_hide; 
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                this.pictureBoxEye.BackgroundImage = global::QuanLyThuVien2.Properties.Resources._103177_see_watch_view_eye_icon;
            }
        }

        

        private void libraryCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borrows borrows = new Borrows();
            borrows.Show();
        }

        

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword fg = new ForgotPassword();
            fg.Show();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void btSI_Click(object sender, EventArgs e)
        {
            
            if(groupBox1.Visible == false)
            {
                groupBox1.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
            }
        }


        /*b 
        private void timer1_Tick(object sender, EventArgs e)
        {

            int d = 0, x;
            x = A.Length;
            d++;
            string a = A.Substring(0, 1);
            A = A.Substring(1, A.Length - 1);
            label1.Text = label1.Text + a;
            if (d == x)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            int d = 0, x;
            x = B.Length;
            d++;
            string a = B.Substring(0, 1);
            B = B.Substring(1, B.Length - 1);
            label5.Text = label5.Text + a;
            if (d == x)
            {
                timer2.Stop();
                timer3.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            int d = 0, x;
            x = C.Length;
            d++;
            string a = C.Substring(0, 1);
            C = C.Substring(1, C.Length - 1);
            label6.Text = label6.Text + a;
            if (d == x)
            {
                timer3.Stop();
                timer4.Start();
                timer5.Start();
                timer6.Start();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {

            int d = 0, x;
            x = D.Length;
            d++;
            string a = D.Substring(0, 1);
            D = D.Substring(1, D.Length - 1);
            label7.Text = label7.Text + a;
            if (d == x)
            {
                timer4.Stop();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {

            int d = 0, x;
            x = E.Length;
            d++;
            string a = E.Substring(0, 1);
            E = E.Substring(1, E.Length - 1);
            label8.Text = label8.Text + a;
            if (d == x)
            {
                timer5.Stop();
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {

            int d = 0, x;
            x = F.Length;
            d++;
            string a = F.Substring(0, 1);
            F = F.Substring(1, F.Length - 1);
            label9.Text += a;
            if (d == x)
            {
                timer6.Stop();
            }
        }
        */
        //private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    groupBox1.Enabled = true;
        //    dropdownSystemManagement.Enabled = false;
        //    dropdownSearch.Enabled = false;
        //    toolBookSearch.Enabled = false;
        //    toolCheckEmployeeInformation.Enabled = false;
        //    toolRoadSearch.Enabled = false;
        //    dropdownUpdate.Enabled = false;
        //    dropdownInformation.Enabled = false;
        //    dropdownReport.Enabled = false;
        //    toolBookUpdates.Enabled = false;
        //    toolAuthorUpdate.Enabled = false;
        //    toolUpdateReaders.Enabled = false;
        //    toolUpdateField.Enabled = false;
        //    toolPublisherUpdate.Enabled = false;
        //    toolUpdateBorrowingInformation.Enabled = false;
        //    toolAuthor.Enabled = false;
        //    toolPublishingCompany.Enabled = false;
        //    toolField.Enabled = false;
        //    toolReaders.Enabled = false;
        //    toolBook.Enabled = false;
        //    toolCreateAccount.Enabled = false;
        //    toolUpdateStaff.Enabled = false;
        //    toolChangePassword.Enabled = false;
        //}

        private void DangNhapHeThong(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            dropdownSystemManagement.Enabled = false;
            //dropdownSearch.Enabled = false;
            //toolBookSearch.Enabled = false;
            toolCheckEmployeeInformation.Enabled = false;
            //toolRoadSearch.Enabled = false;
            //dropdownUpdate.Enabled = false;
            dropdownReport.Enabled = false;
            //toolBookUpdates.Enabled = false;
            //toolAuthorUpdate.Enabled = false;
            //toolUpdateReaders.Enabled = false;
            //toolUpdateField.Enabled = false;
            //toolPublisherUpdate.Enabled = false;
            //toolUpdateBorrowingInformation.Enabled = false;
            toolCreateAccount.Enabled = false;
            toolUpdateStaff.Enabled = false;
            toolChangePassword.Enabled = false;
        }





    }
}
// AppDomainManager