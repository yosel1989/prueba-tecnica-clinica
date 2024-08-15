using Clinica.Entity.Models;
using Microsoft.EntityFrameworkCore;

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

    }
}
