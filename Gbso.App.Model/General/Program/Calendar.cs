using System;
using Gbso.App.Model;
using Gbso.App.Model.SystemAdministration;
using Gbso.Core.Model;

namespace Gbso.App.Model.General.Program
{
    public class Calendar : MasterModel<int?>
    {
        private DateTime? _StartDate;
        public DateTime? StartDate { get=> _StartDate?.Date; set => _StartDate = value; }

        public TimeSpan? Inverval { get; set; }

        public DateTime? EndDate { get => Inverval == null ? null: StartDate?.Date.AddDays((int) Inverval?.Days) ;}


    }

    public class Calendars : CollectionMaster<Calendar, int?> { }
}
