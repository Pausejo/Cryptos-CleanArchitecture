using System.Collections.Generic;

namespace Cryptos.Core.Filtering
{
    public class PagedEnumerable<T> : IPagedEnumerable<T>
    {
        public int? CurrentPage { get; set; }

        public IEnumerable<T> Items { get; set; }

        public int TotalCount { get; set; }

        public PagedEnumerable()
        {
            Items = new List<T>();
        }
    }
}