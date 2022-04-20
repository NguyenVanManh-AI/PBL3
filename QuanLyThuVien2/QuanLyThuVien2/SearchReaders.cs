using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyThuVien2
{
    public partial class SearchReaders : Form
    {
        public SearchReaders()
        {
            InitializeComponent();
        }
        Class.clsDatabase Cls = new QuanLyThuVien2.Class.clsDatabase();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.Text + ":";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            if (comboBox1.Text == "Mã Đọc Giả") s = "MADG";
            if (comboBox1.Text == "Họ Tên") s = "HOTEN";
            if (comboBox1.Text == "Ngày Sinh") s = "NGAYSINH";
            if (comboBox1.Text == "Giới Tính") s = "GIOITINH";
            if (comboBox1.Text == "Lớp") s = "LOP";
            if (comboBox1.Text == "Địa Chỉ") s = "DIACHI";
            Cls.LoadData2DataGridView(dataGridView1, "select*from tblDocGia where " + s + " like'%" + textBox1.Text + "%'");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cls.LoadData2DataGridView(dataGridView2, "select*from tblDocGia where MADG like'%" + textBox2.Text + "%'or HOTEN like'%" + textBox3.Text + "%'or NGAYSINH='" + maskedTextBox1.Text + "'or GIOITINH='" + textBox4.Text + "'or LOP like'%" + textBox5.Text + "%'or DIACHI like'%" + textBox6.Text + "%'");
        }

        private void TimkiemDG_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimkiemDG_Load(object sender, EventArgs e)
        {
            //Cls.KetNoi();
        }
    }
}
