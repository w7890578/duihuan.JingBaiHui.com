using JingBaiHui.Common;
using JingBaiHui.Exchange.BLL;
using JingBaiHui.Exchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JingBaiHui.Exchange.Controllers
{
    public class BaseController : Controller
    {
        protected virtual Guid TenantId
        {
            get
            {
                return GiftCard.TenantId;
            }
        }

        protected virtual Guid GiftCardId
        {
            get
            {
                return GiftCard.Id;
            }
        }

        protected virtual Guid UserId
        {
            get
            {
                return Guid.Empty;
            }
        }

        private GiftCard _giftCard = null;
        protected virtual GiftCard GiftCard
        {
            get
            {
                if (_giftCard == null)
                {
                    HttpCookie authCookie = HttpContext.Request.Cookies["CardInfo"];
                    if (authCookie == null)
                    {
                        Response.Redirect("/qq.html");
                    }
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);//解密
                    _giftCard = Newtonsoft.Json.JsonConvert.DeserializeObject<GiftCard>(authTicket.UserData);
                }
                return _giftCard;
            }
        }

        /// <summary>
        /// 通用异常处理信息，如果发生异常返回JSON对象
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            ResponseModel responseModel = new ResponseModel()
            {
                Status = false,
                Msg = filterContext.Exception.Message
            };

            LogHelper.Error(filterContext.Exception);

            filterContext.Result = Json(responseModel, JsonRequestBehavior.AllowGet);
            filterContext.ExceptionHandled = true;
        }
    }
}
