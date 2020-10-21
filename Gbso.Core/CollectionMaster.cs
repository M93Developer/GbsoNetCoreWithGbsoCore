using System;
using System.Collections.Generic;

namespace Gbso.Core.Model
{
    ///// <summary>
    ///// Coleccioón Maestra
    ///// </summary>
    ///// <typeparam name="TypeKey">Recibe el tipo de la llave primaria</typeparam>
    //public class CollectionMaster<TModel, TKey> : IList<TModel> 
    //    where TModel : ModelMaster<TKey>
    //{
    //    private TModel[] Array;

    //    #region Varibles ICollection

    //    public int Count
    //    {
    //        get
    //        {
    //            return Array.Length;
    //        }
    //    }

    //    public bool IsReadOnly { get; }

    //    public TModel this[int index] { get => ((IList<TModel>)Array)[index]; set => ((IList<TModel>)Array)[index] = value; }

    //    #endregion

    //    /// <summary>
    //    /// Constructor de la clase
    //    /// </summary>
    //    public CollectionMaster() {
    //        Array = new TModel[0];
    //        var x = new List<TModel>();
    //    }

    //    /// <summary>
    //    /// Constructor de la Entidad
    //    /// </summary>
    //    /// <param name="array"></param>
    //    CollectionMaster(TModel[] array) {
    //        this.Array = array;
    //    }

    //    /// <summary>
    //    /// Retorna el objeto de la ubicación indicada
    //    /// </summary>
    //    /// <param name="index"></param>
    //    /// <returns></returns>
    //    public TModel GetByIndex(int index)
    //    {
    //        if (Array.Length <= 0 || Array.Length < index) throw new System.OverflowException("Indice no encontrado");
    //        int NewLength = Array.Length - 1;
    //        TModel[] NewArray = new TModel[NewLength];
    //        return (TModel) Array[index];
    //    }

    //    /// <summary>
    //    /// Retorna el primero objeto de la colección cuyo Key sea igual al Key enviado
    //    /// </summary>
    //    /// <param name="key"></param>
    //    /// <returns></returns>
    //    public TModel GetByKey(TKey key)
    //    {
    //        for (int i = 0; i < Array.Length; i++)
    //        {
    //            if (Array[i].Key.Equals(key)) return (TModel) Array[i];
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
    //        var newArray = new TModel[Array.Length - 1];
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
    //                var newArray = new TModel[Array.Length - 1];
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
    //    /// <param name="model"></param>
    //    public void Add(TModel model)
    //    {
    //        try
    //        {
    //            int NewLength = Array.Length + 1;
    //            TModel[] NewArray = new TModel[NewLength];
    //            for (int i = 0; i < Array.Length; i++)
    //            {
    //                NewArray[i] = (TModel)Array[i];
    //            }
    //            NewArray[NewLength-1] = model;
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

    //    public void Create(TModel model)
    //    {
    //        model.ActionState = ActionStateEnum.Created;
    //        Add(model);
    //    }

    //    public void Clear()
    //    {
    //        Array = new TModel[0];
    //    }

    //    public bool Contains(TModel model)
    //    {
    //        for (int i = 0; i < Array.Length - 1; i++)
    //        {
    //            if (Array[i].Equals(model))
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    public void CopyTo(TModel[] array, int arrayIndex)
    //    {
    //        if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex es menor que 0");
    //        if (array == null) throw new ArgumentNullException("El valor de array es null.");
    //        if (Array.Length - (arrayIndex + 1) > array.Length) throw new ArgumentException("El número de elementos en el origen de System.Collections.Generic.ICollection`1 es mayor que el espacio disponible desde arrayIndex hasta el final del destino de array.");

    //        for (int i = arrayIndex, e = 0; i < Array.Length; i++, e++)
    //        {
    //            array[e] = Array[i];
    //        }
    //    }

    //    public bool Remove(TModel Model)
    //    {
    //        var controller = false;
    //        for (int i = 0; i < Array.Length - 1; i++)
    //        {
    //            if (Array[i].Equals(Model))
    //            {
    //                var newArray = new TModel[Array.Length - 1];
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
    //        //return (new CollectionMasterEnumerator<ModelMaster<TKey>>(Array) as IEnumerator<TModel>);
    //        return ((ICollection<TModel>)Array).GetEnumerator();
    //    }

    //    IEnumerator<TModel> IEnumerable<TModel>.GetEnumerator()
    //    {
    //        //Instanciamos el enumerador tipado y lo devolvemos
    //        //return (new CollectionMasterEnumerator<ModelMaster<TKey>>(Array) as IEnumerator<TModel>);
    //        return ((ICollection<TModel>)Array).GetEnumerator();
    //    }

    //    public int IndexOf(TModel model)
    //    {
    //        return ((IList<TModel>)Array).IndexOf(model);
    //    }

    //    public void Insert(int index, TModel model)
    //    {
    //        ((IList<TModel>)Array).Insert(index, model);
    //    }

    //    public void RemoveAt(int index)
    //    {
    //        ((IList<TModel>)Array).RemoveAt(index);
    //    }
    //}

    ///// <summary>
    ///// Enumerador de la clase Collection
    ///// Se usa el enumerador de Array
    ///// </summary>
    ///// <typeparam name="TModel"></typeparam>
    //public class CollectionMasterEnumerator<TModel> : IEnumerator<TModel>  where TModel : IModelMaster
    //{
    //    private TModel[] Array;
    //    private long posicion = -1;
    //    public CollectionMasterEnumerator(TModel[] Array)
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

    //    TModel IEnumerator<TModel>.Current
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
        //    /// <param name="model">Entidad objeto u objeto a registrar</param>
        //    public void Create(TModel model)
        //    {
        //        model.ActionState = ActionStateEnum.Created;
        //        Add(model);
        //    }
    }
}