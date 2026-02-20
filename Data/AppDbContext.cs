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
}