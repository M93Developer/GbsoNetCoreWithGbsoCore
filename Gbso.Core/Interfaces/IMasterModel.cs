using Gbso.Core.Enumerators;
using Gbso.Core.Model;
using Gbso.Core.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbso.Core.Interfaces
{
    /// <summary>
    /// EntityMasters Interface
    /// </summary>
    public interface IMasterModel<TKey> //:IDisposable
    {
        TKey GetKey();
        ModelEstate? GetState();
        byte[] GetTimeStamp();
        IUserModel<TKey> GetUserLastChange();
        string GetIpLastChange();
        ActionStateEnum? GetActionState();
    }
    public interface ICollectionMaster : IEnumerable
    {
    }
}
