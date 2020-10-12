using System;
using Gbso.Core.Model;
using Gbso.App.Model.Patients;
using Gbso.App.Model.MedicalCenter.Staff;
using Gbso.App.Model.MedicalCenter.Services;
using Gbso.App.Model.General.Program;
using Gbso.App.Model.SystemAdministration;

namespace Gbso.App.Model.MedicalCenter.Program
{
    public class Apointment : Event
    {
        public Patient Patient { get; set; }

        public StaffMember StaffMember { get; set; }

        public DateTime? RequestedDateTime { get; set; }

        public DateTime? AssignedDateTime { get; set; }

        public Procedure Procedure { get; set; }
    }

    public class Apointments : CollectionMaster<Apointment,long?>
    {

    }
}
