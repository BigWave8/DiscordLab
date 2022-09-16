using Discord.DataAccess.Abstraction;
using Discord.Dto;
using Discord.Interfaces.Repository;
using Discord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabase _database;
        public UserRepository(IDatabase database)
        {
            _database = database;
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<UserDto> users =
                await _database.QueryAsync<UserDto>(SqlQueryProvider.GetAll(SqlQueryProvider.UserTableName));

            return users;
        }

        public async Task<UserDto> GetById(string id)
        {
            UserDto user = await _database.QuerySingleOrDefault<UserDto>(SqlQueryProvider.GetById(SqlQueryProvider.UserTableName, id));

            return user;
        }

        public async Task<string> Insert(UserDto user)
        {
            string insertUserSql = @"
            INSERT INTO[dbo].[User] (id,name,microOn,soundOn,chatId)
            VALUES (@Id,@Name,@MicroOn,@SoundOn,@ChatId)";
            var userValues = new
            {
                user.Id,
                user.Name,
                user.MicroOn,
                user.SoundOn,
                user.ChatId,
            };
            return await _database.ExecuteScalarAsync<string>(insertUserSql, userValues);
        }

        public async Task Update(UserDto user)
        {
            string updateUserSql = @"
            UPDATE [dbo].[User]
            SET id = @Id
               ,name = @Name
               ,microOn = @MicroOn
               ,soundOn = @SoundOn
               ,chatId = @ChatId
            WHERE id = @Id";
            var userValues = new
            {
                user.Id,
                user.Name,
                user.MicroOn,
                user.SoundOn,
                user.ChatId,
            };
            await _database.ExecuteAsync(updateUserSql, userValues);
        }

        public async Task Delete(string id)
        {
            await _database.ExecuteAsync(SqlQueryProvider.Delete(SqlQueryProvider.UserTableName), new { Id = id });
        }
    }
}
