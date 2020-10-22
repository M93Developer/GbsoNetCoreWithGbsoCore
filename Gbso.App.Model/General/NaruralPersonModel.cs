using System;
using Gbso.Core;
using Gbso.Core.Model;
using Gbso.Core.Extensions;
using Gbso.Core.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Gbso.App.Model.General
{
    [Serializable]
    [ModelToDataBase("General", "NaturalPerson", "NaturalPerson_Crud")]
    public class NaturalPersonModel : PersonModel , IPersonModel<IdTypeNaturalPerson?>
    {
        /// <summary>
        /// Type identification of the person
        /// </summary>
        [Display(Name = "Id Type")]
        [Required]
        [PropertyToDBColumn("IdType")]
        public IdTypeNaturalPerson? IdType { get; set; }

        /// <summary>
        /// Identification number of a person
        /// </summary>
        [Required]
        [PropertyToDBColumn("Identification")]
        public string Identification { get; set; }

        /// <summary>
        /// Birthdate of the person
        /// </summary>
        [Required]
        [PropertyToDBColumn("Birthdate")]
        public override DateTime? Birthdate { get; set; }

        /// <summary>
        /// first name
        /// </summary>
        [Required]
        [Display(Name = "First Name")]
        [PropertyToDBColumn("FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// second name
        /// </summary>
        [Display(Name = "Second Name")]
        [PropertyToDBColumn("SecondName")]
        public string SecondName { get; set; }

        /// <summary>
        /// First surname
        /// </summary>
        [Required]
        [Display(Name = "First Surname")]
        [PropertyToDBColumn("FirstSurname")]
        public string FirstSurname { get; set; }

        /// <summary>
        /// Second surname
        /// </summary>
        [Display(Name = "Second Surname")]
        [PropertyToDBColumn("SecondSurname")]
        public string SecondSurname { get; set; }

        /// <summary>
        /// Type blood of person
        /// </summary>
        [Required]
        [Display(Name = "Blood Type")]
        [PropertyToDBColumn("BloodType")]
        public BloodType? BloodType { get; set; }

        /// <summary>
        /// Type RH of person
        /// </summary>
        [Required]
        [PropertyToDBColumn("Rh")]
        public RhType? Rh { get; set; }

        public ContactInformation Contact { get; set; }

        /// <summary>
        /// Full name of person
        /// </summary>
        public string Name { get => string.Format("{0} {1} {2} {3}", FirstName, SecondName, FirstSurname, SecondSurname).Replace(@"\s*(?!\S)", "").Trim(); }

    }

    public class NaturalPersonCollection : PersonCollection<NaturalPersonModel>
    { 
    }

    [EnumDataBase("IdTypeNaturalPerson")]
    public enum IdTypeNaturalPerson
    {
        [EnumDescription("R.C.", "Registro Cibil")]
        RC = 1,
        [EnumDescription("T.I.", "Tarjeta de Identidad")]
        TI = 2,
        [EnumDescription("C.C.", "Cédula de Ciudadania")]
        CC = 3,
        [EnumDescription("N.I.T.", "Nit")]
        NIT = 4,
        [EnumDescription("P.T.", "Pasaporte")]
        PT = 5,
        [EnumDescription("VCOD", "Virtual Cod")]
        VCOD = 6
    }

    [EnumDataBase("BloodType")]
    public enum BloodType
    {
        [EnumDescription("O")]
        O = 1,
        [EnumDescription("A")]
        A = 2,
        [EnumDescription("B")]
        B = 3,
        [EnumDescription("AB")]
        AB = 4,
    }

    [EnumDataBase("EnumTypesRhPerson")]
    public enum RhType
    {
        [EnumDescription("+")]
        Positive = 1,
        [EnumDescription("-")]
        Negative = 2,
    }

}

