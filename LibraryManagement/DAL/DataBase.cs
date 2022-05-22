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
        //public void CommandMovie(Movie movie, string query)
        //{
        //    using (SqlConnection sqlconnection = GetSqlConnection())
        //    {
        //        sqlconnection.Open();
        //        SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
        //        sqlCommand.Parameters.AddWithValue("@movie_name", movie.Name);
        //        sqlCommand.Parameters.AddWithValue("@movie_id", movie.ID);
        //        sqlCommand.Parameters.AddWithValue("@movie_genres", movie.Genres);
               
        //        //, , @movie_release, @movie_image
        //        sqlCommand.Parameters.AddWithValue("@movie_description", movie.Description);
        //        sqlCommand.Parameters.AddWithValue("@movie_length", movie.Length);
        //        sqlCommand.Parameters.AddWithValue("@movie_release", movie.Release);
        //        sqlCommand.Parameters.AddWithValue("@movie_image", movie.Image);
        //        sqlCommand.ExecuteNonQuery(); //thực thi câu truy vấn
        //        sqlconnection.Close();

        //    }
        //}
    }
    
}
