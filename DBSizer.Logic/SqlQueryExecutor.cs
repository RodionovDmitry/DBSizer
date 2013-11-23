using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DBSizer.Data
{
    public class SqlQueryExecutor : ISqlQueryExecutor
    {
        public bool ConnectionIsValid(string serverConnectionString)
        {
            using (var conn = new SqlConnection(serverConnectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public List<string> LoadDatabaseList(string serverConnectionString)
        {
            using (var conn = new SqlConnection(serverConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(SqlQueries.QUERY_ALL_DATABASES, conn);
                var dbNames = new List<string>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dbNames.Add(reader.GetString(0));
                    }
                }
                return dbNames;
            }
        }

        public List<TableInfo> LoadTableList(string databaseConnectionString)
        {
            List<TableInfo> tables;
            using (var conn = new SqlConnection(databaseConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(SqlQueries.QUERY_ALL_TABLES, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    tables = new List<TableInfo>();
                    while (reader.Read())
                    {
                        tables.Add(new TableInfo(reader.GetString(0), reader.GetString(1)));
                    }
                }
                int tableCount = 0;
                foreach (var tableInfo in tables)
                {
                    cmd = new SqlCommand(string.Format(SqlQueries.QUERY_DATA_SIZE, tableInfo.Name, tableInfo.Schema), conn);
                    cmd.CommandTimeout = 60000;
                    tableInfo.DataSizeBytes = (double) cmd.ExecuteScalar();
                    cmd.CommandText = string.Format(SqlQueries.QUERY_INDEX_SIZE, tableInfo.Name, tableInfo.Schema);
                    tableInfo.IndexSizeBytes = (double) cmd.ExecuteScalar();
                    cmd.CommandText = string.Format(SqlQueries.QUERY_ROW_COUNT, tableInfo.Name, tableInfo.Schema);
                    tableInfo.RowCount = (long) cmd.ExecuteScalar();
                    OnTableLoadProgressChanged(new ProgressEventArgs(tableCount++*100 / tables.Count));
                }
            }
            return tables;
        }

        /// <summary>
        /// Reports loading progress in percent (0 to 100)
        /// </summary>
        public event ProgressEventHandler TableLoadProgressChanged;

        protected virtual void OnTableLoadProgressChanged(ProgressEventArgs args)
        {
            ProgressEventHandler handler = TableLoadProgressChanged;
            if (handler != null) handler(this, args);
        }
    }
}