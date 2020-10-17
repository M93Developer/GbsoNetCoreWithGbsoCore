using System;
using Gbso.Core;
using Gbso.Core.Model;
using Gbso.Core.Extensions;
using Gbso.Core.Attributes;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace Gbso.App.Model.General
{
    /// <summary>
    /// Clase base para el modelado de personas en el sistema
    /// </summary>
    /// <typeparam name="TKey">Tipo de dato numerico </typeparam>
    /// <typeparam name="TIdType"></typeparam>
    public interface IPersonModel<TIdType>
    {
        /// <summary>
        /// Type identification of the person
        /// </summary>
        TIdType IdType { get; set; }

        /// <summary>
        /// Identification number of a person
        /// </summary>
        string Identification { get; set; }

        /// <summary>
        /// Nombre compuesto
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Birthdate of the person
        /// </summary>
        DateTime? Birthdate { get; set; }
    }
}

