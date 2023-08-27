namespace EsportFTW_DAL.DTOs;

public class ManagerBase
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int AdminId { get; set; }
}