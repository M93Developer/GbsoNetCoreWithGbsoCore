using Gbso.Core;
using System.Data.SqlClient;
using Gbso.App.Model.SystemAdministration;

namespace Gbso.App.Data.SystemAdministration
{
    public class UserData : DataMaster<User, int?, Users, User>
    {
        public UserData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }
    }
}
