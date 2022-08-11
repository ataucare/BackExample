using Api.Core.Pagination;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrastructure.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Core.Entities.Usuario, Core.DTOs.Usuario>()
                .ForMember(dest => dest.Rol, map => map.MapFrom(src => src.Rol.Nombre))
                .ForMember(dest => dest.Locacion, map => map.MapFrom(src => src.Locacion.Nombre));
            CreateMap<Core.Entities.Menu, Core.DTOs.Menu>();
            CreateMap<Core.Entities.MenuItem, Core.DTOs.MenuItem>();

            CreateMap(typeof(PaginatedResult<>), typeof(PaginatedResult<>))
                .ConvertUsing(typeof(PaginationConverter<,>));
        }
    }
}
