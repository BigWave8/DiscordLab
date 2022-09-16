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
    internal class ChatRepository : IChatRepository
    {
        private readonly IDatabase _database;
        public ChatRepository(IDatabase database)
        {
            _database = database;
        }

        public async Task<IEnumerable<ChatDto>> GetAll()
        {
            IEnumerable<ChatDto> chats =
                await _database.QueryAsync<ChatDto>(SqlQueryProvider.GetAll(SqlQueryProvider.ChatTableName));

            return chats;
        }

        public async Task<ChatDto> GetById(string id)
        {
            ChatDto chat = await _database.QuerySingleOrDefault<ChatDto>(SqlQueryProvider.GetById(SqlQueryProvider.ChatTableName, id));

            return chat;
        }

        public async Task<string> Insert(ChatDto chat)
        {
            string insertChatSql = @"
            INSERT INTO[dbo].[Chat] (id,name,serverId)
            VALUES (@Id,@Name,@ServerId)";
            var chatValues = new
            {
                chat.Id,
                chat.Name,
                chat.ServerId
            };
            return await _database.ExecuteScalarAsync<string>(insertChatSql, chatValues);
        }

        public async Task Update(ChatDto chat)
        {
            string updateChatSql = @"
            UPDATE [dbo].[Chat]
            SET id = @Id
               ,name = @Name
               ,serverId = @ServerId
            WHERE id = @Id";
            var chatValues = new
            {
                chat.Id,
                chat.Name,
                chat.ServerId
            };
            await _database.ExecuteAsync(updateChatSql, chatValues);
        }

        public async Task Delete(string id)
        {
            await _database.ExecuteAsync(SqlQueryProvider.Delete(SqlQueryProvider.ChatTableName), new { Id = id });
        }
    }
}
