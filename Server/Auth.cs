namespace Server;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using MySql.Data.MySqlClient;

public class Auth
{
    public record User(string Email, string Password);
    public static async Task<IResult> Login(User user, State state, HttpContext ctx)
    {
        // here you should query the database about the info sent from the client
        // and return early if its incorrect
        // return TypedResults.Problem("Wrong email or password")
        string result = string.Empty;
        string query = "SELECT id, role FROM users WHERE email = @Email AND password = @Password";
        MySqlCommand command = new(query, state.DB);

        command.Parameters.AddWithValue("@Email", user.Email);
        command.Parameters.AddWithValue("@Password", user.Password);

        using MySqlDataReader reader = command.ExecuteReader();
       

        while (reader.Read())
        {
            int id = reader.GetInt32("id");
            string role = reader.GetString("role");

            await ctx.SignInAsync("opa23.molez.foodcourt", new ClaimsPrincipal(
            new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                    new Claim(ClaimTypes.Role, role),
                },
                "opa23.molez.foodcourt"
            )
        ));
        }

        Console.WriteLine(result);


        return TypedResults.Ok("Signed in");
    }
}