using Gbso.Core;
using Gbso.App.Model.Patients;
using Gbso.App.Model.SystemAdministration;
using System.Data.SqlClient;

namespace Gbso.App.Data.MedicalCenter.Patients
{
    public class PatientData : DataMaster<Patient, long?, Model.Patients.Patients, User>
    {
        public PatientData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }

        public PatientData() : base()
        {
        }
    }

}
