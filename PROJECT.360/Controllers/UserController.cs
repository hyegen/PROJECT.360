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
                return new RestResult
                {
                    Data = result,
                    Message = "Kullanıcılar Başarı ile Çekildi."
                };
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
        }

        [HttpGet]
        [Route("GetUserById")]
        public RestResult GetUserById(int userId)
        {
            try
            {
                var result = _userManager.GetUserById(userId);
                return new RestResult
                {
                    Data = result,
                    Message = $"{result.Email} - Kullanıcı Başarı ile Çekildi."
                };
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
                    Message = "User model null geldi. User modelinizi kontrol ediniz."
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
