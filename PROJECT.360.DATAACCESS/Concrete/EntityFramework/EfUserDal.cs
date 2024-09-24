using PROJECT._360.CORE.DataAccess.EntityFramework;
using PROJECT._360.DATAACCESS.Abstract;
using PROJECT._360.DATAACCESS.Context;
using PROJECT._360.ENTITY.Dtos;
using PROJECT._360.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.DATAACCESS.Concrete.EntityFramework
{
    public class EfUserDal : EfGenericRepositoryBase<User, Project360Context>, IUserDal
    {
        public List<UsernameDto> GetAllUsers()
        {
            using (var context = new Project360Context())
            {
                var result = (from user in context.Users
                              select new UsernameDto
                              {
                                  Id = user.Id,
                                  Name = user.Name,
                                  Surname = user.Surname,
                                  Password = user.Password,
                                  BirthDate = user.BirthDate,
                                  Email = user.Email,
                                  Gender = user.Gender,
                                  Phone = user.Phone,
                                  UserName = user.UserName
                              }).ToList();

                return result;
            }
        }
        public bool CheckUserName(string userName)
        {
            using (var context = new Project360Context())
            {
                var result = from user in context.Users
                             where user.UserName == userName
                             select new
                             {
                                 user.UserName
                             };
                return result.Any();
            }
        }
    }
}
