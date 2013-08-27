using System;
using System.Collections.Generic;

namespace DBSizer.Data
{
    /// <summary>
    /// Description of the table
    /// </summary>
    public class TableInfo
    {
        public string Name { get; private set; }
        /// <summary>
        /// Like "[dbo]"
        /// </summary>
        public string Schema { get; private set; }
        /// <summary>
        /// Number of rows
        /// </summary>
        public long RowCount { get; set; }

        public double DataSizeBytes { get; set; }
        public double DataSizeMB
        {
            get
            {
                return Math.Round(DataSizeBytes / 1024.0, 2);
            }
        }
        public double IndexSizeBytes { get; set; }
        public double IndexSizeMB
        {
            get
            {
                return Math.Round(IndexSizeBytes / 1024.0, 2);
            }
        }

        public TableInfo(string name, string schema)
        {
            Name = name;
            Schema = schema;
        }
    }

    public enum DataToDisplay
    {
        DataSize = 1,
        IndexSize,
        RowCount
    }

    public class TableInfoViewItem
    {
        public string TableName { get; private set; }
        public double Value { get; private set; }
        public TableInfoViewItem(TableInfo tableInfo, DataToDisplay dataToDisplay)
        {
            TableName = tableInfo.Schema + "." + tableInfo.Name;
            if (dataToDisplay == DataToDisplay.DataSize)
            {
                Value = tableInfo.DataSizeMB;
            }
            else if (dataToDisplay == DataToDisplay.IndexSize)
            {
                Value = tableInfo.IndexSizeMB;
            }
            else if (dataToDisplay == DataToDisplay.RowCount)
            {
                Value = tableInfo.RowCount;
            }
            else
            {
                throw new ArgumentException("unknown value of DataToDisplay", "dataToDisplay");
            }
        }
    }

    public class DataSizeComparer : IComparer<TableInfo>
    {
        public int Compare(TableInfo x, TableInfo y)
        {
            return -1 * x.DataSizeMB.CompareTo(y.DataSizeMB);
        }
    }

    public class IndexSizeComparer : IComparer<TableInfo>
    {
        public int Compare(TableInfo x, TableInfo y)
        {
            return -1 * x.IndexSizeMB.CompareTo(y.IndexSizeMB);
        }
    }

    public class RowCountComparer : IComparer<TableInfo>
    {
        public int Compare(TableInfo x, TableInfo y)
        {
            return -1 * x.RowCount.CompareTo(y.RowCount);
        }
    }
}
