using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace sqlite_persistence
{
    public class PlayerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=player.db");
        }
    }
}
