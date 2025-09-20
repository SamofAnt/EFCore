using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace EFCore.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        public FootballLeagueDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "FootballLeague_EfCore.db");
        }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Coach> Coaches { get; set; }
        public string DbPath { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}")
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    TeamId = 1,
                    Name = "Tivoli Gardens F.C.",
                    CreatedDate = new DateTime(2025, 9, 20, 2, 41, 50, 31)
                },
                new Team
                {
                    TeamId = 2,
                    Name = "Waterhouse F.C.",
                    CreatedDate = new DateTime(2025, 9, 20, 2, 41, 50, 31)
                },
                new Team
                {
                    TeamId = 3,
                    Name = "Humble Lions F.C.",
                    CreatedDate = new DateTime(2025, 9, 20, 2, 41, 50, 31)
                }
            );
        }
    }
}
