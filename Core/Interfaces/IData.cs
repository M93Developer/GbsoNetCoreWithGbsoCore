using Gbso.Core.Entities;
using Gbso.Core.Utils;
using System.Collections.Generic;

namespace Gbso.Core
{
    public interface IData<TEntity, TKey, TCollection> where TEntity: EntityMaster<TKey> where TCollection : CollectionMaster<TEntity, TKey>
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
