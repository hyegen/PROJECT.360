using PROJECT._360.CORE.DataAccess;
using PROJECT._360.ENTITY.Dtos;
using PROJECT._360.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.DATAACCESS.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserDto> GetAllUsers();
        bool CheckUserName(string userName);
        UserDto GetUserById(int userId);
    }
}
