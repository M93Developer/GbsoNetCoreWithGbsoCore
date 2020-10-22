using System;
using Gbso.Core;
using Gbso.Core.Model;
using Gbso.Core.Extensions;
using Gbso.Core.Attributes;

namespace Gbso.App.Model.General
{
    [Serializable]
    [ModelToDataBase("General", "LegalPerson", "LegalPerson_Crud")]
    public class LegalPerson : PersonModel, IPersonModel<IdTypesLegalPerson?>
    {
        /// <summary>
        /// 
        /// </summary>
        [PropertyToDBColumn("IdType")]
        public IdTypesLegalPerson? IdType { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [PropertyToDBColumn("Identification")]
        public string Identification { get; set; }
        
        /// <summary>
        /// Short name
        /// </summary>
        [PropertyToDBColumn("ShortName")]
        public string ShortName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [PropertyToDBColumn("Name")]
        public string BussinesName { get; set; }

        /// <summary>
        /// Second surname
        /// </summary>
        [PropertyToDBColumn("SecondSurname")]
        public string SecondSurname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [PropertyToDBColumn("Birthdate")]
        public override DateTime? Birthdate { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string Name { get => string.Format("{0}\n{1}: {2}", BussinesName, IdType.GetShortDescription(), Identification).Replace(@"\s*(?!\S)", "").Trim(); }
        
    }

    [Serializable]
    public class LegalPersonCollection : PersonCollection<LegalPerson> { }

    [EnumDataBase("EnumTypesLegalPerson")]
    public enum IdTypesLegalPerson
    {
        [EnumDescription("S.A.", "Sociedad Anonima")]
        SA = 1,
        [EnumDescription("S.A.S.", "Sociedad por Acción Simplificada")]
        SAS = 2,
    }
}

