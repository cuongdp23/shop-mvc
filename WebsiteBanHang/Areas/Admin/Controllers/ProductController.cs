using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebBanHangEntities db = new WebBanHangEntities();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var lstProduct = db.Products.ToList();
            return View(lstProduct);
        }

        public ActionResult Details(int Id)
        {
            var detailProduct = db.Products.Where(n => n.IDProduct== Id).FirstOrDefault();
            return View(detailProduct);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Product product = db.Products.Where(n => n.IDProduct == Id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int Id)
        {
            try
            {
                Product product = db.Products.Where(n => n.IDProduct == Id).FirstOrDefault();
                db.Products.Remove(product);
                db.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}