using System;
using System.Collections.Generic;
using System.Data;
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
        public List<string> resultList = new List<string>();
        public List<string[]> resultListArray = new List<string[]>();

        /// <summary>
        /// initializes connection to database
        /// </summary>
        /// <param name="query"></param>The query to execute
        public void ConnectToDatabase(string query)
        {
            dbConnection = new OleDbConnection(connectionString);
            dbDataAdapter = new OleDbDataAdapter(query, dbConnection);
            dbCommandBuilder = new OleDbCommandBuilder(dbDataAdapter);
        }

        /// <summary>
        /// updates a specific cell in a specified table
        /// </summary>
        /// <param name="tableName">The name of the table to update.</param>
        /// <param name="columnName">The name of the column to update.</param>
        /// <param name="value">The new value to set.</param>
        /// <param name="identifierColumn">The column used to identify the row.</param>
        /// <param name="identifierValue">The value of the identifier column for the row to update.</param>
        public void UpdateCell(string tableName, string columnName, object value, string identifierColumn, object identifierValue)
        {
            using (OleDbCommand updateCommand = dbConnection.CreateCommand())
            {
                try
                {
                    dbConnection.Open(); 
                    updateCommand.CommandText = "UPDATE " + tableName + " SET " + columnName + " = @Value WHERE " + identifierColumn + " = @IdentifierValue";
                    updateCommand.Parameters.AddWithValue("@Value", value);
                    updateCommand.Parameters.AddWithValue("@IdentifierValue", identifierValue);
                    updateCommand.ExecuteNonQuery();
                }
                finally
                {
                    if (dbConnection.State == ConnectionState.Open)
                    {
                        dbConnection.Close();  
                    }
                }
            }
        }

        /// <summary>
        /// checks if specified data is already in the database
        /// </summary>
        /// <param name="value">The data to search for in the specified column.</param>
        /// <param name="columnName">The name of the column to search.</param>
        /// <param name="query">The query to execute.</param>
        /// <returns>True if the data is found, otherwise false.</returns>
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
        /// fetches a row from the database based on the query and columns provided
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="columns">The columns to fetch from the database.</param>
        public void FetchRowDataFromDB(string query, params string[] columns)
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
                resultList = rowData;
            }
            dbConnection.Close();
        }

        /// <summary>
        /// fetches data from the database based on the columns provided
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <param name="columns">The columns to fetch from the database.</param>
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
                resultListArray.Add(rowData.ToArray());
            }
            dbConnection.Close();
        }

        /// <summary>
        /// checks if specified data is already in the database and fetches a row based on the columns provided
        /// </summary>
        /// <param name="value">The data to search for in the specified column.</param>
        /// <param name="columnName">The name of the column to search.</param>
        /// <param name="query">The query to execute.</param>
        /// <param name="additionalColumns">Additional columns to fetch if the data is found.</param>
        /// <returns>True if the data is found, otherwise false.</returns>
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
                    resultList = rowData;
                }
            }
            dbConnection.Close();
            return found;
        }

        /// <summary>
        /// checks if two data are found in the database, mainly if there are two primary keys
        /// </summary>
        /// <param name="value1">The first data to search for in the first specified column.</param>
        /// <param name="value2">The second data to search for in the second specified column.</param>
        /// <param name="columnName1">The name of the first column to search.</param>
        /// <param name="columnName2">The name of the second column to search.</param>
        /// <param name="query">The query to execute.</param>
        /// <returns>True if both data are found, otherwise false.</returns>
        public bool CheckIfDataInDBTwoKeys(string value1, string value2, string columnName1, string columnName2, string query)
        {
            bool found = false;
            dbConnection.Open();
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            dbDataReader = dbCommand.ExecuteReader();
            while (dbDataReader.Read())
            {
                if (dbDataReader[columnName1].ToString().Trim().ToUpper() == value1.Trim().ToUpper() &&
                    dbDataReader[columnName2].ToString().Trim().ToUpper() == value2.Trim().ToUpper())
                {
                    found = true;
                    break;
                }
            }
            dbConnection.Close();
            return found;
        }
    }
}
