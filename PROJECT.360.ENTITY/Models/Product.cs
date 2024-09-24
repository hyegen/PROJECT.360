
using PROJECT._360.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT._360.ENTITY.Models
{
    public class Product :IEntity
    {
        [Key]
        public int Id { get; set; }
        public string ProductCode{ get; set; }
        public string ProductName{ get; set; }
        public double? PurchasingPrice { get; set; }
        public double? SalesPrice { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string TestField { get; set; }
    }
}
