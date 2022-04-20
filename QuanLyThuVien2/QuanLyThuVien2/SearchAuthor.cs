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

namespace QuanLyThuVien2
{
    public partial class SearchAuthor : Form
    {
        public SearchAuthor()
        {
            InitializeComponent();
        }
        Class.clsDatabase Cls = new QuanLyThuVien2.Class.clsDatabase();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCloseA_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            label2.Text = comboBox1.Text + ":";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cls.LoadData2DataGridView(dataGridView1, "select * from tblTacGia where " + comboBox1.Text + " like'%" + txtBasicSearch.Text + "%'");
        }

        private void btnSearchA_Click(object sender, EventArgs e)
        {
            Cls.LoadData2DataGridView(dtgv2,"select*from tblTacGia where MATG like'%" + txtAuthorcode.Text + "%'or TENTG like'%" + txtName.Text  + "'or GIOITINH='" + txtGender.Text 
                 + "'or DIACHI like'%" + txtAddress.Text + "%'");
        }
    }
}
