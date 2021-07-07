namespace LocalFileDatabase
{
    public interface IFileDatabase
    {
        string SchemaName { get; set; }

        bool IsSchemaExist(string schemaName);

        bool CreateTable(string tableName);

        bool IsTableExist(string tableName);

        bool IsColumnNameExist(string schema, string tableName, string columnName);

        bool InserData(string tableName, string columnName, string columnValue);

        bool UpdateData(string tableName, string columnName, string columnValue);

        bool DeleteData(string tableName, string columnName);

        bool SelectData(string tableName, string columnName, out string columnValue);

        bool CreateSchema(string tableName);
    }
}
