using EFPro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFPro.Data
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options):base(options)
        {

        }
        public DbSet<Players> players { get; set; }
        public DbSet<League> leagues { get; set; }
        public DbSet<Club> clubs { get; set; }
        public DbSet<Game> games { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamePlayer>().HasKey(x => new { x.playerid, x.gameid });//主键
            modelBuilder.Entity<Resume>()
                .HasOne(x => x.players)
                .WithOne(x => x.resume)
                .HasForeignKey<Resume>(x => x.playerid);
        }
    }
}
