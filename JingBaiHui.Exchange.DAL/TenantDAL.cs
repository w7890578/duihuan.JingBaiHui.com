using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JingBaiHui.Common;
using JingBaiHui.Exchange.Enum;
using JingBaiHui.Exchange.Model;

namespace JingBaiHui.Exchange.DAL
{
    /// <summary>
    /// Tenant数据访问层
    /// </summary>
    public class TenantDAL : BaseDAL, IDAL<Tenant>
    {
        #region singleton
        private static readonly TenantDAL instance = new TenantDAL();
        private TenantDAL() { }
        public static TenantDAL Instance
        {
            get { return instance; }
        }
        #endregion

        /// <summary>
        ///  创建
        /// </summary>
        /// <param name="entity"></param>
        public void Create(Tenant entity)
        {
            string sql = @"
				        INSERT INTO [dbo].[Tenant]
				           	(
			    	            [Id],
	            	            [TenantName],
                                [TenantLoginPage],
                                [AccesseAddress],
                                [TenantLetter],
	            	            [CreateTime],
	            	            [CreateUserId]
	              			)
				     	VALUES
				           (
					            @Id,
	            	            @TenantName,
                                @TenantLoginPage,
                                @AccesseAddress,
                                @TenantLetter,
	            	            @CreateTime,
	            	            @CreateUserId
	            			)
        			";
            Dictionary<string, object> parameters = new Dictionary<string, object>() 
        	 {
          	      {"@Id",entity.Id},
	      	      {"@TenantName",entity.TenantName},
                  {"@TenantLoginPage",entity.TenantLoginPage},
	      	      {"@CreateTime",entity.CreateTime},
	      	      {"@CreateUserId",entity.CreateUserId},
	      	      {"@AccesseAddress",entity.AccesseAddress},
	      	      {"@TenantLetter",entity.TenantLetter}
	          };
            DataBase db = DataBaseFactory.Create(Const.DBName);
            db.ExecuteNoneQuery(sql, parameters);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Tenant entity)
        {
            string sql = @"
                    UPDATE [dbo].[Tenant]
                       SET  
                	            [TenantName] = @TenantName,
                                [TenantLoginPage]=@TenantLoginPage,
                                [AccesseAddress]=@AccesseAddress,
                                [TenantLetter]=@TenantLetter,
	            	            [UpdateTime] = @UpdateTime,
	            	            [UpdateUserId] = @UpdateUserId
	              		WHERE [Id]=@Id
                        ";
            Dictionary<string, object> parameters = new Dictionary<string, object>() 
        	 {
                  {"@Id",entity.Id},
          	      {"@TenantName",entity.TenantName},
                  {"@TenantLoginPage",entity.TenantLoginPage},
	      	      {"@UpdateTime",entity.UpdateTime},
	      	      {"@UpdateUserId",entity.UpdateUserId},
	      	      {"@AccesseAddress",entity.AccesseAddress},
	      	      {"@TenantLetter",entity.TenantLetter}
	          };
            DataBase db = DataBaseFactory.Create(Const.DBName);
            db.ExecuteNoneQuery(sql, parameters);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(Guid Id)
        {
            string sql = @" 
                DELETE FROM [dbo].[Tenant]
                  WHERE [Id]=@Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() 
        	{
          	     {"@Id",Id} 
	        };
            DataBase db = DataBaseFactory.Create(Const.DBName);
            db.ExecuteNoneQuery(sql, parameters);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Tenant Get(Guid Id)
        {
            string sql = @" 
                SELECT TOP 1 * FROM [dbo].[Tenant]
                  WHERE [Id]=@Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() 
        	{
          	     {"@Id",Id} 
	        };
            return db.GetEntity<Tenant>(
                delegate(IDataReader reader, Tenant entity)
                {
                    BuildTenant(reader, entity);
                },
                sql, parameters);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IList<Tenant> GetList(Tenant entity)
        {
            StringBuilder sql = new StringBuilder(" SELECT * FROM [dbo].[Tenant] ");
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            LoadCondition(entity, sql, ref parameters);

            return db.GetList<Tenant>(
                    delegate(IDataReader reader, Tenant dataModel)
                    {
                        BuildTenant(reader, dataModel);
                    },
                    sql.ToString(), parameters);

        }

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="entity">查询实体</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">一页显示条数</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public IList<Tenant> GetList(Tenant entity, int pageIndex, int pageSize, string order = Const.Order)
        {
            StringBuilder sql = new StringBuilder(" SELECT * FROM [dbo].[Tenant] ");
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            LoadCondition(entity, sql, ref parameters);

            return db.GetList<Tenant>(
                 delegate(IDataReader reader, Tenant dataModel)
                 {
                     BuildTenant(reader, dataModel);
                 },
                 sql.ToString(), parameters, pageIndex, pageSize, order);

        }

        #region private

        /// <summary>
        /// 映射
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="entity"></param>
        private void BuildTenant(IDataReader reader, Tenant entity)
        {
            entity.Id = reader.GetValue<Guid>("Id");
            entity.TenantName = reader.GetValue<string>("TenantName");
            entity.TenantLoginPage = reader.GetValue<string>("TenantLoginPage");
            entity.CreateTime = reader.GetValue<DateTime>("CreateTime");
            entity.CreateUserId = reader.GetValue<Guid>("CreateUserId");
            entity.UpdateTime = reader.GetValue<DateTime>("UpdateTime");
            entity.UpdateUserId = reader.GetValue<Guid>("UpdateUserId");
            entity.AccesseAddress = reader.GetValue<string>("AccesseAddress");
            entity.TenantLetter = reader.GetValue<string>("TenantLetter");
        }

        /// <summary>
        /// 加载条件
        /// </summary>
        /// <param name="entity">查询实体</param>
        /// <param name="sql">SQL命令</param>
        /// <param name="parameters">参数</param>
        private void LoadCondition(Tenant entity, StringBuilder sql, ref Dictionary<string, object> parameters)
        {
            if (entity == null)
                return;

            sql.AppendFormat(" WHERE 1=1 ");
          
            if (entity.Id != Guid.Empty)
            {
                sql.AppendFormat(" AND [Id]=@Id ");
                parameters.Add("@Id", entity.Id);
            }
            if (!string.IsNullOrEmpty(entity.TenantName))
            {
                sql.AppendFormat(" AND [TenantName] Like '%'+@TenantName+'%' ");
                parameters.Add("@TenantName", entity.TenantName);
            }
            if (!string.IsNullOrEmpty(entity.TenantLetter))
            {
                sql.AppendFormat(" AND [TenantLetter]=@TenantLetter ");
                parameters.Add("@TenantLetter", entity.TenantLetter);
            }
            if (entity.CreateUserId != Guid.Empty)
            {
                sql.AppendFormat(" AND [CreateUserId]=@CreateUserId ");
                parameters.Add("@CreateUserId", entity.CreateUserId);
            }

            if (entity.UpdateUserId != Guid.Empty)
            {
                sql.AppendFormat(" AND [UpdateUserId]=@UpdateUserId ");
                parameters.Add("@UpdateUserId", entity.UpdateUserId);
            }
        }

        #endregion
    }
}


