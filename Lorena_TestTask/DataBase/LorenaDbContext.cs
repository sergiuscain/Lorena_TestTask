using Lorena_TestTask.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lorena_TestTask.DataBase
{
    public class LorenaDbContext : DbContext
    {
        public DbSet<Salon> Salons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=salons.db"); // Укажите имя файла базы данных
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salon>()
                .HasOne(s => s.Parent)
                .WithMany(s => s.Children)
                .HasForeignKey(s => s.ParentId);
        }
    }
}
