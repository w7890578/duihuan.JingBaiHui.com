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
    public class TenantBLL
    {
        #region singleton
        private static readonly TenantBLL instance = new TenantBLL();
        private TenantBLL() { }
        public static TenantBLL Instance
        {
            get { return instance; }
        }
        #endregion

        public void Save(Tenant entity, Guid userId)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.CreateUserId = userId;
                Create(entity);
            }
            else
            {
                entity.UpdateUserId = userId;
                Update(entity);
            }
        }

        /// <summary>
        ///  创建
        /// </summary>
        /// <param name="entity"></param>
        public void Create(Tenant entity)
        {
            var result = Get(new Tenant() { TenantLetter = entity.TenantLetter });
            if (result != null)
                throw new Exception("已存在公司名称（英文）:“" + entity.TenantLetter + "”,请勿填写重复！");
            entity.Id = Guid.NewGuid();
            entity.CreateTime = DateTime.Now;
            TenantDAL.Instance.Create(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Tenant entity)
        {
            entity.UpdateTime = DateTime.Now;
            TenantDAL.Instance.Update(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(Guid Id)
        {
            TenantDAL.Instance.Delete(Id);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Tenant Get(Guid Id)
        {
            return TenantDAL.Instance.Get(Id);
        }

        /// <summary>
        /// 根据条件获取
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Tenant Get(Tenant entity)
        {
            var list = TenantDAL.Instance.GetList(entity);
            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int GetRecordCount(Tenant entity)
        {
            var list = GetList(entity);
            return list == null ? 0 : list.Count;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IList<Tenant> GetList(Tenant entity)
        {
            return TenantDAL.Instance.GetList(entity);
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
            return TenantDAL.Instance.GetList(entity, pageIndex, pageSize, order);
        }

        /// <summary>
        /// 获取EasyUiDataGrid数据集
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public EasyUiDataGrid<Tenant> GetEasyUiDataList(Tenant entity, int pageIndex, int pageSize, string order)
        {
            return new EasyUiDataGrid<Tenant>()
            {
                Total = GetRecordCount(entity),
                Rows = GetList(entity, pageIndex, pageSize, order)
            };
        }
    }
}
