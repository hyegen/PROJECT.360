using PROJECT._360.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.ENTITY.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        //public List<UserRole> UserRoles { get; set; } = null;
        public List<UserRoleDto> UserRoles { get; set; } = null;
    }
}
