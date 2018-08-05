﻿using Gbso.Core;
using Gbso.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gbso.App.Data
{
    public class UserData : DataMaster<UserEntity, int?, UsersCollection, UserEntity>
    {
        public UserData(SqlConnection SqlConnection) : base(SqlConnection)
        {
        }
    }
}