using Gbso.App.Model.MedicalCenter.Services;
using Gbso.Core;
using System.Data.SqlClient;

namespace Gbso.App.Data.MedicalCenter.Services
{
    public class ProcedureData : MasterData<Procedure, int?, Procedures>
    {
        public ProcedureData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }

        public ProcedureData() : base()
        {
        }
    }
}
