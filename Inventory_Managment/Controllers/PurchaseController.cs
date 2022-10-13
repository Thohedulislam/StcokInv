using Inventory_Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Managment.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_managmentEntities1 DB = new Inventory_managmentEntities1();
        // GET: Purchase

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> list = DB.Purchases.OrderByDescending(x => x.id).ToList();

            return View(list);
        }
        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> list = DB.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(Purchase purchase)
        {
            DB.Purchases.Add(purchase);
            DB.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Purchase ph= DB.Purchases.Where(x => x.id == id).SingleOrDefault();
            List<string> list = DB.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(ph);
        }

        [HttpPost]
        public ActionResult Edit(int id, Purchase purchase)
        {
            Purchase ph = DB.Purchases.Where(x => x.id == id).SingleOrDefault();
            ph.Purchase_Date = purchase.Purchase_Date;
            ph.Purchase_Product = purchase.Purchase_Product;
            ph.Purchase_Qntity= purchase.Purchase_Qntity;
            DB.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }


        [HttpGet]
        public ActionResult PurchaseDetails(int id)
        {
            Purchase purchase = DB.Purchases.Where(x => x.id == id).SingleOrDefault();

            return View(purchase);
        }

        [HttpGet]
        public ActionResult DeletePurchase(int id)
        {
            Purchase purs = DB.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(purs);
        }

        [HttpPost]
        public ActionResult DeletePurchase(int id, Purchase purchase)
        {
            Purchase purs = DB.Purchases.Where(x => x.id == id).SingleOrDefault();
            DB.Purchases.Remove(purs);
            DB.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

    }
}