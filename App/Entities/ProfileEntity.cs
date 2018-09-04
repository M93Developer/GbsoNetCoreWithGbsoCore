using Gbso.Core.Entities;
using Gbso.App.Entities;
using Gbso.Core;
using Gbso.Core.Enum;
using System;

namespace Gbso.App.Entities
{
    [Serializable]
    [EntityDatabaseReferences("Perfil", "Stp_Perfil")]
    public class ProfileEntity : AppEntityMaster<short?>
    {
        [InfoDataBase("Description",SqlTypesColumn.Default,true)]
        public string Description { get; set; }
    }

    [Serializable]
    public class ProfilesCollection : CollectionMaster<ProfileEntity, short?>
    { }
}
