using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JingBaiHui.Exchange.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JingBaiHui.Exchange.Model
{
    /// <summary>
    /// 礼品卡
    /// </summary>
    public class GiftCard : BaseModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 方案Id
        /// </summary>
        public Guid ProgramId { get; set; }

        /// <summary>
        /// 方案名称
        /// </summary>
        public string ProgramName { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 礼品卡状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public GiftCardStatus GiftCardStatus { get; set; }
    }
}
