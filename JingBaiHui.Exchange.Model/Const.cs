using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace JingBaiHui.Exchange.Model
{
    public class Const
    {
        /// <summary>
        /// 数据库名（连接字符串名）
        /// </summary>
        public const string DBName = "Exchange";

        /// <summary>
        /// 一页显示条数
        /// </summary>
        public static int PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"] ?? "15");

        /// <summary>
        /// 排序
        /// </summary>
        public const string Order = " CreateTime DESC ";
    }
}
