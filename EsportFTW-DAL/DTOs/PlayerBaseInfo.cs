using EsportFTW_DAL.Model;

namespace EsportFTW_DAL.DTOs;

public class PlayerBaseInfo : User
{
    public DateTime JoinDate { get; set; }
    public decimal Salary { get; set; }
    public int PlayHours { get; set; }
    public DateTime DOB { get; set; }
}