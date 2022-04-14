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
    public partial class UpdateReaders : Form
    {
        public UpdateReaders()
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
        public static bool hasSpecialChar1(string input)
        {
            string specialChar = @"@gmail.com";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
        public int numberUndo = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMADG.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtHOTEN.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cboGioiTinh.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtLOP.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDIACHI.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtNote.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                madg = txtMADG.Text;
            }
            catch { };
        }

        string madg;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateReaders_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from tblDocGia");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMADG.Text != "")
            {


                if (txtHOTEN.Text != "")
                {
                    if (hasSpecialChar(txtHOTEN.Text))
                    {
                        MessageBox.Show("Họ Tên độc giả không có kí tự đặc biệt");
                    }
                    else
                    {



                        if (txtLOP.Text != "")
                        {

                            if (txtDIACHI.Text != "")
                            {

                                if (maskedTextBox1.Text != "")
                                {

                                    if (txtemail.Text != "")
                                    {
                                        if (!hasSpecialChar1(txtemail.Text))
                                        {
                                            MessageBox.Show("địa chỉ Email phải có đuôi @gmail.com ");
                                        }
                                        else
                                        {
                                            try
                                            {
                                                string strInsert = "Insert Into tblDocGia(MADG,HOTEN,NGAYSINH,GIOITINH,LOP,DIACHI,EMAIL,GHICHU) values ('" + txtMADG.Text + "',N'" + txtHOTEN.Text
                                                    + "','" + maskedTextBox1.Text + "','" + cboGioiTinh.Text + "','" + txtLOP.Text
                                                    + "',N'" + txtDIACHI.Text + "','" + txtemail.Text + "','" + txtNote.Text + "')";
                                                cls.ThucThiSQLTheoPKN(strInsert);
                                                cls.LoadData2DataGridView(dataGridView1, "select * from tblDocGia");
                                                MessageBox.Show("Thêm thành công");
                                                txtMADG.Text = "";
                                                txtHOTEN.Text = "";
                                                txtDIACHI.Text = "";
                                                txtLOP.Text = "";
                                                maskedTextBox1.Text = "";
                                                txtemail.Text = "";
                                                txtNote.Text = "";
                                                cboGioiTinh.Text = "";
                                                numberUndo = 0;


                                            }
                                            catch { MessageBox.Show("Trùng Mã"); };
                                        }


                                    }
                                    else
                                    {
                                        MessageBox.Show("Email không được để trống");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ngày sinh không được để trống");
                                }
                            }

                            else
                            {
                                MessageBox.Show("Địa chỉ không được để trống");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lớp không được để trống");
                        }
                    }
                }




                else
                {
                    MessageBox.Show("Tên độc giả không được để trống");
                }



            }
            else
            {
                MessageBox.Show("Mã độc giả không được để trống");
            }








        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMADG.Text == "")
            {
                MessageBox.Show("Bạn hãy chọn 1 dòng để xóa");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    try
                    {
                        undoMDG = txtMADG.Text;
                        undoHT = txtHOTEN.Text;
                        undoDIACHI = txtDIACHI.Text;
                        undoNS = maskedTextBox1.Text;
                        undoLOP = txtLOP.Text;
                        undoEMAIL = txtemail.Text;
                        undoGHICHU = txtNote.Text;
                        undoGT = cboGioiTinh.Text;
                        string strDelete = "Delete from tblDocGia where MADG='" + txtMADG.Text + "'";
                        cls.ThucThiSQLTheoKetNoi(strDelete);
                        cls.LoadData2DataGridView(dataGridView1, "select * from tblDocGia");
                        MessageBox.Show("Xóa thành công");
                        txtMADG.Text = "";
                        txtHOTEN.Text = "";
                        txtDIACHI.Text = "";
                        txtLOP.Text = "";
                        maskedTextBox1.Text = "";
                        txtemail.Text = "";
                        txtNote.Text = "";
                        cboGioiTinh.Text = "";
                        numberUndo = 1;



                    }
                    catch { MessageBox.Show("Phải xóa những thông tin liên quan đến nhà xuất bản này trước"); };
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)

        {

            if (txtMADG.Text != "")
            {
                if (txtHOTEN.Text != "")
                {
                    if (hasSpecialChar(txtHOTEN.Text))
                    {
                        MessageBox.Show("Tên độc giả không được chứa ký tự đặc biệt");
                    }
                    else
                    {
                        if (txtLOP.Text != "")
                        {
                            if (txtDIACHI.Text != "")
                            {
                                if (maskedTextBox1.Text != "")
                                {
                                    if (txtemail.Text != "")
                                    {
                                        if (!hasSpecialChar1(txtemail.Text))
                                        {
                                            MessageBox.Show("địa chỉ Email phải có @gmail.com ");
                                        }
                                        else
                                        {
                                            try
                                            {
                                                string strUpdate = "Update tblDocGia set MADG='" + txtMADG.Text + "',HOTEN=N'" + txtHOTEN.Text + "',NGAYSINH='" + maskedTextBox1.Text
                                                    + "',GIOITINH='" + cboGioiTinh.Text + "',LOP='"
                                                    + txtLOP.Text + "',DIACHI=N'" + txtDIACHI.Text + "',EMAIL='" + txtemail.Text + "',GHICHU='" + txtNote.Text + "' where MADG='" + madg + "'";
                                                cls.ThucThiSQLTheoPKN(strUpdate);
                                                cls.LoadData2DataGridView(dataGridView1, "select * from tblDocGia");

                                                MessageBox.Show("Sửa thành công");
                                                txtMADG.Text = "";
                                                txtHOTEN.Text = "";
                                                maskedTextBox1.Text = "";
                                                txtLOP.Text = "";
                                                txtDIACHI.Text = "";
                                                txtemail.Text = "";
                                                txtNote.Text = "";
                                                numberUndo = 0;


                                            }
                                            catch { MessageBox.Show("Không thể sửa !!!"); };
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Email không được để trống");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ngày sinh không được để trống");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Địa chỉ không được để trống");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lớp không được để trống");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tên độc giả không được để trống");
                }

            }
            else
            {
                MessageBox.Show("Mã độc giả khong được để trống");
            }








        }

        public string undoMDG, undoHT, undoNS, undoGT, undoLOP, undoDIACHI, undoEMAIL, undoGHICHU;

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (numberUndo == 1)
            {
                string strInsert = "Insert Into tblDocGia(MADG,HOTEN,NGAYSINH,GIOITINH,LOP,DIACHI,EMAIL,GHICHU) values ('" + undoMDG + "',N'" + undoHT
                                                    + "','" + undoNS + "','" + undoGT + "','" + undoLOP
                                                    + "',N'" + undoDIACHI + "','" + undoEMAIL + "','" + undoGHICHU + "')";
                cls.ThucThiSQLTheoPKN(strInsert);
                cls.LoadData2DataGridView(dataGridView1, "select * from tblDocGia");
                MessageBox.Show("Hoàn tác thành công !");
                numberUndo = 0;
            }
        }
    }
}
