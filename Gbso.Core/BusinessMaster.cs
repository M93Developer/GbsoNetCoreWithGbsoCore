using System;
using System.Data.SqlClient;

namespace Gbso.Core
{
    /// <summary>
    /// clase maestra de negocios
    /// </summary>
    public class BusinessMaster : IDisposable
    {
        /// <summary>
        /// Conexión que se usará para negociar con la base de datos
        /// </summary>
        public SqlConnection SqlConnection { get; set; }
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="sqlConnection">Conección qué se usará para negociar con la base de datos</param>
        public BusinessMaster(SqlConnection sqlConnection)
        {
            this.SqlConnection = sqlConnection;
        }
        
        /// <summary>
        /// método destructor
        /// </summary>
        public void Dispose()
        {
            if (SqlConnection != null && SqlConnection.State != System.Data.ConnectionState.Closed) SqlConnection.Dispose();
        }
    }
}
