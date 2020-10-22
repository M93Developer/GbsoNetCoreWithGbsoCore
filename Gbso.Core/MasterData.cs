using Gbso.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Linq;
using Gbso.Core.Enumerators;
using System.Data;
using Gbso.Core.Interfaces;
using Gbso.Core.Attributes;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;

namespace Gbso.Core.Data
{
    /// <summary>
    /// Clase maestra que se encarga de negociar con la base de datos y de persistir los datos según según los tipos de datos indicados
    /// </summary>
    /// <typeparam name="TModel">Tipo de entidad</typeparam>
    /// <typeparam name="TKey">Tipo de llave primaria de la entidad</typeparam>
    /// <typeparam name="TCollection">Tipo de colección de la entidad</typeparam>
    public class MasterData<TModel, TKey, TCollection> : IMasterData<TModel, TKey, TCollection>, IDisposable
        where TModel : MasterModel<TKey>, new()
        where TCollection : CollectionMaster<TModel, TKey>, new()
    {

        protected string SqlString { get; set; }
        protected SqlConnection SqlConnection { get; set; }
        protected Type InstanceType { get; set; }

        /// <summary>
        /// Constructor de cla clase
        /// </summary>
        protected MasterData()
        {
            OpenConnection();
        }
      
        /// <summary>
        /// Constructor de la clase que recive una conexión
        /// </summary>
        /// <param name="sqlConnection"></param>
        public MasterData(SqlConnection sqlConnection)
        {
            this.SqlConnection = sqlConnection;
            OpenConnection();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sqlConnectionString">Cadena de conexión</param>
        public MasterData(string sqlConnectionString)
        {
            this.SqlConnection = new SqlConnection(sqlConnectionString);
            OpenConnection();
        }

        private void OpenConnection()
        {
            if (SqlConnection != null && SqlConnection.State == System.Data.ConnectionState.Closed) this.SqlConnection.Open();
            var modelDescriptionAttributes = (ModelToDataBase)typeof(TModel).GetCustomAttribute(typeof(ModelToDataBase));
            if (modelDescriptionAttributes == null) throw new Exception("La entidad no tiene descripciones de transancción");
            SqlString = modelDescriptionAttributes.Schema+ "." + modelDescriptionAttributes.StoredProcedure;
            InstanceType = typeof(TModel);
        }

        /// <summary>
        /// Registra un objeto en la base de datos y devuelve su identificador
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TKey Set(TModel model)
        {
            using (var sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = SqlConnection;
                sqlCommand.CommandText = SqlString;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Stp_Action", SqlAction.Set);
                var param = sqlCommand.Parameters;
                ModelPropertiesToParameterCollection(ref param, model);
                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var value = reader[0];
                        var type = typeof(TKey);
                        model.Key = value == DBNull.Value ? default : (TKey)Convert.ChangeType(value, Nullable.GetUnderlyingType(type) ?? type);
                    }
                }
            }
            return model.Key;
        }

        /// <summary>
        /// Registra un objeto en la base de datos y devuelve dicho objeto sincronizado
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TModel SetAndReturnModel(TModel model)
        {
            using (var sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = SqlConnection;
                sqlCommand.CommandText = SqlString;
                sqlCommand.Parameters.AddWithValue("@Stp_Action", SqlAction.RegisterAndReturnModel);
                var param = sqlCommand.Parameters;
                ModelPropertiesToParameterCollection(ref param, model);
                return SqlDataRederToModel(sqlCommand.ExecuteReader());
            }
        }

        /// <summary>
        /// Elimina los objetos que tengan las mismas propiedades del objeto envíado
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Número de registros afectados</returns>
        public int Delete(TModel model)
        {
            using (var sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = SqlConnection;
                sqlCommand.CommandText = SqlString;
                sqlCommand.Parameters.AddWithValue("@Stp_Action", SqlAction.Delete);
                var param = sqlCommand.Parameters;
                ModelPropertiesToParameterCollection(ref param, model);
                return sqlCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Elimina un objteo por su clave principal
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Delete(TKey key)
        {
            return Delete(new TModel() { Key = key });
        }

        /// <summary>
        /// Devuelve un objeto de la base de datos
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public TModel Get(TKey key)
        {
            using (var sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = SqlConnection;
                sqlCommand.CommandText = SqlString;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Stp_Action", SqlAction.Get);
                sqlCommand.Parameters.AddWithValue("@Key", key);
                var param = sqlCommand.Parameters;
                return SqlDataRederToModel(sqlCommand.ExecuteReader());
            }
        }

        /// <summary>
        /// Devuelve una colección con todos los objetos de un mismo tipo
        /// </summary>
        /// <returns></returns>
        public TCollection Get()
        {
            return Get(new TModel());
        }

        public TCollection Get<TResult>(Expression<Func<TModel, TResult>> selector, Expression<Func<TModel, bool>> predicate)
        {
            string expBody = SelectExpressionToSelectSql(selector);
            string preBody = WhereExpressionToWhereSql(predicate);
            
            return new TCollection();
        }

        private string SelectExpressionToSelectSql<TResult>(Expression<Func<TModel, TResult>> selector)
        {
            var modelType = typeof(TModel);
            var att = (ModelToDataBase)modelType.GetCustomAttribute(typeof(ModelToDataBase), false);

            string expBody = selector.Body.ToString();
            expBody = Regex.Replace(expBody, @".*\((.*)\)", "$1");
            expBody = Regex.Replace(expBody, @"( = )\w+",  "$1"+ att.TableName);
            expBody = Regex.Replace(expBody, @"\w+ = ", "");
            var a = expBody.Split(",").Select(e=> e.Split("."));
            var pares = a.Where(e => e.Length == 2).ToList();
            
            foreach (var item in a.Where(i=> i.Length == 3))
            {
                var pType = modelType.GetProperty(item[1]).PropertyType;
                if (Utils.IsSubclassOfRawGeneric(typeof(MasterModel<>), pType))
                {
                    var pAttr = (ModelToDataBase) pType.GetCustomAttribute(typeof(ModelToDataBase),false);
                    var par = new string[2] { pAttr.TableName, item[2] + " AS " + item[1] + "_" + item[2] };
                    pares.Add(par);
                }
            }
            var columns = pares.Select(p => string.Join(".", p));
            expBody = string.Join(",", string.Join(", ", columns));
            expBody = Regex.Replace(expBody, @"(\w+)", "[$1]").Replace(" [AS] ", " AS "); 
            return expBody;
        }

        private string WhereExpressionToWhereSql(Expression<Func<TModel, bool>> predicate)
        {
            string preBody = predicate.Body.ToString();
            // Gives: ((x.Id > 5) AndAlso (x.Warranty != False))

            var paramName = predicate.Parameters[0].Name;
            var paramTypeName = predicate.Parameters[0].Type.Name;

            // You could easily add "OrElse" and others...
            preBody = preBody.Replace(paramName + ".", paramTypeName + ".")
                             .Replace("AndAlso", "AND")
                             .Replace("==", "=")
                             .Replace("\"", "'")
                             .Replace("OrElse", "OR");

            preBody = Regex.Replace(preBody, @"Convert\((\w+\.\w+), Nullable`\d+\)", "$1");
            return preBody;
        }

        /// <summary>
        /// Devuelve una colección de objetos de la base de datos que tengan los mismo parámetros del objeto envíado
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TCollection Get(TModel model)
        {
            using (var sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = SqlConnection;
                sqlCommand.CommandText = SqlString;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Stp_Action", SqlAction.Get);
                var param = sqlCommand.Parameters;
                ModelPropertiesToParameterCollection(ref param, model);
                return SqlDataRederToModelCollection(sqlCommand.ExecuteReader());
            }
        }

        /// <summary>
        /// Actunaliza un objeto en la base de datos
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(TModel model)
        {
            using (var sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = SqlConnection;
                sqlCommand.CommandText = SqlString;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Stp_Action", SqlAction.Update);
                var param = sqlCommand.Parameters;
                ModelPropertiesToParameterCollection(ref param, model);
                return sqlCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Actualiza el objeto en la base de datos y devuelve el mismo objeto sincronizado
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TModel UpdateAndReturnModel(TModel model)
        {
            using (var sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = SqlConnection;
                sqlCommand.CommandText = SqlString;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Stp_Action", SqlAction.UpdateAndReturnModel);
                var param = sqlCommand.Parameters;
                ModelPropertiesToParameterCollection(ref param, model);
                return SqlDataRederToModel(sqlCommand.ExecuteReader());
            }
        }

        /// <summary>
        /// Ejecuta las acciones pendientes de una colección en la base de datos
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public UpdateCollectionResult Update(TCollection collection)
        {
            using (var sqlCommand = new SqlCommand())
            {
                sqlCommand.Connection = SqlConnection;
                sqlCommand.CommandText = SqlString;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var updateCollectionResult = new UpdateCollectionResult();
                foreach (TModel Model in collection.OrderBy(n => n.ActionState))
                {
                    var param = sqlCommand.Parameters;
                    ModelPropertiesToParameterCollection(ref param, Model);
                    switch (Model.ActionState)
                    {
                        case ActionStateEnum.Created:
                            sqlCommand.Parameters.AddWithValue("@Stp_Action", SqlAction.Set);
                            sqlCommand.ExecuteNonQuery();
                            updateCollectionResult.Registered++;
                            break;
                        case ActionStateEnum.Modified:
                            sqlCommand.Parameters.AddWithValue("@Stp_Action", SqlAction.Update);
                            sqlCommand.ExecuteNonQuery();
                            updateCollectionResult.Updated++;
                            break;
                        case ActionStateEnum.Deleted:
                            sqlCommand.Parameters.AddWithValue("@Stp_Action", SqlAction.Delete);
                            sqlCommand.ExecuteNonQuery();
                            updateCollectionResult.Deleted++;
                            break;
                        default:
                            break;
                    }
                    sqlCommand.Parameters.Clear();
                }
                return updateCollectionResult;
            };
        }

        /// <summary>
        /// Valida las columnas de la consulta, instancia e inicializa los objetos correspondientes
        /// </summary>
        /// <param name="columns">Lista de columnas a generar</param>
        /// <param name="column">String con expresión de columnas</param>
        /// <param name="columnFragments">Partes de columnas a inicalizar como objetos</param>
        private void ValidarPartesColumna(ref List<object> columns, string column, string[] columnFragments = null)
        {
            if (columnFragments == null)
            {
                columnFragments = column.Split('_');
            }
            if (columnFragments.Length == 1)
            {
                columns.Add(new string[] { columnFragments.FirstOrDefault(), column });
            }
            else
            {
                var PartesColumnaRestantes = new string[columnFragments.Length - 1];
                var firstColumnName = columnFragments.FirstOrDefault();
                Array.Copy(columnFragments, 1, PartesColumnaRestantes, 0, PartesColumnaRestantes.Length);
                object objeto = columns.Where(n =>
                    (
                        n.GetType() == typeof(string[]) && ((string[])n).FirstOrDefault().ToString() == columnFragments.FirstOrDefault()
                    )
                    ||
                    (
                        n.GetType() == typeof(Dictionary<string,List<object>>) 
                        &&
                        ((Dictionary<string, List<object>>)n).ContainsKey(columnFragments.FirstOrDefault())
                    )
                ).ToList().FirstOrDefault();
                if (objeto == null)
                {
                    if (columnFragments.Count() == 1)
                    {
                        columns.Add(new string[]{ columnFragments.FirstOrDefault(), column });
                    }
                    else
                    {
                        var nSubColumnas = new Dictionary<string, List<object>>
                        {
                            { columnFragments.FirstOrDefault(), new List<object>() }
                        };
                        var lista = nSubColumnas[columnFragments.FirstOrDefault()];
                        ValidarPartesColumna(ref lista, column, PartesColumnaRestantes);
                        columns.Add(nSubColumnas);
                    }
                }
                else
                {
                    if (columnFragments.Count() > 1)
                    {
                        if (objeto.GetType() == typeof(string[]))
                        {
                            var name = ((string[])objeto).FirstOrDefault().ToString();
                            objeto = new Dictionary<string, List<object>>();
                            ((Dictionary<string, List<object>>)objeto).Add(name, new List<object>());
                            var lista = ((Dictionary<string, List<object>>) objeto)[name];
                            ValidarPartesColumna(ref lista, column, PartesColumnaRestantes);
                        }
                        else
                        {
                            var lista = ((Dictionary<string, List<object>>)objeto)[columnFragments.FirstOrDefault()];
                            ValidarPartesColumna(ref lista, column, PartesColumnaRestantes);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Recorre un SqlDataReader y debuelve una colleccion de un tipo especifico con los datos obtenidos
        /// </summary>
        /// <param name="sqlDataReader">SqlDataReader a persistir</param>
        /// <returns></returns>
        private TCollection SqlDataRederToModelCollection(SqlDataReader sqlDataReader)
        {
            //Obtener nombre de propiedades y columnas Descrpcion_ReferenciaSubObjeto_ReferenciaObjeto
            var columns = new List<object>();
            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                ValidarPartesColumna(ref columns, sqlDataReader.GetName(i));
            }
            TCollection collection = new TCollection(); //Crear la collección de tipo especifico a devolver que hereda de CollectionMaster<TModel, TKey>
            PropertyInfo[] properties = typeof(TModel).GetProperties(); //Obtener las propiedades de la entidad
            while (sqlDataReader.Read()) //Recorrer los datos devueltos por sql
            {
                collection.Add(InitializeProperties(sqlDataReader, columns, new TModel()) as TModel);
            }
            return collection;
        }

        /// <summary>
        /// Devuelve una entidad con sus propiedades inicializadas asignando la información de un SqlDatareader
        /// </summary>
        /// <param name="sqlDataReder"></param>
        /// <returns></returns>
        private TModel SqlDataRederToModel(SqlDataReader sqlDataReader)
        {
            var columns = new List<object>();
            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                ValidarPartesColumna(ref columns, sqlDataReader.GetName(i));
            }
            sqlDataReader.Read();
            return InitializeProperties(sqlDataReader, columns, new TModel()) as TModel;
        }

        /// <summary>
        /// Inicializa las propidedades de una instancia y asigna los valores devueltos por una consulta
        /// </summary>
        /// <param name="sqlDataReader">Resultados de consulta apersistir</param>
        /// <param name="columns">Columnas correspondientes a las propiedades del objeto a inicalizar</param>
        /// <param name="instance">Instancia u objeto a inicalizar</param>
        /// <returns></returns>
        private object InitializeProperties(SqlDataReader sqlDataReader, List<object> columns, object instance)
        {
            var propertyState = typeof(MasterModel<TKey>).GetProperty("_actionState", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            propertyState.SetValue(instance, ActionStateEnum.Original);

            foreach (string[] item in columns.Where(c => c.GetType() == typeof(string[])))
            {

                PropertyInfo property = InstanceType.GetProperty(item.First());
                object databaseValue;
                try
                {
                    var res = sqlDataReader[item[1]];
                    var w2 = res.GetType();
                    databaseValue = sqlDataReader[item[1]] is DBNull ? null : sqlDataReader[item[1]]; //Valor obtenido de la base de datos
                }
                catch (Exception)
                {
                    throw new Exception(string.Format("el método de consulta no puede obtener el valor de la colúmna {0}", item[1])); //si la propiedad de la de la entidad no corresponde a una de las columnas devueltas
                }
                if (databaseValue != null && !String.IsNullOrEmpty(databaseValue.ToString()))
                {
                    Type propertyType = property.PropertyType;
                    if (propertyType.IsEnum || (Nullable.GetUnderlyingType(propertyType)?.IsEnum ?? false))
                    {
                        var enumType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
                        var value = Enum.Parse(enumType, databaseValue.ToString());
                        property.SetValue(instance, value);
                    }
                    else if (propertyType.Equals(typeof(System.Byte[])))
                    {
                        property.SetValue(instance, databaseValue);
                    }
                    else
                    {
                        propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                        var safeValue = Convert.ChangeType(databaseValue, propertyType);
                        property.SetValue(instance, safeValue);
                    }
                }
            }
            foreach (Dictionary<string, List<object>> dictionary in columns.Where(n => n.GetType() == typeof(Dictionary<string, List<object>>)))
            {
                foreach (string key in dictionary.Keys)
                {
                    PropertyInfo propertyInfo = InstanceType.GetProperty(key);
                    Type propertyType = propertyInfo.GetMethod.ReturnType;
                    var pp = propertyType.GetNestedTypes().ToList();
                    if (propertyType.GetNestedTypes().Contains(typeof(MasterModel<object>))) //Si extiene el modelo maestro tratar como modelo
                    {
                        var constructor = propertyType.GetConstructors();
                        var newInstanceBySubPropertyClass = propertyType.GetConstructors().FirstOrDefault().Invoke(new Object[] { });
                        ((MasterModel<object>)newInstanceBySubPropertyClass).ActionState = ActionStateEnum.Original;
                        newInstanceBySubPropertyClass = InitializeProperties(sqlDataReader, dictionary[key], newInstanceBySubPropertyClass);
                        propertyInfo.SetValue(instance, newInstanceBySubPropertyClass); //inicializar la propiedad de tipo entidad con el contructor por defecto
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Setea las propiedades de un ogjeto en parametros sql
        /// </summary>
        /// <param name="parameters">Parametros</param>
        /// <param name="model">Entidad u objeto del cual se obtienen los parámetros</param>
        private void ModelPropertiesToParameterCollection(ref SqlParameterCollection parameters, TModel model)
        {
            foreach (PropertyInfo propertyInfo in InstanceType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                foreach (Attribute Attribute in Attribute.GetCustomAttributes(propertyInfo, true))
                {
                    if (Attribute.GetType() == typeof(PropertyToDBColumn) && ((PropertyToDBColumn)Attribute).TypeColumn != SqlTypesColumn.AppController)
                    {
                        var value = propertyInfo.GetValue(model);
                        if (value != null) parameters.AddWithValue("@" + ((PropertyToDBColumn)Attribute).ColumnName , value);
                    }
                }
            }
        }

        public void Dispose()
        {
            if (SqlConnection != null && SqlConnection.State != System.Data.ConnectionState.Closed) SqlConnection.Dispose();
            SqlString = null;
        }

    }

    public class UpdateCollectionResult
    {
        public int Registered { get; set; }
        public int Updated { get; set; }
        public int Deleted { get; set; }
    }

}
