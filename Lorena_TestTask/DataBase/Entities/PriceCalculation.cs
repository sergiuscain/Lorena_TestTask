

namespace Lorena_TestTask.DataBase.Entities
{
    public class PriceCalculation
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountParent { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime CalculationDate { get; set; }
    }
}
