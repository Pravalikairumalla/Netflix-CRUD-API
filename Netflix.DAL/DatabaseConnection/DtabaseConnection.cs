using MySql.Data.MySqlClient;

namespace Netflix.DAL;

public class DatabaseConnection
{
    private readonly string connectionString =
        "Server=localhost;Database=netflix;User=root;Password=YOUR_PASSWORD;";

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}