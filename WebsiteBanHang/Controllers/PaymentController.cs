﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang;
using System.Web.Mvc;

namespace WebsiteBanHang.Controllers
{
    
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Payment()
        {
            return View();
        }
    }
}