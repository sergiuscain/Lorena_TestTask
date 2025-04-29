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
            db.SeedData();

            var x = db.Salons.FirstOrDefault();
            Console.WriteLine(x.Name);
            Console.ReadKey();
        }
    }
}
