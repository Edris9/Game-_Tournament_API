// To fix CS0234, ensure the Microsoft.EntityFrameworkCore package is referenced in your project.
// In Visual Studio, right-click your project > Manage NuGet Packages > Browse > search for "Microsoft.EntityFrameworkCore" and install it.
// Or, run the following command in the Package Manager Console:
// Install-Package Microsoft.EntityFrameworkCore

using Game__Tournament_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Game__Tournament_API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tournament>().HasData(
            new Tournament { Id = 1, Title = "NBI skolan Nemos Lag", Description = "ludwig är fotboll tränare", MaxPlayers = 32, Date = new DateTime(2026, 2, 15) },
            new Tournament { Id = 2, Title = "CS2 Championship", Description = "E-sport turnering", MaxPlayers = 16, Date = new DateTime(2026, 7, 20) },
            new Tournament { Id = 3, Title = "Chess Masters", Description = "Schackturnering", MaxPlayers = 8, Date = new DateTime(2026, 8, 10) }
        );

        modelBuilder.Entity<Game>().HasData(
            new Game { Id = 1, Title = "Final Match", Time = new DateTime(2026, 6, 15, 18, 0, 0), TournamentId = 1 },
            new Game { Id = 2, Title = "Semi Final 1", Time = new DateTime(2026, 6, 14, 15, 0, 0), TournamentId = 1 },
            new Game { Id = 3, Title = "Grand Final", Time = new DateTime(2026, 7, 20, 20, 0, 0), TournamentId = 2 }
        );
    }
}