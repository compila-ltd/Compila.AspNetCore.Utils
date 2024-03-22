using System.Collections.Generic;

namespace Compila.AspNetCore.Utils.Http.Requests
{
    public abstract class RequestParametersBase
    {
        const int maxPageSize = 1000;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 100;
        public int PageSize { get => _pageSize; set { _pageSize = (value > maxPageSize) ? maxPageSize : value; } }

        protected static List<string> LoadMultiparamsInQuery(string queryParams)
        {
            var splitted = queryParams.Split('\u002C');
            var query = new List<string>();
            if (splitted.Length > 0)
                foreach (var item in splitted)
                {
                    query.Add(item);
                }

            return query;
        }
    }
}
