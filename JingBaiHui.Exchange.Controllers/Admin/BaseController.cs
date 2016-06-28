using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using JingBaiHui.Exchange.Model;
using JingBaiHui.Common;

namespace JingBaiHui.Exchange.Controllers.Admin
{
    public class BaseController : Controller
    {
        protected virtual int PageIndex
        {
            get
            {
                int pageIndex = 1;
                int.TryParse(Request["page"]??"1", out pageIndex);
                return pageIndex;
            }
        }

        protected virtual int PageSize
        {
            get
            {
                int pageSize = 15;
                int.TryParse(Request["rows"]??"15", out pageSize);
                return pageSize;
            }
        }

        protected virtual string SortName
        {
            get
            {
                return Request["sort"] ?? "CreateTime";
            }
        }

        protected virtual string Order
        {
            get
            {
                return Request["order"] ?? "Desc";
            }
        }

        protected virtual string OrderBy
        {
            get
            {
                return string.Concat(" ", SortName, " ", Order, " ");
            }
        }

        protected virtual Guid UserId
        {
            get
            {
                return Guid.Empty;
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

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonNetResult(data, behavior, contentType, contentEncoding);
        }
 
    }
}
