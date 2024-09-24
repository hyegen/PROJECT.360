using PROJECT._360.ENTITY.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.BUSINESS.Abstract
{
    public interface IUserService
    {
        List<UsernameDto> GetAllUsers();
        bool CheckUserName(string userName);
    }
}
