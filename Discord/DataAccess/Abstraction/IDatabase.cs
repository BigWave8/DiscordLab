using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.DataAccess.Abstraction
{
    public interface IDatabase
    {
        Task<IEnumerable<T>> QueryAsync<T>(string query, object queryParameters = null);
        Task<T> QuerySingleOrDefault<T>(string query, object queryParameters = null);
        Task<TResult> ExecuteScalarAsync<TResult>(string query, object queryParameters = null);
        Task<int> ExecuteAsync(string query, object queryParameters = null);
    }
}
