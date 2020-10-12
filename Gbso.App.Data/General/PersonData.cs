using Gbso.Core;
using System.Data.SqlClient;
using Gbso.App.Model.General;

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
