using System;
using Gbso.Core;
using System.Data.SqlClient;
using Gbso.App.Model.SystemAdministration;
using Gbso.App.Model.MedicalCenter.Staff;

namespace Gbso.App.Data.MedicalCenter.Staff
{
    public class StaffMemberData : DataMaster<StaffMember, long?, StaffMembers, User>
    {
        public StaffMemberData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }

        public StaffMemberData() : base()
        {
        }
    }
}
