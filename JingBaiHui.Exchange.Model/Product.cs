using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JingBaiHui.Exchange.Model
{
    /// <summary>
    /// 产品
    /// </summary>
    public class Product : BaseModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 父名称
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 产品名
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 产品图片路径
        /// </summary>
        public string ProductImgUrl { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

    }
}
