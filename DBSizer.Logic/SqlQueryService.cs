namespace DBSizer.Data
{
    public static class SqlQueryService
    {
        private static ISqlQueryExecutor _mock;
        public static ISqlQueryExecutor CreateSqlQueryService()
        {
            if (_mock != null)
                return _mock;
            return new SqlQueryExecutor();
        }

        public static void SetMock(ISqlQueryExecutor mock)
        {
            _mock = mock;
        }
    }
}