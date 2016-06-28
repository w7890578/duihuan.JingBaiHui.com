
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using JingBaiHui.Common;
using JingBaiHui.Exchange.Enum;
using JingBaiHui.Exchange.Model;
using JingBaiHui.Exchange.BLL;
using Newtonsoft.Json;

namespace JingBaiHui.Exchange.Controllers.Admin
{
    public class TenantController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Save(Tenant entity)
        {
            entity.AccesseAddress = "duihuan.jbh-lp.com/" + entity.TenantLetter + ".html";
            TenantBLL.Instance.Save(entity, this.UserId);
            return Json(new ResponseModel() { Status = true });
        }

        public ViewResult Create()
        {
            return View("Save", new Tenant());
        }

        [HttpPost]
        public JsonResult Delete(Guid Id)
        {
            TenantBLL.Instance.Delete(Id);
            return Json(new ResponseModel() { Status = true });
        }

        public ViewResult Update(Tenant entity)
        {
            var model = TenantBLL.Instance.Get(entity.Id);
            return View("Save", model);
        }

        public JsonResult Get(Guid Id)
        {
            var model = TenantBLL.Instance.Get(Id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetList(Tenant entity)
        {
            var list = TenantBLL.Instance.GetEasyUiDataList(entity, this.PageIndex, this.PageSize, this.OrderBy);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
