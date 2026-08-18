namespace Netflix.DTO;

public class NetflixDTO
{
    public string Show_Id { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Director { get; set; } = string.Empty;

    public string Cast { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public DateOnly Date_Added { get; set; }

    public int Release_Year { get; set; }

    public string Rating { get; set; } = string.Empty;

    public string Duration { get; set; } = string.Empty;

    public string Listed_In { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}