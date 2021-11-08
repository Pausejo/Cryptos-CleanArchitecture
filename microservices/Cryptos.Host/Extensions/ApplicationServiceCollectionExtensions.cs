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
    public static class ApplicationServiceCollectionExtensions
    {
        public static void AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<ICryptoService, CryptoService>();

            services.AddTransient<IValueService, ValueService>();
        }
    }
}