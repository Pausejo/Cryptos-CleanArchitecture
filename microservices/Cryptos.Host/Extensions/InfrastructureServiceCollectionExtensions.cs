using Cryptos.Application.Cryptos;
using Cryptos.Application.Values;
using Cryptos.Domain.Cryptos;
using Cryptos.Domain.UnitOfWork;
using Cryptos.Domain.Values;
using Cryptos.Infrastructure.EntityFrameworkCore;
using Cryptos.Infrastructure.EntityFrameworkCore.Cryptos;
using Cryptos.Infrastructure.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cryptos.Host.Extensions
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static void AddInfrastructureDependencies(this IServiceCollection services, string SqliteConnectionString)
        {
            services.AddTransient<ICryptoRepository, CryptoRepository>();

            services.AddTransient<IValueRepository, ValueRepository>();

            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork<ApplicationDbContext>>();

            services.AddDbContext<ApplicationDbContext>(o => {
                o.UseSqlite(SqliteConnectionString);
                o.UseLazyLoadingProxies(true);
            });
        }
    }
}