using System;
using System.Collections.Generic;

namespace Gbso.Core.Model
{
    ///// <summary>
    ///// Coleccioón Maestra
    ///// </summary>
    ///// <typeparam name="TypeKey">Recibe el tipo de la llave primaria</typeparam>
    //public class CollectionMaster<TEntity, TKey> : IList<TEntity> 
    //    where TEntity : EntityMaster<TKey>
    //{
    //    private TEntity[] Array;

    //    #region Varibles ICollection

    //    public int Count
    //    {
    //        get
    //        {
    //            return Array.Length;
    //        }
    //    }

    //    public bool IsReadOnly { get; }

    //    public TEntity this[int index] { get => ((IList<TEntity>)Array)[index]; set => ((IList<TEntity>)Array)[index] = value; }

    //    #endregion

    //    /// <summary>
    //    /// Constructor de la clase
    //    /// </summary>
    //    public CollectionMaster() {
    //        Array = new TEntity[0];
    //        var x = new List<TEntity>();
    //    }

    //    /// <summary>
    //    /// Constructor de la Entidad
    //    /// </summary>
    //    /// <param name="array"></param>
    //    CollectionMaster(TEntity[] array) {
    //        this.Array = array;
    //    }

    //    /// <summary>
    //    /// Retorna el objeto de la ubicación indicada
    //    /// </summary>
    //    /// <param name="index"></param>
    //    /// <returns></returns>
    //    public TEntity GetByIndex(int index)
    //    {
    //        if (Array.Length <= 0 || Array.Length < index) throw new System.OverflowException("Indice no encontrado");
    //        int NewLength = Array.Length - 1;
    //        TEntity[] NewArray = new TEntity[NewLength];
    //        return (TEntity) Array[index];
    //    }

    //    /// <summary>
    //    /// Retorna el primero objeto de la colección cuyo Key sea igual al Key enviado
    //    /// </summary>
    //    /// <param name="key"></param>
    //    /// <returns></returns>
    //    public TEntity GetByKey(TKey key)
    //    {
    //        for (int i = 0; i < Array.Length; i++)
    //        {
    //            if (Array[i].Key.Equals(key)) return (TEntity) Array[i];
    //        }
    //        throw new System.OverflowException("Key no encontrado");
    //    }

    //    /// <summary>
    //    /// Remueve el objeto de la ubicación indicada
    //    /// </summary>
    //    /// <param name="index"></param>
    //    public void Remove(int index)
    //    {
    //        if (index < 0 || Array.Length < index) throw new System.OverflowException("Indice fuera de rango");
    //        var newArray = new TEntity[Array.Length - 1];
    //        for (int i = 0, c = 0; i < Array.Length - 1; i++)
    //        {
    //            if (i != index)
    //            {
    //                newArray[c] = Array[i];
    //                c++;
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Remueve los objetos cuya Key se igual al Key Enviado
    //    /// </summary>
    //    /// <param name="Index"></param>
    //    public bool RemoveByKey(TKey key)
    //    {
    //        var controller = false;
    //        for (int i = 0; i < Array.Length - 1; i++)
    //        {
    //            if (Array[i].Key.Equals(key))
    //            {
    //                var newArray = new TEntity[Array.Length - 1];
    //                for (int e = 0, c = 0; e < Array.Length - 1; e++)
    //                {
    //                    if (e != i)
    //                    {
    //                        newArray[c] = Array[e];
    //                        c++;
    //                    }
    //                }
    //                controller = true;
    //            }
    //        }
    //        return controller;
    //    }

    //    /// <summary>
    //    /// Adiciona el objeto enviado a la colección
    //    /// </summary>
    //    /// <param name="entity"></param>
    //    public void Add(TEntity entity)
    //    {
    //        try
    //        {
    //            int NewLength = Array.Length + 1;
    //            TEntity[] NewArray = new TEntity[NewLength];
    //            for (int i = 0; i < Array.Length; i++)
    //            {
    //                NewArray[i] = (TEntity)Array[i];
    //            }
    //            NewArray[NewLength-1] = entity;
    //            Array = NewArray;
    //        }
    //        catch (OverflowException)
    //        {
    //            throw new OverflowException("La lista de objetos llegó a su máxima capacidad");
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //    }

    //    public void Create(TEntity entity)
    //    {
    //        entity.ActionState = ActionStateEnum.Created;
    //        Add(entity);
    //    }

    //    public void Clear()
    //    {
    //        Array = new TEntity[0];
    //    }

    //    public bool Contains(TEntity entity)
    //    {
    //        for (int i = 0; i < Array.Length - 1; i++)
    //        {
    //            if (Array[i].Equals(entity))
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    public void CopyTo(TEntity[] array, int arrayIndex)
    //    {
    //        if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex es menor que 0");
    //        if (array == null) throw new ArgumentNullException("El valor de array es null.");
    //        if (Array.Length - (arrayIndex + 1) > array.Length) throw new ArgumentException("El número de elementos en el origen de System.Collections.Generic.ICollection`1 es mayor que el espacio disponible desde arrayIndex hasta el final del destino de array.");

    //        for (int i = arrayIndex, e = 0; i < Array.Length; i++, e++)
    //        {
    //            array[e] = Array[i];
    //        }
    //    }

    //    public bool Remove(TEntity Entity)
    //    {
    //        var controller = false;
    //        for (int i = 0; i < Array.Length - 1; i++)
    //        {
    //            if (Array[i].Equals(Entity))
    //            {
    //                var newArray = new TEntity[Array.Length - 1];
    //                for (int e = 0, c = 0; e < Array.Length - 1; e++)
    //                {
    //                    if (e != i)
    //                    {
    //                        newArray[c] = Array[e];
    //                        c++;
    //                    }
    //                }
    //                controller = true;
    //            }
    //        }
    //        return controller;
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        //Instanciamos el enumerador tipado y lo devolvemos
    //        //return (new CollectionMasterEnumerator<EntityMaster<TKey>>(Array) as IEnumerator<TEntity>);
    //        return ((ICollection<TEntity>)Array).GetEnumerator();
    //    }

    //    IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
    //    {
    //        //Instanciamos el enumerador tipado y lo devolvemos
    //        //return (new CollectionMasterEnumerator<EntityMaster<TKey>>(Array) as IEnumerator<TEntity>);
    //        return ((ICollection<TEntity>)Array).GetEnumerator();
    //    }

    //    public int IndexOf(TEntity entity)
    //    {
    //        return ((IList<TEntity>)Array).IndexOf(entity);
    //    }

    //    public void Insert(int index, TEntity entity)
    //    {
    //        ((IList<TEntity>)Array).Insert(index, entity);
    //    }

    //    public void RemoveAt(int index)
    //    {
    //        ((IList<TEntity>)Array).RemoveAt(index);
    //    }
    //}

    ///// <summary>
    ///// Enumerador de la clase Collection
    ///// Se usa el enumerador de Array
    ///// </summary>
    ///// <typeparam name="TEntity"></typeparam>
    //public class CollectionMasterEnumerator<TEntity> : IEnumerator<TEntity>  where TEntity : IEntityMaster
    //{
    //    private TEntity[] Array;
    //    private long posicion = -1;
    //    public CollectionMasterEnumerator(TEntity[] Array)
    //    {
    //        this.Array = Array;
    //    }

    //    public bool MoveNext()
    //    {
    //        posicion++;
    //        if (posicion < Array.Length) return true;
    //        return false;
    //    }

    //    public void Reset()
    //    {
    //        posicion = -1;
    //    }

    //    object IEnumerator.Current
    //    {
    //        get
    //        {
    //            return Array[posicion];
    //        }
    //    }

    //    TEntity IEnumerator<TEntity>.Current
    //    {
    //        get
    //        {
    //            return Array[posicion];
    //        }
    //    }

    //    #region IDisposable Support
    //    private bool disposedValue = false; // Para detectar llamadas redundantes

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!disposedValue)
    //        {
    //            if (disposing)
    //            {
    //                // TODO: elimine el estado administrado (objetos administrados).
    //            }

    //            // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
    //            // TODO: configure los campos grandes en nulos.

    //            disposedValue = true;
    //        }
    //    }

    //    // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
    //    // ~CollectionMasterEnumerator() {
    //    //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
    //    //   Dispose(false);
    //    // }

    //    // Este código se agrega para implementar correctamente el patrón descartable.
    //    void IDisposable.Dispose()
    //    {
    //        // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
    //        Dispose(true);
    //        // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
    //        // GC.SuppressFinalize(this);
    //    }
    //    #endregion
    //}

    [Serializable]
    public class CollectionMaster<TModel, TKey> : List<TModel>
        where TModel : MasterModel<TKey>
    {
        //    /// <summary>
        //    /// Agrega nuevo objeto para ser registrado en base de datos
        //    /// </summary>
        //    /// <param name="entity">Entidad objeto u objeto a registrar</param>
        //    public void Create(TEntity entity)
        //    {
        //        entity.ActionState = ActionStateEnum.Created;
        //        Add(entity);
        //    }
    }
}