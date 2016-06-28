using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JingBaiHui.Exchange.Model
{
    /// <summary>
    /// 租户
    /// </summary>
    public class Tenant
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 租户名称
        /// </summary>
        public string TenantName { get; set; }

        /// <summary>
        /// 租户登录页面内容(Html)
        /// </summary>
        public string TenantLoginPage { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        private string _createTimeStr = null;
        public string CreateTimeStr
        {
            get
            {
                if (_createTimeStr == null)
                {
                    _createTimeStr = CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
                return _createTimeStr;
            }
        }
        /// <summary>
        /// 创建人Id
        /// </summary>
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 更新人Id
        /// </summary>
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 访问地址
        /// </summary>
        public string AccesseAddress { get; set; }

        /// <summary>
        /// 租户英文显示名称，比如：拼音或英语单词
        /// </summary>
        public string TenantLetter { get; set; }
    }
}
