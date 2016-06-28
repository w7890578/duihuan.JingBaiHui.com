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
    public class GiftCardBLL
    {
        #region singleton
        private static readonly GiftCardBLL instance = new GiftCardBLL();
        private GiftCardBLL() { }
        public static GiftCardBLL Instance
        {
            get { return instance; }
        }
        #endregion

        public void Save(GiftCard entity, Guid userId)
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
        public void Create(GiftCard entity)
        {
            entity.GiftCardStatus = GiftCardStatus.未使用;
            entity.Id = Guid.NewGuid();

            var model = Get(new GiftCard() { CardNumber = entity.CardNumber });
            if (model != null)
                throw new Exception(string.Format("卡号：{0}，已存在。请勿重复添加！", entity.CardNumber));

            GiftCardDAL.Instance.Create(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(GiftCard entity)
        {
            GiftCardDAL.Instance.Update(entity);
        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="giftCardStatus"></param>
        public void UpdateStatus(Guid Id, GiftCardStatus giftCardStatus)
        {
            GiftCardDAL.Instance.UpdateStatus(Id, giftCardStatus);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(Guid Id)
        {
            GiftCardDAL.Instance.Delete(Id);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public GiftCard Get(Guid Id)
        {
            return GiftCardDAL.Instance.Get(Id);
        }

        /// <summary>
        /// 获取
        /// </summary>

        /// <returns></returns>
        public GiftCard Get(GiftCard entity)
        {
            var list = GetList(entity);
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
        public int GetRecordCount(GiftCard entity)
        {
            var list = GetList(entity);
            return list == null ? 0 : list.Count;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IList<GiftCard> GetList(GiftCard entity)
        {
            return GiftCardDAL.Instance.GetList(entity);
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
            return GiftCardDAL.Instance.GetList(entity, pageIndex, pageSize, order);
        }

        /// <summary>
        /// 获取EasyUiDataGrid数据集
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public EasyUiDataGrid<GiftCard> GetEasyUiDataList(GiftCard entity, int pageIndex, int pageSize, string order)
        {
            return new EasyUiDataGrid<GiftCard>()
            {
                Total = GetRecordCount(entity),
                Rows = GetList(entity, pageIndex, pageSize, order)
            };
        }
    }
}
