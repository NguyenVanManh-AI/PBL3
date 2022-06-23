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
    public partial class UpdatePublishers : Form
    {
        public UpdatePublishers()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new LibraryManagement.Class.clsDatabase();
        private void capnhatNXB_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select *from publishers");
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
            string specialChar = @"~!@#$%^&*()_+`-=[]\{}|;':,./<>?qwertyuiopasdfghjklzxcvbnm";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
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
        public int bug = 0, numberEdit = 0, numberUndo = 0;
        string manxb;
        private void btAdd_Click(object sender, EventArgs e)
        {
            bug = 0;
            if (txtId.Text != "")
            {
                MessageBox.Show("Id is already exist!");
                bug++;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Publisher's Name can't be left blank!");
                bug++;
            }
            if (hasSpecialChar(txtName.Text))
            {
                MessageBox.Show("Publisher's Name can't contain special characters (~!@#$%^&*()_+`1234567890-=[]{}|;':,./<>? !)");
                bug++;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Publiser's Id can't be left blank!");
                bug++;
            }
            if (txtCountry.Text == "")
            {
                MessageBox.Show("Publisher's Country can't be left blank!");
                bug++;
            }
            if (bug == 0)
            {
                try
                {
                    string datetime = DateTime.Now.ToString();

                    string strInsert = "Insert Into publishers (name,address,country,description,created_at,updated_at) values (N'" + txtName.Text + "',N'" + txtAddress.Text + "',N'" + txtCountry.Text + "',N'" + txtDes.Text + "','" + ChangeDate(datetime) + "','" + ChangeDate(datetime) + "')";
                    cls.ThucThiSQLTheoPKN(strInsert);
                    cls.LoadData2DataGridView(dataGridView1, "select *from publishers");
                    MessageBox.Show("Add successfully");
                    txtId.Text = "";
                    txtName.Text = "";
                    txtAddress.Text = "";
                    txtCountry.Text = "";
                    txtDes.Text = "";
                    txtCreate.Text = "";
                    txtUpdate.Text = "";
                    numberEdit = 0;
                    numberUndo = 0;
                }
                catch { MessageBox.Show("Add Failure!"); };
            }

        }


        public string undoid, undoname, undoaddress, undodes, undocountry,undocreate,undoupdate;

        
        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from publishers where name like N'%" + txtSearch.Text + "%' OR address like N'%" + txtSearch.Text + "%' OR country like N'%" + txtSearch.Text + "%'");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from publishers where name like N'%" + txtSearch.Text + "%' OR address like N'%" + txtSearch.Text + "%' OR country like N'%" + txtSearch.Text + "%'");
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row of data you want to delete !");
            }
            else if(dataGridView1.SelectedRows.Count > 0 )
            {
                if (MessageBox.Show("Are you sure you want to delete?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    { 
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string id = row.Cells[0].Value.ToString();
                            string strDelete = "Delete from publishers where id='" + id + "'";
                            cls.ThucThiSQLTheoKetNoi(strDelete);
                        }
                        cls.LoadData2DataGridView(dataGridView1, "select * from publishers");
                        txtId.Text = "";
                        txtName.Text = "";
                        txtAddress.Text = "";
                        txtCountry.Text = "";
                        txtDes.Text = "";
                        txtCreate.Text = "";
                        txtUpdate.Text = "";
                        MessageBox.Show("Delete successfully");
                        numberEdit = 0;
                        numberUndo = 1;

                    }
                    catch
                    {
                        MessageBox.Show("You must remove the links to the publisher before");
                    };
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCountry.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCreate.Text= dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtUpdate.Text= dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtDes.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                manxb = txtId.Text;
                if (txtId.Text != "") numberEdit = 1;
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
                MessageBox.Show("Please select a row of data you want to edit!");
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
                
                if (txtName.Text == "")
                {
                    MessageBox.Show("Publisher's Name can't be left blank!");
                    bug2++;
                }
                if (hasSpecialChar(txtName.Text))
                {
                    MessageBox.Show("Publisher's Name can't contain special characters (~!@#$%^&*()_+`1234567890-=[]{}|;':,./<>? !)");
                    bug2++;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Publiser's Id can't be left blank!");
                    bug2++;
                }
                if (txtCountry.Text == "")
                {
                    MessageBox.Show("Publisher's Country can't be left blank!");
                    bug2++;
                }
                if (bug2 == 0)
                {
                    try
                    {
                        string datetime = DateTime.Now.ToString();
                        string strUpdate = "update publishers set name=N'" + txtName.Text + "',address=N'" + txtAddress.Text + "',country=N'" + txtCountry.Text + "',description=N'" + txtDes.Text + "',updated_at='" + ChangeDate(datetime) + "' where id=" + Int32.Parse(txtId.Text) ;
                        cls.ThucThiSQLTheoPKN(strUpdate);

                        cls.LoadData2DataGridView(dataGridView1, "select * from publishers");
                        btAdd.Enabled = true;
                        btDelete.Enabled = true;
                        //dem = 0;
                        MessageBox.Show("Edit successfully!");
                        txtId.Text = "";
                        txtName.Text = "";
                        txtAddress.Text = "";
                        txtCountry.Text = "";
                        txtDes.Text = "";
                        txtUpdate.Text = "";
                        txtCreate.Text = "";
                        numberEdit = 0;
                        numberUndo = 0;
                    }
                    catch { MessageBox.Show("Edit Fail!"); };
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