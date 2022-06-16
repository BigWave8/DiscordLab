using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord.DataAccess
{
    internal static class SqlQueryProvider
    {
        public const string UserTableName = "[Discord].[dbo].[User]";
        public const string ServerTableName = "[Discord].[dbo].[Server]";
        public const string ServerUserTableName = "[Discord].[dbo].[Server_User]";
        public const string ChatTableName = "[Discord].[dbo].[Chat]";
        public const string MessageTableName = "[Discord].[dbo].[Message]";

        public static string GetAll(string table) => $@"SELECT * FROM {table}";
        public static string GetById(string table, string id) => $@"SELECT * FROM {table} WHERE Id = '{id}'";
        public static string Delete(string table) => $@"DELETE FROM {table} WHERE id = @Id";
    }
}
