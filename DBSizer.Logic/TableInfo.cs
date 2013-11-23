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

    public enum Characteristic
    {
        DataSize = 1,
        IndexSize,
        RowCount
    }

    public class TableInfoViewItem
    {
        public string TableName { get; private set; }
        public double Value { get; private set; }
        public TableInfoViewItem(TableInfo tableInfo, Characteristic characteristic)
        {
            TableName = tableInfo.Schema + "." + tableInfo.Name;
            if (characteristic == Characteristic.DataSize)
            {
                Value = tableInfo.DataSizeMB;
            }
            else if (characteristic == Characteristic.IndexSize)
            {
                Value = tableInfo.IndexSizeMB;
            }
            else if (characteristic == Characteristic.RowCount)
            {
                Value = tableInfo.RowCount;
            }
            else
            {
                throw new ArgumentException("unknown value of characteristic", "characteristic");
            }
        }
    }

    public class DataSizeComparer : IComparer<TableInfo>
    {
        public int Compare(TableInfo x, TableInfo y)
        {
            return x.DataSizeMB.CompareTo(y.DataSizeMB);
        }
    }

    public class IndexSizeComparer : IComparer<TableInfo>
    {
        public int Compare(TableInfo x, TableInfo y)
        {
            return  x.IndexSizeMB.CompareTo(y.IndexSizeMB);
        }
    }

    public class RowCountComparer : IComparer<TableInfo>
    {
        public int Compare(TableInfo x, TableInfo y)
        {
            return x.RowCount.CompareTo(y.RowCount);
        }
    }
}
