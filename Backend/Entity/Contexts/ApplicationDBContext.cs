using Clinica.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Clinica.Entity.Contexts
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Ubigeo> Ubigeo { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasKey(x => x.DocumentNumber);
            modelBuilder.Entity<Ubigeo>().HasKey(x => x.UbigeoCode);
            modelBuilder.Entity<Province>().HasKey(x => x.ProvinceCode);
            modelBuilder.Entity<Region>().HasKey(x => x.RegionCode);
        }

    }
}
