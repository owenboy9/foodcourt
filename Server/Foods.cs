using MySql.Data.MySqlClient;
using static Server.Auth;

namespace Server;

public class Foods
{

    public static string All(State state)
    {
        string result = string.Empty;
        string query = "SELECT * FROM foods";
        MySqlCommand command = new(query, state.DB);

        using MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32("id");
            string name = reader.GetString("name");
            string category = reader.GetString("category");
            string description = reader.GetString("description");
            double price = reader.GetDouble("price");
            result += $"{name}: {category}\n{description}\n${price}\n\n";
        }
        return result;
    }

    public static string Category(string food_category, State state)
    {

        string result = string.Empty;
        string query = "SELECT name, category, price FROM foods WHERE category = @Category";
        MySqlCommand command = new(query, state.DB);
        command.Parameters.AddWithValue("@Category", food_category);


        using MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString("name");
            string category = reader.GetString("category");
            double price = reader.GetDouble("price");
            result += $"{name}\n Category: {category}\n${price}\n\n";
        }
        return result;
    }

    public static string Preference(string alternative, State state)
    {

        string result = string.Empty;
        string query = "SELECT name, preference, price FROM foods WHERE preference = @Preference";
        MySqlCommand command = new(query, state.DB);
        command.Parameters.AddWithValue("@Preference", alternative);


        using MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString("name");
            string preference = reader.GetString("preference");
            double price = reader.GetDouble("price");
            result += $"{name}\n dietary option: {preference}\n${price}\n\n";
        }
        return result;
    }
}

