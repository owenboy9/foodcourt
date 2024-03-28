/*using MySql.Data.MySqlClient;
using Server;


public Class
string Login(User credentials, Dictionary<string, string> state)
{
    // Define hardcoded email and password values
    string hardcodedEmail = "manuel@nodehill.com";
    string hardcodedPassword = "password123";

    // Your database connection logic (retrieving MySqlConnection from state or elsewhere)

    // Query the database to check if the credentials exist
    string query = "SELECT COUNT(*) FROM users WHERE email = @email AND password = @password";
    MySqlCommand command = new MySqlCommand(query, yourDatabaseConnection);
    command.Parameters.AddWithValue("@email", credentials.Email);
    command.Parameters.AddWithValue("@password", credentials.Password);

    int count = (int)command.ExecuteScalar(); // Assuming the query returns a count

    if (count > 0 || (credentials.Email == hardcodedEmail && credentials.Password == hardcodedPassword))
    {
        state.Remove("signed-in");
        state.Add("signed-in", "true");
        return "Signed in\n";
    }
    else
    {
        state.Remove("signed-in");
        state.Add("signed-in", "false");
        return "Not signed in\n";
    }
}
*/