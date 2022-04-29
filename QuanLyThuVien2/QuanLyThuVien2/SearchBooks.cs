using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien2
{
    public partial class SearchBooks : Form
    {
        public SearchBooks()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();
        private void timkiem_Load(object sender, EventArgs e)
        {
            cls.KetNoi();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label4.Text = comboBox1.Text + ":";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            if (comboBox1.Text == "Mã Sách") s = "MASACH";
            if (comboBox1.Text == "Tên Sách") s = "TENSACH";
            if (comboBox1.Text == "Mã Tác Giả") s = "MATG";
            if (comboBox1.Text == "Mã Nhà Xuất Bản") s = "MANXB";
            if (comboBox1.Text == "Mã Lĩnh Vực") s = "MaLv";
            if (comboBox1.Text == "Năm Xuất Bản") s = "NAMXB";
            if (comboBox1.Text == "Ngày Nhập") s = "NGAYNHAP";
            cls.LoadData2DataGridView(dataGridView1, "select*from tblSach where " + s + " like'%" + textBox1.Text + "%'"); // phải là string s = ""; còn string s ; thì sẽ lỗi 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView2, "select*from tblSach where MASACH like'%" + textBox2.Text + "%'or TENSACH like'%" + textBox3.Text + "%'or MATG like'%" + textBox4.Text + "%'or MANXB like'%" + textBox5.Text + "%'or MaLV like'%" + textBox7.Text + "%'or NAMXB='" + textBox6.Text + "'or SOLUONG='" + textBox8.Text + "'or NGAYNHAP='" + maskedTextBox1.Text + "'");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

    }
}
