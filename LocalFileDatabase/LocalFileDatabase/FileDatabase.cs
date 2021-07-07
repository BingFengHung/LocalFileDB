using System;
using System.IO;
using System.Linq;

namespace LocalFileDatabase
{
    public class FileDatabase : IFileDatabase
    {
        #region Properties

        public string SchemaName { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructors
        /// </summary>
        /// <param name="schemaName"></param>
        public FileDatabase(string schemaName)
        {
            SchemaName = schemaName;
        }

        #endregion

        #region Methods

        public bool CreateSchema(string schemaName)
        {
            bool isExist = IsSchemaExist(schemaName);

            // If not exist create directory in root project
            if (!isExist)
                Directory.CreateDirectory(schemaName);

            return true;
        }

        public bool CreateTable(string tableName)
        {
            try
            {
                var path = Path.Combine(SchemaName, tableName);

                if (!IsTableExist(tableName))
                    File.Create(path);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteData(string tableName, string columnName)
        {
            try
            {
                var path = Path.Combine(SchemaName, tableName);
                var textLines = File.ReadLines(path).ToList();

                var index = textLines.IndexOf($"[{columnName}]");

                // Remove twice beacuse need to remove column value as well.
                textLines.RemoveAt(index);
                textLines.RemoveAt(index);

                File.WriteAllLines(path, textLines);

                return true;
            }
            catch { return false; }
        }

        public bool InserData(string tableName, string columnName, string columnValue)
        {
            try
            {
                string path = Path.Combine(SchemaName, tableName);

                if (!IsColumnNameExist(SchemaName, tableName, tableName))
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine($"[{columnName}]");
                        sw.WriteLine(columnValue);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsColumnNameExist(string schema, string tableName, string columnName)
        {
            string path = Path.Combine(schema, tableName);

            var textLines = File.ReadAllLines(path);

            return textLines.Contains($"[{columnName}]");
        }

        public bool IsSchemaExist(string schemaName)
        {
            return Directory.Exists(schemaName);
        }

        public bool SelectData(string tableName, string columnName, out string columnValue)
        {
            columnValue = string.Empty;

            try
            {

                var path = Path.Combine(SchemaName, tableName);

                var textLines = File.ReadLines(path).ToList();

                var index = textLines.IndexOf($"{textLines}");

                columnValue = textLines[index + 1];

                return true;
            }
            catch { return false; }
        }

        public bool UpdateData(string tableName, string columnName, string columnValue)
        {
            var path = Path.Combine(SchemaName, tableName);

            var textLines = File.ReadLines(path).ToList();

            var index = textLines.IndexOf($"[{columnName}]");

            textLines.RemoveAt(index + 1);
            textLines.Insert(index + 1, columnValue);
            File.WriteAllLines(path, textLines);

            return true;
        }

        public bool IsTableExist(string tableName)
        {
            return File.Exists(Path.Combine(SchemaName, tableName));
        }

        #endregion
    }
}
