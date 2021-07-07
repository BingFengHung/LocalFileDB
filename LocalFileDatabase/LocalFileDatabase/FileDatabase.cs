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

        public bool DeleteData(string tableName, string titleName)
        {
            try
            {
                var path = Path.Combine(SchemaName, tableName);
                var textLines = File.ReadLines(path).ToList();

                var index = textLines.IndexOf($"[{titleName}]");

                // Remove twice beacuse need to remove column value as well.
                textLines.RemoveAt(index);
                textLines.RemoveAt(index);

                File.WriteAllLines(path, textLines);

                return true;
            }
            catch { return false; }
        }

        public bool InserData(string tableName, string titleName, string data)
        {
            try
            {
                string path = Path.Combine(SchemaName, tableName);

                if (!IsColumnNameExist(SchemaName, tableName, tableName))
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine($"[{titleName}]");
                        sw.WriteLine(data);
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

        public bool SelectData(string tableName, string titleName, out string data)
        {
            data = string.Empty;

            try
            {

                var path = Path.Combine(SchemaName, tableName);

                var textLines = File.ReadLines(path).ToList();

                var index = textLines.IndexOf($"{textLines}");

                data = textLines[index + 1];

                return true;
            }
            catch { return false; }
        }

        public bool UpdateData(string tableName, string titleName, string data)
        {
            var path = Path.Combine(SchemaName, tableName);

            var textLines = File.ReadLines(path).ToList();

            var index = textLines.IndexOf($"[{titleName}]");

            textLines.RemoveAt(index + 1);
            textLines.Insert(index + 1, data);
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
