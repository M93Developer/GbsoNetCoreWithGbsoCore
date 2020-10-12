using System;
using Gbso.Core;
using Gbso.Core.Model;
using Gbso.App.Model;
using Gbso.Core.Extensions;
using Gbso.App.Model.SystemAdministration;

namespace Gbso.App.Model.General
{
    #region Entities

    [Serializable]
    [DatabaseEntityInfo("Person", "Person_Crud")]
    public class PersonModel : MasterModel<long?>
    {
        /// <summary>
        /// Type identification of the person
        /// </summary>
        [DatabasePropertyInfo("TypeId")]
        public IdeTypes? TypeId { get; set; }

        /// <summary>
        /// Identification number of a person
        /// </summary>
        [DatabasePropertyInfo("Identification")]
        public string Identification { get; set; }

        /// <summary>
        /// Identification number of a person
        /// </summary>
        public virtual string FullName { get; protected set; }

        /// <summary>
        /// Birthdate of the person
        /// </summary>
        [DatabasePropertyInfo("Birthdate")]
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Year old of the person
        /// </summary>
        public TimeSpan? YearOld { get => Birthdate != null ? DateTime.Now - Birthdate : (TimeSpan?)null; }
    }

    [Serializable]
    [DatabaseEntityInfo("NaturalPerson", "NaturalPerson_Crud")]
    public class NaturalPerson : PersonModel
    {
        /// <summary>
        /// first name
        /// </summary>
        [DatabasePropertyInfo("FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// second name
        /// </summary>
        [DatabasePropertyInfo("SecondName")]
        public string SecondName { get; set; }

        /// <summary>
        /// First surname
        /// </summary>
        [DatabasePropertyInfo("FirstSurname")]
        public string FirstSurname { get; set; }

        /// <summary>
        /// Second surname
        /// </summary>
        [DatabasePropertyInfo("SecondSurname")]
        public string SecondSurname { get; set; }

        /// <summary>
        /// Full name of person
        /// </summary>
        public override string FullName { get => string.Format("{0} {1} {2} {3}", FirstName, SecondName, FirstSurname, SecondSurname).Replace(@"\s*(?!\S)", "").Trim(); }

        /// <summary>
        /// Type blood of person
        /// </summary>
        public TypesBloodPerson TypeBlood { get; set; }

        /// <summary>
        /// Type RH of person
        /// </summary>
        public TypesRhPerson Rh { get; set; }
    }

    [Serializable]
    [DatabaseEntityInfo("LegalPerson", "LegalPerson_Crud")]
    public class LegalPerson : PersonModel
    {
        /// <summary>
        /// Short name
        /// </summary>
        [DatabasePropertyInfo("ShortName")]
        public string ShortName { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DatabasePropertyInfo("Name")]
        public string Name { get; set; }


        /// <summary>
        /// Second surname
        /// </summary>
        [DatabasePropertyInfo("SecondSurname")]
        public string SecondSurname { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public override string FullName { get => string.Format("{2}\n{1}: {2}", Name, TypeId.GetCode(), Identification).Replace(@"\s*(?!\S)", "").Trim(); }

    }

    [Serializable]
    [DatabaseEntityInfo("VirtualPerson", "VirtualPerson_Crud")]
    public class VirtualPerson : PersonModel
    {
        /// <summary>
        /// Name
        /// </summary>
        [DatabasePropertyInfo("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public override string FullName { get => string.Format("{2}\n{1}: {2}", Name, TypeId.GetCode(), Identification).Replace(@"\s*(?!\S)", "").Trim(); }
    }

    #endregion

    #region Collections

    [Serializable]
    public class Persons : CollectionMaster<PersonModel, long?> { }

    [Serializable]
    public class NaturalPersons : CollectionMaster<NaturalPerson, long?> { }

    [Serializable]
    public class LegalPersons : CollectionMaster<LegalPerson, long?> { }

    [Serializable]
    public class VirtualPersons : CollectionMaster<VirtualPerson, long?> { }

    #endregion

    #region Enumerables

    [DatabaseEnumInfo("EnumTypesIdPerson")]
    public enum IdeTypes
    {
        [DatabaseItemEnumInfo("R.C.", "Registro Cibil")]
        RC = 1,
        [DatabaseItemEnumInfo("T.I.", "Tarjeta de Identidad")]
        TI = 2,
        [DatabaseItemEnumInfo("C.C.", "Cédula de Ciudadania")]
        CC = 3,
        [DatabaseItemEnumInfo("N.I.T.", "Nit")]
        NIT = 4,
        [DatabaseItemEnumInfo("P.T.", "Pasaporte")]
        PT = 5,
        [DatabaseItemEnumInfo("VCOD", "Virtual Cod")]
        VCOD = 6
    }

    [DatabaseEnumInfo("EnumTypesLegalPerson")]
    public enum TypesLegalPerson
    {
        [DatabaseItemEnumInfo("S.A.", "Sociedad Anonima")]
        SA = 1,
        [DatabaseItemEnumInfo("S.A.S.", "Sociedad por Acción Simplificada")]
        SAS = 2,
    }

    [DatabaseEnumInfo("EnumTypesBloodPerson")]
    public enum TypesBloodPerson
    {
        [DatabaseItemEnumInfo("O", "O")]
        O = 1,
        [DatabaseItemEnumInfo("A", "A")]
        A = 2,
        [DatabaseItemEnumInfo("B", "B")]
        B = 3,
        [DatabaseItemEnumInfo("B", "B")]
        AB = 4,

    }

    [DatabaseEnumInfo("EnumTypesRhPerson")]
    public enum TypesRhPerson
    {
        [DatabaseItemEnumInfo("+", "+")]
        Positive = 1,
        [DatabaseItemEnumInfo("-", "-")]
        Negative = 2,
    }

    #endregion
}

