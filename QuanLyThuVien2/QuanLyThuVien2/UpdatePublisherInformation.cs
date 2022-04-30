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
    public partial class UpdatePublisherInformation : Form
    {
        public UpdatePublisherInformation()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();
        private void capnhatNXB_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select *from tblNXB");
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

        public static bool hasSpecialCharSDT(string input)
        {
            string specialChar = @"~!@#$%^&*()_+`-=[]\{}|;':,./<>?qưertyuiopasdfghjklzxcvbnm";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        public int bug = 0, numberEdit = 0, numberUndo = 0;
        string manxb;
        private void btAdd_Click(object sender, EventArgs e)
        {
            bug = 0;
            if (MaNhaXuatBan.Text == "")
            {
                MessageBox.Show("Mã Nhà Xuất Bản không được để trống !");
                bug++;
            }
            if (TenNhaXuatBan.Text == "")
            {
                MessageBox.Show("Tên Nhà Xuất Bản không được để trống !");
                bug++;
            }
            if (hasSpecialChar(TenNhaXuatBan.Text))
            {
                MessageBox.Show("Tên Nhà Xuất Bản không được chứa kí tự số hoặc kí tự đặc biệt gồm : ~!@#$%^&*()_+`1234567890-=[]{}|;':,./<>? !");
                bug++;
            }
            if (DiaChiNhaXuatBan.Text == "")
            {
                MessageBox.Show("Địa chỉ Nhà Xuất Bản không được để trống !");
                bug++;
            }
            if (SDTNhaXuatBan.Text == "")
            {
                MessageBox.Show("Số điện thoại Nhà Xuất Bản không được để trống !");
                bug++;
            }
            if (bug == 0)
            {
                try
                {
                    string strInsert = "Insert Into tblNXB(MANXB,TENNXB,DIACHI,SODIENTHOAI,GHICHU) values ('" + MaNhaXuatBan.Text + "','" + TenNhaXuatBan.Text + "','" + DiaChiNhaXuatBan.Text + "','" + SDTNhaXuatBan.Text + "','" + txtNote.Text + "')";
                    cls.ThucThiSQLTheoPKN(strInsert);
                    cls.LoadData2DataGridView(dataGridView1, "select *from tblNXB");
                    MessageBox.Show("Thêm thành công");
                    MaNhaXuatBan.Text = "";
                    TenNhaXuatBan.Text = "";
                    DiaChiNhaXuatBan.Text = "";
                    SDTNhaXuatBan.Text = "";
                    txtNote.Text = "";
                    numberEdit = 0;
                    numberUndo = 0;
                }
                catch { MessageBox.Show("Mã Nhà Xuất Bản đã tồn tại !"); };
            }

        }


        public string undoMNXB, undoTNXB, undoDCNXB, undoSDTNXB, undoNote;

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from tblnxb where manxb like'%" + MaNhaXuatBan.Text + "%'and tennxb like'%" + TenNhaXuatBan.Text + "%'and diachi like'%" + DiaChiNhaXuatBan.Text + "%'and sodienthoai like'%" + SDTNhaXuatBan.Text + "%'and ghichu like'%" + txtNote.Text + "%'");
        }
        private void btnSearch2_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from tblnxb where tennxb like'%" + txtSearch2.Text + "%' OR diachi like'%" + txtSearch2.Text + "%' OR sodienthoai like'%" + txtSearch2.Text + "%'");
        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            if (numberUndo == 1)
            {
                string strInsert = "Insert Into tblNXB(MANXB,TENNXB,DIACHI,SODIENTHOAI,GHICHU) values ('" + undoMNXB + "','" + undoTNXB + "','" + undoDCNXB + "','" + undoSDTNXB + "','" + undoNote + "')";
                cls.ThucThiSQLTheoPKN(strInsert);
                cls.LoadData2DataGridView(dataGridView1, "select *from tblNXB");
                MessageBox.Show("Hoàn tác thành công !!!");
                numberUndo = 0;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MaNhaXuatBan.Text == "")
            {
                MessageBox.Show("Hay chọn một hàng dữ liệu bạn muốn xóa !");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        undoMNXB = MaNhaXuatBan.Text;
                        undoTNXB = TenNhaXuatBan.Text;
                        undoDCNXB = DiaChiNhaXuatBan.Text;
                        undoSDTNXB = SDTNhaXuatBan.Text;
                        undoNote = txtNote.Text;
                        string strDelete = "Delete from tblNXB where MANXB='" + manxb + "'";
                        cls.ThucThiSQLTheoKetNoi(strDelete);
                        cls.LoadData2DataGridView(dataGridView1, "select *from tblNXB");
                        MaNhaXuatBan.Text = "";
                        TenNhaXuatBan.Text = "";
                        DiaChiNhaXuatBan.Text = "";
                        SDTNhaXuatBan.Text = "";
                        txtNote.Text = "";
                        MessageBox.Show("Xóa thành công");
                        numberEdit = 0;
                        numberUndo = 1;

                    }
                    catch { MessageBox.Show("Phải xóa những thông tin liên quan đến nhà xuất bản này trước"); };
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MaNhaXuatBan.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TenNhaXuatBan.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                DiaChiNhaXuatBan.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                SDTNhaXuatBan.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtNote.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                manxb = MaNhaXuatBan.Text;
                if (MaNhaXuatBan.Text != "") numberEdit = 1;
                else numberEdit = 0;
            }
            catch { };
        }

        //int dem = 0;


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
                //if (dem == 0)
                //{
                //    manxb = MaNhaXuatBan.Text;
                //    dem = 1;
                //    btAdd.Enabled = false;
                //    btDelete.Enabled = false;
                //}
                //else
                //{
                if (MaNhaXuatBan.Text == "")
                {
                    MessageBox.Show("Mã Nhà Xuất Bản không được để trống !");
                    bug2++;
                }
                if (TenNhaXuatBan.Text == "")
                {
                    MessageBox.Show("Tên Nhà Xuất Bản không được để trống !");
                    bug2++;
                }
                if (hasSpecialChar(TenNhaXuatBan.Text))
                {
                    MessageBox.Show("Tên Nhà Xuất Bản không được chứa kí tự số hoặc kí tự đặc biệt gồm : ~!@#$%^&*()_+`1234567890-=[]{}|;':,./<>? !");
                    bug2++;
                }
                if (DiaChiNhaXuatBan.Text == "")
                {
                    MessageBox.Show("Địa chỉ Nhà Xuất Bản không được để trống !");
                    bug2++;
                }
                if (hasSpecialCharSDT(SDTNhaXuatBan.Text))
                {
                    MessageBox.Show("Số điện thoại chỉ được chứa Kí tự số và Không được chứa kí tự số hoặc kí tự đặc biệt gồm : ~!@#$%^&*()_+`-=[]{}|;':,./<>? !");
                    bug2++;
                }
                if (SDTNhaXuatBan.Text == "")
                {
                    MessageBox.Show("Số điện thoại Nhà Xuất Bản không được để trống !");
                    bug2++;
                }
                if (bug2 == 0)
                {
                    try
                    {
                        string strUpdata = "Update tblNXB set MANXB='" + MaNhaXuatBan.Text + "',TENNXB='" + TenNhaXuatBan.Text + "',DIACHI='" + DiaChiNhaXuatBan.Text + "',SODIENTHOAI='" + SDTNhaXuatBan.Text + "',GHICHU='" + txtNote.Text + "' where MANXB='" + manxb + "'";
                        cls.ThucThiSQLTheoPKN(strUpdata);
                        cls.LoadData2DataGridView(dataGridView1, "select *from tblNXB");
                        btAdd.Enabled = true;
                        btDelete.Enabled = true;
                        //dem = 0;
                        MessageBox.Show("Sửa thành công");
                        MaNhaXuatBan.Text = "";
                        TenNhaXuatBan.Text = "";
                        DiaChiNhaXuatBan.Text = "";
                        SDTNhaXuatBan.Text = "";
                        txtNote.Text = "";
                        numberEdit = 0;
                        numberUndo = 0;
                    }
                    catch { MessageBox.Show("Không thể sửa - Mã Nhà Xuất Bản đã tồn tại !!!"); };
                }

                //}
            }

        }
        // chỉ cho nhập từ 0 đến 9 
        private void txtSODIENTHOAI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}