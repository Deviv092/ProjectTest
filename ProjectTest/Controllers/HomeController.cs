using ProjectTest.Database;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectTest.Controllers
{
    public class HomeController : Controller
    {
        AniketTestEntities1 db = new AniketTestEntities1();
        
        public ActionResult CreateOrder() {

            return View();
        }
        [HttpPost]
        public ActionResult CreateOrder(OrderDetails model)
        {
            Order_datails orderdetails = new Order_datails
            {
                Id = model.Id,
                customer = model.customer,
                product = model.product,
                remarks = model.remarks,
            };

            if (model.Id == 0)
            {

                db.Order_datails.Add(orderdetails);
                db.SaveChanges();
            }
            else
            {
                db.Entry(orderdetails).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ShowData");
        }

        public ActionResult Edit(int id)
        {
            var res = db.Order_datails.Select(x => new OrderDetails()
            {
                Id = x.Id,
                customer = x.customer,
                product = x.customer,
                remarks = x.remarks,
               
            }).SingleOrDefault(x => x.Id == id);
            return View("CreateOrder", res);
        }

        public ActionResult ShowData()
        {

            // List<EmployeeModel> emp = new List<EmployeeModel>();

            var result = db.Order_datails
                .Select(x => new OrderDetails()
                {
                    Id = x.Id,
                    customer = x.customer,
                    product = x.customer,
                    remarks = x.remarks,
                }).ToList();

            return View(result);

        }


        public ActionResult Delete(int id)
        {

            var res = db.Order_datails.FirstOrDefault(x => x.Id == id);

            db.Order_datails.Remove(res);
            db.SaveChanges();
            return RedirectToAction("ShowData");


        }
    }
}