using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalFileDatabase
{
    /// <summary>
    /// Database fetch api interface
    /// </summary>
    /// <typeparam name="T">enum type column name</typeparam>
    /// <typeparam name="C">enum type column value></typeparam>  
    public interface IDatabaseFetch<T, C>
        where T : Enum
        where C : Enum
    {
        T TableName { get; set; }

        void CreateTable();

        bool InsertData(T column, string value);

        bool SelectData(T column, out string value);

        bool UpdateData(T column, string value);

        bool DeleteData(T column);
    }

    public class DatabaseFetch<T, C> : IDatabaseFetch<T, C>
        where T : Enum
        where C : Enum
    {
        #region Fields

        IFileDatabase database;

        #endregion


        #region Constructors

        public DatabaseFetch(T tableName, IFileDatabase database)
        {
            this.database = database;
        }

        #endregion

        #region Properties

        public T TableName { get; set; }

        #endregion

        #region Methods

        public void CreateTable()
        {
            database.CreateTable($"{TableName}");
        }

        public bool DeleteData(T column)
        {
            return database.DeleteData($"{TableName}", $"{column}");
        }

        public bool InsertData(T column, string value)
        {
            return database.InserData($"{TableName}", $"{column}", value);
        }

        public bool SelectData(T column, out string value)
        {
            return database.SelectData($"{TableName}", $"{column}", out value);
        }

        public bool UpdateData(T column, string value)
        {
            return database.UpdateData($"{TableName}", $"{column}", value);
        }

        #endregion
    }
}
