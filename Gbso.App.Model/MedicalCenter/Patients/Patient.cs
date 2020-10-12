using Gbso.Core.Model;
using Gbso.App.Model.General;
using Gbso.App.Model.MedicalCenter.Program;

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
