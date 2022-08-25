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
    public class MovieService
    {
        public DataTable displayMovies(String conStr, DataTable table)
        {
            string query = "SELECT * FROM Movie";
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.Fill(table);
                sqlCon.Close();
            }
            return table;
        }

        public Movie Create(string conStr, Movie movie)
        {
            string query = "INSERT INTO Movie (MovieName, ReleaseYear, Genre) " +
                "VALUES(@MovieName, @ReleaseYear, @Genre)";
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MovieName", movie.MovieName);
                sqlCmd.Parameters.AddWithValue("@ReleaseYear", movie.ReleaseYear);
                sqlCmd.Parameters.AddWithValue("@Genre", movie.Genre);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            return movie;
        }

        public Movie Edit(string conStr, int id, Movie movie)
        {
            DataTable dtblMovie = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Movie WHERE MovieID = @MovieID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@MovieID", id);
                sqlDa.Fill(dtblMovie);

                movie.MovieID = Convert.ToInt32(dtblMovie.Rows[0][0].ToString());
                movie.MovieName = dtblMovie.Rows[0][1].ToString();
                movie.ReleaseYear = Convert.ToInt32(dtblMovie.Rows[0][2].ToString());
                movie.Genre = Convert.ToInt32(dtblMovie.Rows[0][3].ToString());
                sqlCon.Close();

            }
            return movie;
        }
        public void Edit(string conStr,Movie movie)
        {
                using (SqlConnection sqlCon = new SqlConnection(conStr))
                {
                    sqlCon.Open();
                    string query = "UPDATE Movie SET MovieName = @MovieName, ReleaseYear = @ReleaseYear, Genre = @Genre WHERE MovieID = @MovieID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    sqlCmd.Parameters.AddWithValue("@MovieID", movie.MovieID);
                    sqlCmd.Parameters.AddWithValue("@MovieName", movie.MovieName);
                    sqlCmd.Parameters.AddWithValue("@ReleaseYear", movie.ReleaseYear);
                    sqlCmd.Parameters.AddWithValue("@Genre", movie.Genre);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
        }
        public void Delete(string conStr, int id)
        {
                using (SqlConnection sqlCon = new SqlConnection(conStr))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Movie WHERE MovieID = @MovieID";
                    SqlCommand sqlCmd1 = new SqlCommand(query, sqlCon);
                    sqlCmd1.Parameters.AddWithValue("@MovieID", id);
                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
        }
        public MovieService()
        {
        }
    }
}
