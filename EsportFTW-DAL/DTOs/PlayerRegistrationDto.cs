using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportFTW_DAL.DTOs
{
    public class PlayerRegistrationDto
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? IGN { get; set; }
        public DateTime? DOB { get; set; }
        public string? Password { get; set; }
        public string? SelectedCountry { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
        public string? Phone { get; set; }
        public string? Picture { get; set; } = "default.png";
        public DateTime? JoinDate { get; set; } = DateTime.Now;
        public decimal Salary { get; set; } = 0;
        public int PlayHours { get; set; } = 0;
    }
}
