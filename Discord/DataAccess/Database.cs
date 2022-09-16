using Dapper;
using Discord.DataAccess.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.DataAccess
{
    public class Database : IDatabase
    {
        private const int CommandTimeoutSeconds = 3000;
        private readonly string _connectionString;

        public Database(string connectionStringString)
        {
            _connectionString = connectionStringString;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object? queryParameters = null)
        {
            var connection = await GetDatabaseConnection();

            CommandDefinition command = new(
                query,
                queryParameters,
                commandType: CommandType.Text,
                commandTimeout: CommandTimeoutSeconds);
            try
            {
                IEnumerable<T> result = (await connection.QueryAsync<T>(command)).ToList();

                return result;
            }
            catch (SqlException sqlException) when (sqlException.Message.Contains("Operation cancelled by user."))
            {
                throw new OperationCanceledException();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public async Task<T> QuerySingleOrDefault<T>(string query, object? queryParameters = null)
        {
            var connection = await GetDatabaseConnection();

            CommandDefinition command = new(
                query,
                queryParameters,
                commandType: CommandType.Text,
                commandTimeout: CommandTimeoutSeconds);
            try
            {
                return connection.QuerySingleOrDefault<T>(command);
            }
            catch (SqlException sqlException) when (sqlException.Message.Contains("Operation cancelled by user."))
            {
                throw new OperationCanceledException();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        public async Task<int> ExecuteAsync(string query, object? queryParameters = null)
        {
            var connection = await GetDatabaseConnection();

            CommandDefinition command = new(
                query,
                queryParameters,
                commandType: CommandType.Text,
                commandTimeout: CommandTimeoutSeconds);

            int result;
            try
            {
                result = await connection.ExecuteAsync(command);
            }
            catch (SqlException sqlException) when (sqlException.Message.Contains("Operation cancelled by user."))
            {
                throw new OperationCanceledException();
            }
            finally
            {
                await connection.DisposeAsync();
            }
            return result;
        }

        public async Task<TResult> ExecuteScalarAsync<TResult>(string query, object? queryParameters = null)
        {
            var connection = await GetDatabaseConnection();

            var command = new CommandDefinition(
                query,
                queryParameters,
                commandType: CommandType.Text,
                commandTimeout: CommandTimeoutSeconds);
            try
            {
                return await connection.ExecuteScalarAsync<TResult>(command);
            }
            catch (SqlException sqlException) when (sqlException.Message.Contains("Operation cancelled by user."))
            {
                throw new OperationCanceledException();
            }
            finally
            {
                await connection.DisposeAsync();
            }
        }

        private async Task<SqlConnection> GetDatabaseConnection()
        {
            SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
