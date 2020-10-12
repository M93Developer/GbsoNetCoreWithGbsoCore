using Gbso.Core;
using Gbso.Core.Model;
using System;

namespace Gbso.App.Model.SystemAdministration
{
    [Serializable]
    [DatabaseEntityInfo("Module", "Module_Crud")]
    public class Module : MasterModel<short?>
    {
        public Sections Sections { get; set; }
    }
    [Serializable]
    public class Modules : CollectionMaster<Module, short?> {}
}
