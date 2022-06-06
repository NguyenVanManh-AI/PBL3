using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient; // + 


namespace LibraryManagement
{
    public partial class Borrows : Form
    {
        public Borrows()
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

        Class.clsDatabase cls = new LibraryManagement.Class.clsDatabase();

        string id = "", first_name = "", last_name = "";

        private void Borrows_Load(object sender, EventArgs e)
        {
            // + 
            try
            {
                Con = new SqlConnection();
                Con.ConnectionString = @"Server =DESKTOP-QCOSLTK\VANMANH;" + "database=System_Library ; Integrated Security = true";
                Con.Open();
            }
            catch { }
            // +
            //object Q = layGiaTri("SELECT id FROM employees WHERE username = '" + Main.TenDN + "'");
            //id = Convert.ToString(Q);
            //Q = layGiaTri("SELECT first_name FROM employees WHERE username = '" + Main.TenDN + "'");
            //first_name = Convert.ToString(Q);
            //Q = layGiaTri("SELECT last_name FROM employees WHERE username = '" + Main.TenDN + "'");
            //last_name = Convert.ToString(Q);

            txtCreatorId.Text = id;
            txtCreatorName.Text = last_name + " " + first_name;
            
            cls.LoadData2DataGridView(dataGridView1, "select *  from borrows");
            cls.LoadData3DataGridView(dataGridView2, "select *  from readers");
            dataGridView2.Hide();
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()
            //    + "/" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "/"
            //    + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "/" + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()
            //    + "/" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "/" + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()
            //    + "/" + dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() + "/" + dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());

            // nếu click vào 'Column12' (Click Here) thì mới hiện form ra 
            if (e.ColumnIndex == dataGridView1.Columns["Column12"].Index && e.RowIndex >= 0)
            {
                BorrowDetails borrowDetails = new BorrowDetails(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                borrowDetails.Show();
            }

            txtBorrowId.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCreatorId.Text = id;
            txtCreatorName.Text = last_name + " " + first_name;
            txtReaderId.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtReaderName.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtCreatedAt.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtUpdatedAt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

            
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtReaderId.Text == "")
                MessageBox.Show("Please select reader !!!");
            else
            {
                try
                {
                    string strInsert = "Insert Into borrows(creator_id,creator_name,reader_id,reader_name,created_at,updated_at) values ('" + id + "',N'" + last_name + " " + first_name
                    + "','" + txtReaderId.Text + "',N'" + txtReaderName.Text + "','" + Date_Now() + "','" + Date_Now() + "')";
                    //MessageBox.Show(strInsert);
                    cls.ThucThiSQLTheoPKN(strInsert);
                    MessageBox.Show("Added Success !!!");
                    ReSet_txt();
                }
                catch
                {
                    MessageBox.Show("Error !!!");
                }

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBorrowId.Text == "")
                MessageBox.Show("Please select borrow !!!");
            else
            {
                try
                {
                    string strInsert = ("update borrows set reader_id=N'" + txtReaderId.Text + "',reader_name = N'" + txtReaderName.Text + "',updated_at='" + Date_Now()
                             + "'where id='" + txtBorrowId.Text + "'");
                    cls.ThucThiSQLTheoPKN(strInsert);
                    MessageBox.Show("Edit Success !!!");
                    ReSet_txt();
                }
                catch
                {
                    MessageBox.Show("Error !!!");
                }

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtReaderId.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtReaderName.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString() + " " + dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Borrows")
            {
                dataGridView2.Hide();
                dataGridView1.Show();
            }
            else
            {
                dataGridView1.Hide();
                dataGridView2.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to delete borrow information " + txtBorrowId.Text.ToUpper(), "Delete Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    string SQL = ("delete from borrows where id='" + txtBorrowId.Text + "'");
                    cls.ThucThiSQLTheoKetNoi(SQL);
                    MessageBox.Show("Delete successfully");
                    ReSet_txt();
                }
            }
            catch
            {
                MessageBox.Show("Error !!!");
            }
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Borrows")
            {
                dataGridView2.Hide();
                dataGridView1.Show();
                cls.LoadData3DataGridView(dataGridView1, "select * from borrows where creator_name like N'%" + txtSearch2.Text + "%' or reader_name like N'%" + txtSearch2.Text + "%'");
            }
            else
            {
                dataGridView1.Hide();
                dataGridView2.Show();
                cls.LoadData3DataGridView(dataGridView2, "select * from readers where first_name like N'%" + txtSearch2.Text + "%' or last_name like N'%" + txtSearch2.Text + "%' or email like '%" + txtSearch2.Text + "%' or phone like '%" + txtSearch2.Text + "%' or identity_card_number like '%" + txtSearch2.Text + "%' or address like N'%" + txtSearch2.Text + "%'");
            }

        }
        public void ReSet_txt()
        {
            txtCreatedAt.Text = "";
            txtUpdatedAt.Text = "";
            txtReaderName.Text = "";
            txtReaderId.Text = "";
            txtBorrowId.Text = "";
            comboBox1.Text = "Borrows";
            dataGridView2.Hide();
            dataGridView1.Show();
            cls.LoadData2DataGridView(dataGridView1, "select *  from borrows");
        }
    }
}
