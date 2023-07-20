namespace EsportFTW_DAL.Model;

public class ContentCreator : SocialMedia
{
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public ContentCreatorSocialMedia SocialMediaLinks { get; set; }
    public ContentCreatorAddress Address { get; set; }
    public List<ContentCreatorPhone> ContentCreatorPhones { get; set; }

// Additional properties and methods specific to ContentCreator
}