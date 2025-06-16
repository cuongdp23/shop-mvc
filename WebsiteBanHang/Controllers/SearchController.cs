using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class SearchController : Controller
    {
        WebBanHangEntities db = new WebBanHangEntities();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string keyword)
        {
            // Tìm kiếm sản phẩm dựa trên từ khóa
            var products = db.Products.Where(p => p.Name.Contains(keyword)).ToList();

            // Trả về kết quả tìm kiếm cho view
            return View("Search", products);
        }

    }
}