using Dapper;
using MicroServices.Infra.Common.Interfaces;
using MicroServices.User.Domain.Entities;
using MicroServices.User.Domain.Interfaces;
using System;
using System.Data;
using System.Threading.Tasks;

namespace MicroServices.User.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _connection;
        private readonly ITransactionManager _transactionManager;

        public ClientRepository(IDbConnection connection, ITransactionManager transactionManager)
        {
            _connection = connection;
            _transactionManager = transactionManager;
        }

        public async Task Create(Client entity)
        {
            var sql = @"INSERT INTO CLIENT (NAME) VALUES (@NAME);
                        SELECT CAST(SCOPE_IDENTITY() as int)";

            var id = await _connection.QuerySingleOrDefaultAsync<int>(sql, new
            {
                entity.Name
            }, _transactionManager.GetCurrentTransaction());

            entity.Id = id;
        }

        public async Task Delete(object id)
        {
            var sql = "DELETE FROM CLIENT WHERE ID = @ID";

            var a = await _connection.ExecuteAsync(sql, new { id }, _transactionManager.GetCurrentTransaction());
        }

        public async Task<Client> Get(object id)
        {
            var sql = "SELECT * FROM CLIENT WHERE ID = @ID";

            return await _connection.QuerySingleOrDefaultAsync<Client>(sql, new { id }, _transactionManager.GetCurrentTransaction());
        }

        public async Task Update(object id, Client entity)
        {
            var sql = "UPDATE CLIENT SET NAME = @NAME WHERE ID = @ID";

            var a = await _connection.ExecuteAsync(sql, new
            {
                id,
                entity.Name
            }, _transactionManager.GetCurrentTransaction());
        }
    }
}
