using Gbso.Core.Entities;
using Gbso.App.Entities;
using Gbso.Core;
using Gbso.Core.Enum;
using System;

namespace Gbso.App.Entities
{
    /// <summary>
    /// Entidad Maestra para las aplicaciones con base de datos
    /// </summary>
    /// <typeparam name="TypeKey">Define el tipo de dato de la llave primaria</typeparam>
    [Serializable]
    public class AppEntityMaster<TKey> : EntityMaster<TKey> 
    {
        [InfoDataBase("IpLastChange")]
        public String IpLastChange { get; set; }
        [InfoDataBase("UserLastChange", SqlTypesColumn.ForeignKey, false, new string[2] { "Security", "User" })]
        public UserEntity UserLastChange { get; set; }
    }
}
