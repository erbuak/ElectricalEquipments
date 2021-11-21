using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricalEquipments.Models
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Motor> Motors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>().HasData(
                new Unit()
                {
                    Id = 1,
                    Name = "Döner Fırın 1",
                    CodeName = "DF1"
                },
                new Unit()
                {
                    Id = 2,
                    Name = "Döner Fırın 2",
                    CodeName = "DF2"
                },
                new Unit()
                {
                    Id = 3,
                    Name = "Çimento Değirmeni 1",
                    CodeName = "ÇD1"
                }
                ); ;
            base.OnModelCreating(modelBuilder);
        }
    }
}
