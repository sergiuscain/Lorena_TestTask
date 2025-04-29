using Lorena_TestTask.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorena_TestTask.Services
{
    public class PriceCalculator
    {
        public static decimal CalculatePrice(decimal price, Salon salon)
        {
            decimal discountParent = 0;

            if (salon.IsDependence && salon.Parent != null)
            {
                discountParent = salon.Parent.Discount;
            }

            return price - (price * ((salon.Discount + discountParent) / 100));
        }
    }
}
