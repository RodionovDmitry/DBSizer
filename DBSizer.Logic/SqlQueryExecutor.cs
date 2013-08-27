using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DBSizer.Data
{
    internal class SqlQueryExecutor : ISqlQueryExecutor
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
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dbNames.Add(reader.GetString(0));
                    }
                }
                return dbNames;
            }
        }

        public List<TableInfo> LoadTableList(string databaseConnectionString, IProgressable progress)
        {
            List<TableInfo> _tables;
            using (var conn = new SqlConnection(databaseConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(SqlQueries.QUERY_ALL_TABLES, conn);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    _tables = new List<TableInfo>();
                    while (sdr.Read())
                    {
                        _tables.Add(new TableInfo((string) sdr[0], (string) sdr[1]));
                    }
                }
            }

            if (progress != null)
            {
                progress.SetMaximumProgress(_tables.Count);
            }
            using (var conn = new SqlConnection(databaseConnectionString))
            {
                conn.Open();
                foreach (TableInfo ti in _tables)
                {
                    var cmd = new SqlCommand(string.Format(SqlQueries.QUERY_DATA_SIZE, ti.Name, ti.Schema), conn);
                    cmd.CommandTimeout = 60000;
                    ti.DataSizeBytes = (double) cmd.ExecuteScalar();
                    cmd.CommandText = string.Format(SqlQueries.QUERY_INDEX_SIZE, ti.Name, ti.Schema);
                    ti.IndexSizeBytes = (double) cmd.ExecuteScalar();
                    cmd.CommandText = string.Format(SqlQueries.QUERY_ROW_COUNT, ti.Name, ti.Schema);
                    ti.RowCount = (long) cmd.ExecuteScalar();
                    if (progress != null)
                    {
                        progress.IncProgress();
                    }
                }
            }
            return _tables;
        }
    }
}