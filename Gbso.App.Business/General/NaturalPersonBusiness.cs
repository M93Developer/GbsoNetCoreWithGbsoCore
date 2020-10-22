using Gbso.Core;
using System.Data.SqlClient;

namespace Gbso.App.Business.General
{
    class NaturalPersonBusiness : BusinessMaster
    {
       public NaturalPersonBusiness(SqlConnection sqlConnection) : base(sqlConnection) { }
    }
}
