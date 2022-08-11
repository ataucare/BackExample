using Api.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Locacion> Locacion { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<MenuRol> MenuRol { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiContext).Assembly);
        }
    }
}
