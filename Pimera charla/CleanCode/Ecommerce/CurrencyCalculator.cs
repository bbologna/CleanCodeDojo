using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class CurrencyCalculator
    {
        private readonly decimal salePrice;
        private readonly decimal buyPrice;

        public CurrencyCalculator(decimal salePrice, decimal buyPrice)
        {
            this.salePrice = salePrice;
            this.buyPrice = buyPrice;
        }

        public decimal Convert(decimal price, Currency from, Currency to)
        {
            if (from == to)
            {
                return price;
            }
            // Check the currency type
            switch (from)
            {
                case Currency.Dollar:
                    return price * buyPrice;
                case Currency.Peso:
                    return price / salePrice;
                default:
                    return -1;
            }
        }

    }
}
