﻿using System;
using System.Collections.Generic;
using System.Text;
//using System.Data.Common.DBConnection;
using System.Data.SqlClient;
using System.Data;
using AnagramSolver.Interfaces;
using System.Linq;
using MySql.Data.MySqlClient;

namespace AnagramSolver.Repos
{
    public class DBRepository : IDBRepository
    {
        private readonly IWordRepository repository;
        private readonly string connectionString = "Server=LT-LIT-SC-0513;Database=AnagramSolver;" +
            "Integrated Security = true;Uid=auth_windows";

        public DBRepository()
        {
            repository = new FRepository();
        }

        public void FillDatabaseFromFile(Contracts.WordModel wordModel)
        {
            var insertQuery = "INSERT INTO Word (Word, Category)" +
                "VALUES(@Word, @Category)";
            //var connectionString = "Server=LT-LIT-SC-0513;Database=AnagramSolver;Integrated Security = true;Uid=auth_windows";

            var fileColumns = repository.GetWords().ToList(); 

            using (SqlConnection connection = new SqlConnection(connectionString))
                using(SqlCommand cmd = new SqlCommand(insertQuery, connection))
            {
                cmd.Parameters.Add(new SqlParameter("@Word", wordModel.Word));
                cmd.Parameters.Add(new SqlParameter("@Category", wordModel.Category));

                connection.Open();

                foreach(var item in fileColumns)
                {
                    cmd.Parameters[0].Value = item.Key;
                    cmd.Parameters[1].Value = item.Value;

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public bool checkIfTableIsEmpty()
        {
                
            var commandText = "SELECT COUNT(*) from AnagramSolver.dbo.Word";
            using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(commandText, connection))
            {
                connection.Open();
                int result = int.Parse(cmd.ExecuteScalar().ToString());
                connection.Close();
                return result == 0; // if result equals zero, then the table is empty
            }
        }
    }
}