using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.DTOs
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rut { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int Anexo { get; set; }
        public int RolId { get; set; }
        public string Rol { get; set; }
        public int LocacionId { get; set; }
        public string Locacion { get; set; }
        public bool Deleted { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";
        public string Avatar => $"{Nombre?[0]}{Apellido?[0]}".ToUpper();

        public static Usuario FromClaims(ClaimsPrincipal claims)
        {
            return new Usuario
            {
                Id = int.Parse(claims.FindFirst("Id").Value),
                Email = claims.FindFirst("Email").Value,
                RolId = int.Parse(claims.FindFirst("RolId").Value),
                Username = claims.FindFirst("Username").Value,
                LocacionId = int.Parse(claims.FindFirst("LocacionId").Value)
            };
        }

        public Claim[] ToClaims()
        {
            return new[]
            {
                new Claim("Id", Id.ToString()),
                new Claim("Name", NombreCompleto),
                new Claim("Email", Email),
                new Claim("RolId", RolId.ToString()),
                new Claim("Username", Username),
                new Claim("LocacionId", LocacionId.ToString())
            };
        }

        public bool IsAdministrador()
        {
            return RolId == (int)Enums.Rol.Administrador;
        }
    }
}
