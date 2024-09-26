using PROJECT._360.BUSINESS.Concrete;
using PROJECT._360.DATAACCESS.Concrete.EntityFramework;
using PROJECT._360.ENTITY.Models;
using PROJECT._360.Models;
using PROJECT._360.TokenHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Results;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace PROJECT._360.Controllers
{
    [JwtAuthenticationFilter]
    [RoutePrefix("api")]
    public class UserController : ApiController
    {
        private UserManager _userManager = new UserManager(new EfUserDal());

        [HttpGet]
        [Route("GetAllUsers")]
        public RestResult GetAllUsers()
        {
            try
            {
                var result = _userManager.GetAllUsers();

                if (result != null || result.Count > 0)
                {
                    return new RestResult
                    {
                        Data = result,
                        Message = "Kullanıcılar Başarı ile Geldi."
                    };
                }
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException;
                return new RestResult
                {
                    Data = null,
                    Message = $"İstek Oluşurken Hata: {ex.Message}{inner}"
                };
            }
            return null;
        }

        [HttpPost]
        [Route("AddUser")]
        public RestResult AddUser(User addedUser)
        {
            if (addedUser == null)
            {
                return new RestResult
                {
                    Data = null,
                    Message = "User model null geldi. User modelini kontrol ediniz."
                };
            }
            try
            {
                var result = _userManager.AddUser(addedUser);
                if (result != null)
                {
                    return new RestResult
                    {
                        Data = result,
                        Message = $"{result.Name} isimli kullanıcı başarı ile eklendi."
                    };
                }
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException;
                return new RestResult
                {
                    Data = null,
                    Message = $"Kullanıcı Eklerken Hata: {ex.Message}{inner}"
                };
            }
            return new RestResult
            {
                Data = null,
                Message = $"Kullanıcı Eklerken Hata Oluştu. Bilgilerinizi Kontrol Ediniz."
            };
        }
    }
}
