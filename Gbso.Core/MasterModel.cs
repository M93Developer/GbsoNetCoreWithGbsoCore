using Gbso.Core.Attributes;
using Gbso.Core.Enumerators;
using Gbso.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gbso.Core.Model
{
    /// <summary>
    /// Entidad Maestra
    /// </summary>
    /// <typeparam name="TypeKey">Recibe el tipo de la llave primaria</typeparam>
    [Serializable]
    public abstract class MasterModel<TKey> : IMasterModel<TKey>, IComparable<MasterModel<TKey>>, IEquatable<MasterModel<TKey>>, ICloneable
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabasePropertyInfo("Key", SqlTypesColumn.PrimaryKey)]
        public TKey Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DatabasePropertyInfo("State", SqlTypesColumn.Default)]
        public ModelEstate? State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DatabasePropertyInfo("TimeStamp", SqlTypesColumn.Marker)]
        public byte[] TimeStamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DatabasePropertyInfo("UserLastChange", SqlTypesColumn.ForeignKey)]
        public IUserModel<TKey> UserLastChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DatabasePropertyInfo("IpLastChange")]
        public string IpLastChange { get; set; }
        private ActionStateEnum? _actionState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DatabasePropertyInfo("ActionStatee", SqlTypesColumn.AppController)]
        public ActionStateEnum? ActionState
        {
            get => this._actionState;
            set
            {
                if (_actionState == value) return;
                bool Ok = true;
                if (_actionState == ActionStateEnum.Created && value != ActionStateEnum.CreationOnHold)
                    Ok = false;
                else if (_actionState == ActionStateEnum.CreationOnHold && value != ActionStateEnum.Created)
                    Ok = false;
                else if (_actionState == ActionStateEnum.Original && (value != null && value != ActionStateEnum.Modified && value != ActionStateEnum.Deleted))
                    Ok = false;
                else if (_actionState == ActionStateEnum.Modified && (value != ActionStateEnum.Deleted && value != ActionStateEnum.ModificationOnHold))
                    Ok = false;
                else if (_actionState == ActionStateEnum.ModificationOnHold && (value != ActionStateEnum.Modified && value != ActionStateEnum.Deleted))
                     Ok = false;
                else if (_actionState == ActionStateEnum.Deleted && (value != ActionStateEnum.Modified && value != ActionStateEnum.ModificationOnHold))
                    Ok = false;
                if (!Ok) throw new ActionStateException(String.Format("No puede pasar un estado de acción {0} a {1}", this._actionState.ToString(), value.ToString()));
                _actionState = value;
            }
        }

        /// <summary>
        /// Consutrctor de la clase
        /// </summary>
        public MasterModel()
        {
            //this.ActionState = ActionStateEnum.Created;
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="key"></param>
        public MasterModel(TKey key)
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
        int IComparable<MasterModel<TKey>>.CompareTo(MasterModel<TKey> entity)
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
        bool IEquatable<MasterModel<TKey>>.Equals(MasterModel<TKey> entity)
        {
            if (this.Key.Equals(entity.Key)) return true;
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TKey GetKey()
        {
            return Key;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ModelEstate? GetState()
        {
            return State;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] GetTimeStamp()
        {
            return TimeStamp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IUserModel<TKey> GetUserLastChange()
        {
            return UserLastChange;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetIpLastChange()
        {
            return IpLastChange;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionStateEnum? GetActionState()
        {
            return _actionState;
        }

    }

    

    public class ActionStateException : Exception
    {
        public ActionStateException(string String) : base(String) { }
    }

}
