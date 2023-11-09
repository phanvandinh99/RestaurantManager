using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhaHang.Areas.KhachHang.Controllers
{
    public class ErrorController : Controller
    {
        // GET: KhachHang/Error
        public ActionResult HoaDonTrong()
        {
            return View();
        }
    }
}