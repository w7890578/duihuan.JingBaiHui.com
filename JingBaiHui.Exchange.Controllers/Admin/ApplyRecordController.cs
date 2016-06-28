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
    public class ApplyRecordController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Save(FormCollection collection)
        {
            ApplyRecord entity = new ApplyRecord();
            entity.Id = new Guid(collection["Id"]);
            entity.ReceivingAddress = collection["ReceivingAddress"];
            entity.ReceivingUserName = collection["ReceivingUserName"];
            entity.ReceivingUserPhone = collection["ReceivingUserPhone"];
            entity.Remark = collection["Remark"];
            entity.UpdateTime = DateTime.Now;
            entity.UpdateUserId = base.UserId;
            ApplyRecordBLL.Instance.UpdateReceivingInfo(entity);
            return Json(new ResponseModel() { Status = true });
        }

        public JsonResult Get(Guid Id)
        {
            var model = ApplyRecordBLL.Instance.Get(Id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetList(ApplyRecord entity)
        {
            var list = ApplyRecordBLL.Instance.GetEasyUiDataList(entity, this.PageIndex, this.PageSize, this.OrderBy);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
