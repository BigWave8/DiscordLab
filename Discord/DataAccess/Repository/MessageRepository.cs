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
    internal class MessageRepository : IMessageRepository
    {
        private readonly IDatabase _database;
        public MessageRepository(IDatabase database)
        {
            _database = database;
        }

        public async Task<IEnumerable<MessageDto>> GetAll()
        {
            IEnumerable<MessageDto> messages =
                await _database.QueryAsync<MessageDto>(SqlQueryProvider.GetAll(SqlQueryProvider.MessageTableName));

            return messages;
        }

        public async Task<MessageDto> GetById(string id)
        {
            MessageDto message = await _database.QuerySingleOrDefault<MessageDto>(SqlQueryProvider.GetById(SqlQueryProvider.MessageTableName, id));

            return message;
        }

        public async Task<string> Insert(MessageDto message)
        {
            string insertMessageSql = @"
            INSERT INTO[dbo].[Message] (id,text,time,chatId,userId)
            VALUES (@Id,@Text,@Time,@ChatId,@UserId)";
            var messageValues = new
            {
                message.Id,
                message.Text,
                message.Time,
                message.ChatId,
                message.UserId,
            };
            return await _database.ExecuteScalarAsync<string>(insertMessageSql, messageValues);
        }

        public async Task Update(MessageDto message)
        {
            string updateMessageSql = @"
            UPDATE [dbo].[Message]
            SET id = @Id
               ,text = @Text
               ,time = @Time
               ,chatId = @ChatId
               ,userId = @UserId
            WHERE id = @Id";
            var messageValues = new
            {
                message.Id,
                message.Text,
                message.Time,
                message.ChatId,
                message.UserId,
            };
            await _database.ExecuteAsync(updateMessageSql, messageValues);
        }

        public async Task Delete(string id)
        {
            await _database.ExecuteAsync(SqlQueryProvider.Delete(SqlQueryProvider.MessageTableName), new { Id = id });
        }
    }
}
