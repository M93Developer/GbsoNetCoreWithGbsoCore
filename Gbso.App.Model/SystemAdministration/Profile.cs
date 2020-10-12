using Gbso.Core.Model;
using Gbso.App.Model;
using Gbso.Core;
using Gbso.Core.Enumerators;
using System;

namespace Gbso.App.Model.SystemAdministration
{
    [Serializable]
    [DatabaseEntityInfo("Profile_Crud", "Profile_Crud")]
    public class Profile : AppEntityMaster<short?>
    {
        [DatabasePropertyInfo("Description",SqlTypesColumn.Default,true)]
        public string Description { get; set; }
    }

    [Serializable]
    public class Profiles : CollectionMaster<Profile, short?> { }
}
