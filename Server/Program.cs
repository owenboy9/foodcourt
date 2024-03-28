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
    builder.Services.AddAuthentication().AddCookie("opa23.molez.foodcourt");
    var app = builder.Build();
    //app.MapPost("/login", Login);

    

    app.MapGet("/", Greet);
    app.MapGet("/users", Users.All);
    app.MapGet("/restaurants", Restaurants.All);
    app.MapGet("/foods", Foods.All);
    app.MapGet("/categories/{food_category}", Foods.Category);
    app.MapGet("/preferences/{alternative}", Foods.Preference);
    app.MapPost("/login", Auth.Login);

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