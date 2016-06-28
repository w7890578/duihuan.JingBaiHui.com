using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JingBaiHui.Exchange.Enum
{
    /// <summary>
    /// 申请记录状态
    /// </summary>
    public enum ApplyRecordStatus
    {
        /// <summary>
        ///未审批
        /// </summary>
        未审批 = 1,
        /// <summary>
        /// 已审批通过
        /// </summary>
        已审批通过 = 2,

        /// <summary>
        /// 审批不通过
        /// </summary>
        审批不通过 = 3
    }
}
