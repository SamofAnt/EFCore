using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Data
{
    internal class FootballLeagueDbContext : DbContext
    {

        public DbSet<Team> Teams { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FootballLeague_EfCore.db");
        }

    }
}
