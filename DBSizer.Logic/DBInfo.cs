using System;
using System.Data.SqlClient;

namespace DBSizer.Data
{
    /// <summary>
    /// Descriptor of the Database
    /// </summary>
    public class DBInfo
    {
        public double DataSizeMB { get; set; }
        public double LogSizeMB { get; set; }
        public double TotalSizeMB
        {
            get { return DataSizeMB + LogSizeMB; }
        }
        public string Name { get; private set; }
        private readonly bool _infoGathered;

        public DBInfo(string connString, string name)
        {
            Name = name;
            using (var conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SqlQueries.QUERY_DB_SIZE, conn);
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            _infoGathered = true;
                            DataSizeMB = Math.Round(sdr.GetDouble(0) / 1024.0);
                            LogSizeMB = Math.Round(sdr.GetDouble(1)/1024.0);
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