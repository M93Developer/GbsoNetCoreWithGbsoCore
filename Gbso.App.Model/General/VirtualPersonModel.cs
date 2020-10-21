using System;
using Gbso.Core;
using Gbso.Core.Model;
using Gbso.Core.Extensions;
using Gbso.Core.Attributes;

namespace Gbso.App.Model.General
{
    [Serializable]
    [DatabaseEntityInfo("VirtualPerson", "VirtualPerson_Crud")]
    public class VirtualPersonModel : PersonModel, IPersonModel<IdTypesVirtualPerson?>
    {
        /// <summary>
        /// Serial number
        /// </summary>
        public IdTypesVirtualPerson? IdType { get; set; }
        public string Identification { get; set; }

        /// <summary>
        /// creation date
        /// </summary>
        public override DateTime? Birthdate { get; set; }

        /// <summary>
        /// Name of System
        /// </summary>
        [DatabasePropertyInfo("NameSystem")]
        public string NameSystem { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string Name { get => string.Format("{0}\n{1}", NameSystem, IdType.GetShortDescription()); }
    }

    [Serializable]
    public class VirtualPersons : PersonCollection<VirtualPersonModel> { }

    [DatabaseEnumInfo("IdTypeVirtualPerson")]
    public enum IdTypesVirtualPerson
    {
        [EnumDescription("WApp", "Web Applicaction")]
        SA = 1,
        [EnumDescription("Api", "Api")]
        SAS = 2,
    }
}

