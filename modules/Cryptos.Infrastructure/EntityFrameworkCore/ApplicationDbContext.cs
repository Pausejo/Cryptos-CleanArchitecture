using Cryptos.Domain.Cryptos;
using Cryptos.Domain.Values;
using Microsoft.EntityFrameworkCore;

namespace Cryptos.Infrastructure.EntityFrameworkCore
{
    public  class ApplicationDbContext : DbContext
    {
        public DbSet<Crypto> Cryptos { get; set; }

        public DbSet<Value> Values { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}