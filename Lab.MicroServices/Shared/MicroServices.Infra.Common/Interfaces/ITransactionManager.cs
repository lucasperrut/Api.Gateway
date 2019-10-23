using System;
using System.Data;

namespace MicroServices.Infra.Common.Interfaces
{
    public interface ITransactionManager : IDisposable
    {
        IDisposable BeginTrarnsaction();
        void Commit();
        void RollBack();
        IDbTransaction GetCurrentTransaction();
    }
}
