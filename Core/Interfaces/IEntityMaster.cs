using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbso.Core.Entities
{
    /// <summary>
    /// EntityMasters Interface
    /// </summary>
    public interface IEntityMaster //:IDisposable
    {
        void ForceActionState(ActionStateEnum actionstate);
    }
}
