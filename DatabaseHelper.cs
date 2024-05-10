using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;

namespace EnrollmentSystem
{
    internal class DatabaseHelper
    {
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\johnk\source\repos\EnrollmentSystem\Dayola.accdb";
        public OleDbConnection dbConnection;
        public OleDbDataAdapter dbDataAdapter;
        public OleDbCommandBuilder dbCommandBuilder;
        public OleDbCommand dbCommand;
        public OleDbDataReader dbDataReader;
        public List<string[]> resultList = new List<string[]>();

        /// <summary>
        /// initializes connection to database
        /// </summary>
        /// <param name="query"></param>
        public void ConnectToDatabase(string query)
        {
            dbConnection = new OleDbConnection(connectionString);
            dbDataAdapter = new OleDbDataAdapter(query, dbConnection);
            dbCommandBuilder = new OleDbCommandBuilder(dbDataAdapter);
        }

        /// <summary>
        /// checks if specified data is already in the database
        /// </summary>
        /// <param name="value"></param>
        /// <param name="columnName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public bool CheckIfDataInDB(string value, string columnName, string query)
        {
            bool found = false;
            dbConnection.Open();
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            dbDataReader = dbCommand.ExecuteReader();
            while (dbDataReader.Read())
            {
                if (dbDataReader[columnName].ToString().Trim().ToUpper() == value.Trim().ToUpper())
                {
                    found = true;
                    break;
                }
            }
            dbConnection.Close();
            return found;
        }

        /// <summary>
        /// fetches data from the database based on the query and columns provided
        /// </summary>
        /// <param name="query"></param>
        /// <param name="columns"></param>
        public void FetchDataFromDB(string query, params string[] columns)
        {
            dbConnection.Open();
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            dbDataReader = dbCommand.ExecuteReader();
            while (dbDataReader.Read())
            {
                List<string> rowData = new List<string>();
                foreach (string column in columns)
                {
                    rowData.Add(dbDataReader[column].ToString());
                }
                resultList.Add(rowData.ToArray());
            }
            dbConnection.Close();
        }

        /// <summary>
        /// checks if specified data is already in the database and fetches data based on the additional columns provided
        /// </summary>
        /// <param name="value"></param>
        /// <param name="columnName"></param>
        /// <param name="query"></param>
        /// <param name="additionalColumns"></param>
        /// <returns></returns>
        public bool CheckAndFetchFromDB(string value, string columnName, string query, params string[] additionalColumns)
        {
            bool found = false;
            dbConnection.Open();
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            dbDataReader = dbCommand.ExecuteReader();
            while (dbDataReader.Read())
            {
                if (dbDataReader[columnName].ToString().Trim().ToUpper() == value.Trim().ToUpper())
                {
                    found = true;
                    List<string> rowData = new List<string>();
                    rowData.Add(dbDataReader[columnName].ToString());
                    foreach (string column in additionalColumns)
                    {
                        rowData.Add(dbDataReader[column].ToString());
                    }
                    resultList.Add(rowData.ToArray());
                }
            }
            dbConnection.Close();
            return found;
        }
    }
}
