using System;
using Gbso.Core;
using Gbso.Core.Model;
using Gbso.Core.Extensions;
using Gbso.Core.Attributes;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System.ComponentModel.DataAnnotations;

namespace Gbso.App.Model.General
{
    /// <summary>
    /// Clase base para el modelado de personas en el sistema
    /// </summary>
    [Serializable]
    [ModelToDataBase("General.Person", "General.Person_Crud")]
    public class PersonModel : MasterModel<long?>
    {
        /// <summary>
        /// Birthdate of the person
        /// <para>Se requiere sobrescribir con [DatabasePropertyInfo("Birthdate")]</para>
        /// </summary>
        public virtual DateTime? Birthdate { get; set; }

        /// <summary>
        /// Year old of the person
        /// </summary>
        [Display(Name = "Year Old")]
        public int? YearOld { get => Birthdate != null ? (new DateTime() + (DateTime.Now - Birthdate.Value.AddDays(1).AddYears(1))).Year : (int?)null; }
    }

    [Serializable]
    public class PersonCollection : CollectionMaster<PersonModel, long?> 
    { 
    }
    public class PersonCollection<TPerson> : CollectionMaster<TPerson, long?>
    where TPerson : PersonModel
    { 
    }
}

