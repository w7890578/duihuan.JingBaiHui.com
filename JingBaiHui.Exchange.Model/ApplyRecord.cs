using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JingBaiHui.Exchange.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JingBaiHui.Exchange.Model
{
    public class ApplyRecord : BaseModel
    {
        public Guid Id { get; set; }

        public string TenantName { get; set; }

        public string ProductName { get; set; }

        public string ProgramName { get; set; }
        public Guid GiftCardId { get; set; }
        public string CardNumber { get; set; }
        public Guid ProductId { get; set; }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ReceivingUserName = string.Empty;

        /// <summary>
        /// 收货地址
        /// </summary>
        public string ReceivingAddress = string.Empty;

        /// <summary>
        /// 收货人联系方式
        /// </summary>
        public string ReceivingUserPhone = string.Empty;

        /// <summary>
        /// 邮编
        /// </summary>
        public string ZipCode = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark = string.Empty;

        /// <summary>
        /// 审批状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ApplyRecordStatus ApplyRecordStatus = ApplyRecordStatus.未审批;
    }
}
