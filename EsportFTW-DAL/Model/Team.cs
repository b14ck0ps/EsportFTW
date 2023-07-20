namespace EsportFTW_DAL.Model;

public class Team
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public DateTime EstablishedDate { get; set; }
    public string Country { get; set; }
    public decimal TotalPriceMoney { get; set; }
    public Manager Manager { get; set; }
    public List<TeamWinning> TeamWinnings { get; set; }
    public List<TeamGame> TeamGames { get; set; }

    // Additional properties and methods specific to Team
}