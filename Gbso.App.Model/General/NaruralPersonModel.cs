using System;
using Gbso.Core;
using Gbso.Core.Model;
using Gbso.Core.Extensions;
using Gbso.Core.Attributes;

namespace Gbso.App.Model.General
{
    [Serializable]
    [DatabaseEntityInfo("General.NaturalPerson", "General.NaturalPerson_Crud")]
    public class NaturalPersonModel : PersonModel , IPersonModel<IdTypeNaturalPerson?>
    {
        /// <summary>
        /// Type identification of the person
        /// </summary>
        [DatabasePropertyInfo("IdType")]
        public IdTypeNaturalPerson? IdType { get; set; }

        /// <summary>
        /// Identification number of a person
        /// </summary>
        [DatabasePropertyInfo("Identification")]
        public string Identification { get; set; }

        /// <summary>
        /// Birthdate of the person
        /// </summary>
        [DatabasePropertyInfo("Birthdate")]
        public override DateTime? Birthdate { get; set; }

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
        /// Type blood of person
        /// </summary>
        [DatabasePropertyInfo("TypeBlood")]
        public BloodType TypeBlood { get; set; }

        /// <summary>
        /// Type RH of person
        /// </summary>
        [DatabasePropertyInfo("Rh")]
        public RhType Rh { get; set; }

        /// <summary>
        /// Full name of person
        /// </summary>
        public string Name { get => string.Format("{0} {1} {2} {3}", FirstName, SecondName, FirstSurname, SecondSurname).Replace(@"\s*(?!\S)", "").Trim(); }

    }

    public class NaturalPersonCollection : PersonCollection<NaturalPersonModel>
    { 
    }

    [DatabaseEnumInfo("IdTypeNaturalPerson")]
    public enum IdTypeNaturalPerson
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

    [DatabaseEnumInfo("BloodType")]
    public enum BloodType
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
    public enum RhType
    {
        [DatabaseItemEnumInfo("+", "+")]
        Positive = 1,
        [DatabaseItemEnumInfo("-", "-")]
        Negative = 2,
    }

}

