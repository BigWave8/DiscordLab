using Discord.Dto;
using Discord.DataAccess.Abstraction;
using Discord.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.DataAccess.Repository
{
    internal class ServerRepository : IServerRepository
    {
        private readonly IDatabase _database;
        public ServerRepository(IDatabase database)
        {
            _database = database;
        }

        public async Task<IEnumerable<ServerDto>> GetAll()
        {
            IEnumerable<ServerDto> servers =
                await _database.QueryAsync<ServerDto>(SqlQueryProvider.GetAll(SqlQueryProvider.ServerTableName));

            return servers;
        }

        public async Task<ServerDto> GetById(string id)
        {
            ServerDto server = await _database.QuerySingleOrDefault<ServerDto>(SqlQueryProvider.GetById(SqlQueryProvider.ServerTableName, id));

            return server;
        }

        public async Task<string> Insert(ServerDto server)
        {
            string insertServerSql = @"
            INSERT INTO[dbo].[Server] (id,name)
            VALUES (@Id,@Name)";
            var serverValues = new
            {
                server.Id,
                server.Name,
            };
            return await _database.ExecuteScalarAsync<string>(insertServerSql, serverValues);
        }

        public async Task Update(ServerDto server)
        {
            string updateServerSql = @"
            UPDATE [dbo].[Server]
            SET id = @Id
               ,name = @Name
            WHERE id = @Id";
            var serverValues = new
            {
                server.Id,
                server.Name
            };
            await _database.ExecuteAsync(updateServerSql, serverValues);
        }

        public async Task Delete(string id)
        {
            await _database.ExecuteAsync(SqlQueryProvider.Delete(SqlQueryProvider.ServerTableName), new { Id = id });
        }
    }
}
