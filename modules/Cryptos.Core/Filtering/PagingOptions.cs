namespace Cryptos.Core.Filtering
{
    public class PagingOptions : IPagingOptions
    {
        public static int DefaultMaxResultCount { get; set; } = 10;

        public virtual int MaxResultCount { get; set; } = DefaultMaxResultCount;

        public virtual int SkipCount { get; set; }
    }
}