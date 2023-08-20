using System;
using System.ComponentModel.DataAnnotations;

namespace EsportFTW_DAL.DTOs
{
    public class PlayerRegistrationDto
    {
        [Required][EmailAddress] public string Email { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string IGN { get; set; }
        [Required] public DateTime DOB { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string SelectedCountry { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Street { get; set; }
        [Required] public string ZipCode { get; set; }
        [Required] public string Phone { get; set; }
        [Required] public string Picture { get; set; } = "default.png";
        [Required] public DateTime JoinDate { get; set; } = DateTime.Now;
        [Required] public decimal Salary { get; set; } = 0;
        [Required] public int PlayHours { get; set; } = 0;
    }
}
