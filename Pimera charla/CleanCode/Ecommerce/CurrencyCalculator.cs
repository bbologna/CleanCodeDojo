using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    public static class CurrencyCalculator
    {
        public static decimal Calculate(decimal price, int currency, bool isDollar)
        {
            // Check the currency type
            switch (currency)
            {
                case 0: // 0 Convert to Dollars
                        // If the currency is Dollars, and isDollar is true, do nothing
                        if (isDollar)
                            return price;
                        else
                        // Else, divide it by the current dollar price
                            return price / 31;
                case 1: // 1 Convert to Pesos
                        // If the currency is pesos, and isDollar is true, multiply it by the price of dolar
                        if (isDollar)
                            return price * 31;
                        // Else, do nothing.
                        else
                            return price;
                default:
                        return -1;
            }
        }
    }
}
