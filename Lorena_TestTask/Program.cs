using Lorena_TestTask.DataBase;
using Lorena_TestTask.DataBase.Entities;

namespace Lorena_TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            LorenaDbContext db = new LorenaDbContext();
            db.Database.EnsureCreated();
            db.Salons.Add(new Salon { Name = "Test", Description = "Test test", Discount = 2, IsDependence = false});
            db.SaveChanges();
            var x = db.Salons.FirstOrDefault();
            Console.WriteLine(x.Name);
            Console.ReadKey();
        }
    }
}
