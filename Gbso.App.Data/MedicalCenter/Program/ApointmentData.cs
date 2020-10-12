﻿using System;
using Gbso.Core;
using Gbso.App.Model.MedicalCenter.Program;
using Gbso.App.Model.SystemAdministration;
using System.Data.SqlClient;

namespace Gbso.App.Data.MedicalCenter.Program
{
    class ApointmentData : DataMaster<Apointment, long?, Apointments, User>
    {
        public ApointmentData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }

        public ApointmentData() : base()
        {
        }
    }
}