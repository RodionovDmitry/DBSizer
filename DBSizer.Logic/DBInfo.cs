using System;
using System.Data.SqlClient;

namespace DBSizer.Data
{
    /// <summary>
    /// Descriptor of the Database
    /// </summary>
    public interface IDBInfo
    {
        double DataSizeMB { get; }
        double LogSizeMB { get; }
        double TotalSizeMB { get; }
        string Name { get; }
        string ConnString { get; }
        string ToString();
    }

    /// <summary>
    /// Implementation made internal for testing purposes
    /// </summary>
    internal class DBInfo : IDBInfo
    {
        public double DataSizeMB { get; private  set; }
        public double LogSizeMB { get; private set; }
        public double TotalSizeMB
        {
            get { return DataSizeMB + LogSizeMB; }
        }
        public string Name { get; private set; }
        private readonly bool _infoGathered;
        public string ConnString { get; private set; }

        internal DBInfo(string connString, string name)
        {
            Name = name;
            ConnString = connString;
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    var cmd = new SqlCommand(SqlQueries.QUERY_DB_SIZE, conn);
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            DataSizeMB = Math.Round(sdr.GetDouble(0) / 1024.0);
                            LogSizeMB = Math.Round(sdr.GetDouble(1)/1024.0);
                            _infoGathered = true;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        
        public override string ToString()
        {
            if (_infoGathered)
            {
                return Name + string.Format(" (data size - {0} MB; log size - {1} MB", Math.Round(DataSizeMB, 2), Math.Round(LogSizeMB, 2));
            }
            else
            {
                return Name + " (size unknown)";
            }
        }
    }
}