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
    /// GiftCard数据访问层
    /// </summary>
    public class GiftCardDAL : BaseDAL, IDAL<GiftCard>
    {
        #region singleton
        private static readonly GiftCardDAL instance = new GiftCardDAL();
        private GiftCardDAL() { }
        public static GiftCardDAL Instance
        {
            get { return instance; }
        }
        #endregion

        /// <summary>
        ///  创建
        /// </summary>
        /// <param name="entity"></param>
        public void Create(GiftCard entity)
        {
            string sql = @"
				        INSERT INTO [dbo].[GiftCard]
				           	(
			    	            [Id],
	            	            [TenantId],
	            	            [ProgramId],
	            	            [CardNumber],
	            	            [PassWord],
	            	            [GiftCardStatus],
	            	            [CreateTime],
	            	            [CreateUserId] 
	              			)
				     	VALUES
				           (
					            @Id,
	            	            @TenantId,
	            	            @ProgramId,
	            	            @CardNumber,
	            	            @PassWord,
	            	            @GiftCardStatus,
	            	            @CreateTime,
	            	            @CreateUserId 
	            			)
        			";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
             {
                    {"@Id",entity.Id},
                    {"@TenantId",entity.TenantId},
                    {"@ProgramId",entity.ProgramId},
                    {"@CardNumber",entity.CardNumber},
                    {"@PassWord",entity.PassWord},
                    {"@GiftCardStatus",entity.GiftCardStatus},
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
        public void Update(GiftCard entity)
        {
            string sql = @"
                    UPDATE [dbo].[GiftCard]
                       SET  
                	            [TenantId] = @TenantId,
	            	            [ProgramId] = @ProgramId,
	            	            [CardNumber] = @CardNumber,
	            	            [PassWord] = @PassWord, 
	            	            [UpdateTime] = @UpdateTime,
	            	            [UpdateUserId] = @UpdateUserId 
	              		WHERE [Id]=@Id
                        ";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
             {
                    {"@Id",entity.Id},
                    {"@TenantId",entity.TenantId},
                    {"@ProgramId",entity.ProgramId},
                    {"@CardNumber",entity.CardNumber},
                    {"@PassWord",entity.PassWord},
                    {"@UpdateTime",entity.UpdateTime},
                    {"@UpdateUserId",entity.UpdateUserId} 
              };
            DataBase db = DataBaseFactory.Create(Const.DBName);
            db.ExecuteNoneQuery(sql, parameters);
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="giftCardStatus"></param>
        public void UpdateStatus(Guid Id, GiftCardStatus giftCardStatus)
        {
            string sql = @"
                    UPDATE [dbo].[GiftCard]
                       SET  
                	            [GiftCardStatus] = @GiftCardStatus 
	              		WHERE [Id]=@Id
                        ";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
             {
                    {"@Id",Id},
                    {"@GiftCardStatus",(int)giftCardStatus}
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
                DELETE FROM [dbo].[GiftCard]
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
        public GiftCard Get(Guid Id)
        {
            string sql = @" 
                SELECT TOP 1 A.*,B.ProgramName FROM [dbo].[GiftCard] A
                LEFT JOIN  [dbo].[Program] B ON A.ProgramId=B.Id 
                  WHERE [Id]=@Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                   {"@Id",Id}
            };
            return db.GetEntity<GiftCard>(
                delegate (IDataReader reader, GiftCard entity)
                {
                    BuildGiftCard(reader, entity);
                },
                sql, parameters);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IList<GiftCard> GetList(GiftCard entity)
        {
            StringBuilder sql = new StringBuilder(@" 
                SELECT  A.*,B.ProgramName FROM [dbo].[GiftCard] A
                LEFT JOIN  [dbo].[Program] B ON A.ProgramId=B.Id 
                  WHERE [Id]=@Id ");
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            LoadCondition(entity, sql, ref parameters);

            return db.GetList<GiftCard>(
                 delegate (IDataReader reader, GiftCard dataModel)
                 {
                     BuildGiftCard(reader, dataModel);
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
        public IList<GiftCard> GetList(GiftCard entity, int pageIndex, int pageSize, string order = Const.Order)
        {
            StringBuilder sql = new StringBuilder(@" 
                SELECT  A.*,B.ProgramName FROM [dbo].[GiftCard] A
                LEFT JOIN  [dbo].[Program] B ON A.ProgramId=B.Id 
                  WHERE [Id]=@Id  ");
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            LoadCondition(entity, sql, ref parameters);

            return db.GetList<GiftCard>(
                 delegate (IDataReader reader, GiftCard dataModel)
                 {
                     BuildGiftCard(reader, dataModel);
                 },
                 sql.ToString(), parameters, pageIndex, pageSize, order);
        }

        #region private

        /// <summary>
        /// 映射
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="entity"></param>
        private void BuildGiftCard(IDataReader reader, GiftCard entity)
        {
            entity.Id = reader.GetValue<Guid>("Id");
            entity.TenantId = reader.GetValue<Guid>("TenantId");
            entity.ProgramId = reader.GetValue<Guid>("ProgramId");
            entity.CardNumber = reader.GetValue<string>("CardNumber");
            entity.PassWord = reader.GetValue<string>("PassWord");
            entity.GiftCardStatus = (GiftCardStatus)reader.GetValue<int>("GiftCardStatus");
            entity.CreateTime = reader.GetValue<DateTime>("CreateTime");
            entity.CreateUserId = reader.GetValue<Guid>("CreateUserId");
            entity.UpdateTime = reader.GetValue<DateTime>("UpdateTime");
            entity.UpdateUserId = reader.GetValue<Guid>("UpdateUserId");
            entity.ProgramName = reader.GetValue<string>("ProgramName");
        }

        /// <summary>
        /// 加载条件
        /// </summary>
        /// <param name="entity">查询实体</param>
        /// <param name="sql">sql命令</param>
        /// <param name="parameters">参数</param>
        private void LoadCondition(GiftCard entity, StringBuilder sql, ref Dictionary<string, object> parameters)
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
            if (entity.ProgramId != Guid.Empty)
            {
                sql.AppendFormat(" AND [ProgramId]=@ProgramId ");
                parameters.Add("@ProgramId", entity.ProgramId);
            }
            if (!string.IsNullOrEmpty(entity.CardNumber))
            {
                sql.AppendFormat(" AND [CardNumber] like '%'+@CardNumber+'%'");
                parameters.Add("@CardNumber", entity.CardNumber);
            }
            if (!string.IsNullOrEmpty(entity.PassWord))
            {
                sql.AppendFormat(" AND [PassWord]=@PassWord ");
                parameters.Add("@PassWord", entity.PassWord);
            }
            if (entity.GiftCardStatus > 0)
            {
                sql.AppendFormat(" AND [GiftCardStatus]=@GiftCardStatus ");
                parameters.Add("@GiftCardStatus", entity.GiftCardStatus);
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


