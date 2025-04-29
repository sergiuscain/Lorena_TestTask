using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lorena_TestTask.DataBase.Entities
{
    public class PriceCalculation
    {
        public Guid Id { get; set; }
        public float OriginalPrice { get; set; }
        public float FinalPrice { get; set; }
        public Guid SalonId { get; set; }
        public DateTime CalculationDate { get; set; }
    }
}
