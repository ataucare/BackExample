using Api.Core.Pagination;
using AutoMapper;

namespace Api.Infrastructure.Mappings
{
    public class PaginationConverter<TSource, TDestination> : ITypeConverter<PaginatedResult<TSource>, PaginatedResult<TDestination>>
        where TSource : class where TDestination : class
    {
        public PaginatedResult<TDestination> Convert(PaginatedResult<TSource> source, PaginatedResult<TDestination> destination, ResolutionContext context)
        {
            var items = context.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source.Items);
            return new PaginatedResult<TDestination>(source.Page, source.PageSize, source.Total, items);
        }
    }
}
