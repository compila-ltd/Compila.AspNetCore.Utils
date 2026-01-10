using Compila.Net.Utils.Http.RequestsParameters;

using Microsoft.EntityFrameworkCore;

namespace Compila.AspNetCore.Utils.Infrastructure.Extensions
{
    public static class EfCorePagedListExtensions
    {
        public static Task<PagedList<T>> ToPagedListAsync<T>(
            this IQueryable<T> source,
            int pageNumber,
            int pageSize)
        {
            return PagedList<T>.ToPagedListAsync(
                source,
                pageNumber,
                pageSize,
                q => q.CountAsync(),
                q => q.ToListAsync()
            );
        }
    }
}
