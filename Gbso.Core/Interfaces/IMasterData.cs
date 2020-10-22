using Gbso.Core.Model;
using Gbso.Core.Data;

namespace Gbso.Core.Data
{
    public interface IMasterData<TModel, TKey, TCollection> where TModel : MasterModel<TKey> where TCollection : CollectionMaster<TModel, TKey>
    {
        TKey Set(TModel model);
        TModel SetAndReturnModel(TModel model);
        TModel Get(TKey key);
        TCollection Get();
        TCollection Get(TModel model);
        int Update(TModel model);
        int Delete(TModel model);
        int Delete(TKey key);
        TModel UpdateAndReturnModel(TModel model);
        UpdateCollectionResult Update(TCollection collectionModel);
    }
}
