using System;
using System.Collections.Generic;

namespace DBSizer.Data
{
    public interface ISqlQueryExecutor
    {
        bool ConnectionIsValid(string serverConnectionString);
        List<string> LoadDatabaseList(string serverConnectionString);
        List<TableInfo> LoadTableList(string databaseConnectionString);
        event ProgressEventHandler TableLoadProgressChanged;
    }

    public delegate void ProgressEventHandler(object sender, ProgressEventArgs args);
    public class ProgressEventArgs : EventArgs
    {
        public int ProgressValue { get; private set; }
        public ProgressEventArgs(int progressValue)
        {
            ProgressValue = progressValue;
        }
    }
}
