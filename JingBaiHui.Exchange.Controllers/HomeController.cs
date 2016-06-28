using JingBaiHui.Common;
using JingBaiHui.Exchange.BLL;
using JingBaiHui.Exchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JingBaiHui.Exchange.Controllers
{

    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            string tenantLetter = "asyt";
            var result = TenantBLL.Instance.Get(new Tenant() { TenantLetter = tenantLetter });
            if (result == null)
                throw new Exception("未找到该公司的登录页");

            ViewBag.TenantLetter = result.TenantLetter;
            return View(result);
        }

        [HttpPost]
        public ViewResult Login(FormCollection collection)
        {

            ViewBag.Msg = "卡号或密码错误！请重新填写";
            return View("Index");
        }

        public ViewResult Error()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GiftCardLogin(GiftCard entity)
        {
            Tenant t = new Tenant();
            t.TenantLetter = Request["CompanyPinYin"] ?? string.Empty;
            if (string.IsNullOrEmpty(t.TenantLetter))
            {
                return Json(new ResponseModel() { Status = false, Msg = "未知商家" });
            }

            t = TenantBLL.Instance.Get(t);
            if (t == null)
            {
                return Json(new ResponseModel() { Status = false, Msg = "未知商家" });
            }

            entity.TenantId = t.Id;

            var giftCard = GiftCardBLL.Instance.Get(entity);

            bool result = giftCard != null;

            if (result)
            {
                // var applyRecord = ApplyRecordBLL.Instance.Get(new ApplyRecord() { GiftCardId = giftCard.Id });
                if (giftCard.GiftCardStatus == Enum.GiftCardStatus.已使用)
                {
                    return Json(new ResponseModel() { Status = false, Msg = "该卡已兑换，请勿重复兑换！" });
                }

                entity = GiftCardBLL.Instance.GetList(entity)[0];
                entity.PassWord = "";
                string userData = Newtonsoft.Json.JsonConvert.SerializeObject(entity);
                //保存身份信息
                FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, entity.CardNumber, DateTime.Now, DateTime.Now.AddHours(1), false, userData);
                HttpCookie Cookie = new HttpCookie("CardInfo", FormsAuthentication.Encrypt(Ticket));//加密身份信息，保存至Cookie
                Response.AppendCookie(Cookie);
            }
            return Json(new ResponseModel() { Status = result, Msg = "用户名或密码错误！" });
        }
    }
}
