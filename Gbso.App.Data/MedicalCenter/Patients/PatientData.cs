using Gbso.Core;
using Gbso.App.Model.Patients;
using System.Data.SqlClient;

namespace Gbso.App.Data.MedicalCenter.Patients
{
    public class PatientData : MasterData<Patient, long?, Model.Patients.Patients>
    {
        public PatientData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }

        public PatientData() : base()
        {
        }
    }

}
