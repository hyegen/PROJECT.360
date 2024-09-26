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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<ProductDto> GetAllProducts()
        {
            return _productDal.GetAllProducts();
        }
    }
}
