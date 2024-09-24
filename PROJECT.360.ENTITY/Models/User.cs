
using Newtonsoft.Json;
using PROJECT._360.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.ENTITY.Models
{
    public class User :IEntity
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password{ get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
