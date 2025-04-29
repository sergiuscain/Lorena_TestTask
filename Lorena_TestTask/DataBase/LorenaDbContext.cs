using Lorena_TestTask.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lorena_TestTask.DataBase
{
    public class LorenaDbContext : DbContext
    {
        public DbSet<Salon> Salons { get; set; }
        public DbSet<PriceCalculation> PriceCalculations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=salons.db"); 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salon>()
                .HasOne(s => s.Parent)
                .WithMany(s => s.Children)
                .HasForeignKey(s => s.ParentId);
        }
        public void SeedData()
        {
            // Если данные уже есть, выходим
            if (Salons.Any()) return;

            // Начальные данные
            var miass = new Salon { Id = Guid.NewGuid(), Name = "Миасс", Discount = 4, IsDependence = false, Description = "Салон в Миассе" };
            var amelia = new Salon { Id = Guid.NewGuid(), Name = "Амелия", Discount = 5, IsDependence = true, Description = "Салон Амелия", ParentId = miass.Id };
            var test1 = new Salon { Id = Guid.NewGuid(), Name = "Тест1", Discount = 2, IsDependence = true, Description = "Тестовый салон 1", ParentId = amelia.Id };
            var test2 = new Salon { Id = Guid.NewGuid(), Name = "Тест2", Discount = 0, IsDependence = true, Description = "Тестовый салон 2", ParentId = miass.Id };
            var kurgan = new Salon { Id = Guid.NewGuid(), Name = "Курган", Discount = 11, IsDependence = false, Description = "Салон в Кургане" };

            //Добавляем данные
            Salons.AddRange(miass, amelia, test1, test2, kurgan);
            //Затем сохраняем изменения
            SaveChanges(); 
        }
    }
}
