using AnagramSolver.Contracts;
using AnagramSolver.Interfaces;
using Renci.SshNet.Messages.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AnagramSolver.BusinessLogic
{
    public class DatabaseLogic : IDatabaseLogic
    {
        private readonly string connectionString = "Server=LT-LIT-SC-0513;Database=AnagramSolver;" +
            "Integrated Security = true;Uid=auth_windows";

        public List<WordModel> SearchWords(string searchInput)
        {
            var wordModel = new List<WordModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM AnagramSolver.dbo.Word WHERE Word LIKE @searchInput", connection);
                cmd.Parameters.Add(new SqlParameter("@searchInput", "%" + searchInput + "%"));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            wordModel.Add(new WordModel
                            {
                                Word = reader["Word"].ToString(),
                                Category = reader["Category"].ToString()
                            });
                        }
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return wordModel;
        }
    }
}
