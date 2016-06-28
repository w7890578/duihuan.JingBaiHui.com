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
    public class ProgramController : BaseController
    {
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Save(Program entity)
        {
            ProgramBLL.Instance.Save(entity, this.UserId);
            return Json(new ResponseModel() { Status = true });
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Delete(Guid Id)
        {
            ProgramBLL.Instance.Delete(Id);
            return Json(new ResponseModel() { Status = true });
        }

        [HttpPost]
        public JsonResult Update(Program entity)
        {
            ProgramBLL.Instance.Update(entity);
            return Json(new ResponseModel() { Status = true });
        }

        public JsonResult Get(Guid Id)
        {
            var model = ProgramBLL.Instance.Get(Id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetList(Program entity)
        {
            var list = ProgramBLL.Instance.GetEasyUiDataList(entity, this.PageIndex, this.PageSize, this.OrderBy);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
