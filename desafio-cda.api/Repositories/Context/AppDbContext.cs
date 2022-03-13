using desafio_cda.api.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace desafio_cda.api.Repositories.Context;

public class AppDbContext: DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }
  
  public DbSet<User> Users { get; set; }
  public DbSet<Status> Status { get; set; }
  public DbSet<CriminalCode> CriminalCodes { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<CriminalCode>(e => e.Property(x => x.CreatedAt).HasDefaultValueSql("now()"));
    modelBuilder.Entity<CriminalCode>(e => e.Property(x => x.UpdatedAt).HasDefaultValueSql("now()"));
    modelBuilder.Entity<User>(e => e.Property(x => x.CreatedAt).HasDefaultValueSql("now()"));
    modelBuilder.Entity<User>(e => e.Property(x => x.UpdatedAt).HasDefaultValueSql("now()"));
    modelBuilder.Entity<Status>(e => e.Property(x => x.CreatedAt).HasDefaultValueSql("now()"));
    modelBuilder.Entity<Status>(e => e.Property(x => x.UpdatedAt).HasDefaultValueSql("now()"));
  }
}
