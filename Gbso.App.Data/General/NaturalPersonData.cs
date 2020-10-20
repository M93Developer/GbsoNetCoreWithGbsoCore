using Gbso.Core;
using System.Data.SqlClient;
using Gbso.App.Model.General;
using Microsoft.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.Design;
using System.Transactions;

namespace Gbso.App.Data.General
{
    public class NaturalPersonData : PersonData<NaturalPersonModel, NaturalPersonCollection>
    {
        public NaturalPersonData(SqlConnection SqlConnection) : base(SqlConnection)
        {
            
        }

        public NaturalPersonData(string sqlConnectionString) : base(sqlConnectionString)
        {

        }

        public new long? Set(NaturalPersonModel naturalPerson)
        {
            using (var ts = new TransactionScope())
            {
                var personData = new PersonData(SqlConnection);
                naturalPerson.Key = personData.Set(naturalPerson);

                base.Set(naturalPerson);
                ts.Complete();
            }
            return naturalPerson.Key;
        }
    }
}
