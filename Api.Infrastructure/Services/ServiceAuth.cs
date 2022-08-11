using Api.Core.Configurations;
using Api.Core.DTOs;
using Api.Core.Exceptions;
using Api.Core.Interfaces;
using Api.Core.Models.Responses;
using Api.Core.Utilities;
using Api.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Api.Infrastructure.Services
{
    public class ServiceAuth : IServiceAuth
    {
        private readonly ApiContext context;
        private readonly IMapper mapper;
        private readonly JwtOptions jwtOptions;

        public ServiceAuth(ApiContext context, IMapper mapper, IOptions<JwtOptions> jwtOptions)
        {
            this.context = context;
            this.mapper = mapper;
            this.jwtOptions = jwtOptions.Value;
        }

        public async Task<LoginResponse> Login(string username, string password)
        {
            var usuario = await this.context
                                    .Usuario
                                    .Include(x => x.Rol)
                                    .Include(x => x.Locacion)
                                    .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));

            if (usuario != null && usuario.Password.Equals(Security.PasswordToBase64(password)))
            {
                if (usuario.Deleted)
                {
                    throw new ServiceException("La cuenta de usuario esta desactivada");
                }

                var menu = await this.GetMenu(usuario.RolId);
                if (menu.Count == 0)
                {
                    throw new ServiceException("El rol del usuario no tiene asigando un menu");
                }

                if (usuario.Locacion == null)
                {
                    throw new ServiceException("El usuario no tiene asigando una locacion");
                }

                var usuarioDto = mapper.Map<Usuario>(usuario);
                return new LoginResponse
                {
                    Usuario = usuarioDto,
                    Token = this.CreateToken(usuarioDto),
                    Menu = menu
                };
            }
            else
            {
                throw new ServiceException("El usuario y/o la contraseña son incorrectas");
            }
        }

        public string CreateToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                expires: DateTime.Now.AddHours(jwtOptions.ExpireInHours),
                signingCredentials: credentials,
                claims: usuario.ToClaims()
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<List<Menu>> GetMenu(int rolId)
        {
            var menu = await this.context
                                 .MenuRol
                                 .Include(x => x.Menu)
                                    .ThenInclude(x => x.MenuItem)
                                 .Where(x => x.RolId == rolId && !x.Deleted)
                                 .Select(x => new Core.Entities.Menu
                                 {
                                     Id = x.Id,
                                     Nombre = x.Menu.Nombre,
                                     Descripcion = x.Menu.Descripcion,
                                     Icon = x.Menu.Icon,
                                     Url = x.Menu.Url,
                                     Orden = x.Menu.Orden,
                                     MenuItem = x.Menu.MenuItem.Where(m => !m.Deleted).OrderBy(m => m.Orden).ToList()
                                 })
                                 .OrderBy(x => x.Orden)
                                 .AsNoTracking()
                                 .ToListAsync();

            return mapper.Map<List<Menu>>(menu);
        }
    }
}
