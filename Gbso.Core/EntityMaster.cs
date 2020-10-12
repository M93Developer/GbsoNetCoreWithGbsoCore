using Gbso.Core.Enumerators;
using Gbso.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gbso.Core.Model
{
    /// <summary>
    /// Entidad Maestra
    /// </summary>
    /// <typeparam name="TypeKey">Recibe el tipo de la llave primaria</typeparam>
    [Serializable]
    public class EntityMaster<TKey> :IEntityMaster, IComparable<EntityMaster<TKey>>, IEquatable<EntityMaster<TKey>>, ICloneable
    {
        [DatabasePropertyInfo("Key", SqlTypesColumn.PrimaryKey)]
        public TKey Key { get; set; }
        [DatabasePropertyInfo("State", SqlTypesColumn.Default)]
        public EntityEstates? State { get; set; }
        [DatabasePropertyInfo("TimeStamp", SqlTypesColumn.Marker)]
        public byte[] TimeStamp { get; set; }
        private ActionStateEnum? actionState;
        [DatabasePropertyInfo("ActionStatee", SqlTypesColumn.AppController)]
        public ActionStateEnum? ActionState
        {
            get => this.actionState;
            set
            {
                if (actionState == value) return;
                bool Ok = true;
                if (actionState == ActionStateEnum.Created && value != ActionStateEnum.CreationOnHold)
                    Ok = false;
                else if (actionState == ActionStateEnum.CreationOnHold && value != ActionStateEnum.Created)
                    Ok = false;
                else if (actionState == ActionStateEnum.Original && (value != null && value != ActionStateEnum.Modified && value != ActionStateEnum.Deleted))
                    Ok = false;
                else if (actionState == ActionStateEnum.Modified && (value != ActionStateEnum.Deleted && value != ActionStateEnum.ModificationOnHold))
                    Ok = false;
                else if (actionState == ActionStateEnum.ModificationOnHold && (value != ActionStateEnum.Modified && value != ActionStateEnum.Deleted))
                     Ok = false;
                else if (actionState == ActionStateEnum.Deleted && (value != ActionStateEnum.Modified && value != ActionStateEnum.ModificationOnHold))
                    Ok = false;
                if (!Ok) throw new ActionStateException(String.Format("No puede pasar un estado de acción {0} a {1}", this.actionState.ToString(), value.ToString()));
                actionState = value;
            }
        }

        /// <summary>
        /// Consutrctor de la clase
        /// </summary>
        public EntityMaster()
        {
            this.ActionState = ActionStateEnum.Created;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="key"></param>
        public EntityMaster(TKey key)
        {
            this.Key = key;
            this.ActionState = ActionStateEnum.Created;
        }

        ///// <summary>
        ///// Fuerza la asignación del estado de acción (ActionState)
        ///// </summary>
        ///// <param name="actionState">Estado de acción a asignar</param>
        //public void ForceActionState(ActionStateEnum actionState)
        //{
        //    this.actionState = actionState;
        //}

        /// <summary>
        /// Compara el objeto con el objeto enviado si ambos tiene Keys Numericos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int IComparable<EntityMaster<TKey>>.CompareTo(EntityMaster<TKey> entity)
        {
            try
            {
                var a = Convert.ToInt64(this.Key);
                var b = Convert.ToInt64(entity.Key);
                if (b < a) return -1;
                if (b > a) return 1;
                return 0;
            }
            catch (Exception)
            {

                throw new System.Exception("Objetos Incomparables");
            }
        }

        /// <summary>
        /// Valida si el objeto es igual al Objeto enviado
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool IEquatable<EntityMaster<TKey>>.Equals(EntityMaster<TKey> entity)
        {
            if (this.Key.Equals(entity.Key)) return true;
            return false;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }

    

    public class ActionStateException : Exception
    {
        public ActionStateException(string String) : base(String) { }
    }

}
