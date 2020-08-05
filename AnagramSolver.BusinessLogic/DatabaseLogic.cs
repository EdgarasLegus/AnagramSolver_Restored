using AnagramSolver.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AnagramSolver.BusinessLogic
{
    public class DatabaseLogic
    {
        private readonly string connectionString = "Server=LT-LIT-SC-0513;Database=AnagramSolver;" +
            "Integrated Security = true;Uid=auth_windows";

        public List<WordModel> SearchWords(string searchInput)
        {
            var wordModel = new List<WordModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(new SqlParameter($"SELECT * FROM AnagramSolver.dbo.Word WHERE Word like '%{searchInput}%'", connection));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        wordModel.Add(new WordModel
                        {
                            Word = reader["Word"].ToString()
                        });
                    }
                }

            }
            return wordModel;
        }
    }
}
