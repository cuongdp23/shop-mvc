using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        WebBanHangEntities db = new WebBanHangEntities();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var category = db.Categories.ToList();
            return View(category);
        }
        public ActionResult Details(int Id)
        {
            var detailCate = db.Categories.Where(n => n.IDCategory == Id).FirstOrDefault();
            return View(detailCate);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                db.Categories.Add(category);
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
            Category category = db.Categories.Where(n => n.IDCategory == Id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(category).State = EntityState.Modified;
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
                Category category = db.Categories.Where(n => n.IDCategory == Id).FirstOrDefault();
                db.Categories.Remove(category);
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