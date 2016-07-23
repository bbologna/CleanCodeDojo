using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class SystemData : ISystemData
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
