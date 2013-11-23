namespace DBSizer.Data
{
    public interface IDBInfoBuilder
    {
        IDBInfo Create(string connectionString, string dbName);
    }

    public class DBInfoBuilder : IDBInfoBuilder
    {
        public IDBInfo Create(string connectionString, string dbName)
        {
            return new DBInfo(connectionString, dbName);
        }
    }
}