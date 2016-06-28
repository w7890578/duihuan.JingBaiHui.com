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
    public class ApplyRecordBLL
    {
        #region singleton
        private static readonly ApplyRecordBLL instance = new ApplyRecordBLL();
        private ApplyRecordBLL() { }
        public static ApplyRecordBLL Instance
        {
            get { return instance; }
        }
        #endregion

        public void Save(ApplyRecord entity, Guid userId)
        {
            if (entity.Id == Guid.Empty)
            {
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
        public void Create(ApplyRecord entity)
        {
            ApplyRecordDAL.Instance.Create(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(ApplyRecord entity)
        {
            ApplyRecordDAL.Instance.Update(entity);
        }

        public void UpdateProductInfo(ApplyRecord entity)
        {
            ApplyRecordDAL.Instance.UpdateProductInfo(entity);
        }

        public void UpdateReceivingInfo(ApplyRecord entity)
        {
            ApplyRecordDAL.Instance.UpdateReceivingInfo(entity);
            //礼品卡状态更新为 已使用
            var applyRecord = ApplyRecordBLL.Instance.Get(entity.Id);
            GiftCardBLL.Instance.UpdateStatus(applyRecord.GiftCardId, Enum.GiftCardStatus.已使用);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(Guid Id)
        {
            ApplyRecordDAL.Instance.Delete(Id);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ApplyRecord Get(Guid Id)
        {
            return ApplyRecordDAL.Instance.Get(Id);
        }


        public ApplyRecord Get(ApplyRecord entity)
        {
            var list = GetList(entity);
            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            else {

                return null;
            }
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int GetRecordCount(ApplyRecord entity)
        {
            var list = GetList(entity);
            return list == null ? 0 : list.Count;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IList<ApplyRecord> GetList(ApplyRecord entity)
        {
            return ApplyRecordDAL.Instance.GetList(entity);
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
            return ApplyRecordDAL.Instance.GetList(entity, pageIndex, pageSize, order);
        }

        /// <summary>
        /// 获取EasyUiDataGrid数据集
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public EasyUiDataGrid<ApplyRecord> GetEasyUiDataList(ApplyRecord entity, int pageIndex, int pageSize, string order)
        {
            return new EasyUiDataGrid<ApplyRecord>()
            {
                Total = GetRecordCount(entity),
                Rows = GetList(entity, pageIndex, pageSize, order)
            };
        }
    }
}
