using Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Data.Configurations
{
    public class CfgMenuRol : IEntityTypeConfiguration<MenuRol>
    {
        public void Configure(EntityTypeBuilder<MenuRol> builder)
        {
            // Administrador
            builder.HasData(
                new MenuRol { Id = 1, RolId = (int)Core.Enums.Rol.Administrador, MenuId = 1, Enabled = true },
                new MenuRol { Id = 2, RolId = (int)Core.Enums.Rol.Administrador, MenuId = 2, Enabled = true }
            );
        }
    }
}
