using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace JingBaiHui.Common
{
    public class EmailHelper
    {
        public static string SendMail(string content)
        {
            string result =  SendMail("yangjun199008@126.com", "ouyang", "601626046@qq.com", "礼品卡兑换通知", content, "yangjun199008", "q7890578", "smtp.126.com", "");

            return result;
        }
        /// <summary> 
        /// 发送邮件程序 
        /// </summary> 
        /// <param name="from">发送人邮件地址</param> 
        /// <param name="fromname">发送人显示名称</param> 
        /// <param name="to">发送给谁（邮件地址）</param> 
        /// <param name="subject">标题</param> 
        /// <param name="body">内容</param> 

        /// <param name="username">邮件登录名</param> 

        /// <param name="password">邮件密码</param> 

        /// <param name="server">邮件服务器</param> 

        /// <param name="fujian">附件</param> 

        /// <returns>send ok</returns> 

        /// 调用方法 SendMail("abc@126.com", "某某人", "cba@126.com", "你好", "我测试下邮件", "邮箱登录名", "邮箱密码", "smtp.126.com", ""); 

        private static string SendMail(string from, string fromname, string to, string subject, string body, string username, string password, string server, string fujian)
        {

            try
            {

                //邮件发送类 

                MailMessage mail = new MailMessage();

                //是谁发送的邮件 

                mail.From = new MailAddress(from, fromname);

                //发送给谁 

                mail.To.Add(to);

                //标题 

                mail.Subject = subject;

                //内容编码 

                mail.BodyEncoding = Encoding.Default;

                //发送优先级 

                mail.Priority = MailPriority.High;

                //邮件内容 

                mail.Body = body;

                //是否HTML形式发送 

                mail.IsBodyHtml = true;

                //附件 

                if (fujian.Length > 0)
                {

                    mail.Attachments.Add(new Attachment(fujian));

                }

                //邮件服务器和端口 

                SmtpClient smtp = new SmtpClient(server, 25);

                smtp.UseDefaultCredentials = true;

                //指定发送方式 

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                //指定登录名和密码 

                smtp.Credentials = new System.Net.NetworkCredential(username, password);

                //超时时间 

                smtp.Timeout = 50000;

                smtp.Send(mail);

                return "send ok";

            }

            catch (Exception exp)
            {

                return exp.Message;

            }

        }

        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="FromAddress">发送地址</param>
        /// <param name="FromDisplayName">发送人昵称</param>
        /// <param name="ToAddress">接收地址</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="isHtml">是否以Html格式发送</param>
        /// <returns></returns>
        public static bool SendMail(string FromAddress, string FromDisplayName, string ToAddress, string title, string content, bool isHtml)
        {
            try
            {
                MailAddress from = new MailAddress(FromAddress, FromDisplayName, System.Text.Encoding.GetEncoding("gb2312"));
                MailAddress to = new MailAddress(ToAddress);
                MailMessage msg = new MailMessage(from, to);
                msg.Subject = title;//邮件标题
                msg.SubjectEncoding = System.Text.Encoding.GetEncoding("gb2312"); //标题所使用的编码集
                msg.Body = content;//邮件正文


                //msg.Body = ScreenScrapeHtml(contentUrl);//("http://shequ.soufun.com/g/emailmodel.aspx");
                // msg.BodyEncoding = System.Text.Encoding.GetEncoding("gb2312"); //邮件正文所使用的编码集


                msg.IsBodyHtml = isHtml; //设置正文是否为html格式的值
                msg.Priority = MailPriority.High; //设置此邮件具有高优先级
                SmtpClient smtp = new SmtpClient(); //允许应用程序使用SMTP发邮件
                smtp.Credentials = new System.Net.NetworkCredential("homespace", "S2a%d5n3"); //设置验证发件人的凭据（邮件服务器需要身份验证）
                smtp.Host = "smtp.staff.soufun.com";//设置用于SMTP事务的主机名或ip地址。例如smtp.163.com
                //smtp.EnableSsl = true; //是否使用SSL加密连接（有的服务器不支持此链接）
                try
                {
                    smtp.Send(msg);//发信
                    msg.Dispose(); //释放有MailMessage使用的所有资源
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// 邮件发送（从url中获取内容）
        /// </summary>
        /// <param name="FromAddress">发送地址</param>
        /// <param name="FromDisplayName">发送人昵称</param>
        /// <param name="ToAddress">接收地址</param>
        /// <param name="title">标题</param>
        /// <param name="contentUrl">获取内容的url</param>
        /// <returns></returns>
        public static bool SendMailFromUrl(string FromAddress, string FromDisplayName, string ToAddress, string Title, string ContentUrl)
        {
            try
            {
                MailAddress from = new MailAddress(FromAddress, FromDisplayName, System.Text.Encoding.GetEncoding("gb2312"));
                //zhuyupu 2011-06-23修改
                if (ToAddress.IndexOf(";") > 0)
                {
                    string[] ToAddressArr = ToAddress.Split(';');
                    foreach (string ToAddress_i in ToAddressArr)
                    {
                        MailAddress to = new MailAddress(ToAddress_i);
                        MailMessage msg = new MailMessage(from, to);
                        msg.Subject = Title;//邮件标题
                        msg.SubjectEncoding = System.Text.Encoding.GetEncoding("gb2312"); //标题所使用的编码集
                        // msg.Body = content;//邮件正文


                        msg.Body = ScreenScrapeHtml(ContentUrl);//("http://shequ.soufun.com/g/emailmodel.aspx");
                        // msg.BodyEncoding = System.Text.Encoding.GetEncoding("gb2312"); //邮件正文所使用的编码集


                        msg.IsBodyHtml = true; //设置正文是否为html格式的值
                        msg.Priority = MailPriority.High; //设置此邮件具有高优先级
                        SmtpClient smtp = new SmtpClient(); //允许应用程序使用SMTP发邮件
                        smtp.Credentials = new System.Net.NetworkCredential("homespace", "S2a%d5n3"); //设置验证发件人的凭据（邮件服务器需要身份验证）
                        smtp.Host = "smtp.staff.soufun.com";//设置用于SMTP事务的主机名或ip地址。例如smtp.163.com
                        //smtp.EnableSsl = true; //是否使用SSL加密连接（有的服务器不支持此链接）
                        try
                        {
                            smtp.Send(msg);//发信
                            msg.Dispose(); //释放有MailMessage使用的所有资源

                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    } return true;
                }
                else
                {
                    MailAddress to = new MailAddress(ToAddress);
                    MailMessage msg = new MailMessage(from, to);
                    msg.Subject = Title;//邮件标题
                    msg.SubjectEncoding = System.Text.Encoding.GetEncoding("gb2312"); //标题所使用的编码集
                    // msg.Body = content;//邮件正文


                    msg.Body = ScreenScrapeHtml(ContentUrl);//("http://shequ.soufun.com/g/emailmodel.aspx");
                    // msg.BodyEncoding = System.Text.Encoding.GetEncoding("gb2312"); //邮件正文所使用的编码集


                    msg.IsBodyHtml = true; //设置正文是否为html格式的值
                    msg.Priority = MailPriority.High; //设置此邮件具有高优先级
                    SmtpClient smtp = new SmtpClient(); //允许应用程序使用SMTP发邮件
                    smtp.Credentials = new System.Net.NetworkCredential("homespace", "S2a%d5n3"); //设置验证发件人的凭据（邮件服务器需要身份验证）
                    smtp.Host = "smtp.staff.soufun.com";//设置用于SMTP事务的主机名或ip地址。例如smtp.163.com
                    //smtp.EnableSsl = true; //是否使用SSL加密连接（有的服务器不支持此链接）
                    try
                    {
                        smtp.Send(msg);//发信
                        msg.Dispose(); //释放有MailMessage使用的所有资源
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string ScreenScrapeHtml(string url)
        {
            WebRequest objRequest = System.Net.HttpWebRequest.Create(url);
            StreamReader sr = new StreamReader(objRequest.GetResponse().GetResponseStream(), System.Text.Encoding.GetEncoding("gb2312"));
            string result = sr.ReadToEnd();
            sr.Close();

            return result;

        }

        private static string getUrltoHtml(string Url)
        {
            string errorMsg = "";
            try
            {
                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("gb2312");
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(Url);
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(respStream, encoding);
                return reader.ReadToEnd();
            }
            catch (System.Exception ex)
            {
                errorMsg = ex.Message;
            }
            return "";
        }
    }
}
