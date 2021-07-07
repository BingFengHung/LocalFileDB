using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalFileDatabase
{
    public interface IFileDatabase
    {
        string SchemaName { get; set; }

        bool IsSchemaExist(string schemaName);

        bool CreateTable(string tableName);

        bool InserData(string tableName);

        bool UpdateData(string tableName);

        bool DeleteData(string tableName);

        bool SelectData(string tableName);

        bool CreateSchema(string tableName);
    }
}
