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
    /// Product数据访问层
    /// </summary>
    public class ProductDAL : BaseDAL, IDAL<Product>
    {
        #region singleton
        private static readonly ProductDAL instance = new ProductDAL();
        private ProductDAL() { }
        public static ProductDAL Instance
        {
            get { return instance; }
        }
        #endregion
            
        /// <summary>
        ///  创建
        /// </summary>
        /// <param name="entity"></param>
        public void Create(Product entity)
        {
            string sql = @"
				        INSERT INTO [dbo].[Product]
				           	(
			    	            [Id],
	            	            [TenantId],
	            	            [ParentId],
	            	            [ProductName],
	            	            [ProductImgUrl],
	            	            [Price],
	            	            [Description],
	            	            [CreateTime],
	            	            [CreateUserId]
	              			)
				     	VALUES
				           (
					            @Id,
	            	            @TenantId,
	            	            @ParentId,
	            	            @ProductName,
	            	            @ProductImgUrl,
	            	            @Price,
	            	            @Description,
	            	            @CreateTime,
	            	            @CreateUserId
	            			)
        			";
            Dictionary<string, object> parameters = new Dictionary<string, object>() 
        	 {
          	      {"@Id",entity.Id},
	      	      {"@TenantId",entity.TenantId},
	      	      {"@ParentId",entity.ParentId},
	      	      {"@ProductName",entity.ProductName},
	      	      {"@ProductImgUrl",entity.ProductImgUrl},
	      	      {"@Price",entity.Price},
	      	      {"@Description",entity.Description},
	      	      {"@CreateTime",entity.CreateTime},
	      	      {"@CreateUserId",entity.CreateUserId},
	          };
            DataBase db = DataBaseFactory.Create(Const.DBName);
            db.ExecuteNoneQuery(sql, parameters);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Product entity)
        {
            string sql = @"
                    UPDATE [dbo].[Product]
                       SET  
                	            [TenantId] = @TenantId,
	            	            [ParentId] = @ParentId,
	            	            [ProductName] = @ProductName,
	            	            [ProductImgUrl] = @ProductImgUrl,
	            	            [Price] = @Price,
	            	            [Description] = @Description,
	            	            [UpdateTime] = @UpdateTime,
	            	            [UpdateUserId] = @UpdateUserId
	              		WHERE [Id]=@Id
                        ";
            Dictionary<string, object> parameters = new Dictionary<string, object>() 
        	 {
          	      {"@Id",entity.Id},
          	      {"@TenantId",entity.TenantId},
	      	      {"@ParentId",entity.ParentId},
	      	      {"@ProductName",entity.ProductName},
	      	      {"@ProductImgUrl",entity.ProductImgUrl},
	      	      {"@Price",entity.Price},
	      	      {"@Description",entity.Description},
	      	      {"@UpdateTime",entity.UpdateTime},
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
                DELETE FROM [dbo].[Product]
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
        public Product Get(Guid Id)
        {
            string sql = @" 
                SELECT TOP 1 a.*,
       b.ProductName AS ParentName
FROM [dbo].[Product] a left join [dbo].[Product] b ON a.parentId=b.Id
                  WHERE a.[Id]=@Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() 
        	{
          	     {"@Id",Id} 
	        };
            return db.GetEntity<Product>(
                delegate(IDataReader reader, Product entity)
                {
                    BuildProduct(reader, entity);
                },
                sql, parameters);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IList<Product> GetList(Product entity)
        {
            StringBuilder sql = new StringBuilder(@" 
SELECT * FROM 
(
SELECT a.*,
       b.ProductName AS ParentName
FROM [dbo].[Product] a left join [dbo].[Product] b ON a.parentId=b.Id
)  AS T ");
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            LoadCondition(entity, sql, ref parameters);

            return db.GetList<Product>(
                 delegate(IDataReader reader, Product dataModel)
                 {
                     BuildProduct(reader, dataModel);
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
        public IList<Product> GetList(Product entity, int pageIndex, int pageSize , string order = Const.Order)
        {
            StringBuilder sql = new StringBuilder(@" 
SELECT * FROM 
(
SELECT a.*,
       b.ProductName AS ParentName
FROM [dbo].[Product] a left join [dbo].[Product] b ON a.parentId=b.Id
)  AS T ");
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            LoadCondition(entity, sql, ref parameters);

            return db.GetList<Product>(
                 delegate(IDataReader reader, Product dataModel)
                 {
                     BuildProduct(reader, dataModel);
                 },
                 sql.ToString(), parameters, pageIndex, pageSize, order);
        }

        #region private

        /// <summary>
        /// 映射
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="entity"></param>
        private void BuildProduct(IDataReader reader, Product entity)
        {
            entity.Id = reader.GetValue<Guid>("Id");
            entity.TenantId = reader.GetValue<Guid>("TenantId");
            entity.ParentId = reader.GetValue<Guid>("ParentId");
            entity.ProductName = reader.GetValue<string>("ProductName");
            entity.ProductImgUrl = reader.GetValue<string>("ProductImgUrl");
            entity.Price = reader.GetValue<decimal>("Price");
            entity.Description = reader.GetValue<string>("Description");
            entity.CreateTime = reader.GetValue<DateTime>("CreateTime");
            entity.CreateUserId = reader.GetValue<Guid>("CreateUserId");
            entity.UpdateTime = reader.GetValue<DateTime>("UpdateTime");
            entity.UpdateUserId = reader.GetValue<Guid>("UpdateUserId");
            entity.ParentName = reader.GetValue<string>("ParentName");
        }

        /// <summary>
        /// 加载条件
        /// </summary>
        /// <param name="entity">查询实体</param>
        /// <param name="sql">sql命令</param>
        /// <param name="parameters">参数</param>
        private void LoadCondition(Product entity, StringBuilder sql, ref Dictionary<string, object> parameters)
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
            if (entity.ParentId != Guid.Empty)
            {
                sql.AppendFormat(" AND [ParentId]=@ParentId ");
                parameters.Add("@ParentId", entity.ParentId);
            }
            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                sql.AppendFormat(" AND [ProductName] like '%'+@ProductName+'%' ");
                parameters.Add("@ProductName", entity.ProductName);
            }
            if (!string.IsNullOrEmpty(entity.ProductImgUrl))
            {
                sql.AppendFormat(" AND [ProductImgUrl]=@ProductImgUrl ");
                parameters.Add("@ProductImgUrl", entity.ProductImgUrl);
            }

            if (!string.IsNullOrEmpty(entity.Description))
            {
                sql.AppendFormat(" AND [Description]=@Description ");
                parameters.Add("@Description", entity.Description);
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


