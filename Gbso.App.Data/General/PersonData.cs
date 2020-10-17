using Gbso.Core;
using System.Data.SqlClient;
using Gbso.App.Model.General;

namespace Gbso.App.Data.General
{
    public class PersonData : PersonData<PersonModel>
    {
        public PersonData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }
    }
    public class PersonData<TPerson> : MasterData<TPerson, long?, PersonCollection<TPerson>>
        where TPerson : PersonModel, new()
    {
        public PersonData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }
    }
}
