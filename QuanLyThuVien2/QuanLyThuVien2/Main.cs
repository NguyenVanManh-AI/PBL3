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

namespace QuanLyThuVien2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public static string TenDN, MatKhau, Quyen , checkMatKhau; // TenDN = tên đăng nhập 
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
                object Q = layGiaTri("select QuyenHan from tblNhanVien where TaiKhoan='" + TenDN + "' and MatKhau='" + hasPass + "'");
                if (Q == null)
                {
                    MessageBox.Show("Wrong account :((");
                }
                else
                {
                    MessageBox.Show("Logged in successfully ! :)) ");
                    Quyen = Convert.ToString(Q);
                    if (Quyen == "user")
                    {
                        dropdownSystemManagement.Enabled = true;
                        dropdownSearch.Enabled = true;
                        toolBookSearch.Enabled = true;
                        toolRoadSearch.Enabled = true;
                        dropdownUpdate.Enabled = true;
                        dropdownInformation.Enabled = true;
                        dropdownReport.Enabled = true;
                        toolBookUpdates.Enabled = true;
                        toolAuthorUpdate.Enabled = true;
                        toolUpdateReaders.Enabled = true;
                        toolUpdateField.Enabled = true;
                        toolPublisherUpdate.Enabled = true;
                        toolUpdateBorrowingInformation.Enabled = true;
                        toolAuthor.Enabled = true;
                        toolPublishingCompany.Enabled = true;
                        toolField.Enabled = true;
                        toolReaders.Enabled = true;
                        toolBook.Enabled = true;
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
                        dropdownSearch.Enabled = true;
                        toolBookSearch.Enabled = true;
                        toolCheckEmployeeInformation.Enabled = true;
                        toolRoadSearch.Enabled = true;
                        dropdownUpdate.Enabled = true;
                        dropdownInformation.Enabled = true;
                        dropdownReport.Enabled = true;
                        toolBookUpdates.Enabled = true;
                        toolAuthorUpdate.Enabled = true;
                        toolUpdateReaders.Enabled = true;
                        toolUpdateField.Enabled = true;
                        toolPublisherUpdate.Enabled = true;
                        toolUpdateBorrowingInformation.Enabled = true;
                        toolAuthor.Enabled = true;
                        toolPublishingCompany.Enabled = true;
                        toolField.Enabled = true;
                        toolReaders.Enabled = true;
                        toolBook.Enabled = true;
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
            try
            {
                Con = new SqlConnection();
                Con.ConnectionString = @"Server =DESKTOP-QCOSLTK\VANMANH;" + "database=Library2; Integrated Security = true";
                Con.Open();
            }
            catch { MessageBox.Show("Unable to connect !!! :(( "); }
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
            UpdateAuthorInformation CNTG = new UpdateAuthorInformation();
            CNTG.Show();
        }

        private void CapNhatLinhVuc(object sender, EventArgs e)
        {
            UpdateFieldInformation cnLV = new UpdateFieldInformation();
            cnLV.Show();
        }

        private void CapNhatNhaXuatBan(object sender, EventArgs e)
        {
            UpdatePublisherInformation cnNXB = new UpdatePublisherInformation();
            cnNXB.Show();
        }


        private void CapNhatSach(object sender, EventArgs e)
        {
            UpdatesBook cnsach = new UpdatesBook();
            cnsach.Show();
        }

        private void CapNhatNguoiDoc(object sender, EventArgs e)
        {
            UpdateReaders cndocgia = new UpdateReaders();
            cndocgia.Show();

        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CapNhatThongTinMuon(object sender, EventArgs e)
        {
            UpdateBorrowingInforamtion ttmuon = new UpdateBorrowingInforamtion();
            ttmuon.Show();
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

        private void ThongTinTacGia(object sender, EventArgs e)
        {
            InforAuthors authors = new InforAuthors();
            authors.Show();
        }

        private void ThongTinNhaXuatban(object sender, EventArgs e)
        {
            InforPublishers publishers = new InforPublishers();
            publishers.Show();
        }

        private void ThongTinLinhVuc(object sender, EventArgs e)
        {
            InforFields fields = new InforFields();
            fields.Show();
        }

        private void ThongTinSach(object sender, EventArgs e)
        {
            InforBooks books = new InforBooks();
            books.Show();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Help hl = new Help();
            hl.Show();
        }

        private void ThongTinNguoiDoc(object sender, EventArgs e)
        {
            InforReaders readers = new InforReaders();
            readers.Show();
        }

        private void TimKiemSach(object sender, EventArgs e)
        {
            SearchBooks sbooks = new SearchBooks();
            sbooks.Show();
        }

        private void TimKiemDocGia(object sender, EventArgs e)
        {
            SearchReaders sreaders = new SearchReaders();
            sreaders.Show();
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
            groupBox1.Visible = true;
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
            dropdownSearch.Enabled = false;
            toolBookSearch.Enabled = false;
            toolCheckEmployeeInformation.Enabled = false;
            toolRoadSearch.Enabled = false;
            dropdownUpdate.Enabled = false;
            dropdownInformation.Enabled = false;
            dropdownReport.Enabled = false;
            toolBookUpdates.Enabled = false;
            toolAuthorUpdate.Enabled = false;
            toolUpdateReaders.Enabled = false;
            toolUpdateField.Enabled = false;
            toolPublisherUpdate.Enabled = false;
            toolUpdateBorrowingInformation.Enabled = false;
            toolAuthor.Enabled = false;
            toolPublishingCompany.Enabled = false;
            toolField.Enabled = false;
            toolReaders.Enabled = false;
            toolBook.Enabled = false;
            toolCreateAccount.Enabled = false;
            toolUpdateStaff.Enabled = false;
            toolChangePassword.Enabled = false;
        }





    }
}
// AppDomainManager