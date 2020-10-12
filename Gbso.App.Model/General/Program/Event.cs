using System;
using Gbso.App.Model;
using Gbso.Core.Model;

namespace Gbso.App.Model.General.Program
{
    public class Event : AppEntityMaster<long?>
    {
        public DateTime? StartDateTime { get; set; }

        public TimeSpan? Interval { get; set; }

        public DateTime? EndDateTime { get => Interval == null ? null : StartDateTime?.AddMilliseconds((double)Interval?.TotalMilliseconds); }
    }

    public class Events : CollectionMaster<Event, long?> { }
}
