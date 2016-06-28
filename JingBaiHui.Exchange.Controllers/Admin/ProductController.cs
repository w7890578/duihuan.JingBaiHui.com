using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using JingBaiHui.Exchange.Enum;
using JingBaiHui.Exchange.Model;
using JingBaiHui.Exchange.BLL;
using System.Web;

namespace JingBaiHui.Exchange.Controllers.Admin
{ 
    public class ProductController : BaseController
    {
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Save(Product entity)
        {
            ProductBLL.Instance.Save(entity, this.UserId);
            return Json(new ResponseModel() { Status = true });
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Delete(Guid Id)
        {
            ProductBLL.Instance.Delete(Id);
            return Json(new ResponseModel() { Status = true });
        }

        [HttpPost]
        public JsonResult Update(Product entity)
        {
            ProductBLL.Instance.Update(entity);
            return Json(new ResponseModel() { Status = true });
        }

        public JsonResult Get(Guid Id)
        {
            var model = ProductBLL.Instance.Get(Id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetList(Product entity)
        {
            var list = ProductBLL.Instance.GetEasyUiDataList(entity, this.PageIndex, this.PageSize, this.OrderBy);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ContentResult UploadImg()
        {
            string msg = string.Empty;
            string error = string.Empty;
            string imgurl = string.Empty;
            try
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase hpf = Request.Files["ProductImgUrl"] as HttpPostedFileBase;
                    string savepath = "/Content/images/jingbaihui";
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + System.IO.Path.GetExtension(hpf.FileName);
                    hpf.SaveAs(string.Concat(Server.MapPath(savepath), @"\", fileName));

                    msg = "success";
                    imgurl = string.Concat(savepath, "/" + fileName);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                msg = "error";
            }
            return Content("{ error:'" + error + "', msg:'" + msg + "',imgurl:'" + imgurl + "'}", "text/html");
       
        }
    }
}
