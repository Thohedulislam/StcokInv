using Inventory_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Managment.Controllers
{
    public class SaleController : Controller
    {
        Inventory_managmentEntities1 DB = new Inventory_managmentEntities1();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Displaysale()
        {
            List<Sale> list = DB.Sales.OrderByDescending(x => x.id).ToList();

            return View(list);
        }
        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = DB.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(Sale sale)
        {
            DB.Sales.Add(sale);
            DB.SaveChanges();
            return RedirectToAction("Displaysale");
        }

        [HttpGet]
        public ActionResult SaleDetails(int id)
        {
            Sale sale = DB.Sales.Where(x => x.id == id).SingleOrDefault();

            return View(sale);
        }

        [HttpGet]
        public ActionResult DeleteSale(int id)
        {
            Sale s = DB.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);
        }

        [HttpPost]
        public ActionResult DeleteSale(int id, Sale sale)
        {
            Sale s = DB.Sales.Where(x => x.id == id).SingleOrDefault();
            DB.Sales.Remove(s);
            DB.SaveChanges();
            return RedirectToAction("Displaysale");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Sale s = DB.Sales.Where(x => x.id == id).SingleOrDefault();
            List<string> list = DB.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(int id,Sale sale)
        {
            Sale s = DB.Sales.Where(x => x.id == id).SingleOrDefault();
            s.Sale_Date = sale.Sale_Date;
            s.Sale_Product = sale.Sale_Product;
            s.Sale_Qntity = sale.Sale_Qntity;
            DB.SaveChanges();
            return RedirectToAction("Displaysale");
        }
    }
}