using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Managment.Models;
using System.Web.Mvc;

namespace Inventory_Managment.Controllers
{
   
    public class ProductController : Controller
    {
        Inventory_managmentEntities1 DB = new Inventory_managmentEntities1();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List < Product > list = DB.Products.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            DB.Products.Add(product);
            DB.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Product pt = DB.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pt);
        }
        [HttpPost]
        public ActionResult UpdateProduct(int id, Product product)
        {
            Product pt = DB.Products.Where(x => x.id == id).SingleOrDefault();
            pt.Product_name = product.Product_name;
            pt.Product_Qntity = product.Product_Qntity;
            DB.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            Product pro = DB.Products.Where(x => x.id == id).SingleOrDefault();

            return View(pro);
        }
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            Product pros = DB.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pros);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id, Product product)
        {
            Product p = DB.Products.Where(x => x.id == id).SingleOrDefault();
            DB.Products.Remove(p);
            DB.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
    }

}