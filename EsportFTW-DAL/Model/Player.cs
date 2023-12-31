namespace EsportFTW_DAL.Model;

public class Player : User
{
    public string Ign { get; set; }
    public DateTime JoinDate { get; set; }
    public decimal Salary { get; set; }
    public int PlayHours { get; set; }
    public DateTime DOB { get; set; }
    public PlayerAddress Address { get; set; }
    public PlayerSocialLink SocialLinks { get; set; }
    public List<PlayerPhone> PlayerPhones { get; set; }
    public List<PlayerWinning> PlayerWinnings { get; set; }
    public Team Team { get; set; }

    // Additional properties and methods specific to Player
}