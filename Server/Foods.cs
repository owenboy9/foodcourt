using MySql.Data.MySqlClient;

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
}
