
using PROJECT._360.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.ENTITY.Models.Base
{
    public class BaseEntity : IEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
