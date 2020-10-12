using Gbso.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Gbso.App.Business.General
{
    class PersonBusiness : BusinessMaster
    {
       public PersonBusiness(SqlConnection sqlConnection) : base(sqlConnection) { }
    }
}
