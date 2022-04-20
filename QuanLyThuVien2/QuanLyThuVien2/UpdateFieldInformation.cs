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
    public partial class UpdateFieldInformation : Form
    {
        public UpdateFieldInformation()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new Class.clsDatabase();
        private void capnhatLv_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select *from tblLinhVuc");
        }
        public int bug = 0, nundo = 0;
        public int numberEdit = 0;
        public string MaLVText = "";

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (MaLinhVuc.Text == "")
            {
                MessageBox.Show("Mã lĩnh vực không được để trống !");
            }
            else
            {
                if (MaLinhVuc.Text == MaLVText)
                {
                    MessageBox.Show("Mã Lĩnh Vực Đã tồn tại !");
                }
                else
                {
                    bug = 0;
                    if (MaLinhVuc.Text == "")
                    {
                        MessageBox.Show("Mã lĩnh vực không được để trống !");
                        bug++;
                    }
                    if (TenLinhVuc.Text == "")
                    {
                        MessageBox.Show("Tên Lĩnh vực không được để trống !");
                        bug++;
                    }

                    if (bug == 0)
                    {
                        try
                        {
                            string strInsert = "Insert Into tblLinhVuc(MaLv,TenLv,GhiChu) values ('" + MaLinhVuc.Text + "','" + TenLinhVuc.Text + "','" + GhiChuLinhVuc.Text + "')";
                            cls.ThucThiSQLTheoPKN(strInsert);
                            cls.LoadData2DataGridView(dataGridView1, "select *from tblLinhVuc");
                            MessageBox.Show("Thêm thành công");
                            nundo = 0;
                            MaLinhVuc.Text = "";
                            TenLinhVuc.Text = "";
                            GhiChuLinhVuc.Text = "";
                            numberEdit = 0;
                        }
                        catch
                        {
                            MessageBox.Show("Mã Lĩnh Vực Đã tồn tại !");
                        };

                    }
                }
            }



        }

        public string undoMLV, undoTLV, undoGCLV;

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MaLinhVuc.Text == "")
            {
                MessageBox.Show("Hay chọn một hàng dữ liệu bạn muốn xóa !");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        undoMLV = MaLinhVuc.Text;
                        undoTLV = TenLinhVuc.Text;
                        undoGCLV = GhiChuLinhVuc.Text;
                        string strDelete = "Delete from tblLinhVuc where MaLv='" + MALV + "'";
                        cls.ThucThiSQLTheoKetNoi(strDelete);
                        cls.LoadData2DataGridView(dataGridView1, "select *from tblLinhVuc");
                        MaLinhVuc.Text = "";
                        TenLinhVuc.Text = "";
                        GhiChuLinhVuc.Text = "";
                        MessageBox.Show("Xóa thành công");
                        nundo = 1;
                        numberEdit = 0;

                    }
                    catch { MessageBox.Show("Phải xóa những thông tin liên quan đến lĩnh vực này trước"); };

                }
            }

        }

        private void btUndo_Click(object sender, EventArgs e)
        {
            if (nundo == 1)
            {
                string strInsert = "Insert Into tblLinhVuc(MaLv,TenLv,GhiChu) values ('" + undoMLV + "','" + undoTLV + "','" + undoGCLV + "')";
                cls.ThucThiSQLTheoPKN(strInsert);
                cls.LoadData2DataGridView(dataGridView1, "select *from tblLinhVuc");
                MessageBox.Show("Hoàn tác thành công");
                nundo = 0;
            }

        }

        private void MaLinhVuc_TextChanged(object sender, EventArgs e)
        {

        }

        string MALV;

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchField search = new SearchField();
            search.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MaLinhVuc.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                TenLinhVuc.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                GhiChuLinhVuc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                MALV = MaLinhVuc.Text; // khi click vào cái nào thì lưu mã của cái đó lại để nếu có edit thì edit sau đó update đến sql đúng cái 
                MaLVText = MaLinhVuc.Text;
                if (MaLinhVuc.Text != "") numberEdit = 1;
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

                if (MaLinhVuc.Text == "")
                {
                    MessageBox.Show("Mã lĩnh vực không được để trống !");
                    bug2++;
                }
                if (TenLinhVuc.Text == "")
                {
                    MessageBox.Show("Tên Lĩnh vực không được để trống !");
                    bug2++;
                }
                //if (dem == 0)
                //{
                // MALV = MaLinhVuc.Text;
                //    dem = 1;
                //    btAdd.Enabled = false;
                //    btDelete.Enabled = false;
                //}
                if (bug2 == 0)
                {
                    try
                    {
                        string strUpdate = "Update tblLinhVuc set Malv='" + MaLinhVuc.Text + "',TenLv='" + TenLinhVuc.Text + "',GhiChu='" + GhiChuLinhVuc.Text + "' where Malv='" + MALV + "'";
                        cls.ThucThiSQLTheoPKN(strUpdate);
                        cls.LoadData2DataGridView(dataGridView1, "select *from tblLinhVuc");
                        btAdd.Enabled = true;
                        btDelete.Enabled = true;
                        MessageBox.Show("Sửa thành công");
                        // dem = 0;
                        nundo = 0;
                        MaLinhVuc.Text = "";
                        TenLinhVuc.Text = "";
                        GhiChuLinhVuc.Text = "";
                        numberEdit = 0;
                    }
                    catch { MessageBox.Show("Không thể sửa - Mã Lĩnh vực đã tồn tại !!!"); };
                }
            }

        }

    }
}
