using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        WebBanHangEntities db = new WebBanHangEntities();
        // GET: Admin/User
        public ActionResult Index()
        {
            var user = db.Users.ToList();
            return View(user);
        }
        public ActionResult Details(int Id)
        {
            var detailUser = db.Users.Where(n => n.IDUser == Id).FirstOrDefault();
            return View(detailUser);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                db.Users.Add(user);
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
            User user = db.Users.Where(n => n.IDUser == Id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(user).State = EntityState.Modified;
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
                User user = db.Users.Where(n => n.IDUser == Id).FirstOrDefault();
                db.Users.Remove(user);
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
