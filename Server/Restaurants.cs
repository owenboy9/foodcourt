using MySql.Data.MySqlClient;

namespace Server;

public class Restaurants
{

    public static string All(State state)
    {
        string result = string.Empty;
        string query = "SELECT * FROM restaurants";
        MySqlCommand command = new(query, state.DB);

        using MySqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32("id");
            string name = reader.GetString("name");
            result += $"{name} has the id: {id}\n";
        }
        return result;
    }

}
