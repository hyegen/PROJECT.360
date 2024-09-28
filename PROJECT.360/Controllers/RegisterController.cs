using PROJECT._360.BUSINESS.Concrete;
using PROJECT._360.DATAACCESS.Concrete.EntityFramework;
using PROJECT._360.ENTITY.Models;
using PROJECT._360.Models;
using PROJECT._360.TokenHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace PROJECT._360.Controllers
{
    [RoutePrefix("api")]
    public class RegisterController : ApiController
    {
        private readonly TokenService _tokenService;
        private UserManager _userManager = new UserManager(new EfUserDal());

        public RegisterController()
        {
            _tokenService = new TokenService();
        }

        [HttpPost]
        [Route("Register")]
        public RestResult Register(User registeredUser)
        {
            if (registeredUser == null)
            {
                return new RestResult
                {
                    Data = null,
                    Message = "User model null geldi. User modelinizi kontrol ediniz."
                };
            }
            try
            {
                var result = _userManager.AddUser(registeredUser);
                if (result != null)
                {
                    var token = _tokenService.GenerateToken(registeredUser.Email);
                    return new RestResult
                    {
                        Data = token,
                        Message = $"{result.Email} - kullanıcı başarı ile eklendi."
                    };
                }
                else
                {
                    return new RestResult
                    {
                        Data = null,
                        Message = "Kullanıcı Eklenirken Bir Hata Meydana Geldi. Lütfen Bilgilerinizi Kontrol Ediniz."
                    };
                }
            }
            catch (Exception ex)
            {
                return new RestResult
                {
                    Data = null,
                    Message = string.Format("Kullanıcı Eklerken Hata: {0}-{1}", ex.Message, ex.InnerException)
                };
            }
        }
    }
}
