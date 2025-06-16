using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class DSSanPhamController : Controller
    {
        // GET: DSSanPham
        public ActionResult Index()
        {
            WebBanHangEntities db = new WebBanHangEntities();
            var lstPro = db.Products.ToList();
            return View(lstPro);
        }

    }
}