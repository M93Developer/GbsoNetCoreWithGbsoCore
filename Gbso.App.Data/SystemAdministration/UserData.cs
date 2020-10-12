using Gbso.Core;
using System.Data.SqlClient;
using Gbso.App.Model.SystemAdministration;

namespace Gbso.App.Data.SystemAdministration
{
    public class UserData : MasterData<UserModel, int?, UserCollection>
    {
        public UserData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }
    }
}
