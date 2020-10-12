using Gbso.Core.Enumerators;
using System;

namespace Gbso.Core
{
    public class DatabasePropertyInfo : Attribute
    {
        /// <summary>
        /// Column name in database
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// Type column in table
        /// </summary>
        public SqlTypesColumn TypeColumn { get; set; }

        /// <summary>
        /// Indicates if is an unique index
        /// </summary>
        public bool IsUniqueIndex { get; set; }
        
        /// <summary>
        /// Property descripction withh references to the database
        /// </summary>
        /// <param name="columnName">Column name in the database</param>
        /// <param name="typeColumn">Column type in the database</param>
        /// <param name="isUniqueIndex">Indicates if is an unique index</param>
        public DatabasePropertyInfo(string columnName, SqlTypesColumn typeColumn = SqlTypesColumn.Default, bool isUniqueIndex = false)
        {
            this.ColumnName = columnName;
            this.TypeColumn = typeColumn;
            this.IsUniqueIndex = (typeColumn == SqlTypesColumn.PrimaryKey || typeColumn == SqlTypesColumn.PrimaryAndForeignKey) ? true : isUniqueIndex;
        }
    }

    /// <summary>
    /// Entity description with references to the database
    /// </summary>
    public class DatabaseEntityInfo : Attribute
    {
        /// <summary>
        /// Table name in database
        /// </summary>
        public string TableName { get; set; }
        
        /// <summary>
        /// stored procedure in database
        /// </summary>
        public string StoredProcedure { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tableName">Indica el nombre de la tabla en base de datos asociada a la clase</param>
        /// <param name="storedProcedure">Indica el nombre del procedimiento almacenado asociado a la clase</param>
        public DatabaseEntityInfo(string tableName, string storedProcedure)
        {
            this.TableName = tableName;
            this.StoredProcedure = storedProcedure;
        }
        
    }

    /// <summary>
    /// Enum descripcion with references to the database
    /// </summary>
    public class DatabaseEnumInfo : Attribute
    {
        /// <summary>
        /// Table name in database
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Consutructor with table name
        /// </summary>
        /// <param name="tableName">table name</param>
        public DatabaseEnumInfo(string tableName)
        {
            this.TableName = tableName;
        }

    }

    /// <summary>
    /// Item enum description with
    /// </summary>
    public class DatabaseItemEnumInfo : Attribute
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Consutructor with table name
        /// </summary>
        /// <param name="tableName">table name</param>
        public DatabaseItemEnumInfo(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }

    }

}
