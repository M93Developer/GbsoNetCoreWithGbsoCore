using Gbso.App.Model.General;
using Gbso.App.Model.SystemAdministration;
using Gbso.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

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
