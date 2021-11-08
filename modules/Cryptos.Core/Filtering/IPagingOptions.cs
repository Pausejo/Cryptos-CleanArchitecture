namespace Cryptos.Core.Filtering
{
    public interface IPagingOptions
    {
        int MaxResultCount { get; set; }

        int SkipCount { get; set; }
    }
}