using System;
using Gbso.App.Model.SystemAdministration;
using Gbso.App.Model.MedicalCenter.Services;
using Gbso.Core;
using System.Data.SqlClient;

namespace Gbso.App.Data.MedicalCenter.Services
{
    public class ProcedureData : DataMaster<Procedure, int?, Procedures, User>
    {
        public ProcedureData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }

        public ProcedureData() : base()
        {
        }
    }
}
