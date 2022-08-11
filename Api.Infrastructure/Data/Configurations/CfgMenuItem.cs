using Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Data.Configurations
{
    public class CfgMenuItem : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            // Usuarios (2)
            builder.HasData(
                new MenuItem { Id = 1, MenuId = 2, Nombre = "Listar", Url = "/lista", Orden = 2, Creacion = DateTime.Now }
            );
        }
    }
}
