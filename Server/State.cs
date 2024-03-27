using MySql.Data.MySqlClient;

namespace Server;

public record State(MySqlConnection DB);