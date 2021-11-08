using System;

namespace Cryptos.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();
    }
}