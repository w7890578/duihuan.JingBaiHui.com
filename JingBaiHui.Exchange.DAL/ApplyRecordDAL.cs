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
    /// ApplyRecord数据访问层
    /// </summary>
    public class ApplyRecordDAL : BaseDAL, IDAL<ApplyRecord>
    {
        #region singleton
        private static readonly ApplyRecordDAL instance = new ApplyRecordDAL();
        private ApplyRecordDAL() { }
        public static ApplyRecordDAL Instance
        {
            get { return instance; }
        }
        #endregion

        /// <summary>
        ///  创建
        /// </summary>
        /// <param name="entity"></param>
        public void Create(ApplyRecord entity)
        {
            string sql = @"
				        INSERT INTO [dbo].[ApplyRecord]
				           	(
			    	            [Id],
	            	            [TenantId],
	            	            [GiftCardId],
	            	            [ReceivingUserName],
	            	            [ReceivingAddress],
	            	            [ReceivingUserPhone],
	            	            [ZipCode],
	            	            [ApplyRecordStatus],
	            	            [Remark],
	            	            [CreateTime],
	            	            [CreateUserId],
                                [ProductId]
	              			)
				     	VALUES
				           (
					            @Id,
	            	            @TenantId,
	            	            @GiftCardId,
	            	            @ReceivingUserName,
	            	            @ReceivingAddress,
	            	            @ReceivingUserPhone,
	            	            @ZipCode,
	            	            @ApplyRecordStatus,
	            	            @Remark,
	            	            @CreateTime,
	            	            @CreateUserId,
                                @ProductId
	            			)
        			";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
             {
                    {"@Id",entity.Id},
                    {"@TenantId",entity.TenantId},
                    {"@GiftCardId",entity.GiftCardId},
                    {"@ReceivingUserName",entity.ReceivingUserName},
                    {"@ReceivingAddress",entity.ReceivingAddress},
                    {"@ReceivingUserPhone",entity.ReceivingUserPhone},
                    {"@ZipCode",entity.ZipCode},
                    {"@ApplyRecordStatus",entity.ApplyRecordStatus},
                    {"@Remark",entity.Remark},
                    {"@CreateTime",entity.CreateTime},
                    {"@CreateUserId",entity.CreateUserId},
                    {"@ProductId",entity.ProductId}
              };
            DataBase db = DataBaseFactory.Create(Const.DBName);
            db.ExecuteNoneQuery(sql, parameters);
        }


        public void UpdateProductInfo(ApplyRecord entity)
        {
            string sql = @"
                    UPDATE [dbo].[ApplyRecord]
                       SET  
                	            [TenantId] = @TenantId, 
	            	            [UpdateTime] = @UpdateTime,
	            	            [UpdateUserId] = @UpdateUserId,
                                [ProductId]=@ProductId
	              		WHERE [Id]=@Id
                        ";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
             {
                    {"@Id",entity.Id},
                    {"@TenantId",entity.TenantId},
                    {"@UpdateTime",entity.UpdateTime},
                    {"@UpdateUserId",entity.UpdateUserId},
                    {"@ProductId",entity.ProductId}

              };
            DataBase db = DataBaseFactory.Create(Const.DBName);
            db.ExecuteNoneQuery(sql, parameters);
        }

        public void UpdateReceivingInfo(ApplyRecord entity)
        {
            string sql = @"
                    UPDATE [dbo].[ApplyRecord]
                       SET   
	            	            [ReceivingUserName] = @ReceivingUserName,
	            	            [ReceivingAddress] = @ReceivingAddress,
	            	            [ReceivingUserPhone] = @ReceivingUserPhone,
	            	            [ZipCode] = @ZipCode, 
	            	            [Remark] = @Remark,
	            	            [UpdateTime] = @UpdateTime,
	            	            [UpdateUserId] = @UpdateUserId 
	              		WHERE [Id]=@Id
                        ";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
             {
                  {"@Id",entity.Id}, 
                    {"@ReceivingUserName",entity.ReceivingUserName},
                    {"@ReceivingAddress",entity.ReceivingAddress},
                    {"@ReceivingUserPhone",entity.ReceivingUserPhone},
                    {"@ZipCode",entity.ZipCode},
                    {"@Remark",entity.Remark},
                    {"@UpdateTime",entity.UpdateTime},
                    {"@UpdateUserId",entity.UpdateUserId} 
              };
            DataBase db = DataBaseFactory.Create(Const.DBName);
            db.ExecuteNoneQuery(sql, parameters);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(ApplyRecord entity)
        {
            string sql = @"
                    UPDATE [dbo].[ApplyRecord]
                       SET  
                	            [TenantId] = @TenantId,
	            	            [GiftCardId] = @GiftCardId,
	            	            [ReceivingUserName] = @ReceivingUserName,
	            	            [ReceivingAddress] = @ReceivingAddress,
	            	            [ReceivingUserPhone] = @ReceivingUserPhone,
	            	            [ZipCode] = @ZipCode,
	            	            [ApplyRecordStatus] = @ApplyRecordStatus,
	            	            [Remark] = @Remark,
	            	            [UpdateTime] = @UpdateTime,
	            	            [UpdateUserId] = @UpdateUserId,
                                [ProductId]=@ProductId
	              		WHERE [Id]=@Id
                        ";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
             {
                  {"@Id",entity.Id},
                    {"@TenantId",entity.TenantId},
                    {"@GiftCardId",entity.GiftCardId},
                    {"@ReceivingUserName",entity.ReceivingUserName},
                    {"@ReceivingAddress",entity.ReceivingAddress},
                    {"@ReceivingUserPhone",entity.ReceivingUserPhone},
                    {"@ZipCode",entity.ZipCode},
                    {"@ApplyRecordStatus",entity.ApplyRecordStatus},
                    {"@Remark",entity.Remark},
                    {"@UpdateTime",entity.UpdateTime},
                    {"@UpdateUserId",entity.UpdateUserId},
                    {"@ProductId",entity.ProductId}

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
                DELETE FROM [dbo].[ApplyRecord]
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
        public ApplyRecord Get(Guid Id)
        {
            string sql = @" 
SELECT * FROM (
	   SELECT A.*,B.TenantName,C.ProductName,E.ProgramName,D.CardNumber FROM [dbo].[ApplyRecord] A 
	   LEFT JOIN  [dbo].[Tenant] B ON A.TenantId=B.Id
	   LEFT JOIN  [dbo].[Product] C ON A.ProductId=C.Id
	   Left join  [dbo].[GiftCard] D ON A.GiftCardId=D.Id
	   left join  [dbo].[Program]  E ON D.ProgramId=E.Id
   ) T WHERE [Id]=@Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                   {"@Id",Id}
            };
            return db.GetEntity<ApplyRecord>(
                delegate (IDataReader reader, ApplyRecord entity)
                {
                    BuildApplyRecord(reader, entity);
                },
                sql, parameters);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IList<ApplyRecord> GetList(ApplyRecord entity)
        {
            StringBuilder sql = new StringBuilder(@" 
SELECT * FROM (
	   SELECT A.*,B.TenantName,C.ProductName,E.ProgramName,D.CardNumber FROM [dbo].[ApplyRecord] A 
	   LEFT JOIN  [dbo].[Tenant] B ON A.TenantId=B.Id
	   LEFT JOIN  [dbo].[Product] C ON A.ProductId=C.Id
	   Left join  [dbo].[GiftCard] D ON A.GiftCardId=D.Id
	   left join  [dbo].[Program]  E ON D.ProgramId=E.Id
   ) T");
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            LoadCondition(entity, sql, ref parameters);

            return db.GetList<ApplyRecord>(
                 delegate (IDataReader reader, ApplyRecord dataModel)
                 {
                     BuildApplyRecord(reader, dataModel);
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
        public IList<ApplyRecord> GetList(ApplyRecord entity, int pageIndex, int pageSize, string order = Const.Order)
        {
            StringBuilder sql = new StringBuilder(@" 
SELECT * FROM (
	   SELECT A.*,B.TenantName,C.ProductName,E.ProgramName,D.CardNumber FROM [dbo].[ApplyRecord] A 
	   LEFT JOIN  [dbo].[Tenant] B ON A.TenantId=B.Id
	   LEFT JOIN  [dbo].[Product] C ON A.ProductId=C.Id
	   Left join  [dbo].[GiftCard] D ON A.GiftCardId=D.Id
	   left join  [dbo].[Program]  E ON D.ProgramId=E.Id
   ) T");
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            LoadCondition(entity, sql, ref parameters);

            return db.GetList<ApplyRecord>(
                 delegate (IDataReader reader, ApplyRecord dataModel)
                 {
                     BuildApplyRecord(reader, dataModel);
                 },
                 sql.ToString(), parameters, pageIndex, pageSize, order);
        }

        #region private

        /// <summary>
        /// 映射
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="entity"></param>
        private void BuildApplyRecord(IDataReader reader, ApplyRecord entity)
        {
            entity.Id = reader.GetValue<Guid>("Id");
            entity.TenantId = reader.GetValue<Guid>("TenantId");
            entity.TenantName = reader.GetValue<string>("TenantName");
            entity.GiftCardId = reader.GetValue<Guid>("GiftCardId");
            entity.ReceivingUserName = reader.GetValue<string>("ReceivingUserName");
            entity.ReceivingAddress = reader.GetValue<string>("ReceivingAddress");
            entity.ReceivingUserPhone = reader.GetValue<string>("ReceivingUserPhone");
            entity.ZipCode = reader.GetValue<string>("ZipCode");
            entity.ApplyRecordStatus = (ApplyRecordStatus)reader.GetValue<int>("ApplyRecordStatus");
            entity.Remark = reader.GetValue<string>("Remark");
            entity.CreateTime = reader.GetValue<DateTime>("CreateTime");
            entity.CreateUserId = reader.GetValue<Guid>("CreateUserId");
            entity.UpdateTime = reader.GetValue<DateTime>("UpdateTime");
            entity.UpdateUserId = reader.GetValue<Guid>("UpdateUserId");
            entity.ProductId = reader.GetValue<Guid>("ProductId");
            entity.ProductName = reader.GetValue<string>("ProductName");
            entity.ProgramName = reader.GetValue<string>("ProgramName");
            entity.CardNumber = reader.GetValue<string>("CardNumber");
        }

        /// <summary>
        /// 加载条件
        /// </summary>
        /// <param name="entity">查询实体</param>
        /// <param name="sql">sql命令</param>
        /// <param name="parameters">参数</param>
        private void LoadCondition(ApplyRecord entity, StringBuilder sql, ref Dictionary<string, object> parameters)
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
            if (entity.GiftCardId != Guid.Empty)
            {
                sql.AppendFormat(" AND [GiftCardId]=@GiftCardId ");
                parameters.Add("@GiftCardId", entity.GiftCardId);
            }
            if (!string.IsNullOrEmpty(entity.ReceivingUserName))
            {
                sql.AppendFormat(" AND [ReceivingUserName]=@ReceivingUserName ");
                parameters.Add("@ReceivingUserName", entity.ReceivingUserName);
            }
            if (!string.IsNullOrEmpty(entity.ReceivingAddress))
            {
                sql.AppendFormat(" AND [ReceivingAddress]=@ReceivingAddress ");
                parameters.Add("@ReceivingAddress", entity.ReceivingAddress);
            }
            if (!string.IsNullOrEmpty(entity.ReceivingUserPhone))
            {
                sql.AppendFormat(" AND [ReceivingUserPhone]=@ReceivingUserPhone ");
                parameters.Add("@ReceivingUserPhone", entity.ReceivingUserPhone);
            }
            if (!string.IsNullOrEmpty(entity.ZipCode))
            {
                sql.AppendFormat(" AND [ZipCode]=@ZipCode ");
                parameters.Add("@ZipCode", entity.ZipCode);
            }
            if (entity.ApplyRecordStatus > 0)
            {
                sql.AppendFormat(" AND [ApplyRecordStatus]=@ApplyRecordStatus ");
                parameters.Add("@ApplyRecordStatus", entity.ApplyRecordStatus);
            }
            if (!string.IsNullOrEmpty(entity.Remark))
            {
                sql.AppendFormat(" AND [Remark]=@Remark ");
                parameters.Add("@Remark", entity.Remark);
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


