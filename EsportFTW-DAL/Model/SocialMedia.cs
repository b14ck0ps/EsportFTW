namespace EsportFTW_DAL.Model;

public class SocialMedia : Manager
{
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public List<ContentCreator> ContentCreators { get; set; }
    public List<SocialMediaPhone> SocialMediaPhones { get; set; }

// Additional properties and methods specific to SocialMedia
}