using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gbso.App.Data;
using Gbso.App.Entities;
using Gbso.Core;
using Gbso.Core.Enum;

namespace Gbso.App.Business
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
        public SecurityBusiness():base(new SqlConnection(Confi.DefatultConnectionString))
        {
        }

        #region Usuario

        /// <summary>
        /// Registra un usuario
        /// </summary>
        /// <param name="user">Usuario a registrar</param>
        /// <returns>Identificador asignado en base de datos</returns>
        public int? RegisterUser(UserEntity user)
        {
            return new UserData(SqlConnection).Register(user);
        }
        
        /// <summary>
        /// Registra un usuario
        /// </summary>
        /// <param name="user">Usuario a registrar</param>
        /// <returns>Entidad del usuario registrado</returns>
        public UserEntity RegisterReturnUser(UserEntity user)
        {
            return new UserData(SqlConnection).RegisterAndReturnEntity(user);
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="user">Usuario a eliminar</param>
        /// <returns>Si el usuario ha diso eliminado o no</returns>
        public bool DeleteUser(UserEntity user)
        {
            return new UserData(SqlConnection).Delete(user) > 0;
        }

        /// <summary>
        /// lista los usuario activos
        /// </summary>
        /// <returns>Una colección de usuarios</returns>
        public UsersCollection ListUsers()
        {
            return new UserData(SqlConnection).GetCollection(
                new UserEntity()
                {
                    State = EntityEstates.Enabled
                }
            );
        }

        /// <summary>
        /// Lista los usuario inactivos
        /// </summary>
        /// <returns>retorna una lista de usuarios</returns>
        public UsersCollection ListInactiveUsers()
        {
            return new UserData(SqlConnection).GetCollection(
                new UserEntity()
                {
                    State = EntityEstates.Disabled
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
        public int? RegisterProfile(ProfileEntity profile)
        {
            return new ProfileData(SqlConnection).Register(profile);
        }

        /// <summary>
        /// Registra un perfil
        /// </summary>
        /// <param name="profiles">Perfil a registrar</param>
        /// <returns>retorna el identificador asignado al perfil registrado</returns>
        public int? RegisterProfiles(ProfilesCollection profiles)
        {
            return new ProfileData(SqlConnection).UpdateCollection(profiles.Where(n => n.ActionState == Core.Entities.ActionStateEnum.Created) as ProfilesCollection).Registered;
        }

        /// <summary>
        /// Registra un perfil y retorna el objeto registrado
        /// </summary>
        /// <param name="profile">Perfil a registrar</param>
        /// <returns>Retorna el objeto registrado</returns>
        public ProfileEntity RegisterReturnProfile(ProfileEntity profile)
        {
            return new ProfileData(SqlConnection).RegisterAndReturnEntity(profile);
        }

        /// <summary>
        /// Elimina un perfil
        /// </summary>
        /// <param name="profile">Perfile a eliminar</param>
        /// <returns>Retorna si el perfil fue o no eliminado</returns>
        public bool DeleteProfile(ProfileEntity profile)
        {
            return new ProfileData(SqlConnection).Delete(profile) > 0;
        }

        /// <summary>
        /// Lista los perfiles activos
        /// </summary>
        /// <returns></returns>
        public ProfilesCollection ListActiveProfiles()
        {
            return new ProfileData(SqlConnection).GetCollection(
                new ProfileEntity()
                {
                    State = EntityEstates.Enabled
                }
            );
        }

        /// <summary>
        /// Lista lo perfiles inactivos
        /// </summary>
        /// <returns>Retorna un perfil</returns>
        public ProfilesCollection ListInactiveProfiles()
        {
            return new ProfileData(SqlConnection).GetCollection(
                new ProfileEntity()
                {
                    State = EntityEstates.Disabled
                }
            );
        }
        #endregion

    }
}
