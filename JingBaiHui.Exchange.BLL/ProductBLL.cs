using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JingBaiHui.Common;
using JingBaiHui.Exchange.Enum;
using JingBaiHui.Exchange.Model;
using JingBaiHui.Exchange.DAL;

namespace JingBaiHui.Exchange.BLL
{
    public class ProductBLL
    {
        #region singleton
        private static readonly ProductBLL instance = new ProductBLL();
        private ProductBLL() { }
        public static ProductBLL Instance
        {
            get { return instance; }
        }
        #endregion

        public void Save(Product entity, Guid userId)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
                entity.CreateUserId = userId;
                entity.CreateTime = DateTime.Now;
                Create(entity);
            }
            else
            {
                entity.UpdateTime = DateTime.Now;
                entity.UpdateUserId = userId;
                Update(entity);
            }
        }

        /// <summary>
        ///  创建
        /// </summary>
        /// <param name="entity"></param>
        public void Create(Product entity)
        {
            ProductDAL.Instance.Create(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Product entity)
        {
            ProductDAL.Instance.Update(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(Guid Id)
        {
            ProductDAL.Instance.Delete(Id);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Product Get(Guid Id)
        {
            return ProductDAL.Instance.Get(Id);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int GetRecordCount(Product entity)
        {
            var list = GetList(entity);
            return list == null ? 0 : list.Count;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IList<Product> GetList(Product entity)
        {
            return ProductDAL.Instance.GetList(entity);
        }

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="entity">查询实体</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">一页显示条数</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        public IList<Product> GetList(Product entity, int pageIndex, int pageSize, string order = Const.Order)
        {
            return ProductDAL.Instance.GetList(entity, pageIndex, pageSize, order);
        }

        /// <summary>
        /// 获取EasyUiDataGrid数据集
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public EasyUiDataGrid<Product> GetEasyUiDataList(Product entity, int pageIndex, int pageSize, string order)
        {
            return new EasyUiDataGrid<Product>()
            {
                Total = GetRecordCount(entity),
                Rows = GetList(entity, pageIndex, pageSize, order)
            };
        }
    }
}
