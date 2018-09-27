using Gbso.App.Model.General;
using Gbso.Core;
using Gbso.Core.Model;
using Gbso.Core.Enumerators;
using System;

namespace Gbso.App.Model.SystemAdministration
{
    [Serializable]
    [DatabaseEntityInfo("User", "User_Crud")]
    public class User : AppEntityMaster<int?>
    {
        [DatabasePropertyInfo("Nikname", SqlTypesColumn.Default, true)]
        public string Nikname { get; set; }
        [DatabasePropertyInfo("Password")]
        public string Password { get; set; }
        [DatabasePropertyInfo("Key_Perfil", SqlTypesColumn.ForeignKey)]
        public Profile Perfil { get; set; }
        [DatabasePropertyInfo("Key_Person", SqlTypesColumn.ForeignKey)]
        public Person Person { get; set; }
    }
    [Serializable]
    public class Users : CollectionMaster<User, int?>{}
}
