using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_mvccrud.Models;
using System.Data.Entity;

namespace WebApplication_mvccrud.Controllers
{
    public class customerController : Controller
    {
        my_dbEntities db = new my_dbEntities();
        // GET: customer
        public ActionResult Index()
        {
            
            var customerList = (from test in db.Customer select test).ToList();
            return View(customerList);
        }

        // GET: customer/Details/5
        public ActionResult Details(int id)
        {
    
            var cust = (from test in db.Customer
                        where test.Id == id
                        select test).FirstOrDefault();
            return View(cust);
        }

        // GET: customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: customer/Create
        [HttpPost]
        public ActionResult Create(Customer c)
        {
            try
            {
                // TODO: Add insert logic here
                db.Customer.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: customer/Edit/5
        public ActionResult Edit(int id )
        {
            var cust = (from test in db.Customer
                        where test.Id == id
                        select test).FirstOrDefault();
            return View(cust);
        }

        // POST: customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer c)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: customer/Delete/5
        public ActionResult Delete(int id)
        {
            var cust = (from test in db.Customer
                        where test.Id == id
                        select test).FirstOrDefault();
            return View(cust);
        }

        // POST: customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var cust = (from test in db.Customer
                            where test.Id == id
                            select test).FirstOrDefault();
                db.Customer.Remove(cust);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
