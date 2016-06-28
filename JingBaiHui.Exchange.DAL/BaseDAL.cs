using JingBaiHui.Common;
using JingBaiHui.Exchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JingBaiHui.Exchange.DAL
{
    public abstract class BaseDAL
    {
        public virtual DataBase GetDataBase()
        {
            return DataBaseFactory.Create(Const.DBName);
        }

        /// <summary>
        /// 数据库
        /// </summary>
        public static DataBase db = DataBaseFactory.Create(Const.DBName);
         
    }

    /// <summary>
    /// 数据访问层统一操作
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDAL<T>
    {
        /// <summary>
        ///  创建
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        void Delete(Guid Id);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T Get(Guid Id);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IList<T> GetList(T entity);

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="entity">查询实体</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">一页显示条数</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        IList<T> GetList(T entity, int pageIndex, int pageSize, string order = Const.Order);
    }
}
