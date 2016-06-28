using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using JingBaiHui.Exchange.Enum;
using JingBaiHui.Exchange.Model;
using JingBaiHui.Exchange.BLL;

namespace JingBaiHui.Exchange.Controllers.Admin
{ 
    public class GiftCardController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Save(GiftCard entity)
        {
            GiftCardBLL.Instance.Save(entity, this.UserId);
            return Json(new ResponseModel() { Status = true });
        }

        [HttpPost]
        public JsonResult Delete(Guid Id)
        {
            GiftCardBLL.Instance.Delete(Id);
            return Json(new ResponseModel() { Status = true });
        }

        [HttpPost]
        public JsonResult Update(GiftCard entity)
        {
            GiftCardBLL.Instance.Update(entity);
            return Json(new ResponseModel() { Status = true });
        }

        public JsonResult Get(Guid Id)
        {
            var model = GiftCardBLL.Instance.Get(Id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetList(GiftCard entity)
        {
            var list = GiftCardBLL.Instance.GetEasyUiDataList(entity, this.PageIndex, this.PageSize, this.OrderBy);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
