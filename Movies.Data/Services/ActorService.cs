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
    public class ActorService
    {
        public DataTable display(String conStr, DataTable table)
        {
            string query = "SELECT * FROM Actor";
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.Fill(table);
                sqlCon.Close();
            }
            return table;
        }

        public Actor Create(string conStr, Actor actor)
        {
            string query = "INSERT INTO Actor (ActorName, [Actor DOB]) " +
                "VALUES(@ActorName, @ActorDOB)";
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ActorName", actor.ActorName);
                sqlCmd.Parameters.AddWithValue("@ActorDOB", actor.ActorDOB);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            return actor;
        }

        public Actor Edit(string conStr, int id, Actor actor)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Actor WHERE ActorID = @ActorID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ActorID", id);
                sqlDa.Fill(dataTable);

                actor.ActorID = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                actor.ActorName = dataTable.Rows[0][1].ToString();
                actor.ActorDOB = Convert.ToDateTime(dataTable.Rows[0][2].ToString());
                sqlCon.Close();

            }
            return actor;
        }
        public void Edit(string conStr, Actor actor)
        {
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                string query = "UPDATE Actor SET ActorName = @ActorName, [Actor DOB] = @ActorDOB WHERE ActorID = @ActorID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                sqlCmd.Parameters.AddWithValue("@ActorID", actor.ActorID);
                sqlCmd.Parameters.AddWithValue("@ActorName", actor.ActorName);
                sqlCmd.Parameters.AddWithValue("@ActorDOB", actor.ActorDOB);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public void Delete(string conStr, int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(conStr))
            {
                sqlCon.Open();
                string query = "DELETE FROM Actor WHERE ActorID = @ActorID";
                SqlCommand sqlCmd1 = new SqlCommand(query, sqlCon);
                sqlCmd1.Parameters.AddWithValue("@ActorID", id);
                sqlCmd1.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public ActorService()
        {
        }
    }
}
