using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class UpdateReaders : Form
    {
        public UpdateReaders()
        {
            InitializeComponent();
        }


        Class.clsDatabase cls = new LibraryManagement.Class.clsDatabase();
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
        public static string LuuNgay(string input)
        {
            string dd = input.Substring(0, 2);
            string mm = input.Substring(3, 2);
            string yyyy = input.Substring(6, 4);
            input = mm + "/" + dd + "/" + yyyy;
            return input;
        }

        public static string HienThiNgay(string input)
        {
            string[] arrListStr = input.Split('/');
            string mm = arrListStr[0];
            string dd = arrListStr[1];
            string yyyy = arrListStr[2];
            if (mm.Length == 1) mm = "0" + mm;
            if (dd.Length == 1) dd = "0" + dd;
            input = dd + "/" + mm + "/" + yyyy;
            return input;
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
        public int numberUndo = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtCard.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtCreate.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtUpdate.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtFName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() != "")
                {
                    maskedDOB.Text = HienThiNgay(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
                else
                {
                    maskedDOB.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                }
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "True")
                {
                    cbbGender.Text = "Nam";
                }
                else 
                { 
                    cbbGender.Text = "Nữ";
                }

                madg = txtId.Text;
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
            cls.LoadData2DataGridView(dataGridView1, "select * from readers");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int bug = 0;
            if(txtId.Text != "")
            {
                MessageBox.Show("Id is already exist!");
                bug++;
            }
            if(txtFName.Text == "")
            {
                MessageBox.Show("First Name cann't be left blank");
                bug++;
            }
            if (txtLName.Text == "")
            {
                MessageBox.Show("Last Name cann't be left blank");
                bug++;
            }
            if (txtCard.Text == "")
            {
                MessageBox.Show("Identity Card cann't be left blank");
                bug++;
            }
            if (txtPhone.Text == "")
            {
                MessageBox.Show("Phone Number cann't be left blank");
                bug++;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Email cann't be left blank");
                bug++;
            }
            if (bug == 0)
            {
                try
                {
                    string gender = "";
                    if (cbbGender.Text == "Nam") gender = "True";
                    else gender = "False";
                    string strInsert = "Insert Into readers (first_name,last_name,gender,date_of_birth,email,identity_card_number,phone,address,created_at,updated_at) values (N'" + txtFName.Text + "',N'" + txtLName.Text + "','" + gender + "','" + LuuNgay(maskedDOB.Text) + "','" + txtEmail.Text + "','" + txtCard.Text + "','" + txtPhone.Text + "',N'" + txtAddress.Text + "','" + ChangeDate(DateTime.Now.ToString()) + "','" + ChangeDate(DateTime.Now.ToString())+"')";
                    //MessageBox.Show(strInsert);
                    cls.ThucThiSQLTheoPKN(strInsert);
                    cls.LoadData2DataGridView(dataGridView1, "select * from readers");
                    MessageBox.Show("Add successfully!");
                    txtId.Text = "";
                    txtFName.Text = "";
                    txtLName.Text = "";
                    txtEmail.Text = "";
                    txtAddress.Text = "";
                    maskedDOB.Text = "";
                    txtEmail.Text = "";
                    cbbGender.Text = "";
                    txtCreate.Text = "";
                    txtUpdate.Text = "";
                    cbbGender.Text = "";
                    numberUndo = 0;


                }
                catch { MessageBox.Show("Add Fail!"); };
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
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

                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string id = row.Cells[0].Value.ToString();
                            string strDelete = "Delete from readers where id='" + id + "'";
                            cls.ThucThiSQLTheoKetNoi(strDelete);
                        }
                        cls.LoadData2DataGridView(dataGridView1, "select * from readers");
                        txtId.Text = "";
                        txtFName.Text = "";
                        txtLName.Text = "";
                        txtEmail.Text = "";
                        txtAddress.Text = "";
                        maskedDOB.Text = "";
                        txtEmail.Text = "";
                        cbbGender.Text = "";
                        txtCreate.Text = "";
                        txtUpdate.Text = "";
                        cbbGender.Text = "";
                        numberUndo = 0;
                        MessageBox.Show("Delete successfully!");
                    }
                    catch
                    {
                        MessageBox.Show("Delete fail");
                    };

                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int bug = 0;
            if (txtId.Text == "")
            {
                MessageBox.Show("Please select a row of data you want to edit!");
                bug++;
            }
            if (txtFName.Text == "")
            {
                MessageBox.Show("First Name cann't be left blank");
                bug++;
            }
            if (txtLName.Text == "")
            {
                MessageBox.Show("Last Name cann't be left blank");
                bug++;
            }
            if (txtCard.Text == "")
            {
                MessageBox.Show("Identity Card cann't be left blank");
                bug++;
            }
            if (txtPhone.Text == "")
            {
                MessageBox.Show("Phone Number cann't be left blank");
                bug++;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Email cann't be left blank");
                bug++;
            }
            if (bug == 0)
            {
                try
                {
                    string gender = "";
                    if (cbbGender.Text == "Nam") gender = "True";
                    else gender = "False";
                    string strUpdate = "update readers set first_name =N'" + txtFName.Text + "',last_name =N'" + txtLName.Text + "',gender='" + gender + "',date_of_birth='" + maskedDOB.Text + "',email='" + txtEmail.Text + "',identity_card_number='" + txtCard.Text + "',phone='" + txtPhone.Text + "',address=N'" + txtAddress.Text + "',updated_at='" + ChangeDate(DateTime.Now.ToString()) + "' where id ='" + txtId.Text + "'";
                    MessageBox.Show(strUpdate);
                    cls.ThucThiSQLTheoPKN(strUpdate);
                    cls.LoadData2DataGridView(dataGridView1, "select * from readers");
                    MessageBox.Show("Edit successfully!");
                }
                catch
                {
                    MessageBox.Show("Edit fail!");
                }
            }
        }

        public string undoMDG, undoHT, undoNS, undoGT, undoLOP, undoDIACHI, undoEMAIL, undoGHICHU;


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from readers where first_name like N'%" + txtSearch.Text + "%' or last_name like N'%" + txtSearch.Text + "%' or email like '%" + txtSearch.Text + "%' or phone like '%" + txtSearch.Text + "%' or identity_card_number like '%" + txtSearch.Text + "%' or address like N'%" + txtSearch.Text + "%'");
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
