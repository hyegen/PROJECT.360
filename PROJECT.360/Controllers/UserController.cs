using PROJECT._360.DATAACCESS.Context;
using PROJECT._360.ENTITY.Models;
using PROJECT._360.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace PROJECT._360.Controllers
{
    [RoutePrefix("api")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("GetAllUsers")]
        public List<UserNameDto> GetAllUsers()
        {
            using (var context = new Project360Context())
            {
                var result = (from user in context.Users
                             select new UserNameDto
                             {
                                 Id = user.Id,
                                 Name = user.Name,
                                 Surname = user.Surname,
                                 Password = user.Password,
                                 BirthDate = user.BirthDate,
                                 Email = user.Email,
                                 Gender = user.Gender,
                                 TelNr1 = user.TelNr1,
                                 UserName = user.UserName
                             }).ToList();

                return result;
            }
        }

    }
}
