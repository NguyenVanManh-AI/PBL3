using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class DataBase
    {
        private static string stringConnectSql = @"Data Source=DESKTOP-QCOSLTK\VANMANH;Initial Catalog=System_Library;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnectSql);
        }
        public DataTable LoadData(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlconnection = GetSqlConnection())
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlconnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(data);
                sqlconnection.Close();
            }
            return data;
        }
        public void EditData(string query)
        {
            using (SqlConnection sqlconnection = GetSqlConnection())
            {
                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlCommand.ExecuteNonQuery(); //thực thi câu truy vấn
                sqlconnection.Close();
            }
        }
        public Object GetValue(string query) //lay gia tri cua  cot dau tien trong bang 
        {
            Object obj;
            using (SqlConnection sqlconnection = GetSqlConnection())
            {
                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlconnection;
                obj = sqlCommand.ExecuteScalar();
                sqlconnection.Close();
            }
            return obj;
        }
    }
    
}
