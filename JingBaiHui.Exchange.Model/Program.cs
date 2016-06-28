using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JingBaiHui.Exchange.Model
{
    /// <summary>
    /// 方案
    /// </summary>
    public class Program : BaseModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 方案名称
        /// </summary>
        public string ProgramName { get; set; }

        /// <summary>
        /// 产品集合
        /// </summary>
        public string ProductIds { get; set; }
    }
}
