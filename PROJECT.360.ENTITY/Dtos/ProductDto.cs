using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.ENTITY.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double? PurchasingPrice { get; set; }
        public double? SalesPrice { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
    }
}
