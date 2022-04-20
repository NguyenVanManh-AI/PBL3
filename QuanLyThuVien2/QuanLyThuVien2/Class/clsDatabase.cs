﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien2.Class
{
    class clsDatabase
    {
        //Khai báo các chuỗi kết nối và các đối tượng
<<<<<<< HEAD
<<<<<<< HEAD
        string strConnect = @"Data Source=DESKTOP-QCOSLTK\VANMANH;Initial Catalog=Library2;Integrated Security=True";
=======
        public string strConnect = @"Data Source=21AK22-COM\QUOC;Initial Catalog=Library;Integrated Security=True";
>>>>>>> 15d612f1ceaf65821eedefa0f7945c906334bdd2
=======
        string strConnect = @"Data Source=DESKTOP-QCOSLTK\VANMANH;Initial Catalog=Library2;Integrated Security=True";
>>>>>>> main
        SqlConnection sqlCon;
        SqlCommand sqlCom;
        SqlDataReader sqlRea;
        SqlDataAdapter sqlAdap;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable("DB");
        DataTable dt3 = new DataTable("DB");

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
    }
}
