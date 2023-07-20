namespace EsportFTW_DAL.Model;

public class Manager : User
{
    public DateTime HireDate { get; set; }
    public Admin Admin { get; set; }
    public List<ManagerPhone> ManagerPhones { get; set; }
    public Finance Finance { get; set; }
    public Team Team { get; set; }

// Additional properties and methods specific to Manager
}