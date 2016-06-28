using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JingBaiHui.Common 
{
    public static class HttpHelper
    {
        /// <summary>
        /// 获得二级域名名称
        /// </summary>
        /// <returns></returns>
        public static  string GetCurrentTwoLevelDomainName()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            return url.Substring(0, url.IndexOf('.'));
        }
    }
}
