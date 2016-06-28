using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JingBaiHui.Common
{
    public class DataBaseFactory
    {
        public static DataBase Create(string dataBaseName)
        {
            return new DataBase(dataBaseName);
        }
    }

    public class DataBase
    {
        public DataBase(string dataBaseName)
        {
            this.ConnectionStringName = dataBaseName;
        }
        private const string OrderBy = " CreateTime desc ";
        public string ConnectionStringName { get; set; }
        public delegate void EntityConverter<T>(IDataReader reader, T entity) where T : new();

        private string ConnectionString
        {
            get
            {
                var settingsCollection = ConfigurationManager.ConnectionStrings[ConnectionStringName];
                if (settingsCollection == null)
                    throw new Exception(String.Format("连接字符串名 {0} 未找到， 请确认配置文件的配置是否正确", ConnectionStringName));
                else
                    return settingsCollection.ConnectionString;
            }
        }

        private string DefaultProvider
        {
            get { return "System.Data.SqlClient"; }
        }

        private string ProviderName
        {
            get
            {
                var settingsCollection = ConfigurationManager.ConnectionStrings[ConnectionStringName];
                return settingsCollection == null ? DefaultProvider : settingsCollection.ProviderName;
            }
        }

        private DbProviderFactory Factory
        {
            get
            {
                if (!string.IsNullOrEmpty(ProviderName))
                    return DbProviderFactories.GetFactory(ProviderName);
                else
                    throw new Exception("请设定正确的提供程序名称，程序无法创建数据对象工厂！");
            }
        }

        private DbConnection CreateConnection()
        {
            DbConnection connection = Factory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            return connection;
        }

        private DbCommand CreateCommand(CommandType commandType, String commandText, Dictionary<string, object> parameters = null)
        {
            DbCommand cmd = CreateConnection().CreateCommand();
            cmd.CommandType = commandType;
            cmd.CommandText = commandText;
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> item in parameters)
                {
                    DbParameter dbParameter = cmd.CreateParameter();
                    dbParameter.ParameterName = item.Key;
                    dbParameter.Value = item.Value;
                    cmd.Parameters.Add(dbParameter);
                }
            }
            return cmd;
        }

        #region ExecuteScalar
        private Object ExecuteScalar(DbCommand cmd)
        {
            object scalar = null;
            try
            {
                cmd.Connection.Open();

                scalar = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex, cmd);
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return scalar;
        }

        private Object ExecuteScalarWithTransaction(DbCommand cmd)
        {
            Object scalar = null;
            try
            {
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                try
                {
                    scalar = cmd.ExecuteScalar();

                    cmd.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex, cmd);
                    cmd.Transaction.Rollback();
                    throw ex;
                }
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return scalar;
        }

        private Object ExecuteScalar(DbCommand cmd, Boolean isTranscation)
        {
            if (isTranscation)
                return ExecuteScalarWithTransaction(cmd);
            else
                return ExecuteScalar(cmd);
        }

        public object ExecuteScalar(string commandText, Dictionary<String, Object> parameters = null, CommandType commandType = CommandType.Text, Boolean isTranscation = false)
        {
            var cmd = CreateCommand(commandType, commandText, parameters);
            return ExecuteScalar(cmd, isTranscation);
        }
        #endregion

        #region ExecuteNoneQuery
        /// <summary>
        /// 执行非查询操作
        /// </summary>
        /// <param name="cmd">命令对象</param>
        /// <returns>受影响的行数</returns>
        private int ExecuteNoneQuery(DbCommand cmd)
        {
            int affectedRows = 0;
            try
            {
                cmd.Connection.Open();
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex, cmd);
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return affectedRows;
        }

        /// <summary>
        /// 执行非查询操作，执行务事
        /// </summary>
        /// <param name="cmd">命令对象</param>
        /// <returns>受影响的行数</returns>
        private int ExecuteNonQueryWithTransaction(DbCommand cmd)
        {
            Int32 affectedRows = 0;
            try
            {
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction();
                try
                {
                    affectedRows = cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    LogHelper.Error(ex, cmd);
                    cmd.Transaction.Rollback();
                    throw ex;
                }
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return affectedRows;
        }

        private int ExecuteNoneQuery(DbCommand cmd, Boolean IsTransaction)
        {
            if (IsTransaction)
                return ExecuteNonQueryWithTransaction(cmd);
            else
                return ExecuteNoneQuery(cmd);
        }

        public object ExecuteNoneQuery(string commandText, Dictionary<String, Object> parameters = null, CommandType commandType = CommandType.Text, Boolean isTranscation = false)
        {
            var cmd = CreateCommand(commandType, commandText, parameters);
            return ExecuteNoneQuery(cmd, isTranscation);
        }
        #endregion

        #region GetEntity
        private T GetEntity<T>(EntityConverter<T> converter, DbCommand cmd) where T : class, new()
        {
            T obj = new T();
            try
            {
                cmd.Connection.Open();

                DbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    converter(reader, obj);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex, cmd);
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return obj;
        }

        public T GetEntity<T>(EntityConverter<T> converter, String cmdText, Dictionary<String, Object> parameters = null, CommandType commandType = CommandType.Text) where T : class, new()
        {
            DbCommand cmd = CreateCommand(commandType, cmdText, parameters);
            return GetEntity<T>(converter, cmd);
        }
        #endregion

        #region GetList
        /// <summary>
        /// 执行返回实体列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="converter"></param>
        /// <param name="cmd">命令对象</param>
        /// <returns>实体列表</returns>
        public IList<T> GetList<T>(EntityConverter<T> converter, DbCommand cmd) where T : class, new()
        {
            IList<T> list = new List<T>();
            try
            {
                cmd.Connection.Open();
                DbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    T obj = new T();
                    converter(reader, obj);
                    list.Add(obj);
                }
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex, cmd);
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                cmd.Dispose();
            }
            return list;
        }

        /// <summary>
        /// 执行返回实体列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="converter"></param>
        /// <param name="cmdText">命令文本</param>
        /// <returns>实体列表</returns>
        public IList<T> GetList<T>(EntityConverter<T> converter, String cmdText, Dictionary<String, Object> parameters = null, CommandType commandType = CommandType.Text) where T : class, new()
        {
            DbCommand cmd = CreateCommand(commandType, cmdText, parameters);
            return GetList<T>(converter, cmd);
        }
        #endregion

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="converter"></param>
        /// <param name="cmdText">SQL</param>
        /// <param name="parameters">参数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">一页显示条数</param>
        /// <param name="order">排序 例如：CreateTime desc</param>
        /// <returns></returns>
        public IList<T> GetList<T>(EntityConverter<T> converter, String cmdText, Dictionary<String, Object> parameters, int pageIndex, int pageSize, string order) where T : class, new()
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            cmdText = string.Format(@"
SELECT *
FROM
  (SELECT ROW_NUMBER() OVER(
                            ORDER BY {0}) AS aaaaa ,
          *
   FROM ({1})as temp) as temp
WHERE temp.aaaaa BETWEEN {2} AND {3}", string.IsNullOrEmpty(order) ? OrderBy : order, cmdText, start, end);
            DbCommand cmd = CreateCommand(CommandType.Text, cmdText, parameters);
            return GetList<T>(converter, cmd);
        }
    }
}
