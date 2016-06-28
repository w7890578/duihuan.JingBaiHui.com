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
    /// Program数据访问层
    /// </summary>
    public class ProgramDAL : BaseDAL, IDAL<Program>
    {
        #region singleton
        private static readonly ProgramDAL instance = new ProgramDAL();
        private ProgramDAL() { }
        public static ProgramDAL Instance
        {
            get { return instance; }
        }
        #endregion

        /// <summary>
        ///  创建
        /// </summary>
        /// <param name="entity"></param>
        public void Create(Program entity)
        {
            string sql = @"
				        INSERT INTO [dbo].[Program]
				           	(
			    	            [Id],
	            	            [TenantId],
	            	            [ProgramName],
	            	            [ProductIds],
	            	            [CreateTime],
	            	            [CreateUserId]
	              			)
				     	VALUES
				           (
					            @Id,
	            	            @TenantId,
	            	            @ProgramName,
	            	            @ProductIds,
	            	            @CreateTime,
	            	            @CreateUserId 
	            			)
        			";
            Dictionary<string, object> parameters = new Dictionary<string, object>() 
        	 {
          	      {"@Id",entity.Id},
	      	      {"@TenantId",entity.TenantId},
	      	      {"@ProgramName",entity.ProgramName},
	      	      {"@ProductIds",entity.ProductIds},
	      	      {"@CreateTime",entity.CreateTime},
	      	      {"@CreateUserId",entity.CreateUserId} 
	          };
            DataBase db = DataBaseFactory.Create(Const.DBName);
            db.ExecuteNoneQuery(sql, parameters);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Program entity)
        {
            string sql = @"
                    UPDATE [dbo].[Program]
                       SET  
                	            [TenantId] = @TenantId,
	            	            [ProgramName] = @ProgramName,
	            	            [ProductIds] = @ProductIds,
	            	            [UpdateTIme] = @UpdateTIme,
	            	            [UpdateUserId] = @UpdateUserId
	              		WHERE [Id]=@Id
                        ";
            Dictionary<string, object> parameters = new Dictionary<string, object>() 
        	 {
          	      {"@Id",entity.Id},
          	      {"@TenantId",entity.TenantId},
	      	      {"@ProgramName",entity.ProgramName},
	      	      {"@ProductIds",entity.ProductIds},
	      	      {"@UpdateTIme",entity.UpdateTime},
	      	      {"@UpdateUserId",entity.UpdateUserId}
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
                DELETE FROM [dbo].[Program]
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
        public Program Get(Guid Id)
        {
            string sql = @" 
                SELECT TOP 1 * FROM [dbo].[Program]
                  WHERE [Id]=@Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() 
        	{
          	     {"@Id",Id} 
	        };
            return db.GetEntity<Program>(
                delegate(IDataReader reader, Program entity)
                {
                    BuildProgram(reader, entity);
                },
                sql, parameters);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IList<Program> GetList(Program entity)
        {
            StringBuilder sql = new StringBuilder(" SELECT * FROM [dbo].[Program] ");
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            LoadCondition(entity, sql, ref parameters);

            return db.GetList<Program>(
                 delegate(IDataReader reader, Program dataModel)
                 {
                     BuildProgram(reader, dataModel);
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
        public IList<Program> GetList(Program entity, int pageIndex, int pageSize, string order = Const.Order)
        {
            StringBuilder sql = new StringBuilder(" SELECT * FROM [dbo].[Program] ");
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            LoadCondition(entity, sql, ref parameters);

            return db.GetList<Program>(
                 delegate(IDataReader reader, Program dataModel)
                 {
                     BuildProgram(reader, dataModel);
                 },
                 sql.ToString(), parameters, pageIndex, pageSize, order);
        }

        #region private

        /// <summary>
        /// 映射
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="entity"></param>
        private void BuildProgram(IDataReader reader, Program entity)
        {
            entity.Id = reader.GetValue<Guid>("Id");
            entity.TenantId = reader.GetValue<Guid>("TenantId");
            entity.ProgramName = reader.GetValue<string>("ProgramName");
            entity.ProductIds = reader.GetValue<string>("ProductIds");
            entity.CreateTime = reader.GetValue<DateTime>("CreateTime");
            entity.CreateUserId = reader.GetValue<Guid>("CreateUserId");
            entity.UpdateTime = reader.GetValue<DateTime>("UpdateTime");
            entity.UpdateUserId = reader.GetValue<Guid>("UpdateUserId");
        }

        /// <summary>
        /// 加载条件
        /// </summary>
        /// <param name="entity">查询实体</param>
        /// <param name="sql">sql命令</param>
        /// <param name="parameters">参数</param>
        private void LoadCondition(Program entity, StringBuilder sql, ref Dictionary<string, object> parameters)
        {
            if (entity == null)
                return;

            sql.AppendFormat(" WHERE 1=1 ");

            if (entity.Id != Guid.Empty)
            {
                sql.AppendFormat(" AND [Id]=@Id ");
                parameters.Add("@Id", entity.Id);
            }
            if (entity.TenantId != Guid.Empty)
            {
                sql.AppendFormat(" AND [TenantId]=@TenantId ");
                parameters.Add("@TenantId", entity.TenantId);
            }
            if (!string.IsNullOrEmpty(entity.ProgramName))
            {
                sql.AppendFormat(" AND [ProgramName]=@ProgramName ");
                parameters.Add("@ProgramName", entity.ProgramName);
            }
            if (!string.IsNullOrEmpty(entity.ProductIds))
            {
                sql.AppendFormat(" AND [ProductIds]=@ProductIds ");
                parameters.Add("@ProductIds", entity.ProductIds);
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


