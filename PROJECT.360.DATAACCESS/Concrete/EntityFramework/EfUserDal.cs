using PROJECT._360.CORE.DataAccess.EntityFramework;
using PROJECT._360.DATAACCESS.Abstract;
using PROJECT._360.DATAACCESS.Context;
using PROJECT._360.ENTITY.Dtos;
using PROJECT._360.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.DATAACCESS.Concrete.EntityFramework
{
    public class EfUserDal : EfGenericRepositoryBase<User, Project360Context>, IUserDal
    {
        public List<UserDto> GetAllUsers()
        {
            using (var context = new Project360Context())
            {
                var result = (from user in context.Users
                              select new UserDto
                              {
                                  Id = user.Id,
                                  Name = user.Name,
                                  Surname = user.Surname,
                                  Password = user.Password,
                                  BirthDate = user.BirthDate.ToString(),
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
        public UserDto GetUserById(int userId)
        {
            using (var context = new Project360Context())
            {
                //context.Configuration.LazyLoadingEnabled = false;
                //var res= context.Users.Include("UserRoles").FirstOrDefault();
                //return res;

                var result = (from user in context.Users
                              join usrRole in context.UserRoles on user.Id equals usrRole.UserId
                              join role in context.Roles on usrRole.RoleId equals role.Id
                              where user.Id == userId
                              group role by user into userGroup
                              select new
                              {
                                  User = userGroup.Key,
                                  Roles = userGroup.Select(r => new { r.RoleName }).ToList()
                              }).FirstOrDefault();

                if (result != null)
                {
                    return new UserDto
                    {
                        Id = result.User.Id,
                        UserName = result.User.UserName,
                        Password = result.User.Password,
                        Name = result.User.Name,
                        Surname = result.User.Surname,
                        BirthDate = result.User.BirthDate.ToString() ?? null,
                        Email = result.User.Email,
                        Gender = result.User.Gender,
                        Phone = result.User.Phone,
                        UserRoles = result.Roles.Select(r => new UserRoleDto
                        {
                            RoleName = r.RoleName,
                        }).ToList()
                    };
                }

                return null;
            }
        }
    }
}
