using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sweets.Models
{
  public class SweetsContext : IdentityDbContext<User>
  {
    public virtual DbSet<Treat> Treats { get; set; }
    public virtual DbSet<Flavor> Flavors { get; set; }
    public virtual DbSet<FlavorTreat> FlavorTreat { get; set; }
    public SweetsContext(DbContextOptions options) : base(options) {}
  }
}