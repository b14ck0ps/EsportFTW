namespace EsportFTW_DAL.Model;

public class Tournament
{
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime EndingDate { get; set; }
    public string Location { get; set; }
    public decimal PrizePool { get; set; }
    public Organization Organization { get; set; }
    public List<TournamentGame> TournamentGames { get; set; }

// Additional properties and methods specific to Tournament
}