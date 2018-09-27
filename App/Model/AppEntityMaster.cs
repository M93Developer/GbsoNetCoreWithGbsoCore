using Gbso.Core.Model;
using Gbso.Core;
using Gbso.Core.Enumerators;
using System;
using Gbso.App.Model.SystemAdministration;

namespace Gbso.App.Model
{
    /// <summary>
    /// Entidad Maestra para las aplicaciones con base de datos
    /// </summary>
    /// <typeparam name="TypeKey">Define el tipo de dato de la llave primaria</typeparam>
    [Serializable]
    public class AppEntityMaster<TKey> : EntityMaster<TKey> 
    {
        [DatabasePropertyInfo("IpLastChange")]
        public String IpLastChange { get; set; }
        [DatabasePropertyInfo("UserLastChange", SqlTypesColumn.ForeignKey)]
        public User UserLastChange { get; set; }
    }
}
