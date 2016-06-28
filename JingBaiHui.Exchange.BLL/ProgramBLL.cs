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
    public class ProgramBLL
    {
        #region singleton
        private static readonly ProgramBLL instance = new ProgramBLL();
        private ProgramBLL() { }
        public static ProgramBLL Instance
        {
            get { return instance; }
        }
        #endregion

        public void Save(Program entity, Guid userId)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.CreateUserId = userId;
                entity.CreateTime = DateTime.Now;
                entity.Id = Guid.NewGuid();
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
        public void Create(Program entity)
        {
            int count = GetRecordCount(new Program() { ProgramName = entity.ProgramName });
            if (count > 0)
                throw new Exception(string.Format("方案名称：{0},已存在 。请勿重复添加！", entity.ProgramName));

            ProgramDAL.Instance.Create(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Program entity)
        {
            ProgramDAL.Instance.Update(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(Guid Id)
        {
            ProgramDAL.Instance.Delete(Id);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Program Get(Guid Id)
        {
            return ProgramDAL.Instance.Get(Id);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int GetRecordCount(Program entity)
        {
            var list = GetList(entity);
            return list == null ? 0 : list.Count;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IList<Program> GetList(Program entity)
        {
            return ProgramDAL.Instance.GetList(entity);
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
            return ProgramDAL.Instance.GetList(entity, pageIndex, pageSize, order);
        }

        /// <summary>
        /// 获取EasyUiDataGrid数据集
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public EasyUiDataGrid<Program> GetEasyUiDataList(Program entity, int pageIndex, int pageSize, string order)
        {
            return new EasyUiDataGrid<Program>()
            {
                Total = GetRecordCount(entity),
                Rows = GetList(entity, pageIndex, pageSize, order)
            };
        }
    }
}
