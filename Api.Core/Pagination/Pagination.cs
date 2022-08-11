namespace Api.Core.Pagination
{
    public static class Extensions
    {
        public static async Task<PaginatedResult<T>> ToPage<T>(this IQueryable<T> source, int page)
           where T : class
            => await new PaginatedResult<T>(page, null).MakePagination(source);

        public static async Task<PaginatedResult<T>> ToPage<T>(this IQueryable<T> source, int page, int perpage)
            where T : class
            => await new PaginatedResult<T>(page, perpage).MakePagination(source);

    }

    public class PaginatedResult<T>
    {
        public const int DefaultPage = 0;
        public const int DefaultPageSize = 100;
        public const int MaxPageSize = 80;

        public int PageSize { get; private set; } = DefaultPageSize;
        public int Page { get; private set; } = DefaultPage;
        public int Total { get; private set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Items { get; private set; }
        public bool HasNext => (Page + 1) < TotalPages;
        public bool HasPrev => Page > 0;


        public PaginatedResult(int page, int? perpage)
        {
            Page = page;
            PageSize = perpage ?? DefaultPageSize;

            if (Page < 0)
            {
                Page = DefaultPage;
            }

            if (PageSize < 0 || PageSize > MaxPageSize)
            {
                PageSize = MaxPageSize;
            }
        }

        public PaginatedResult(int page, int perpage, int total, IEnumerable<T> items)
            : this(page, perpage)
        {
            Total = total;
            Items = items;
            TotalPages = (int)Math.Ceiling(Total / (double)PageSize);
        }

        //public async Task<PaginatedResult<T>> Paginate(IQueryable<T> source)
        //{
        //    Total = source.Count();

        //    if(PageSize > Total)
        //    {
        //        PageSize = Total;
        //        Page = DefaultPage;
        //    }

        //    int skip = Page * PageSize;
        //    if(skip > Total)
        //    {
        //        skip = Total - PageSize;
        //        Page = Total / PageSize - 1;
        //    }

        //    // fix for empty
        //    if(Total != 0)
        //    {
        //        Items = source.Skip(skip).Take(PageSize).ToList();
        //    }

        //    return this;
        //}

        public async Task<PaginatedResult<T>> MakePagination(IQueryable<T> source)
        {
            Total = source.Count();

            if (Total != 0)
            {
                Items = source.Skip(Page * PageSize).Take(PageSize);
            }

            return await Task.FromResult(this);
        }


    }
}
