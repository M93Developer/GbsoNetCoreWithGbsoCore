using Gbso.Core.Model;
using Gbso.App.Model.General;
using System;
using System.Collections.Generic;
using System.Text;
using Gbso.App.Model.MedicalCenter.Program;
using Gbso.App.Model.SystemAdministration;

namespace Gbso.App.Model.Patients
{
    public class Patient : NaturalPerson
    {
        /// <summary>
        /// citas asignadas
        /// </summary>
        public Apointments Apointments { get; set; }
    }

    public class Patients : CollectionMaster<Patient, long?> {}
}
