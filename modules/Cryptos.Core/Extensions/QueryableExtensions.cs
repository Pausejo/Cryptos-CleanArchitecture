using Cryptos.Core.Filtering;

namespace System.Linq
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Pages the result of a query and encapsulates the result in a <see cref="IPagedEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the data in the data source.</typeparam>
        /// <param name="query">The query to page.</param>
        /// <param name="pagingOptions">The paging options.</param>
        /// <returns>An instance of <see cref="IPagedEnumerable{T}"/> containing the results of the query and paging information.</returns>
        public static IPagedEnumerable<T> PageResult<T>(this IQueryable<T> query, IPagingOptions pagingOptions)
        {
            var totalCount = query.Count();

            var validOptions = ValidateOptions(pagingOptions);

            if (validOptions)
            {
                query = query.PageBy(pagingOptions.MaxResultCount, pagingOptions.SkipCount);
            }

            return new PagedEnumerable<T>()
            {
                TotalCount = totalCount,
                CurrentPage = totalCount > 0 ? pagingOptions?.SkipCount / pagingOptions?.MaxResultCount + 1 : null,
                Items = query.ToList()
            };
        }

        internal static IQueryable<T> PageBy<T>(this IQueryable<T> query, int maxResultCount, int skipCount = 0)
        {
            if (query == null)
            {
                throw new Exception(nameof(query));
            }

            return (skipCount < 0 || maxResultCount < 1)
                ? query
                : query.Skip(skipCount).Take(maxResultCount);
        }

        private static bool ValidateOptions(IPagingOptions pagingOptions)
        {
            if (pagingOptions != null && (pagingOptions.MaxResultCount > 0 && pagingOptions.SkipCount > -1))
            {
                return true;
            }

            return false;
        }
    }
}