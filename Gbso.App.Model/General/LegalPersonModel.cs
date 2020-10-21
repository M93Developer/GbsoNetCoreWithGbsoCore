using System;
using Gbso.Core;
using Gbso.Core.Model;
using Gbso.Core.Extensions;
using Gbso.Core.Attributes;

namespace Gbso.App.Model.General
{
    [Serializable]
    [DatabaseEntityInfo("LegalPerson", "LegalPerson_Crud")]
    public class LegalPerson : PersonModel, IPersonModel<IdTypesLegalPerson?>
    {
        /// <summary>
        /// 
        /// </summary>
        [DatabasePropertyInfo("IdType")]
        public IdTypesLegalPerson? IdType { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [DatabasePropertyInfo("Identification")]
        public string Identification { get; set; }
        
        /// <summary>
        /// Short name
        /// </summary>
        [DatabasePropertyInfo("ShortName")]
        public string ShortName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DatabasePropertyInfo("Name")]
        public string BussinesName { get; set; }

        /// <summary>
        /// Second surname
        /// </summary>
        [DatabasePropertyInfo("SecondSurname")]
        public string SecondSurname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DatabasePropertyInfo("Birthdate")]
        public override DateTime? Birthdate { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string Name { get => string.Format("{0}\n{1}: {2}", BussinesName, IdType.GetShortDescription(), Identification).Replace(@"\s*(?!\S)", "").Trim(); }
        
    }

    [Serializable]
    public class LegalPersonCollection : PersonCollection<LegalPerson> { }

    [DatabaseEnumInfo("EnumTypesLegalPerson")]
    public enum IdTypesLegalPerson
    {
        [EnumDescription("S.A.", "Sociedad Anonima")]
        SA = 1,
        [EnumDescription("S.A.S.", "Sociedad por Acción Simplificada")]
        SAS = 2,
    }
}

