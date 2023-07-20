namespace EsportFTW_DAL.Model;

public class Company
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Picture { get; set; }
    public string Phone { get; set; }
    public string Location { get; set; }
    public List<CompanyPhone> CompanyPhones { get; set; }

// Additional properties and methods specific to Company
}