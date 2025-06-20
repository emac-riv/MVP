using Microsoft.EntityFrameworkCore;
using Persistance.Entities;

namespace Persistance.Contexts
{ 
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<PackageEntity> Packages { get; set; }
        public DbSet<EventPackagesEntity> EventPackages { get; set; }
    }
}
