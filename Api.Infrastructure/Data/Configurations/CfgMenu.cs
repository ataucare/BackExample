using Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Data.Configurations
{
    public class CfgMenu : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasData(new Menu { Id = 1, Nombre = "Inicio", Icon = "mdi-home", Orden = 0, Creacion = DateTime.Now, Url = "/" });
            builder.HasData(new Menu { Id = 2, Nombre = "Usuarios", Icon = "mdi-account-group-outline", Orden = 1, Creacion = DateTime.Now });
        }
    }
}
