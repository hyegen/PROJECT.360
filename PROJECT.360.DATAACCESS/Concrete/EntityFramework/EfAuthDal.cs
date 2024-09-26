using PROJECT._360.CORE.DataAccess.EntityFramework;
using PROJECT._360.DATAACCESS.Abstract;
using PROJECT._360.DATAACCESS.Context;
using PROJECT._360.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.DATAACCESS.Concrete.EntityFramework
{
    public class EfAuthDal : EfGenericRepositoryBase<User, Project360Context>, IAuthDal
    {
        public bool LoginByUsernameAndPassword(string email, string password)
        {
            using (var context = new Project360Context())
            {
                var result =
                    from i in context.Users
                    where i.Email == email && i.Password == password
                    select i;

                return result.Any();
            }
        }
    }
}
