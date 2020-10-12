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
    public class PersonData : MasterData<PersonModel, long?, Persons>
    {
        public PersonData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }
    }

    public class LegalPersonData : MasterData<LegalPerson, long?, LegalPersons>
    {
        public LegalPersonData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }
    }

    public class NaturalPersonData : MasterData<NaturalPerson, long?, NaturalPersons>
    {
        public NaturalPersonData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }
    }
}
