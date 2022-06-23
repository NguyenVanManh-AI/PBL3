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
    public partial class UpdateAuthors : Form
    {
        public UpdateAuthors()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new LibraryManagement.Class.clsDatabase();

        public int numberEdit = 0;

        private void capnhatTG_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from authors");
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

        public int bug = 0, numberUndo = 0;


        private void btAdd_Click(object sender, EventArgs e)
        {
            bug = 0;
            string datetime = DateTime.Now.ToString();
            if (txtId.Text != "")
            {
                MessageBox.Show("id is already exist!");
            }
            if (txtFName.Text == "")
            {
                MessageBox.Show("First Name cann't be left blank !");
                bug++;
            }
            if (txtLName.Text == "")
            {
                MessageBox.Show("Last Name cann't be left blank !");
                bug++;
            }
            if (hasSpecialChar(txtFName.Text))
            {
                MessageBox.Show("First Name cann't contain specials char(~!@#$%^&*()_+`1234567890-=[]{}|;':,./<>?) !");
                bug++;
            }
            if (hasSpecialChar(txtLName.Text))
            {
                MessageBox.Show("Last Name cann't contain specials char(~!@#$%^&*()_+`1234567890-=[]{}|;':,./<>?) !");
                bug++;
            }
            if (bug == 0)
            {
                try
                {
                    string gender = "";
                    if (cbbGender.Text == "Nam") gender = "1";
                    else gender = "0";
                    string strInsert = "Insert Into authors(first_name, last_name,gender,description,created_at,updated_at) values (N'"  + txtFName.Text + "',N'" +txtLName.Text+"','"+ gender + "',N'" + txtDes.Text + "','" + ChangeDate(datetime) + "','"+ ChangeDate(datetime) + "')";
                    //MessageBox.Show(strInsert);
                    cls.ThucThiSQLTheoPKN(strInsert);
                    cls.LoadData2DataGridView(dataGridView1, "select * from authors");
                    MessageBox.Show("Add successfully!");
                    numberEdit = 0;
                    txtId.Text = "";
                    txtFName.Text = "";
                    txtLName.Text = "";
                    txtDes.Text = "";
                    cbbGender.Text = "";
                    txtCreate.Text = "";
                    txtUpdate.Text = "";
                    numberUndo = 0;
                }
                catch { MessageBox.Show("Add Fail"); };
            }

        }


        public string undoMTG, undoTTG, undoDC, undoNote, undoGT;
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
                        foreach(DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string id = row.Cells[0].Value.ToString();
                            string strDelete = "Delete from authors where Id='" + id + "'";
                            cls.ThucThiSQLTheoKetNoi(strDelete);
                        }
                        cls.LoadData2DataGridView(dataGridView1, "select * from authors");
                        MessageBox.Show("Delete successfully!!");
                        txtId.Text = "";
                        txtFName.Text = "";
                        txtLName.Text = "";
                        cbbGender.Text = "";
                        txtUpdate.Text = "";
                        txtCreate.Text = "";
                        txtDes.Text = "";
                        numberUndo = 1;
                    }
                    catch { MessageBox.Show("You must remove the links to the authors before"); };
                }
            }

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from authors where first_name like N'%"+txtSearch.Text+"%' or last_name like N'%"+txtSearch.Text+"%'");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from authors where first_name like N'%" + txtSearch.Text + "%' or last_name like N'%" + txtSearch.Text + "%'");
        }

        

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        string matg;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtFName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "True") cbbGender.Text = "Nam";
                else cbbGender.Text = "Nữ";
                txtDes.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtCreate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtUpdate.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                matg = txtId.Text;
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
                MessageBox.Show("Please select a row of data you want to edit!");
            }
            else
            {
                bug2 = 0;
                if (txtFName.Text == "")
                {
                    MessageBox.Show("First Name cann't be left blank !");
                    bug2++;
                }
                if (txtLName.Text == "")
                {
                    MessageBox.Show("Last Name cann't be left blank !");
                    bug2++;
                }
                if (hasSpecialChar(txtFName.Text))
                {
                    MessageBox.Show("First Name cann't contain specials char(~!@#$%^&*()_+`1234567890-=[]{}|;':,./<>?) !");
                    bug2++;
                }
                if (hasSpecialChar(txtLName.Text))
                {
                    MessageBox.Show("Last Name cann't contain specials char(~!@#$%^&*()_+`1234567890-=[]{}|;':,./<>?) !");
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
                        string date = DateTime.Now.ToString();
                        string gender = "";
                        if (cbbGender.Text == "Nam") gender = "True"; else gender = "False";
                        string strUpdate = "Update authors set first_name=N'" + txtFName.Text + "',last_name=N'" + txtLName.Text + "',description=N'" + txtDes.Text +"',gender ='"+gender+ "',updated_at = '"+ChangeDate(date)+"' where id='" + matg + "'";
                        //MessageBox.Show(strUpdate);
                        cls.ThucThiSQLTheoPKN(strUpdate);
                        cls.LoadData2DataGridView(dataGridView1, "select *from authors");
                        //btAdd.Enabled = true;
                        //btDelete.Enabled = true;
                        //dem = 0;
                        MessageBox.Show("Edit successfully!");
                        txtId.Text = "";
                        txtFName.Text = "";
                        txtLName.Text = "";
                        txtDes.Text = "";
                        cbbGender.Text = "";
                        txtUpdate.Text = "";
                        txtCreate.Text = "";
                        numberEdit = 0;
                        numberUndo = 0;
                    }
                    catch { MessageBox.Show("Edit Fail!"); };
                    // }
                }
            }


        }
    }
}