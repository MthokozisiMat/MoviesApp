using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.Data.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;

namespace Movies.Data.Services
{
    public class CharacterService
    {
        public DataTable display(String conStr, DataTable table)
        {
            string query = "SELECT c.MovieID, c.ActorID, c.CharacterName, m.MovieName, a.ActorName FROM Character c JOIN Movie m ON m.MovieID = c.MovieID JOIN Actor a ON a.ActorID = c.ActorID\r\n";
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.Fill(table);
                sqlCon.Close();
            }
            return table;
        }

        public Character Create(string conStr, Character character)
        {
            string query = "INSERT INTO Character (MovieID, ActorID, CharacterName) " +
                "VALUES(@MovieID, @ActorID, @CharacterName)";
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@MovieID", character.MovieID);
                sqlCmd.Parameters.AddWithValue("@ActorID", character.ActorID);
                sqlCmd.Parameters.AddWithValue("@CharacterName", character.CharacterName);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            return character;
        }

        public Character Edit(string conStr, int MovieID, int ActorID, string CharacterName, Character character)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Character " +
                                "WHERE MovieID = @MovieID AND ActorID = @ActorID AND CharacterName = @CharacterName";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@MovieID", MovieID);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ActorID", ActorID);
                sqlDa.SelectCommand.Parameters.AddWithValue("@CharacterName", CharacterName);
                sqlDa.Fill(dataTable);

                character.ActorID = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                character.MovieID = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                character.CharacterName = dataTable.Rows[0][1].ToString();
                sqlCon.Close();

            }
            return character;
        }
        public void Edit(string conStr, Character character)
        {
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                string query = "UPDATE Character SET ActorID = @ActorID " +
                               "WHERE MovieID = @MovieID AND CharacterName = @CharacterName";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@MovieID", character.MovieID);
                sqlCmd.Parameters.AddWithValue("@ActorID", character.ActorID);
                sqlCmd.Parameters.AddWithValue("@CharacterName", character.CharacterName);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void Delete(string conStr, int MovieID, int ActorID, string CharacterName)
        {
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                string query = "DELETE FROM Character " +
                                "WHERE MovieID = @MovieID AND ActorID = @ActorID AND CharacterName = @CharacterName";
                SqlCommand sqlCmd1 = new SqlCommand(query, sqlCon);
                sqlCmd1.Parameters.AddWithValue("@MovieID", MovieID);
                sqlCmd1.Parameters.AddWithValue("@ActorID", ActorID);
                sqlCmd1.Parameters.AddWithValue("@CharacterName", CharacterName);
                sqlCmd1.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public CharacterService()
        {
        }
    }
}
