using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Data.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Movies.Data.Services
{
    public class GenreService
    {
        public DataTable display(String conStr, DataTable table)
        {
            string query = "SELECT * FROM Genre";
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.Fill(table);
                sqlCon.Close();
            }
            return table;
        }

        public Genre Create(string conStr, Genre genre)
        {
            string query = "INSERT INTO Genre (GenreName)" +
                            "VALUES(@GenreName)";
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@GenreName", genre.GenreName);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            return genre;
        }

        public Genre Edit(string conStr, int id, Genre genre)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Genre WHERE GenreID = @GenreID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@GenreID", id);
                sqlDa.Fill(dataTable);

                genre.GenreID = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                genre.GenreName = dataTable.Rows[0][1].ToString();
                sqlCon.Close();

            }
            return genre;
        }
        public void Edit(string conStr, Genre genre)
        {
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                string query = "UPDATE Genre SET GenreName = @GenreName WHERE GenreID = @GenreID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@GenreID", genre.GenreID);
                sqlCmd.Parameters.AddWithValue("@GenreName", genre.GenreName);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void Delete(string conStr, int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                string query = "DELETE FROM Genre WHERE GenreID = @GenreID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@GenreID", id);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public GenreService()
        {
        }
    }
}
