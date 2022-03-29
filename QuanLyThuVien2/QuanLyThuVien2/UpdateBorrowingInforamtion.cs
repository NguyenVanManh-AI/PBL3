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
    public partial class UpdateBorrowingInforamtion : Form
    {
        public UpdateBorrowingInforamtion()
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
      


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cboDOCGIA.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                cboMASACH.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSOPHIEU.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                mktNGAYMUON.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                mktNGAYTRA.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                cboXACNHAN.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtGHICHU.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                madg = cboDOCGIA.Text;
            }
            catch { };
        }
       
        string madg;
       

        private void UpdateBorrowingInforamtion_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from tblMuon");
            cls.LoadData2Combobox(cboDOCGIA, "select MADG from tblDocGia");
            cls.LoadData2Combobox(cboMASACH, "Select MASACH from tblSach");
        }

        private void Them_Click(object sender, EventArgs e)
        {
            if(cboDOCGIA.Text != "")
            {
                if(cboMASACH.Text != "")
                {
                    if(txtSOPHIEU.Text != "")
                    {
                        if(mktNGAYMUON.Text != "")
                        {
                            if (mktNGAYTRA.Text != "")
                            {
                                if(cboXACNHAN.Text != "")
                                {
                                    try
                                    {
                                        string strInsert = "Insert Into tblMuon(MADG,MASACH,SOPHIEUMUON,NGAYMUON,NGAYTRA,XACNHANTRA,GHICHU) values ('" + cboDOCGIA.Text + "','" + 
                                            cboMASACH.Text + "','" + txtSOPHIEU.Text + "','" + mktNGAYMUON.Text + "','" + 
                                            mktNGAYTRA.Text + "','" + cboXACNHAN.Text + "','" + txtGHICHU.Text + "')";
                                        cls.ThucThiSQLTheoPKN(strInsert);
                                        cls.LoadData2DataGridView(dataGridView1, "select * from tblMuon");
                                        MessageBox.Show("Thêm thành công");
                                    }
                                    catch { MessageBox.Show("Trùng Mã"); };
                                }
                                else { MessageBox.Show("Thanh xác nhận không được để trống"); }
                            }
                            else { MessageBox.Show("Ngày trả không được để trống"); }
                        }
                        else { MessageBox.Show("Ngày mượn kh được để trống"); }
                    }
                    else { MessageBox.Show("Số phiếu mượn không được để trống"); }
                }
                else { MessageBox.Show("Mã sách không được để trống"); }
            }
            else { MessageBox.Show("Mã độc giả không được để trống"); }
            
        }

        private void Sua_Click(object sender, EventArgs e)
        {
       
            if (cboDOCGIA.Text != "")
            {
                if (cboMASACH.Text != "")
                {
                    if (txtSOPHIEU.Text != "")
                    {
                        if (mktNGAYMUON.Text != "")
                        {
                            if (mktNGAYTRA.Text != "")
                            {
                                if (cboXACNHAN.Text != "")
                                {
                                    
                                        try
                                        {
                                            string strUpdate = "Update tblMuon set MADG='" +cboDOCGIA.Text + "',MASACH='" + cboMASACH.Text + "',SOPHIEUMUON='" + txtSOPHIEU.Text 
                                                + "',NGAYMUON='" + mktNGAYMUON.Text + "',NGAYTRA='" + mktNGAYTRA.Text 
                                                + "',XACNHANTRA='" + cboXACNHAN.Text + "',GHICHU='" + txtGHICHU.Text + "' where MADG='" + madg + "'";

                                            cls.ThucThiSQLTheoPKN(strUpdate);
                                            cls.LoadData2DataGridView(dataGridView1, "select * from tblMuon");
                                           
                                            MessageBox.Show("Sửa thành công");
                                            cboMASACH.Text = "";
                                           cboDOCGIA.Text = "";
                                            txtGHICHU.Text = "";
                                            txtSOPHIEU.Text = "";
                                            mktNGAYMUON.Text = "";
                                            mktNGAYTRA.Text = "";
                                           
                                        }
                                        catch { MessageBox.Show("Không thể sửa !!!"); };

                                   
                                }
                                else { MessageBox.Show("Thanh xác nhận không được để trống"); }
                            }
                            else { MessageBox.Show("Ngày trả không được để trống"); }
                        }
                        else { MessageBox.Show("Ngày mượn kh được để trống"); }
                    }
                    else { MessageBox.Show("Số phiếu mượn không được để trống"); }
                }
                else { MessageBox.Show("Mã sách không được để trống"); }
            }
            else { MessageBox.Show("Mã độc giả không được để trống"); }


           
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strDelete = "Delete from tblMuon where MADG='" + cboDOCGIA.Text + "'";
                    cls.ThucThiSQLTheoKetNoi(strDelete);
                    cls.LoadData2DataGridView(dataGridView1, "select * from tblMuon");
                    MessageBox.Show("Xóa thành công !!!");
                    cboMASACH.Text = "";
                    cboDOCGIA.Text = "";
                    txtGHICHU.Text = "";
                    txtSOPHIEU.Text = "";
                    mktNGAYMUON.Text = "";
                    mktNGAYTRA.Text = "";
                }
            }
            catch { }
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    cls.LoadData2Label(label9, "select count(*)from tblMuon where MASACH='" + comboBox1.Text + "'");
        //}
    }

}
