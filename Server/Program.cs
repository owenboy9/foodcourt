using Server;

using MySql.Data.MySqlClient;

MySqlConnection? db = null;

string connectionString = "server=localhost;uid=root;pwd=mypassword;database=seeSharp;port=3306";
var builder = WebApplication.CreateBuilder(args);


try
{
    db = new MySqlConnection(connectionString);
    db.Open();
    builder.Services.AddSingleton(new State(db));
    var app = builder.Build();
    //app.MapPost("/login", Login);

    

    app.MapGet("/", Greet);
    //app.MapGet("/users", AllUsers);

    app.Run();


}
catch (MySqlException e)
{
    Console.WriteLine(e);
}
finally
{
    db?.Close();
}


string AllUsers(State state)
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

string Login(User credentials, Dictionary<string, string> state)
{
    if (credentials.Email == "manuel@nodehill.com" && credentials.Password == "password123")
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


string Greet()
{
    return "welcome to out food court!";
}