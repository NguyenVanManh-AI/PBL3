using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagement.Class
{
    class clsDatabase
    {
        //Khai báo các chuỗi kết nối và các đối tượng
        string strConnect = @"Data Source=DESKTOP-QCOSLTK\VANMANH;Initial Catalog=System_Library;Integrated Security=True";
        SqlConnection sqlCon;
        SqlCommand sqlCom;
        SqlDataReader sqlRea;
        SqlDataAdapter sqlAdap;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable("DB");
        DataTable dt3 = new DataTable("DB");
        DataTable dt4 = new DataTable("DB");
        DataTable dt5 = new DataTable("DB");

        //Phương thức kết nối tới CSDL SQL Server
        public void KetNoi()
        {
            sqlCon = new SqlConnection(strConnect);
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        //Phương thức đóng kết nối tới CSDL
        private void NgatKetNoi()
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
        /// <param name="sql">Câu lệnh SQL: Insert, Update, Delete...</param>
        public void ThucThiSQLTheoKetNoi(string strSql)
        {
            KetNoi();
            //

            sqlCom = new SqlCommand(strSql, sqlCon);
            sqlCom.ExecuteNonQuery();
            //
            NgatKetNoi();
        }
        /// <param name="sql">Câu lệnh SQL: Insert, Update, Delete...</param>
        public void ThucThiSQLTheoPKN(string strSql)
        {
            ds.Clear();
            //Thực thi
            sqlAdap = new SqlDataAdapter(strSql, strConnect);
            sqlAdap.Fill(ds, "DB");
        }

        /// Phương thức Load dữ liệu lên Combobox
        /// <param name="cb">Tên của  Combobox</param>
        /// <param name="strSelect">Câu lệnh Select cần lấy dữ liệu cho Combobox</param>
        public void LoadData2Combobox(ComboBox cb, string strSelect)
        {
            //Kết nối
            cb.Items.Clear();
            KetNoi();
            //Thực thi
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            //Load dữ liệu vào Combobox
            while (sqlRea.Read())
            {
                cb.Items.Add(sqlRea[0].ToString());
            }
            //Đóng kết nối
            NgatKetNoi();
        }
        public void LoadData3Combobox(ComboBox cb, string strSelect)
        {
            //Kết nối
            cb.Items.Clear();
            KetNoi();
            //Thực thi
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            //Load dữ liệu vào Combobox
            while (sqlRea.Read())
            {
                cb.Items.Add(sqlRea[0].ToString());
            }
            //Đóng kết nối
            NgatKetNoi();
        }
        public void LoadData2Label(Label lb, string strSelect)
        {
            lb.Text = "";
            KetNoi();
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            while (sqlRea.Read())
            {
                lb.Text = sqlRea[0].ToString();
            }
            NgatKetNoi();
        }
        /// Phương thức Load dữ liệu lên DataGridView
        /// <param name="dg">Tên của DataGridView</param>
        /// <param name="strSelect">Câu lệnh Select cần lấy dữ liệu cho DataGridView</param>
        public void LoadData2DataGridView(DataGridView dg, string strSelect)
        {
            dt.Clear();
            //Fill vào DataTable
            sqlAdap = new SqlDataAdapter(strSelect, strConnect);
            sqlAdap.Fill(dt);
            dg.DataSource = dt;
        }
        public void LoadData1Datagirdview(DataGridView DG, string sql, string Bang)
        {

        }

        public void LoadData3DataGridView(DataGridView dg3, string strSelect3)
        {
            dt3.Clear();
            //Fill vào DataTable
            sqlAdap = new SqlDataAdapter(strSelect3, strConnect);
            sqlAdap.Fill(dt3);
            dg3.DataSource = dt3;
        }

        public void LoadData4DataGridView(DataGridView dg4, string strSelect4)
        {
            dt4.Clear();
            //Fill vào DataTable
            sqlAdap = new SqlDataAdapter(strSelect4, strConnect);
            sqlAdap.Fill(dt4);
            dg4.DataSource = dt4;
        }

        public void LoadData5DataGridView(DataGridView dg5, string strSelect5)
        {
            dt5.Clear();
            //Fill vào DataTable
            sqlAdap = new SqlDataAdapter(strSelect5, strConnect);
            sqlAdap.Fill(dt5);
            dg5.DataSource = dt5;
        }
    }
}
