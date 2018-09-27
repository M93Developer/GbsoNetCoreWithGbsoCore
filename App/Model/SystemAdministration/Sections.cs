using Gbso.Core;
using Gbso.Core.Model;
using System;

namespace Gbso.App.Model.SystemAdministration
{
    [Serializable]
    [DatabaseEntityInfo("Sections", "Sections_Crud")]
    public class Section : AppEntityMaster<short?>
    {
        public Module Module { get; set; }
        public Forms Forms { get; set; }
    }
    [Serializable]
    public class Sections : CollectionMaster<Section, short?>{}
}
