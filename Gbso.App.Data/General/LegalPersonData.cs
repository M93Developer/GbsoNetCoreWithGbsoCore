using Gbso.Core;
using System.Data.SqlClient;
using Gbso.App.Model.General;

namespace Gbso.App.Data.General
{
    public class LegalPersonData : PersonData<LegalPerson, LegalPersonCollection>
    {
        public LegalPersonData(SqlConnection sqlConnectionString) : base(sqlConnectionString)
        {
        }
        public LegalPersonData(string sqlConnectionString) : base(sqlConnectionString)
        {
        }
    }
}
