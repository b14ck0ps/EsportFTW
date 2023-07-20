namespace EsportFTW_DAL.Model;

public class TournamentGame
{
    public int TournamentID { get; set; }
    public int GameID { get; set; }
    public ICollection<Game> Games { get; set; }
}