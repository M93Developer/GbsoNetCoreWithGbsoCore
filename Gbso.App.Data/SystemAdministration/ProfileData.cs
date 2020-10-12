using Gbso.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Gbso.App.Model.SystemAdministration;

namespace Gbso.App.Data.SystemAdministration
{
    public class ProfileData : MasterData<Profile, short?, Profiles>
    {
        public ProfileData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }

        public ProfileData() : base()
        {
        }
    }
}
