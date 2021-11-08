using Cryptos.Application.Cryptos;
using Cryptos.Application.Cryptos.Dtos;
using Cryptos.Application.Values;
using Cryptos.Application.Values.Dtos;
using Cryptos.Domain.Cryptos;
using Cryptos.Domain.Values;
using Cryptos.Infrastructure.EntityFrameworkCore;
using Cryptos.Infrastructure.EntityFrameworkCore.Cryptos;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cryptos.Tests
{
    public class ApplicationTester : IDisposable
    {
        protected readonly IServiceCollection ServiceCollection;

        protected CryptoReadingDto Crypto;

        protected ICryptoService CryptoService;

        protected IServiceProvider ServiceProvider;

        protected IValueService ValueService;

        public ApplicationTester()
        {
            ServiceCollection = new ServiceCollection();

            RegisterDependencies();

            ResolveDependencies();

            SetUp();
        }

        public void Dispose()
        {
            ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.EnsureDeleted();
        }

        protected virtual void RegisterDependencies()
        {
            var connectionInMemorySqlite = new SqliteConnection($"Data Source=:memory:");
            connectionInMemorySqlite.Open();

            ServiceCollection
                .AddTransient<IValueService, ValueService>()
                .AddTransient<IValueRepository, ValueRepository>()
                .AddTransient<ICryptoService, CryptoService>()
                .AddTransient<ICryptoRepository, CryptoRepository>()
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddDbContext<ApplicationDbContext>(options => options
                    .UseSqlite(connectionInMemorySqlite)
                    .UseLazyLoadingProxies(true));

            ServiceProvider = ServiceCollection.BuildServiceProvider();

            ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.EnsureCreated();
        }

        protected virtual void ResolveDependencies()
        {
            ValueService = ServiceProvider.GetRequiredService<IValueService>();
            CryptoService = ServiceProvider.GetRequiredService<ICryptoService>();
        }

        protected virtual void SetUp()
        {
            var value1 = new ValueCreationDto()
            {
                Amount = 1,
            };

            var value2 = new ValueCreationDto()
            {
                Amount = 2,
            };

            var Crypto1 = new CryptoCreationDto()
            {
                Name = "First fake Crypto",
                Description = "First fake Crypto for testing purposes",
            };

            Crypto = CryptoService.Insert(Crypto1);

            value1.CryptoId = Crypto.Id;
            value2.CryptoId = Crypto.Id;

            ValueService.Insert(value1);
            ValueService.Insert(value2);
        }
    }
}