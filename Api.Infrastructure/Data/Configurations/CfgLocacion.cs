using Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Data.Configurations
{
    public class CfgLocacion : IEntityTypeConfiguration<Locacion>
    {
        public void Configure(EntityTypeBuilder<Locacion> builder)
        {
            builder.HasData(new Locacion { Id = 1, Nombre = "Servicio 1", Direccion = "Direccion Servicio 1, Región Metropolitana" });
        }
    }
}
