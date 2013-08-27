using System.Collections.Generic;

namespace DBSizer.Data
{
    public interface ISqlQueryExecutor
    {
        bool ConnectionIsValid(string serverConnectionString);
        List<string> LoadDatabaseList(string serverConnectionString);
        List<TableInfo> LoadTableList(string databaseConnectionString, IProgressable progress);
    }
}