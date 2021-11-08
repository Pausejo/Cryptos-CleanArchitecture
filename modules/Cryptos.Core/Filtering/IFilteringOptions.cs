namespace Cryptos.Core.Filtering
{
    public interface IFilteringOptions : IPagingOptions
    {
        string Keyword { get; set; }
    }
}