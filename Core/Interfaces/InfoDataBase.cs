using Gbso.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gbso.Core
{
    public class InfoDataBase : Attribute
    {
        public string ColumnName { get; set; }
        public SqlTypesColumn TypeColumn { get; set; }
        public bool Unique { get; set; }
        public string ReferencesTable { get; set; }
        public string ReferencesSchema { get; set; }
        
        /// <summary>
        /// Inicializa Construye la descripción para una propiedad
        /// </summary>
        /// <param name="ColumnName">Indica el nómbre de la columna a asociar devuelta por la base de datos</param>
        /// <param name="TypeColumn">indica el tipo de columna en la lógica de la base de datos</param>
        /// <param name="Unique">Indica si es un index</param>
        /// <param name="Reference">Recibe un array string[2] que almacena el Schema y la Tabla a la cual hace referencia en caso de ser llave foranea</param>
        public InfoDataBase(string ColumnName, SqlTypesColumn TypeColumn = SqlTypesColumn.Default, bool Unique = false, string[] Reference = null)
        {
            this.ColumnName = ColumnName;
            this.TypeColumn = TypeColumn;
            this.Unique = (TypeColumn == SqlTypesColumn.PrimaryKey || TypeColumn == SqlTypesColumn.PrimaryAndForeignKey) ? true : Unique;
            if (TypeColumn == SqlTypesColumn.ForeignKey || TypeColumn == SqlTypesColumn.PrimaryAndForeignKey)
            {
                this.ReferencesSchema = Reference[0];
                this.ReferencesTable = Reference[1];
            }
        }

    }

    public class EntityDatabaseReferences : Attribute
    {
        public string SqlTable { get; set; }
        public string SqlStoredProcedure { get; set; }
        /// <summary>
        /// Inicializa la descripción de una clase con referencia a la lógica en baase de datos
        /// </summary>
        /// <param name="SqlTable">Indica el nombre de la tabla en base de datos asociada a la clase</param>
        /// <param name="SqlStoredProcedure">Indica el nombre del procedimiento almacenado asociado a la clase</param>
        public EntityDatabaseReferences(string SqlTable, string SqlStoredProcedure)
        {
            this.SqlTable = SqlTable;
            this.SqlStoredProcedure = SqlStoredProcedure;
        }
        
    }

}
