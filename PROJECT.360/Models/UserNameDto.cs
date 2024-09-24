using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT._360.Models
{
    public class UserNameDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string TelNr1 { get; set; }
    }
}