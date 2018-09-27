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
    public interface ICollectionMaster :IEnumerable
    {
    }

    public interface IData<TEntity, TKey, TCollection> where TEntity : EntityMaster<TKey> where TCollection : CollectionMaster<TEntity, TKey>
    {
        TKey Register(TEntity entity);
        TEntity Get(TEntity entity);
        TCollection GetCollection(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
        TEntity UpdateAndReturnEntity(TEntity entity);
        UpdateCollectionResult UpdateCollection(TCollection collectionEntity);
    }

    /// <summary>
    /// EntityMasters Interface
    /// </summary>
    public interface IEntityMaster //:IDisposable
    {
    }

    /// <summary>
    /// EntityMasterWithDatabas's Interface
    /// </summary>
    /// <typeparam name="TKey">Id's Datatype</typeparam>
    /// <typeparam name="TUser">User's Datatype</typeparam>
    public interface IEntityMasterWithDatabase : IEntityMaster
    {
    }
}
