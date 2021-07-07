using System;
using System.IO;

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

        public bool DeleteData(string tableName)
        {
            throw new NotImplementedException();
        }

        public bool InserData(string tableName)
        {
            throw new NotImplementedException();
        }

        public bool IsSchemaExist(string schemaName)
        {
            throw new NotImplementedException();
        }

        public bool SelectData(string tableName)
        {
            throw new NotImplementedException();
        }

        public bool UpdateData(string tableName)
        {
            throw new NotImplementedException();
        }

        public bool IsTableExist(string tableName)
        {
            return File.Exists(Path.Combine(SchemaName, tableName));
        }

        #endregion
    }
}
