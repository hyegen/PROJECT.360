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
        public List<UsernameDto> GetAllUsers()
        {
            var result = _userDal.GetAllUsers();
            if (result.Count > 0)
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
            if (user != null)
            {
                if (!CheckUserName(user.UserName))
                {
                    if (user != null && user.UserName != null && user.Password != null)
                    {
                        _userDal.Add(user);
                        return user;
                    }
                }
            }
            return null;
        }
    }
}
