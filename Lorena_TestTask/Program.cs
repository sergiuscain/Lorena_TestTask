using Lorena_TestTask.DataBase;
using Lorena_TestTask.DataBase.Entities;
using Lorena_TestTask.Services;
using Microsoft.EntityFrameworkCore;

namespace Lorena_TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LorenaDbContext db = new LorenaDbContext();
            db.Database.EnsureCreated();
            db.SeedData();

            while (true)
            {
                Console.WriteLine("Введите номер салона:\n1 - Амелия\n2 - Тест1\n3 - Тест2\n4 - Курган\n5 - Миасс");
                var salonNumber = Console.ReadLine(); 
                Salon salon = salonNumber switch
                {
                    "1" => db.Salons.Include(s => s.Parent).FirstOrDefault(s => s.Name == "Амелия"),
                    "2" => db.Salons.Include(s => s.Parent).FirstOrDefault(s => s.Name == "Тест1"),
                    "3" => db.Salons.Include(s => s.Parent).FirstOrDefault(s => s.Name == "Тест2"),
                    "4" => db.Salons.Include(s => s.Parent).FirstOrDefault(s => s.Name == "Курган"),
                    "5" => db.Salons.Include(s => s.Parent).FirstOrDefault(s => s.Name == "Миасс"),
                    _ => null
                };
                try
                {
                    if (salon != null)
                    {
                        Console.WriteLine("Введите цену, что бы получить стоимость с учетом скидки");
                        Console.WriteLine(PriceCalculator.CalculatePrice(int.Parse(Console.ReadLine()), salon));
                    }
                    else
                    {
                        Console.WriteLine("Салон не найден!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
