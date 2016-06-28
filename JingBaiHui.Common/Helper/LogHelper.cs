using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;

namespace JingBaiHui.Common
{
    public class LogHelper
    {
        public static void Write(string text)
        {
            string filePath = ConfigurationManager.AppSettings["LogFilePath"] ?? "c:\\App.Logfiles";
            //Web请求
            if (System.Web.HttpContext.Current != null)
            {
                filePath = System.Web.HttpContext.Current.Server.MapPath("\\Log.files");
            }

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            string FileName = string.Concat(filePath, "\\", DateTime.Now.ToString("yyyy-MM-dd"), ".txt");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"---------------------------------------");
            sb.AppendLine(@"日志时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine(text);
            sb.AppendLine(@"---------------------------------------");
            sb.AppendLine("");
            StreamWriter sw = new StreamWriter(FileName, true);
            sw.Write(sb.ToString());
            sw.Dispose();
            sw.Close();
        }

        public static void Error(Exception ex)
        {
            Write(ex == null ? "未知异常" : ex.Message);
        }

        public static void Error(Exception ex, DbCommand cmd)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ex.Message);
            sb.AppendLine(string.Format("服务器名称:{0},数据库名称:{1}", cmd.Connection.DataSource, cmd.Connection.Database));
            sb.AppendLine("SQL命令:" + cmd.CommandText);
            sb.AppendLine("参数:");
            for (int i = 0; i < cmd.Parameters.Count; i++)
            {
                sb.AppendLine(string.Format("{0}={1}", cmd.Parameters[i].ParameterName, cmd.Parameters[i].Value));
            }
            Write(sb.ToString());
        }
    }
}
