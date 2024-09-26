using PROJECT._360.BUSINESS.Concrete;
using PROJECT._360.DATAACCESS.Concrete.EntityFramework;
using PROJECT._360.TokenHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PROJECT._360.Controllers
{
    [RoutePrefix("api")]
    public class AuthController : ApiController
    {
        private readonly TokenService _tokenService;
        AuthManager authManager = new AuthManager(new EfAuthDal());
        
        public AuthController()
        {
            _tokenService = new TokenService();
        }

        [HttpPost]
        [Route("Authenticate")]
        public IHttpActionResult Authenticate([FromUri] string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Geçersiz istek: Kullanıcı null.");
            }

            bool _currentUser = authManager.LoginByUsernameAndPassword(email, password);

            if (_currentUser)
            {
                var token = _tokenService.GenerateToken(email);
                return Ok(new { token });
            }

            return Content(HttpStatusCode.Unauthorized, "Kullanıcı adı veya şifre yanlış.");
        }
    }
}
