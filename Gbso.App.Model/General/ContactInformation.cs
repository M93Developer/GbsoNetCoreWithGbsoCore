using Gbso.Core.Attributes;
using Gbso.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gbso.App.Model.General
{
    [ModelToDataBase("General", "ContactInformation", "Stp_ContactInformation")]
    public class ContactInformation: MasterModel<long?>
    {
        public string Tel { get; set; }
        public string Address { get; set; }
    }
}
