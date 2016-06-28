using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JingBaiHui.Exchange.Model
{
    public class BaseModel
    {
        /// <summary>
        /// 租户
        /// </summary>
        public Guid TenantId { get; set; }

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
    }


}
