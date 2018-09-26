using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public bool HasDiscount
        {
            get
            {
                return DiscountPercentage > 0;
            }
        }
        public decimal DiscountPercentage { get; set; }
        public string[] Categories { get; set; }
    }
}
