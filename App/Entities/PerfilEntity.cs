using Gbso.Core.Entities;
using Gbso.App.Entities;
using Gbso.Core;
using Gbso.Core.Enum;

namespace Gbso.App.Entities
{
    [EntityDatabaseReferences("Security", "Perfil", "Security", "Stp_Perfil")]
    public class ProfileEntity : AppEntityMaster<short?>
    {
        [InfoDataBase("Description",SqlTypesColumn.Default,true)]
        public string Description { get; set; }
    }

    public class ProfilesCollection : CollectionMaster<ProfileEntity, short?>
    { }
}
