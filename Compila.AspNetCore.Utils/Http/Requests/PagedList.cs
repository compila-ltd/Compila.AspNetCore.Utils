using System;
using System.Collections.Generic;
using System.Linq;

namespace Compila.AspNetCore.Utils.Http.Requests
{
    public class PagedList<T> : List<T>
    {
        public RequestMetadata Metadata { get; set; }

        public PagedList(List<T> items, int count, int pageSize, int pageNumber)
        {
            Metadata = new RequestMetadata
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedList<T>(items, count, pageSize, pageNumber);
        }
    }
}
