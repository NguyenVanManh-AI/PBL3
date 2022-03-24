using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public static string TenDN, MatKhau, Quyen; // TenDN = tên đăng nhập 
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
            if (TenDN != "")
            {
                object Q = layGiaTri("select QuyenHan from tblNhanVien where TaiKhoan='" + TenDN + "' and MatKhau='" + MatKhau + "'");
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

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void cậpNhậtSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b capnhatsach cnsach = new capnhatsach();
            //b cnsach.Show();
        }

        private void cậpNhậtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //b capnhatdocgia cndocgia = new capnhatdocgia();
            //b cndocgia.Show();

        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        

        private void cậpNhậtTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b capnhatTG cnTG = new capnhatTG();
            //b cnTG.Show();
        }

        private void cậpNhậtNhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b capnhatNXB cnNXB = new capnhatNXB();
            //b cnNXB.Show();
        }

        private void cậpNhậtLĩnhVựcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b capnhatLv cnLV = new capnhatLv();
            //b cnLV.Show();
        }

        

        private void cậpNhậtThôngTinMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b thongtinmuon T = new thongtinmuon();
            //b T.Show();
        }

        

        private void tìnhTrạngSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b BCTinhTrangSach BCTTS = new BCTinhTrangSach();
            //b BCTTS.Show();
        }

        private void sốĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b BCDocGia BCDG = new BCDocGia();
            //b BCDG.Show();
        }
        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b ttTacgia ttTG = new ttTacgia();
            //b ttTG.Show();
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b ttNXB ttnxb = new ttNXB();
            //b ttnxb.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btSI_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }
        

        private void lĩnhVựcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b ttLinhVuc ttlv = new ttLinhVuc();
            //b ttlv.Show();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b ttSach ttsach = new ttSach();
            //b ttsach.Show();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b ttDocgia ttDG = new ttDocgia();
            //b ttDG.Show();
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
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void tìmKiếmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b timkiem Sach = new timkiem();
            //b Sach.Show();
        }

        private void tìmKiếmĐGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //b TimkiemDG Dg = new TimkiemDG();
            //b Dg.Show();
        }

        

    }
}
// AppDomainManager