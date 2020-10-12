using Gbso.Core;
using System.Data.SqlClient;

namespace Gbso.App.Business.General
{
    class PersonBusiness : BusinessMaster
    {
       public PersonBusiness(SqlConnection sqlConnection) : base(sqlConnection) { }
    }
}
