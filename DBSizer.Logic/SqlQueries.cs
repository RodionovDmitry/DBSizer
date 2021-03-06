namespace DBSizer.Data
{
    internal class SqlQueries
    {
        public const string QUERY_ALL_DATABASES = @"select name from sys.databases order by 1";
        public const string QUERY_ALL_TABLES = @"
SELECT
tbl.name AS [Name],
SCHEMA_NAME(tbl.schema_id) AS [Schema]
FROM
sys.tables AS tbl
WHERE
(CAST(
 case 
    when tbl.is_ms_shipped = 1 then 1
    when (
        select 
            major_id 
        from 
            sys.extended_properties 
        where 
            major_id = tbl.object_id and 
            minor_id = 0 and 
            class = 1 and 
            name = N'microsoft_database_tools_support') 
        is not null then 1
    else 0
end          
             AS bit)=0)
ORDER BY
[Schema] ASC,[Name] desc";

        public const string QUERY_DATA_SIZE = @"declare @PageSize float 
select @PageSize=v.low/1024.0 from master.dbo.spt_values v where v.number=1 and v.type='E'

SELECT
ISNULL((select @PageSize * SUM(CASE WHEN alloc.type <> 1 THEN alloc.used_pages WHEN parts.index_id < 2 THEN alloc.data_pages ELSE 0 END) 
FROM sys.indexes as ind
JOIN sys.partitions as parts ON parts.object_id = ind.object_id and parts.index_id = ind.index_id
JOIN sys.allocation_units as alloc ON alloc.container_id = parts.partition_id
where ind.object_id = tbl.object_id),0.0) AS [DataSpaceUsed]
FROM
sys.tables AS tbl
WHERE
(tbl.name=N'{0}' and SCHEMA_NAME(tbl.schema_id)=N'{1}')";
        public const string QUERY_ROW_COUNT = @"SELECT
ISNULL( ( select sum (spart.rows) from sys.partitions spart where spart.object_id = tbl.object_id and spart.index_id < 2), 0) AS [RowCount]
FROM
sys.tables AS tbl
INNER JOIN sys.indexes AS idx ON idx.object_id = tbl.object_id and idx.index_id < 2
--LEFT OUTER JOIN sys.data_spaces AS dstext  ON tbl.lob_data_space_id = dstext.data_space_id
--LEFT OUTER JOIN sys.data_spaces AS dsidx ON dsidx.data_space_id = idx.data_space_id
WHERE
(tbl.name=N'{0}' and SCHEMA_NAME(tbl.schema_id)=N'{1}')";
        public const string QUERY_INDEX_SIZE = @"declare @PageSize float 
select @PageSize=v.low/1024.0 from master.dbo.spt_values v where v.number=1 and v.type='E'
SELECT
ISNULL((select @PageSize * SUM(alloc.used_pages - CASE WHEN alloc.type <> 1 THEN alloc.used_pages WHEN parts.index_id < 2 THEN alloc.data_pages ELSE 0 END) 
FROM sys.indexes as ind
JOIN sys.partitions as parts ON parts.object_id = ind.object_id and parts.index_id = ind.index_id
JOIN sys.allocation_units as alloc ON alloc.container_id = parts.partition_id
where ind.object_id = tbl.object_id),0.0) AS [IndexSpaceUsed]
FROM
sys.tables AS tbl
WHERE
(tbl.name=N'{0}' and SCHEMA_NAME(tbl.schema_id)=N'{1}')";
        public const string QUERY_DB_SIZE = @"SELECT
CAST(ISNULL((select sum(df.size)*convert(float,8) from sys.database_files df where df.data_space_id = fg.data_space_id and type = 0), 0) AS float) AS [SizeData],
CAST(ISNULL((select sum(df.size)*convert(float,8) from sys.database_files df where type = 1), 0) AS float) AS [SizeLog]
FROM
sys.filegroups AS fg
ORDER BY
[Name] ASC
";
    }
}
