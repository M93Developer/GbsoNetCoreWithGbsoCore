using Gbso.Core.Model;
using Gbso.Core.Utils;

namespace Gbso.Core.Interfaces
{
    public interface IMasterData<TEntity, TKey, TCollection> where TEntity : MasterModel<TKey> where TCollection : CollectionMaster<TEntity, TKey>
    {
        TKey Register(TEntity entity);
        TEntity Get(TEntity entity);
        TCollection GetCollection(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        TEntity UpdateAndReturnEntity(TEntity entity);
        UpdateCollectionResult UpdateCollection(TCollection collectionEntity);
    }
}
