﻿using Gbso.App.Model.General;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Gbso.App.Api.Context
{
    public class MssqlDbContext : DbContext
    {
        public MssqlDbContext(DbContextOptions<MssqlDbContext> options) : base(options)
        {

        }

        public DbSet<PersonModel> person { get; set; }
    }
}
