using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBSizer.Data
{
    public class ConnectionStringBuilder
    {
        private const string CONN_SQL = "Data Source={0};Initial Catalog={1};User ID={2};Password = {3}";
        private const string CONN_WIN = "Data Source={0};Initial Catalog={1};integrated security=SSPI;";

        public static string ConnectionStringCreate(IConnectionSettings settings,  string databaseName)
        {
            if (settings.AuthMode == SqlAuthMode.SqlServer)
            {
                return string.Format(CONN_SQL, settings.ServerName, databaseName, settings.UserName, settings.Password);
            }
            return string.Format(CONN_WIN, settings.ServerName, databaseName);
        }
        public static string MasterDBConnectionStringCreate(IConnectionSettings settings)
        {
            return ConnectionStringCreate(settings, "master");
        }
    }

    public interface IConnectionSettings
    {
        string ServerName { get; }
        string UserName { get; }
        string Password { get; }
        SqlAuthMode AuthMode { get; }
    }
}
