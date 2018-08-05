using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gbso.Core;

namespace Gbso.Core.Entities
{
    /// <summary>
    /// EntityMasterWithDatabas's Interface
    /// </summary>
    /// <typeparam name="TKey">Id's Datatype</typeparam>
    /// <typeparam name="TUser">User's Datatype</typeparam>
    public interface IEntityMasterWithDatabase : IEntityMaster
    {
    }
}