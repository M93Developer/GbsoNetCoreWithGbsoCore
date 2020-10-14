using Gbso.Core;
using Gbso.Core.Attributes;
using Gbso.Core.Model;
using System;

namespace Gbso.App.Model.SystemAdministration
{
    [Serializable]
    [DatabaseEntityInfo("Form", "Form_Crud")]
    public class Form : MasterModel<short?>
    {
        public Section Section { get; set; }
    }
    [Serializable]
    public class Forms : CollectionMaster<Form, short?> {}
}
