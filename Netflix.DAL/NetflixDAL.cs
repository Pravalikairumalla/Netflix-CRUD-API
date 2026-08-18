using Netflix.DTO;
using MySql.Data.MySqlClient;

namespace Netflix.DAL;

public class NetflixDAL
{
    private readonly DatabaseConnection databaseConnection;

    public NetflixDAL(DatabaseConnection connection)
    {
        databaseConnection = connection;
    }

    // GET
    public List<NetflixDTO> GetData()
    {
        List<NetflixDTO> netflix = new List<NetflixDTO>();

        using (MySqlConnection connection = databaseConnection.GetConnection())
        {
            connection.Open();

            string query = "SELECT * FROM netflix";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    NetflixDTO movie = new NetflixDTO
                    {
                        Show_Id = reader["show_id"].ToString() ?? "",
                        Type = reader["type"].ToString() ?? "",
                        Title = reader["title"].ToString() ?? "",
                        Director = reader["director"].ToString() ?? "",
                        Cast = reader["cast"].ToString() ?? "",
                        Country = reader["country"].ToString() ?? "",
                        Date_Added = DateOnly.Parse(reader["date_added"].ToString() ?? ""),
                        Release_Year = Convert.ToInt32(reader["release_year"]),
                        Rating = reader["rating"].ToString() ?? "",
                        Duration = reader["duration"].ToString() ?? "",
                        Listed_In = reader["listed_in"].ToString() ?? "",
                        Description = reader["description"].ToString() ?? ""
                    };

                    netflix.Add(movie);
                }
            }
        }

        return netflix;
    }

    // POST
    public void CreateData(NetflixDTO movie)
    {
        using (MySqlConnection connection = databaseConnection.GetConnection())
        {
            connection.Open();

            string query = @"INSERT INTO netflix
                (show_id, type, title, director, cast, country, date_added,
                 release_year, rating, duration, listed_in, description)
                VALUES
                (@show_id, @type, @title, @director, @cast, @country, @date_added,
                 @release_year, @rating, @duration, @listed_in, @description)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@show_id", movie.Show_Id);
                command.Parameters.AddWithValue("@type", movie.Type);
                command.Parameters.AddWithValue("@title", movie.Title);
                command.Parameters.AddWithValue("@director", movie.Director);
                command.Parameters.AddWithValue("@cast", movie.Cast);
                command.Parameters.AddWithValue("@country", movie.Country);
                command.Parameters.AddWithValue("@date_added", movie.Date_Added);
                command.Parameters.AddWithValue("@release_year", movie.Release_Year);
                command.Parameters.AddWithValue("@rating", movie.Rating);
                command.Parameters.AddWithValue("@duration", movie.Duration);
                command.Parameters.AddWithValue("@listed_in", movie.Listed_In);
                command.Parameters.AddWithValue("@description", movie.Description);

                command.ExecuteNonQuery();
            }
        }
    }

    // PUT
    public void UpdateData(NetflixDTO movie)
    {
        using (MySqlConnection connection = databaseConnection.GetConnection())
        {
            connection.Open();

            string query = "UPDATE netflix SET type = @Type WHERE show_id = @Show_Id";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Type", movie.Type);
                command.Parameters.AddWithValue("@Show_Id", movie.Show_Id);

                command.ExecuteNonQuery();
            }
        }
    }

    // DELETE
    public void DeleteData(NetflixDTO movie)
    {
        using (MySqlConnection connection = databaseConnection.GetConnection())
        {
            connection.Open();

            string query = "DELETE FROM netflix WHERE show_id = @Show_Id";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Show_Id", movie.Show_Id);

                command.ExecuteNonQuery();
            }
        }
    }
}