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
    public partial class UpdateAuthorInformation : Form
    {
        public UpdateAuthorInformation()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();

        public int numberEdit = 0;

        private void capnhatTG_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select *from tblTacGia");
        }
        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"~!@#$%^&*()_+`1234567890-=[]\{}|;':,./<>?";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        public int bug = 0, numberUndo = 0;


        private void btAdd_Click(object sender, EventArgs e)
        {
            bug = 0;

            if (MaTacGia.Text == "")
            {
                MessageBox.Show("Mã tác giả không được để trống !");
                bug++;
            }
            if (TenTacGia.Text == "")
            {
                MessageBox.Show("Họ tên không được để trống !");
                bug++;
            }
            if (hasSpecialChar(TenTacGia.Text))
            {
                MessageBox.Show("Tên tác giả không được chứa kí tự số hoặc kí tự đặc biệt gồm : ~!@#$%^&*()_+`1234567890-=[]{}|;':,./<>? !");
                bug++;
            }
            if (DiaChi.Text == "")
            {
                MessageBox.Show("Địa chỉ không được để trống !");
                bug++;
            }
            if (bug == 0)
            {
                try
                {
                    string strInsert = "Insert Into tblTacGia(MATG,TENTG,GIOITINH,DIACHI,GHICHU) values ('" + MaTacGia.Text + "','" + TenTacGia.Text + "','" + cboGioiTinh.Text + "','" + DiaChi.Text + "','" + txtNote.Text + "')";
                    cls.ThucThiSQLTheoPKN(strInsert);
                    cls.LoadData2DataGridView(dataGridView1, "select *from tblTacGia");
                    MessageBox.Show("Thêm thành công");
                    numberEdit = 0;
                    MaTacGia.Text = "";
                    TenTacGia.Text = "";
                    DiaChi.Text = "";
                    txtNote.Text = "";
                    cboGioiTinh.Text = "";
                    numberUndo = 0;
                }
                catch { MessageBox.Show("Trùng Mã"); };
            }

        }


        public string undoMTG, undoTTG, undoDC, undoNote, undoGT;
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MaTacGia.Text == "")
            {
                MessageBox.Show("Hãy chọn một dòng dữ liệu để xóa !");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        undoMTG = MaTacGia.Text;
                        undoTTG = TenTacGia.Text;
                        undoDC = DiaChi.Text;
                        undoNote = txtNote.Text;
                        undoGT = cboGioiTinh.Text;
                        string strDelete = "Delete from tblTacGia where MATG='" + matg + "'";
                        cls.ThucThiSQLTheoKetNoi(strDelete);
                        cls.LoadData2DataGridView(dataGridView1, "select *from tblTacGia");
                        MessageBox.Show("Xóa thành công !!!");
                        MaTacGia.Text = "";
                        TenTacGia.Text = "";
                        DiaChi.Text = "";
                        txtNote.Text = "";
                        numberUndo = 1;
                    }
                    catch { MessageBox.Show("Phải xóa những thông tin liên quan đến tác giả này trước"); };
                }
            }

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from tblTacGia where MATG like '%" + MaTacGia.Text + "%' AND TENTG like '%" +
                TenTacGia.Text + "%' AND GIOITINH = '" + cboGioiTinh.Text + "' AND DIACHI like '%" + DiaChi.Text + "%'");

        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from tblTacGia where TENTG like '%" + txtSearch2.Text + "%' OR DIACHI like '%" + txtSearch2.Text + "%'");
        }

        string matg;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MaTacGia.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TenTacGia.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboGioiTinh.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                DiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtNote.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                matg = MaTacGia.Text;
                if (MaTacGia.Text != "") numberEdit = 1;
                else numberEdit = 0;
            }
            catch { };
        }
        // int dem = 0;


        public int bug2 = 0;
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (numberEdit == 0)
            {
                MessageBox.Show("Hãy chọn một hàng dữ liệu đễ chỉnh sửa !");
            }
            else
            {
                bug2 = 0;
                if (MaTacGia.Text == "")
                {
                    MessageBox.Show("Mã Tác giả không được để trống !");
                    bug2++;
                }
                if (TenTacGia.Text == "")
                {
                    MessageBox.Show("Tên Tác giả không được để trống !");
                    bug2++;
                }
                if (hasSpecialChar(TenTacGia.Text))
                {
                    MessageBox.Show("Tên tác giả không được chứa kí tự số hoặc kí tự đặc biệt gồm : ~!@#$%^&*()_+`1234567890-=[]{}|;':,./<>? !");
                    bug2++;
                }
                if (DiaChi.Text == "")
                {
                    MessageBox.Show("Địa chỉ không được để trống !");
                    bug2++;
                }
                if (bug2 == 0)
                {
                    //if (dem == 0)
                    //{
                    // matg = MaTacGia.Text;
                    //    dem = 1;
                    //    btAdd.Enabled = false;
                    //    btDelete.Enabled = false;
                    //}
                    //else
                    //{
                    try
                    {
                        string strUpdate = "Update tblTacGia set MATG='" + MaTacGia.Text + "',TENTG='" + TenTacGia.Text + "',GIOITINH='" + cboGioiTinh.Text + "',DIACHI='" + DiaChi.Text + "',GHICHU='" + txtNote.Text + "' where MATG='" + matg + "'";
                        cls.ThucThiSQLTheoPKN(strUpdate);
                        cls.LoadData2DataGridView(dataGridView1, "select *from tblTacGia");
                        //btAdd.Enabled = true;
                        //btDelete.Enabled = true;
                        //dem = 0;
                        MessageBox.Show("Sửa thành công");
                        MaTacGia.Text = "";
                        TenTacGia.Text = "";
                        DiaChi.Text = "";
                        txtNote.Text = "";
                        cboGioiTinh.Text = "";
                        numberEdit = 0;
                        numberUndo = 0;
                    }
                    catch { MessageBox.Show("Trùng mã"); };
                    // }
                }
            }


        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            if (numberUndo == 1)
            {
                string strInsert = "Insert Into tblTacGia(MATG,TENTG,GIOITINH,DIACHI,GHICHU) values ('" + undoMTG + "','" + undoTTG + "','" + undoGT + "','" + undoDC + "','" + undoNote + "')";
                cls.ThucThiSQLTheoPKN(strInsert);
                cls.LoadData2DataGridView(dataGridView1, "select *from tblTacGia");
                MessageBox.Show("Hoàn tác thành công !");
                numberUndo = 0;
            }

        }
    }
}