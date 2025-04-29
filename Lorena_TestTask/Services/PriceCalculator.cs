using Lorena_TestTask.DataBase;
using Lorena_TestTask.DataBase.Entities;
using System;

namespace Lorena_TestTask.Services
{
    public class PriceCalculator
    {
        public static decimal CalculatePrice(decimal price, Salon salon)
        {
            decimal discountParent = GetParentDiscount(salon);
            decimal finalPrice = price - (price * ((salon.Discount + discountParent) / 100));

            // Сохранение расчета в базе данных
            SaveCalculation(price, salon.Discount, discountParent, finalPrice);

            return finalPrice;
        }

        // Рекурсивный метод для получения скидки предка
        private static decimal GetParentDiscount(Salon salon)
        {
            if (salon.IsDependence && salon.Parent != null)
            {
                return salon.Parent.Discount + GetParentDiscount(salon.Parent);
            }
            return 0;
        }

        // Метод для сохранения расчета в базе данных
        private static void SaveCalculation(decimal price, decimal discount, decimal discountParent, decimal finalPrice)
        {
            using (var context = new LorenaDbContext())
            {
                var calculation = new PriceCalculation
                {
                    Price = price,
                    Discount = discount,
                    DiscountParent = discountParent,
                    FinalPrice = finalPrice,
                    CalculationDate = DateTime.Now
                };

                context.PriceCalculations.Add(calculation);
                context.SaveChanges();
            }
        }
    }
}