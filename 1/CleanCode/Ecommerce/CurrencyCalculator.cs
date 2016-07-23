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
            switch (currency)
            {
                case 0: // 0 Convert to Dollars
                        if (isDollar)
                            return price;
                        else
                            return price / 31;
                case 1: // 1 Convert to Pesos
                        if (isDollar)
                            return price * 31;
                        else
                            return price;
                default:
                        return -1;
            }
        }
    }
}
