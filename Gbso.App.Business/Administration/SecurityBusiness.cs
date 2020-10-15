using System;
using System.Data.SqlClient;
using System.Linq;
using Gbso.App.Data.SystemAdministration;
using Gbso.App.Model.SystemAdministration;
using Gbso.Core;
using Gbso.Core.Enumerators;

namespace Gbso.App.Business.General
{
    public class SecurityBusiness : BusinessMaster, IDisposable
    {
        /// <summary>
        /// Crea una instancia de la clase de negocio con una conexiónde de base de deatos existente
        /// - Se recomienda usar este contructor en caso de que necesite de multples objetos de negocio de diferente clase usando la misma conexión
        ///     -Esto evita tener habiertas muchas conexiónes cada vez que se hacen instancias en un mismo método a clases de negocios que usan la misma base de datos
        /// </summary>
        /// <param name="SqlConnection"></param>
        public SecurityBusiness(SqlConnection SqlConnection):base(SqlConnection)
        {
        }

        /// <summary>
        /// Crea una instancia de la clase de negocio de negocio creando una nueva conexión usando la configuración por defecto
        /// - Se recomienad usar este contructor en caso de 
        /// </summary>
        public SecurityBusiness():base(new SqlConnection(Config.GetDefatultConnectionString))
        {
        }

        #region Usuario

        /// <summary>
        /// Registra un usuario
        /// </summary>
        /// <param name="user">Usuario a registrar</param>
        /// <returns>Identificador asignado en base de datos</returns>
        public int? RegisterUser(UserModel user)
        {
            return new UserData(SqlConnection).Set(user);
        }
        
        /// <summary>
        /// Registra un usuario
        /// </summary>
        /// <param name="user">Usuario a registrar</param>
        /// <returns>Entidad del usuario registrado</returns>
        public UserModel RegisterReturnUser(UserModel user)
        {
            return new UserData(SqlConnection).SetAndReturnModel(user);
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="user">Usuario a eliminar</param>
        /// <returns>Si el usuario ha diso eliminado o no</returns>
        public bool DeleteUser(UserModel user)
        {
            return new UserData(SqlConnection).Delete(user) > 0;
        }

        /// <summary>
        /// lista los usuario activos
        /// </summary>
        /// <returns>Una colección de usuarios</returns>
        public UserCollection ListUsers()
        {
            return new UserData(SqlConnection).Get(
                new UserModel()
                {
                    State = ModelEstate.Enabled
                }
            );
        }

        /// <summary>
        /// Lista los usuario inactivos
        /// </summary>
        /// <returns>retorna una lista de usuarios</returns>
        public UserCollection ListInactiveUsers()
        {
            return new UserData(SqlConnection).Get(
                new UserModel()
                {
                    State = ModelEstate.Disabled
                }
            );
        }

        #endregion

        #region Perfil

        /// <summary>
        /// Registra un perfil
        /// </summary>
        /// <param name="profile">Perfil a registrar</param>
        /// <returns>retorna el identificador asignado al perfil registrado</returns>
        public int? RegisterProfile(Profile profile)
        {
            return new ProfileData(SqlConnection).Set(profile);
        }

        /// <summary>
        /// Registra multiples perfiles
        /// </summary>
        /// <param name="profiles">Perfiles a registrar</param>
        /// <returns>retorna el número de perfiles registrados</returns>
        public int? RegisterProfiles(Profiles profiles)
        {
            return new ProfileData(SqlConnection).Update(profiles.Where(n => n.ActionState == ActionStateEnum.Created) as Profiles).Registered;
        }

        /// <summary>
        /// Registra un perfil y retorna el objeto registrado
        /// </summary>
        /// <param name="profile">Perfil a registrar</param>
        /// <returns>Retorna el objeto registrado</returns>
        public Profile RegisterReturnProfile(Profile profile)
        {
            return new ProfileData(SqlConnection).SetAndReturnModel(profile);
        }

        /// <summary>
        /// Elimina un perfil
        /// </summary>
        /// <param name="profile">Perfile a eliminar</param>
        /// <returns>Retorna si el perfil fue o no eliminado</returns>
        public bool DeleteProfile(Profile profile)
        {
            return new ProfileData(SqlConnection).Delete(profile) > 0;
        }

        /// <summary>
        /// Lista los perfiles activos
        /// </summary>
        /// <returns></returns>
        public Profiles ListActiveProfiles()
        {
            return new ProfileData(SqlConnection).Get(
                new Profile()
                {
                    State = ModelEstate.Enabled
                }
            );
        }

        /// <summary>
        /// Lista lo perfiles inactivos
        /// </summary>
        /// <returns>Retorna un perfil</returns>
        public Profiles ListInactiveProfiles()
        {
            return new ProfileData(SqlConnection).Get(
                new Profile()
                {
                    State = ModelEstate.Disabled
                }
            );
        }
        #endregion

    }
}
