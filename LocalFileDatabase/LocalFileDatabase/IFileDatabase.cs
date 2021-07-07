namespace LocalFileDatabase
{
    public interface IFileDatabase
    {
        string SchemaName { get; set; }

        bool IsSchemaExist(string schemaName);

        bool CreateTable(string tableName);

        bool IsTableExist(string tableName);

        bool IsColumnNameExist(string schema, string tableName, string columnName);

        bool InserData(string tableName, string titleName, string data);

        bool UpdateData(string tableName, string titleName, string data);

        bool DeleteData(string tableName, string titleName);

        bool SelectData(string tableName, string titleName, out string data);

        bool CreateSchema(string tableName);
    }
}
