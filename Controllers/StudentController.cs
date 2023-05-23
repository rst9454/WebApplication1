using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        Circular_DBEntities2 db = new Circular_DBEntities2();
        public ActionResult Index()
        {
            List<Customer> cst = new List<Customer>();
           var data= db.Customers.ToList();
           foreach(var d in data)
            {
                cst.Add(new Customer
                {
                    Id=d.Id,
                    FirstName=d.FirstName,
                    LastName=d.LastName,
                    Gender=d.Gender,
                    Country=d.Country,
                    Age=d.Age,
                });
            }
            return View(cst);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            var data = new Customer
            {
                FirstName=customer.FirstName,
                LastName=customer.LastName,
                Gender=customer.Gender,
                Age=customer.Age,
                Country=customer.Country


            };
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}