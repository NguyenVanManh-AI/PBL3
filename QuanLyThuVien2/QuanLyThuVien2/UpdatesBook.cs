using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien2
{
    public partial class UpdatesBook : Form
    {
        public UpdatesBook()
        {
            InitializeComponent();
        }

        Class.clsDatabase cls = new QuanLyThuVien2.Class.clsDatabase();
        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"~!@#$%^&*()_+`1234567890-=[]\{}|;':,./<>?";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }


        int dem = 0;
        string masach;
        private void Sua_Click(object sender, EventArgs e)
        {
            //if (dem == 0)
            //{
            //    masach = txtMASACH.Text;
            //    dem = 1;
            //    button1.Enabled = false;
            //    button3.Enabled = false;
            //}

            if (txtMASACH.Text != "")
            {
                if (txtTENSACH.Text != "")

                {
                    if (hasSpecialChar(txtTENSACH.Text))
                    {
                        MessageBox.Show("Tên sách không được chứa ký tự đặc biệt");


                    }

                    else
                    {
                        if (txtNAMXB.Text != "")
                        {
                            if (txtSOTRANG.Text != "")
                            {
                                if (txtSOLUONG.Text != "")
                                {
                                    if (txtsachhong.Text != "")
                                    {
                                        if (maskedTextBox1.Text != "")
                                        {
                                            try
                                            {
                                                string strUpdate = "Update tblSach set MASACH='" + txtMASACH.Text + "',TENSACH= N'" + txtTENSACH.Text + "',MATG='" + cboMATG.Text + "',MANXB='" + cboMANXB.Text + "',MaLv='" + cboMALv.Text + "',NAMXB='" + txtNAMXB.Text + "',SOTRANG='" + txtSOTRANG.Text + "',SOLUONG='" + txtSOLUONG.Text + "',SOSACHHONG='" + txtsachhong.Text + "',NGAYNHAP='" + maskedTextBox1.Text + "',GHICHU='" + txtGHICHU.Text + "' where MASACH='" + masach + "'";
                                                cls.ThucThiSQLTheoPKN(strUpdate);
                                                cls.LoadData2DataGridView(dataGridView1, "select * from tblSach");
                                                //button1.Enabled = true;
                                                //button3.Enabled = true;
                                                //dem = 0;
                                                MessageBox.Show("Sửa thành công");
                                                txtMASACH.Text = "";
                                                txtTENSACH.Text = "";
                                                txtNAMXB.Text = "";
                                                txtSOTRANG.Text = "";
                                                txtSOLUONG.Text = "";
                                                txtsachhong.Text = "";
                                                maskedTextBox1.Text = "";
                                                txtGHICHU.Text = "";
                                                cboMALv.Text = "";
                                                cbotenLV.Text = "";
                                                cboMATG.Text = "";
                                                cbotenTG.Text = "";
                                                cboMANXB.Text = "";
                                                cbotenNXB.Text = "";

                                            }
                                            catch { }
                                        }
                                        else { MessageBox.Show("Ngày nhập không được để trống"); }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Số sách hỏng không được để trống");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Số lượng sách không được bỏ trống");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Số trang không được để trống");
                            }
                        }
                        else { MessageBox.Show("Năm xuất bản không được để trống"); }

                    }
                }
                else
                {
                    MessageBox.Show("Tên sách không được để trống");
                }
            }
            else
            {
                MessageBox.Show("Mã sách không được để trống ");
            }

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMASACH.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTENSACH.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboMATG.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cboMANXB.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                cboMALv.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNAMXB.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtSOTRANG.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSOLUONG.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtsachhong.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtGHICHU.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                masach = txtMASACH.Text;

            }
            catch { };
        }

        private void txtsachhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void cbotenLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMALv.SelectedIndex = cbotenLV.SelectedIndex;
        }

        private void cboMALv_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbotenLV.SelectedIndex = cboMALv.SelectedIndex;
        }

        private void cbotenTG_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMATG.SelectedIndex = cbotenTG.SelectedIndex;
        }

        private void cboMATG_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbotenTG.SelectedIndex = cboMATG.SelectedIndex;
        }

        private void cbotenNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMANXB.SelectedIndex = cbotenNXB.SelectedIndex;
        }

        private void cboMANXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbotenNXB.SelectedIndex = cboMANXB.SelectedIndex;
        }

        private void UpdatesBook_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from tblSach");
            cls.LoadData2Combobox(cboMATG, "select MATG from tblTacGia");
            cls.LoadData2Combobox(cboMANXB, "select MANXB from tblNXB");
            cls.LoadData2Combobox(cboMALv, "select MaLv from tblLinhVuc");
            cls.LoadData2Combobox(cbotenLV, "select TenLv from tblLinhVuc");
            cls.LoadData2Combobox(cbotenTG, "Select TENTG from tblTacGia");
            cls.LoadData2Combobox(cbotenNXB, "Select TENNXB from tblNXB");
        }

        private void Them_Click(object sender, EventArgs e)
        {
            if (txtMASACH.Text != "")
            {
                if (txtTENSACH.Text != "")

                {
                    if (hasSpecialChar(txtTENSACH.Text))
                    {
                        MessageBox.Show("Tên sách không được chứa ký tự đặc biệt");

                    }

                    else
                    {
                        if (txtNAMXB.Text != "")
                        {
                            if (txtSOTRANG.Text != "")
                            {
                                if (txtSOLUONG.Text != "")
                                {
                                    if (txtsachhong.Text != "")
                                    {


                                        if (maskedTextBox1.Text != "")
                                        {
                                            try
                                            {
                                                string strInsert = "Insert Into tblSach(MASACH,TENSACH,MATG,MANXB,MALv,NAMXB,SOTRANG,SOLUONG,SOSACHHONG,NGAYNHAP,GHICHU) values ('" + txtMASACH.Text
                                                    + "',N'" + txtTENSACH.Text + "','" + cboMATG.Text + "','" + cboMANXB.Text + "','"
                                                    + cboMALv.Text + "','" + txtNAMXB.Text + "','" + txtSOTRANG.Text + "','" + txtSOLUONG.Text
                                                    + "','" + txtsachhong.Text + "','" + maskedTextBox1.Text + "','" + txtGHICHU.Text + "')";
                                                cls.ThucThiSQLTheoPKN(strInsert);
                                                cls.LoadData2DataGridView(dataGridView1, "select * from tblSach");
                                            }
                                            catch { MessageBox.Show("Trùng mã"); };
                                        }
                                        else { MessageBox.Show("Ngày nhập không được để trống"); }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Số sách hỏng không được để trống");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Số lượng sách không được bỏ trống");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Số trang không được để trống");
                            }
                        }
                        else { MessageBox.Show("Năm xuất bản không được để trống"); }

                    }
                }
                else
                {
                    MessageBox.Show("Tên sách không được để trống");
                }
            }
            else
            {
                MessageBox.Show("Mã sách không được để trống ");
            }

        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strDelete = "Delete from tblSach where MASACH='" + txtMASACH.Text + "'";
                    cls.ThucThiSQLTheoKetNoi(strDelete);
                    cls.LoadData2DataGridView(dataGridView1, "select * from tblSach");
                    MessageBox.Show("Xóa thành công !!!");
                    txtMASACH.Text = "";
                    txtTENSACH.Text = "";
                    txtNAMXB.Text = "";
                    txtSOTRANG.Text = "";
                    txtSOLUONG.Text = "";
                    txtsachhong.Text = "";
                    maskedTextBox1.Text = "";
                    txtGHICHU.Text = "";
                    cboMALv.Text = "";
                    cbotenLV.Text = "";
                    cboMATG.Text = "";
                    cbotenTG.Text = "";
                    cboMANXB.Text = "";
                    cbotenNXB.Text = "";
                }
            }
            catch { }

        }


    }
}
