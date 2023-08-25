using System.ComponentModel.DataAnnotations;

namespace EsportFTW_DAL.DTOs
{
    public class LoginDto
    {
        [Required][EmailAddress] public string Email { get; set; }
        [Required] public string Password { get; set; }
    }

}
