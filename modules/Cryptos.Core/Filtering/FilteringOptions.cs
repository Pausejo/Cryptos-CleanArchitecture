namespace Cryptos.Core.Filtering
{
    public class FilteringOptions : PagingOptions, IFilteringOptions
    {
        public virtual string Keyword { get; set; }

        public FilteringOptions()
        {
        }

        public FilteringOptions(IPagingOptions options)
        {
            MaxResultCount = options?.MaxResultCount ?? DefaultMaxResultCount;
            SkipCount = options?.SkipCount ?? 0;
        }
    }
}