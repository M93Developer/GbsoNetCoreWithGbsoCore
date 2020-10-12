using Gbso.Core.Model;
using System;

namespace Gbso.App.Model.Administration
{
    public class Agreement : Core.Model.MasterModel<long?>
    {
        public ExternalE External { get; set; }

        public DateTime? CelebrationDateTime { get; set; }

        public DateTime? _StartDate;
        public DateTime? StartDate { get => _StartDate?.Date; set => _StartDate = value; }

        public DateTime? _EndDate;
        public DateTime? EndDate { get => _EndDate?.Date; set => _EndDate = value; }

    }

    public class Agreements : CollectionMaster<Agreement, long?>
    {

    }
}
