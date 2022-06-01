using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using BLL;
using DTO;


namespace LibraryManagement
{
    public partial class Main : Form
    {
        string role;
        public Main(string role)
        {
            InitializeComponent();
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

        private void Main_Load(object sender, EventArgs e)
        {
            menuStrip2.Hide();
            timer1.Start();
        }

        private void KiemTraThongTinNguoiDung(object sender, EventArgs e)
        {
            CheckInfor K = new CheckInfor();
            K.Show();
        }
        
        
        

        private void DangXuat(object sender, EventArgs e)
        {
            this.Hide();
            Main x = new Main("");
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
        //private void CapnhatPhieuMuon(object sender, EventArgs e)
        //{
        //    Borrows library = new Borrows();
        //    library.Show();
        //}
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
        
        //private void libraryCardToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Borrows borrows = new Borrows();
        //    borrows.Show();
        //}
        
        
    }
}
