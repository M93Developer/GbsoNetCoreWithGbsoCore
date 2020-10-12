using Gbso.Core.Enumerators;
using System.Collections;


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
