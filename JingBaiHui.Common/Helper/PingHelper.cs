using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace JingBaiHui.Common
{
    public static class PingHelper
    {
        /// <summary>
        /// 检测域名访问是否畅通
        /// </summary>
        /// <param name="domainName"></param>
        /// <returns></returns>
        public static bool IsSmooth(string domainName)
        {
            Ping ping = new Ping();
            try
            {
                return ping.Send(domainName).Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }
    }
}
