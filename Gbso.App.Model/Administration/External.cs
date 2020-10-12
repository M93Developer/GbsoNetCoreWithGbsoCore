using Gbso.App.Model.General;
using Gbso.Core.Model;

namespace Gbso.App.Model.Administration
{
    public class ExternalE : NaturalPerson
    {
        public Agreements Agreements  { get; set; }
    }

    public class Externals : CollectionMaster<ExternalE, long?>
    {

    }
}
