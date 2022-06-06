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

namespace LibraryManagement
{
    public partial class UpdateInfor : Form
    {
        public UpdateInfor()
        {
            InitializeComponent();
        }
        Class.clsDatabase cls = new LibraryManagement.Class.clsDatabase();
        private void capnhatnhanvien_Load(object sender, EventArgs e)
        {
            //cls.LoadData2DataGridView(dataGridView1, "select first_name ,last_name, address , phone , email , date_of_birth , created_at , updated_at  from employees where username='" + Main.TenDN + "'");
            txtFirstName.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            txtLastName.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            txtPhone.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            if(dataGridView1.Rows[0].Cells[5].Value.ToString() != "")
            {
                mkDateOfBirth.Text = HienThiNgay(dataGridView1.Rows[0].Cells[5].Value.ToString());
            }
            txtCreatedAt.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            txtUpdatedAt.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
            if (txtCreatedAt.Text.Contains("PM") || txtCreatedAt.Text.Contains("AM"))
            {
                txtCreatedAt.Text = HienThiNgay(dataGridView1.Rows[0].Cells[6].Value.ToString());
                txtUpdatedAt.Text = HienThiNgay(dataGridView1.Rows[0].Cells[7].Value.ToString());
            }
            dataGridView1.Hide();
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

        //public static bool CheckNgay(string input)
        //{
            // kiểm tra đã nhập đủ hay chưa cách thủ công 
            //string[] arrListStr = input.Split('/');
            //string mm = arrListStr[0];
            //string dd = arrListStr[1];
            //string yyyy = arrListStr[2];
            //if (mm.Length != 2 || dd.Length != 2 || yyyy.Length != 4) return true;
            //else return false;
        //}

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
            // ngày nhập vào 
            input = LuuNgay(input);
            DateTime oDate = Convert.ToDateTime(input);
            // ngày hiện tại 
            DateTime dateTime = DateTime.UtcNow.Date;
            string date = dateTime.ToString("MM/dd/yyyy");
            //MessageBox.Show(oDate.ToString());
            //MessageBox.Show(dateTime.ToString());
            //MessageBox.Show(date);
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
            // lưu 
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
        private void button5_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length < 3)
                MessageBox.Show("Phone number cannot be less than 3 digits !");
            else
            {
                if (txtPhone.Text.Length > 12)
                    MessageBox.Show("Phone number cannot be more than 12 numbers !");
                else
                {
                    if (CheckTen(txtFirstName.Text))
                        MessageBox.Show("Names can only contain alphanumeric characters !");
                    else
                    {
                        if (!mkDateOfBirth.MaskFull)
                            MessageBox.Show("Invalid Date !");
                        else
                        {
                            if (CheckTen(txtLastName.Text))
                                MessageBox.Show("Names can only contain alphanumeric characters !");
                            else
                            {
                                if (Checkso(txtPhone.Text))
                                    MessageBox.Show("Invalid Phone Number!");
                                else
                                {
                                    if (!isValidEmail(txtEmail.Text) && !VerifyEmail(txtEmail.Text))
                                        MessageBox.Show("Invalid Email!");
                                    else
                                    {
                                        //MessageBox.Show(LuuNgay(mkDateOfBirth.Text));
                                        //DateTime dateTime = DateTime.UtcNow.Date;
                                        //string date = dateTime.ToString("yyyy / MM / dd");

                                        //DateTime aDateTime = DateTime.Now.Date;
                                        //MessageBox.Show(DateTime.Now.ToString());
                                        if (mkDateOfBirth.MaskFull && CheckText(txtAddress.Text) && CheckText(txtFirstName.Text) && CheckText(txtEmail.Text)) // kiểm tra đã nhập đu hay chưa 
                                        {
                                            try
                                            {
                                                DateTime.ParseExact(mkDateOfBirth.Text, "dd/MM/yyyy", null);
                                                
                                                // nếu ngày đã tồn tại thì kiểm tra xem nó có vượt quá ngày hiện tại hay không 
                                                if (!QuaNgay(mkDateOfBirth.Text))
                                                    MessageBox.Show("Invalid Date !"); // Ngày sinh vượt quá ngày hiện tại 
                                                else
                                                {
                                                    try
                                                    {
                                                        //string strUpdate = "update employees set first_name=N'" + txtFirstName.Text + "',last_name=N'" + txtLastName.Text + "',address=N'" + txtAddress.Text + "',phone='" + txtPhone.Text + "',email='" + txtEmail.Text + "',date_of_birth='" + LuuNgay(mkDateOfBirth.Text) + "',updated_at='" + Date_Now() + "' where username='" + Main.TenDN + "'";
                                                        //MessageBox.Show(strUpdate);
                                                        //cls.ThucThiSQLTheoKetNoi(strUpdate);
                                                        MessageBox.Show("Edit Successful");
                                                    }
                                                    catch
                                                    {
                                                        MessageBox.Show("Error !"); // ngoại lệ nào đó làm lệnh query không thực hiện được 
                                                        // nó sẽ báo Error thay vì bật ra khỏi chương trình 
                                                    }
                                                }
                                            }
                                            catch
                                            {
                                                MessageBox.Show("Invalid Date !");
                                                //MessageBox.Show("Ngày không tồn tại !");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Cannot be left blank !");
                                            //MessageBox.Show("Không được để trống !");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //cls.LoadData2DataGridView(dataGridView1, "select first_name ,last_name, address , phone , email , date_of_birth , created_at , updated_at  from employees where username='" + Main.TenDN + "'");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                txtFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                mkDateOfBirth.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtCreatedAt.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtUpdatedAt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() != "")
                {
                    mkDateOfBirth.Text = HienThiNgay(dataGridView1.Rows[0].Cells[5].Value.ToString());
                }
                if (txtCreatedAt.Text.Contains("PM") || txtCreatedAt.Text.Contains("AM"))
                {
                    txtCreatedAt.Text = HienThiNgay(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    txtUpdatedAt.Text = HienThiNgay(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string strDelete = "delete from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'";
            //cls.ThucThiSQLTheoPKN(strDelete);
            //cls.LoadData2DataGridView(dataGridView1, "select * from tblNhanVien where TAIKHOAN='" + Main.TenDN + "'");
            //MessageBox.Show("Xóa thành công");
        }

        private void btExitupdate_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
