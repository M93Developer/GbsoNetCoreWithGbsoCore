using Gbso.Core;
using Gbso.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Gbso.App.Model.General;
using Gbso.App.Model.SystemAdministration;

namespace Gbso.App.Data.General
{
    public class PersonData : DataMaster<Person, long?, Persons, User>
    {
        public PersonData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }
    }

    public class LegalPersonData : DataMaster<LegalPerson, long?, LegalPersons, User>
    {
        public LegalPersonData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }
    }

    public class NaturalPersonData : DataMaster<NaturalPerson, long?, NaturalPersons, User>
    {
        public NaturalPersonData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }
    }
}
