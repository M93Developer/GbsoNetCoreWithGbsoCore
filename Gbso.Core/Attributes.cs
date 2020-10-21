using Gbso.Core.Enumerators;
using System;
using System.ComponentModel;

namespace Gbso.Core.Attributes
{
    public class PropertyToDBColumn : Attribute
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
        public PropertyToDBColumn(string columnName, SqlTypesColumn typeColumn = SqlTypesColumn.Default, bool isUniqueIndex = false)
        {
            this.ColumnName = columnName;
            this.TypeColumn = typeColumn;
            this.IsUniqueIndex = (typeColumn == SqlTypesColumn.PrimaryKey || typeColumn == SqlTypesColumn.PrimaryAndForeignKey) ? true : isUniqueIndex;
        }
    }

    /// <summary>
    /// Model description with references to the database
    /// </summary>
    public class ModelToDataBase : Attribute
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
        public ModelToDataBase(string tableName, string storedProcedure)
        {
            this.TableName = tableName;
            this.StoredProcedure = storedProcedure;
        }
        
    }

    /// <summary>
    /// Enum descripcion with references to the database
    /// </summary>
    public class EnumDataBase : Attribute
    {
        /// <summary>
        /// Table name in database
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Consutructor with table name
        /// </summary>
        /// <param name="tableName">table name</param>
        public EnumDataBase(string tableName)
        {
            this.TableName = tableName;
        }

    }

    /// <summary>
    /// Item enum description with
    /// </summary>
    public class EnumDescription : DescriptionAttribute
    {
        /// <summary>
        /// Code
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Consutructor with table name
        /// </summary>
        /// <param name="tableName">table name</param>
        public EnumDescription(string shortDescription, string description = null): base(description)
        {
            this.ShortDescription = shortDescription;
        }

    }

}
