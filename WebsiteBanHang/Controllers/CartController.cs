using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session["Cart"] as List<Cart>;
            if (cart == null)
            {
                cart = new List<Cart>();
            }
            return View(cart);
        }
        public ActionResult AddToCart(int productId)
        {
            using (var db = new WebBanHangEntities()) 
            {
                var product = db.Products.Find(productId);

                if (product != null)
                {
                    var cartItem = new Cart()
                    {
                        IDProduct = product.IDProduct,
                        ProductName = product.Name,
                        Price = (int)product.Price,
                        Quantity = 1,
                        Avatar = product.Avatar
                    };

                    var cart = Session["Cart"] as List<Cart>;
                    if (cart == null)
                    {
                        cart = new List<Cart>();
                        Session["Cart"] = cart;
                    }

                    var existingProduct = cart.FirstOrDefault(p => p.IDProduct == productId);
                    if (existingProduct != null)
                    {
                        existingProduct.Quantity++;
                    }
                    else
                    {
                        cart.Add(cartItem);
                    }
                }
            }

            return RedirectToAction("Index", "Cart"); 
        }
    }
}