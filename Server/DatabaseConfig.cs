using MySql.Data.MySqlClient;

namespace Server;

public static class DatabaseConfig
{
    public const string ConnectionString = "server=localhost;uid=root;pwd=mypassword;database=seeSharp;port=3306";
}


public static class DatabaseConnection
{
    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(DatabaseConfig.ConnectionString);
    }
}
