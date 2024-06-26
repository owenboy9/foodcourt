﻿using MySql.Data.MySqlClient;

namespace Server;

public class Users
{

    public static string All(State state)
    {
        string result = string.Empty;
        string query = "SELECT * FROM users";
        MySqlCommand command = new(query, state.DB);

        using MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32("id");
            string username = reader.GetString("username");
            result += $"{username} has the id: {id}\n";
        }
        return result;
    }
}
