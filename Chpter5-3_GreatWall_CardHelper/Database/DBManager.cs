using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GreatWall.Database
{
    public class DBManager
    {
        MySqlConnection connection;
        private readonly string connectionString;
        public DBManager(string ip, int port, string databases, string userID, string userPassword)
        {
            connectionString = $"Server={ip};Port={port};Database={databases};Uid={userID};Pwd={userPassword}";

        }

        /*        string insertQuery = "INSERT INTO reserve (name, month, day, rentday, phone, pwd,total, per) " +
                      $"VALUES('{choiceRoom}', {chkMonth}, {choiceDay}, {rentDays},'{phoneNumber}','{password}',{totalPrice},{totalNumber})";
        */

        public bool ExecuteNonQuery(string query)
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public DataTable ExecuteQuery(string query)
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
            
        }
    }
}