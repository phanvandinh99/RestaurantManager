using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyNhaHang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Mặc định
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { action = "Index", id = UrlParameter.Optional }
            //);

            // Chạy trang nhân viên Admin đầu tiên
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { Controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new string[] { "QuanLyNhaHang.Areas.NhanVien.Controllers" }
            //).DataTokens.Add("area", "NhanVien");

            // Chạy trang nhân viên kho đầu tiên 
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { Controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new string[] { "QuanLyNhaHang.Areas.NhanVienKho.Controllers" }
            //).DataTokens.Add("area", "NhanVienKho");

            // Chạy trang khách hàng đầu tiên
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { Controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new string[] { "QuanLyNhaHang.Areas.KhachHang.Controllers" }
            //).DataTokens.Add("area", "KhachHang");

            // Chạy trang nhân viên kho đầu tiên 
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { Controller = "DangNhap", action = "DangNhap", id = UrlParameter.Optional },
                namespaces: new string[] { "QuanLyNhaHang.Areas.NhanVien.Controllers" }
            ).DataTokens.Add("area", "NhanVien");
        }
    }
}

