using PROJECT._360.BUSINESS.Concrete;
using PROJECT._360.DATAACCESS.Concrete.EntityFramework;
using PROJECT._360.Models;
using PROJECT._360.TokenHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PROJECT._360.Controllers
{
    //[JwtAuthenticationFilter]
    [RoutePrefix("api")]
    public class ProductController : ApiController
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        [HttpGet]
        [Route("GetAllProducts")]
        public RestResult GetAllProducts()
        {
            return new RestResult
            {
                Message = "Ürünler Sunucudan Başarı ile Çekildi.",
                Data = productManager.GetAllProducts()
            };
        }
    }
}
