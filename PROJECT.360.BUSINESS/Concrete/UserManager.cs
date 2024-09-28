using PROJECT._360.BUSINESS.Abstract;
using PROJECT._360.DATAACCESS.Abstract;
using PROJECT._360.ENTITY.Dtos;
using PROJECT._360.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.BUSINESS.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<UserDto> GetAllUsers()
        {
            var result = _userDal.GetAllUsers();
            if (result.Count > 0 && result != null)
            {
                return result;
            }
            return null;
        }
        public bool CheckUserName(string userName)
        {
            return _userDal.CheckUserName(userName);
        }
        public User AddUser(User user)
        {
            if (user != null && !CheckUserName(user.UserName) && user.UserName != null && user.Password != null)
            {
                int[] roleId = { 1, 2, 3 };
                foreach (var item in roleId)
                {
                    var userRole = new UserRole
                    {
                        RoleId = item
                    };
                    user.UserRoles.Add(userRole);
                }
                _userDal.Add(user);
                return new User { Email = user.Email };
            }
            return null;
        }

        public UserDto GetUserById(int userId)
        {
            if (userId > 0)
            {
                return _userDal.GetUserById(userId);
            }
            return null;
        }
    }
}
