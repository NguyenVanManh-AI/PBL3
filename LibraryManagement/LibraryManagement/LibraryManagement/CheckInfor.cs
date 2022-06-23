using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;


using System.Data.SqlClient; // + 


namespace LibraryManagement
{
    public partial class CheckInfor : Form
    {
        public CheckInfor()
        {
            InitializeComponent();
        }

        // + 
        SqlCommand sqlCommand;
        public Object layGiaTri(string sql)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = Con;
            Object obj = sqlCommand.ExecuteScalar(); 
            return obj;
        }

        SqlConnection Con;
        // + 

        private void KiemTraTTNVien_Load(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select id,username,role,first_name,last_name,phone,email,address,date_of_birth,created_at,updated_at from employees");
            // + 
            try
            {
                Con = new SqlConnection();
                Con.ConnectionString = @"Server =DESKTOP-QCOSLTK\VANMANH;" + "database=System_Library ; Integrated Security = true";
                Con.Open();
            }
            catch { }
            // + 
        
        }
        Class.clsDatabase cls = new LibraryManagement.Class.clsDatabase();


        public bool CheckUsername(string input)
        {
            object Q = layGiaTri("SELECT id FROM employees WHERE username = '" + input + "'");
            string id = Convert.ToString(Q);
            if (id != "" && Int32.Parse(id) != id_employee) return true;
            else return false;
        }
        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public bool VerifyEmail(string emailVerify)
        {
            using (WebClient webclient = new WebClient())
            {
                string url = "http://verify-email.org/";
                NameValueCollection formData = new NameValueCollection();
                formData["check"] = emailVerify;
                byte[] responseBytes = webclient.UploadValues(url, "POST", formData);
                string response = Encoding.ASCII.GetString(responseBytes);
                if (response.Contains("Result: Ok"))
                {
                    return true;
                }
                return false;
            }
        }
        public static bool Checkso(string input)
        {
            string specialChar = @"~!@#$%^&*()_+`qwertyuiopasdfghjklzxcvbnm-=[]\{}|;':,./<>?";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
        public static bool CheckTen(string input)
        {
            string specialChar = @"~!@#$%^&*()_+`1234567890-=[]\{}|;':,./<>?";
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


        public static bool QuaNgay(string input)
        {
            input = LuuNgay(input);
            DateTime oDate = Convert.ToDateTime(input);
            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString("MM/dd/yyyy");
            DateTime oDate2 = Convert.ToDateTime(date);
            if (oDate > oDate2) return false;
            else return true;
        }


        public static bool CheckText(string input)
        {
            if (input.Length >= 1) return true;
            else return false;
        }

        public static string Date_Now()
        {
            string datetime = DateTime.Now.ToString();
            // MessageBox.Show(datetime);

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





        int id_employee = 0 ;
        string username_employee = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUserName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtRole.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtFirstname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtNumberPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            mkDateOfBirth.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtCreatedAt.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtUpdatedAt.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();

            id_employee = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            username_employee = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            if (dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() != "")
            {
                mkDateOfBirth.Text = HienThiNgay(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
            }
            if (txtCreatedAt.Text.Contains("PM") || txtCreatedAt.Text.Contains("AM"))
            {
                txtCreatedAt.Text = HienThiNgay(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
                txtUpdatedAt.Text = HienThiNgay(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
            }

        }

        


        // SAVE 
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (id_employee == 0)
                MessageBox.Show("Please select a data line !!!");
            else if (txtFirstname.Text == "")
                MessageBox.Show("Employee First Names cannot be left blank");

            else if(CheckUsername(txtUserName.Text))
                MessageBox.Show("Username " + txtUserName.Text.ToUpper() + " already exists !!!");

            else if (CheckTen(txtFirstname.Text))
                MessageBox.Show("Names can only contain alphanumeric characters !");

            else if (txtAddress.Text == "")
                MessageBox.Show("The address cannot be left blank");

            else if (!mkDateOfBirth.MaskFull) // không nhập đủ = false => ngược lại của false = true => thực hiện trong else if  
                MessageBox.Show("Invalid Date !");

            else if (Checkso(txtNumberPhone.Text))
                MessageBox.Show("Invalid Phone Number!");

            else if (txtNumberPhone.Text.Length < 3)
                MessageBox.Show("Phone number cannot be less than 3 digits !");

            else if (txtNumberPhone.Text.Length > 12)
                MessageBox.Show("Phone number cannot be more than 12 numbers !");

            else if (!isValidEmail(txtEmail.Text) && !VerifyEmail(txtEmail.Text))
                MessageBox.Show("Invalid Email!");

            else if (txtEmail.Text == "")
                MessageBox.Show("Email cannot be left blank");
            else
            {
                try
                {
                    DateTime.ParseExact(mkDateOfBirth.Text, "dd/MM/yyyy", null); // kiểm tra xem ngày đúng không 

                    // nếu ngày đã tồn tại thì kiểm tra xem nó có vượt quá ngày hiện tại hay không 
                    if (!QuaNgay(mkDateOfBirth.Text)) // ngày sinh vượt quá ngày hiện tại => false 
                        MessageBox.Show("Invalid Date !");

                    else
                    {
                        try
                        {
                            string SQL = ("update employees set role='" + txtRole.Text + "',username = '" + txtUserName.Text
                            + "',first_name=N'" + txtFirstname.Text + "',last_name=N'" + txtLastName.Text + "',address=N'" + txtAddress.Text + "',phone='"
                            + txtNumberPhone.Text + "',email='" + txtEmail.Text + "',date_of_birth='" + LuuNgay(mkDateOfBirth.Text) + "',updated_at='" + Date_Now()
                             + "'where id='" + id_employee + "'");
                            //MessageBox.Show(SQL);
                            cls.ThucThiSQLTheoKetNoi(SQL);
                            cls.LoadData2DataGridView(dataGridView1, "select*from employees");
                            MessageBox.Show("Edit successfully");
                        }
                        catch
                        {
                            MessageBox.Show("Error !");
                        }
                    }

                }
                catch
                {
                    MessageBox.Show("Invalid Date !");
                }

            }
        }


        // DELETE 
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(id_employee == 0)
                MessageBox.Show("Please select a data line !!!");
            else
            {
                if (txtRole.Text == "admin")
                    MessageBox.Show("Can't delete admin account");
                else
                {
                    if (MessageBox.Show("Are you sure to delete employee information " + username_employee.ToUpper() , "Delete Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string SQL = ("delete from employees where id='" + id_employee + "'");
                        cls.ThucThiSQLTheoKetNoi(SQL);
                        cls.LoadData2DataGridView(dataGridView1, "select*from employees");
                        MessageBox.Show("Delete successfully");
                        txtUserName.Text = "";
                        txtRole.Text = "";
                        txtFirstname.Text = "";
                        txtLastName.Text = "";
                        txtAddress.Text = "";
                        txtNumberPhone.Text = "";
                        txtEmail.Text = "";
                        mkDateOfBirth.Text = "";
                        txtCreatedAt.Text = "";
                        txtUpdatedAt.Text = "";
                    }
                }
            }
            
        }



        
        private void btnSearch2_Click(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from employees where username like '%" + txtSearch2.Text + "%' OR role like '%" + txtSearch2.Text + "%' OR first_name like '%" + txtSearch2.Text + "%' OR last_name like '%" + txtSearch2.Text + "%' OR address like '%" + txtSearch2.Text + "%' OR phone like'%" + txtSearch2.Text + "%' OR email like '%" + txtSearch2.Text + "%' OR date_of_birth like '%" + txtSearch2.Text + "%' OR created_at like '%" + txtSearch2.Text + "%' OR updated_at like '%" + txtSearch2.Text + "%'");
            Reset_Txt();
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            cls.LoadData2DataGridView(dataGridView1, "select * from employees where username like '%" + txtSearch2.Text + "%' OR role like '%" + txtSearch2.Text + "%' OR first_name like '%" + txtSearch2.Text + "%' OR last_name like '%" + txtSearch2.Text + "%' OR address like '%" + txtSearch2.Text + "%' OR phone like'%" + txtSearch2.Text + "%' OR email like '%" + txtSearch2.Text + "%' OR date_of_birth like '%" + txtSearch2.Text + "%' OR created_at like '%" + txtSearch2.Text + "%' OR updated_at like '%" + txtSearch2.Text + "%'");
            //Reset_Txt();
        }
        public void Reset_Txt()
        {
            txtUserName.Text = "";
            txtRole.Text = "";
            txtFirstname.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtNumberPhone.Text = "";
            txtEmail.Text = "";
            mkDateOfBirth.Text = "";
            txtCreatedAt.Text = "";
            txtUpdatedAt.Text = "";
        }
    }
}
