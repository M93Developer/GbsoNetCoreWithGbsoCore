using Gbso.Core;
using System.Data.SqlClient;
using Gbso.App.Model.General;
using Microsoft.AspNetCore.Mvc;

namespace Gbso.App.Data.General
{
    public class PersonData : MasterData<PersonModel, long?, PersonCollection>
    {
        public PersonData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }
        public PersonData(string sqlConnectionString) : base(sqlConnectionString)
        {

        }
    }
    public class PersonData<TPerson, TPersonCollection> : MasterData<TPerson, long?, TPersonCollection>
        where TPerson : PersonModel, new()
        where TPersonCollection : PersonCollection<TPerson>, new()
    {
        public PersonData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }

        public PersonData(string sqlConnectionString) : base(sqlConnectionString)
        {

        }
    }
}
