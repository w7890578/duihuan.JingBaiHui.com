using JingBaiHui.Common;
using JingBaiHui.Exchange.BLL;
using JingBaiHui.Exchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
namespace JingBaiHui.Exchange.Controllers
{
    public class CompanyController : BaseController
    {
        //public ViewResult Index()
        //{
        //    string companyName = TxtHelper.GetUrlDomainName();
        //    companyName = companyName == "localhost" ? "www" : companyName;
        //    companyName = companyName == "www" ? "asyt" : companyName;
        //    var result = TenantBLL.Instance.Get(new Tenant() { TenantLetter = "asyt" });
        //    if (result == null)
        //        throw new Exception("未找到该公司的登录页");

        //    ViewBag.TenantLetter = result.TenantLetter;
        //    return View(result);
        //}

        public ViewResult Test()
        {
            return View();
        }

        /// <summary>
        /// 选择方案
        /// </summary>
        /// <returns></returns>
        public ViewResult ChooseProgram()
        {
            var Program = ProgramBLL.Instance.Get(GiftCard.ProgramId);
            List<Product> products = new List<Product>();
            foreach (var item in Program.ProductIds.Split(','))
            {
                var product = ProductBLL.Instance.Get(new Guid(item));
                products.Add(product);
            }
            ViewBag.Products = products;
            return View();
        }

        /// <summary>
        /// 填写地址
        /// </summary>
        /// <param name="Id">申请记录Id</param>
        /// <returns></returns>
        public ViewResult FillAdrress(Guid Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        [HttpPost]
        public ViewResult AddAdrress(FormCollection collection)
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

            return View("Complete");
        }

        public ViewResult Complete()
        {
            return View();
        }




        [HttpPost]
        public JsonResult AddProduct(ApplyRecord entity)
        {
            entity.TenantId = base.TenantId;
            entity.GiftCardId = base.GiftCardId;
            entity.Id = Guid.NewGuid();
            entity.CreateUserId = base.UserId;
            entity.CreateTime = DateTime.Now;

            var model = ApplyRecordBLL.Instance.Get(new ApplyRecord() { GiftCardId = base.GiftCardId });
            if (model != null)
            {
                entity.Id = model.Id;
                entity.UpdateTime = DateTime.Now;
                entity.UpdateUserId = base.UserId;
                ApplyRecordBLL.Instance.UpdateProductInfo(entity);
            }
            else
            {
                ApplyRecordBLL.Instance.Create(entity);
            }
            return Json(new ResponseModel() { Status = true, Value = entity.Id });
        }
    }
}
