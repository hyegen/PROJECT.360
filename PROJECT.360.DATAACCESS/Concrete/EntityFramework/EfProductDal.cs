using PROJECT._360.CORE.DataAccess;
using PROJECT._360.CORE.DataAccess.EntityFramework;
using PROJECT._360.DATAACCESS.Abstract;
using PROJECT._360.DATAACCESS.Context;
using PROJECT._360.ENTITY.Dtos;
using PROJECT._360.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.DATAACCESS.Concrete.EntityFramework
{
    public class EfProductDal : EfGenericRepositoryBase<Product, Project360Context>, IProductDal
    {
        public List<ProductDto> GetAllProducts()
        {
            using (var context = new Project360Context())
            {
                var products = (from prod in context.Products
                                select new ProductDto
                                {
                                    Id = prod.Id,
                                    CategoryId = prod.CategoryId,
                                    ImagePath = prod.ImagePath,
                                    IsActive = prod.IsActive,
                                    ProductCode = prod.ProductCode,
                                    ProductName = prod.ProductName,
                                    PurchasingPrice = prod.PurchasingPrice,
                                    SalesPrice = prod.SalesPrice
                                }).ToList();
                return products;
            }
        }
    }
}
