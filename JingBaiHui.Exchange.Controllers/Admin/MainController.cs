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
    public class MainController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginCheck()
        {
            return Json(new ResponseModel() { Status = true });
        }
    }
}
