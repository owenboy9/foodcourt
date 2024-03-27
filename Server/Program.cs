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
    app.MapGet("/users", Users.All);

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


string Greet()
{
    return "welcome to out food court!";
}