using Gbso.App.Model.General;
using Gbso.Core;
using Gbso.Core.Model;
using Gbso.Core.Enumerators;
using System;
using Gbso.Core.Interfaces;

namespace Gbso.App.Model.SystemAdministration
{
    [Serializable]
    [DatabaseEntityInfo("User", "User_Crud")]
    public class UserModel : MasterModel<int?>, IUserModel<int?>
    {
        [DatabasePropertyInfo("Nikname", SqlTypesColumn.Default, true)]
        public string Nikname { get; set; }
        [DatabasePropertyInfo("Password")]
        public string Password { get; set; }
        [DatabasePropertyInfo("Key_Perfil", SqlTypesColumn.ForeignKey)]
        public Profile Perfil { get; set; }
        [DatabasePropertyInfo("Key_Person", SqlTypesColumn.ForeignKey)]
        public PersonModel Person { get; set; }
    }
    [Serializable]
    public class UserCollection : CollectionMaster<UserModel, int?>{}
}
