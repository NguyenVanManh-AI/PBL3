using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class UpdateCategorys : Form
    {
        public UpdateCategorys()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new Class.clsDatabase();
        private void capnhatLv_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from categorys");
        }
        public int bug = 0, nundo = 0;
        public int numberEdit = 0;
        public string MaLVText = "";
        public string ChangeDate(string datetime)
        {
            if (datetime.Contains("CH") || datetime.Contains("SA"))
            {
                datetime = datetime.Replace("CH", "PM");
                datetime = datetime.Replace("SA", "AM");
                string[] arrListStr = datetime.Split(' ');
                string date = arrListStr[0];
                string time = arrListStr[1];
                string pm = arrListStr[2];

                string[] arrListStr2 = date.Split('/');

                string dd = arrListStr2[0];
                string mm = arrListStr2[1];
                string yyyy = arrListStr2[2];

                datetime = mm + "/" + dd + "/" + yyyy + " " + time + " " + pm;
            }
            return datetime;
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
                    bug = 0;
                    if(txtId.Text != "")
                    {
                        MessageBox.Show("Id is alredy exist!");
                    }
                    if (txtId.Text != "")
                    {
                        MessageBox.Show("Category's Id is already exist!");
                        bug++;
                    }
                    if (txtName.Text == "")
                    {
                        MessageBox.Show("Category's Name cann't be left blank!");
                        bug++;
                    }

                    if (bug == 0)
                    {
                        try
                        {
                            string strInsert = "Insert Into categorys(name,description,updated_at,created_at) values (N'" + txtName.Text + "',N'" + txtDes.Text +"','"+ChangeDate(DateTime.Now.ToString()) + "','" + ChangeDate(DateTime.Now.ToString()) + "')";
                            cls.ThucThiSQLTheoPKN(strInsert);
                            cls.LoadData2DataGridView(dataGridView1, "select *from categorys");
                            MessageBox.Show("Add successfully!");
                            nundo = 0;
                            txtId.Text = "";
                            txtName.Text = "";
                            txtDes.Text = "";
                            txtUpdate.Text = "";
                            txtCreate.Text = "";
                            numberEdit = 0;
                        }
                        catch
                        {
                            MessageBox.Show("Add fail!");
                        };
                    }
        }

        public string undoMLV, undoTLV, undoGCLV;

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row of data you want to delete !");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        //undoMLV = txtId.Text;
                        //undoTLV = txtName.Text;
                        //undoGCLV = txtDes.Text;
                        
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string id = row.Cells[0].Value.ToString();
                            string strDelete = "Delete from categorys where id='" + id + "'";
                            cls.ThucThiSQLTheoKetNoi(strDelete);
                        }
                        cls.LoadData2DataGridView(dataGridView1, "select * from categorys");
                        txtId.Text = "";
                        txtName.Text = "";
                        txtDes.Text = "";
                        txtUpdate.Text = "";
                        txtCreate.Text = "";
                        MessageBox.Show("Delete successfully!");
                        nundo = 1;
                        numberEdit = 0;

                    }
                    catch { 
                        MessageBox.Show("Delete fail");
                    };

                }
            }

        }

        //private void btUndo_Click(object sender, EventArgs e)
        //{
        //    if (nundo == 1)
        //    {
        //        string strInsert = "Insert Into tblLinhVuc(MaLv,TenLv,GhiChu) values ('" + undoMLV + "','" + undoTLV + "','" + undoGCLV + "')";
        //        cls.ThucThiSQLTheoPKN(strInsert);
        //        cls.LoadData2DataGridView(dataGridView1, "select *from tblLinhVuc");
        //        MessageBox.Show("Hoàn tác thành công");
        //        nundo = 0;
        //    }

        //}
        string MALV;

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from categorys where name like N'%" + txtSearch.Text + "%'");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from categorys where name like N'%" + txtSearch.Text + "%'");
        }

        //private void btnSearch2_Click(object sender, EventArgs e)
        //{
        //    cls.LoadData2DataGridView(dataGridView1, "select * from tblLinhVuc where MaLv like '%" + txtSearch.Text + "%' OR TenLv like '%" + txtSearch.Text + "%'");
        //}

        //private void txtSearch2_TextChanged(object sender, EventArgs e)
        //{
        //    cls.LoadData2DataGridView(dataGridView1, "select * from tblLinhVuc where MaLv like '%" + txtSearch.Text + "%' OR TenLv like '%" + txtSearch.Text + "%'");
        //}
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDes.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtCreate.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtUpdate.Text=dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                MALV = txtId.Text; // khi click vào cái nào thì lưu mã của cái đó lại để nếu có edit thì edit sau đó update đến sql đúng cái 
                MaLVText = txtId.Text;
                if (txtId.Text != "") numberEdit = 1;
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
                MessageBox.Show("Please select a row of data you want to delete!");
            }
            else
            {
                bug2 = 0;
                if (txtName.Text == "")
                {
                    MessageBox.Show("Category's Name cann't be blank!");
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
                        string strUpdate = "Update categorys set name=N'" + txtName.Text + "',description=N'" + txtDes.Text + "',updated_at ='"+ChangeDate(DateTime.Now.ToString())+"' where id='" +txtId.Text  + "'";
                        cls.ThucThiSQLTheoPKN(strUpdate);
                        cls.LoadData2DataGridView(dataGridView1, "select * from categorys");
                        btAdd.Enabled = true;
                        btDelete.Enabled = true;
                        MessageBox.Show("Edit successfully!");
                        // dem = 0;
                        nundo = 0;
                        txtId.Text = "";
                        txtName.Text = "";
                        txtDes.Text = "";
                        txtUpdate.Text = "";
                        txtCreate.Text = "";
                        numberEdit = 0;
                    }
                    catch { MessageBox.Show("Edit fail!"); };
                }
            }

        }

    }
}