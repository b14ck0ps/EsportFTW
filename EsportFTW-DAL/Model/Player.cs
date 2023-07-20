namespace EsportFTW_DAL.Model;

public class Player : User
{
    public DateTime JoinDate { get; set; }
    public decimal Salary { get; set; }
    public int PlayHours { get; set; }
    public DateTime DOB { get; set; }
    public PlayerAddress Address { get; set; }
    public PlayerSocialLink SocialLinks { get; set; }
    public List<PlayerPhone> PlayerPhones { get; set; }
    public List<PlayerWinning> PlayerWinnings { get; set; }
    public List<PlayerTeam> PlayerTeams { get; set; }

// Additional properties and methods specific to Player
}