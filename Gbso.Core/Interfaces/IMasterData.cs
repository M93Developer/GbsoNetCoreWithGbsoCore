using Gbso.Core.Model;
using Gbso.Core.Utils;

namespace Gbso.Core.Interfaces
{
    public interface IMasterData<TEntity, TKey, TCollection> where TEntity : MasterModel<TKey> where TCollection : CollectionMaster<TEntity, TKey>
    {
        TKey Set(TEntity entity);
        TEntity SetAndReturnModel(TEntity entity);
        TEntity Get(TKey key);
        TCollection Get();
        TCollection Get(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        int Delete(TKey key);
        TEntity UpdateAndReturnModel(TEntity entity);
        UpdateCollectionResult Update(TCollection collectionEntity);
    }
}
