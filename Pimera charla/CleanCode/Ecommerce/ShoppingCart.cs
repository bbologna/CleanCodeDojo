using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class ShoppingCart
    {
        public List<Product> Products { get; set; }

        public User User { get; set; }

        private List<string> FatherDiscountCategories { get; set; }

        private ISystemData systemData;
        public ShoppingCart(ISystemData systemData)
        {
            this.systemData = systemData;
            FatherDiscountCategories = new List<string>()
            {
                "Afeitadoras", "Herramientas","Vinos"
            };
        }

        public void AddProduct(Product product)
        {
            if (this.Products == null)
            {
                this.Products = new List<Product>();
            }
            Products.Add(product);
        }

        public decimal Buy(int currency)
        {
            decimal total = 0;
            foreach(var product in Products)
            {
                bool isDollar = true;
                if (product.Currency == 1)
                    isDollar = false;

                var priceWithDiscount = 0m;// Que sera esto

                priceWithDiscount = CurrencyCalculator.Calculate(product.Price - (product.Price * (product.DiscountPercentage) / 100), currency, isDollar);

                // Apply fathers week discount
                if (systemData.GetCurrentDate().DayOfYear <= 192 && systemData.GetCurrentDate().DayOfYear >= 192 - 7)
                {
                    var fd = 10m; //Father's discount 
                    if (product.DiscountPercentage <= 15 && ContainsDiscountCategory(FatherDiscountCategories, product.Categories)) // Only if the discount percentage of the product itself is less than 15
                    {
                        priceWithDiscount = CurrencyCalculator.Calculate(product.Price - (product.Price * (product.DiscountPercentage + fd) / 100), currency, isDollar);
                    }
                }

                // Apply mothers week discount
                if (systemData.GetCurrentDate().DayOfYear <= 136 && systemData.GetCurrentDate().DayOfYear >= 136 - 7)
                {
                    var fd = 15m;
                    if (product.DiscountPercentage <= 15) // Only if the discount percentage of the product itself is less than 15
                    {
                        if (product.Categories != null)
                        {
                            if (product.Categories.Any(c => c.Equals("Flores")))
                            {
                                priceWithDiscount = CurrencyCalculator.Calculate(product.Price - (product.Price * (product.DiscountPercentage + fd) / 100), currency, isDollar);
                            }
                            else if (product.Categories.Any(c => c.Equals("Bombones")))
                            {
                                priceWithDiscount = CurrencyCalculator.Calculate(product.Price - (product.Price * (product.DiscountPercentage + fd) / 100), currency, isDollar);
                            }
                            else if (product.Categories.Any(c => c.Equals("Peluches")))
                            {
                                priceWithDiscount = CurrencyCalculator.Calculate(product.Price - (product.Price * (product.DiscountPercentage + fd) / 100), currency, isDollar);
                            }
                        }
                    }
                }

                if (priceWithDiscount != 0)
                {
                    total += priceWithDiscount; // Sums Discount
                }
                else
                {
                    total += CurrencyCalculator.Calculate(product.Price, currency, isDollar); // Sums price if no discount was applied.
                }
            }
            return total;
        }

        private bool ContainsDiscountCategory(IEnumerable<string> categories, IEnumerable<string> productCategories)
        {
            return productCategories != null 
                && categories != null 
                && categories.Any(x => productCategories.Contains(x));
        }
    }
}
