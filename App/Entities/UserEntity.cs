using Gbso.Core;
using Gbso.Core.Entities;
using Gbso.Core.Enum;
using System;

namespace Gbso.App.Entities
{
    [Serializable]
    [EntityDatabaseReferences("User", "Stp_User")]
    public class UserEntity : AppEntityMaster<int?>
    {
        [InfoDataBase("Nikname", SqlTypesColumn.Default, true)]
        public string Nikname { get; set; }
        [InfoDataBase("Password")]
        public string Password { get; set; }
        [InfoDataBase("Key_Perfil", SqlTypesColumn.ForeignKey,false, new string[2] { "Security", "Perfil" })]
        public ProfileEntity Perfil { get; set; }
    }
    [Serializable]
    public class UsersCollection : CollectionMaster<UserEntity, int?>
    {


    }
}
