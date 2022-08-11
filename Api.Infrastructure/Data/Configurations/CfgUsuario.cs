using Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Data.Configurations
{
    public class CfgUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData(
                new Usuario
                {
                    Id = 1,
                    Nombre = "Alvaro",
                    Apellido = "Taucare",
                    Rut = "15979991-3",
                    Email = "ataucare@newtenberg.com",
                    Username = "ataucare",
                    Password = "YpJX//2e21/6kNyNBQj6dTgQ8/KIlcFrq1sC0CqVfCJ++CksgYLsTjlhVXwFwtq0yqg8X4Az+yissGtCYn4mt76gZCUuhpjtEGlF644zCZOvfrjfdmEnDKpbcYAxSxiMh5kE7rso7vdCLxJUXGHzGlD2v8/dNI+Zu8AZNoIVNf0=", // 12345
                    RolId = (int)Core.Enums.Rol.Administrador,
                    LocacionId = 1
                }
            );
        }
    }
}
