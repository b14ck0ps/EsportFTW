namespace EsportFTW_DAL.Model;

public class Organization
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Picture { get; set; }
    public string Phone { get; set; }
    public Finance Finance { get; set; }
    public List<OrganizationPhone> OrganizationPhones { get; set; }
    public List<OrganizationTournament> OrganizationTournaments { get; set; }
    public List<OrganizationCompany> OrganizationCompanies { get; set; }

// Additional properties and methods specific to Organization
}