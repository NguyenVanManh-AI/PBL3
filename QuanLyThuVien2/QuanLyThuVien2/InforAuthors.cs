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
    public partial class InforAuthors : Form
    {
        public InforAuthors()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();
        private void ttTacgia_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "Select * from tblTacGia");
        }
    }
}
