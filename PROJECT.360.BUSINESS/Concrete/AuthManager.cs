using PROJECT._360.BUSINESS.Abstract;
using PROJECT._360.DATAACCESS.Abstract;
using PROJECT._360.ENTITY.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.BUSINESS.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IAuthDal _authDal;

        public AuthManager(IAuthDal authDal)
        {
            _authDal = authDal;
        }
        public bool LoginByUsernameAndPassword(string email, string password)
        {
            return _authDal.LoginByUsernameAndPassword(email, password);
        }
    }
}
