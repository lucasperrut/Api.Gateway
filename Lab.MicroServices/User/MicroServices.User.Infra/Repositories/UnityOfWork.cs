using MicroServices.User.Domain.Interfaces;
using System;
using System.Data;

namespace MicroServices.User.Infra.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly IDbConnection _dbConnection;
        private IDbTransaction _dbTransaction;

        public UnityOfWork(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IClientRepository ClientRepository => new ClientRepository(_dbConnection, this);

        public IDisposable BeginTrarnsaction()
        {
            _dbTransaction?.Dispose();

            if (_dbConnection.State != ConnectionState.Open)
                _dbConnection.Open();

            _dbTransaction = _dbConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            return _dbTransaction;
        }

        public void Commit()
        {
            _dbTransaction?.Commit();
        }

        public void Dispose()
        {
            if (_dbTransaction != null)
            {
                _dbTransaction.Dispose();
                _dbTransaction = null;
            }
        }

        public IDbTransaction GetCurrentTransaction()
        {
            return _dbTransaction;
        }

        public void RollBack()
        {
            _dbTransaction?.Rollback();
        }
    }
}
