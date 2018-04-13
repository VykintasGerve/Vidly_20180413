using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        //[Route("customers/index")]
        public ActionResult Index()
        {

            var customerList = new List<Customer>
            {
                new Customer{ Id = 1, Name = "John Smith" },
                new Customer{ Id = 2, Name = "Mary Williams" },
            };
            var customers = new CustomersViewModel()
            {
                Id = 1,
                Name = "Customers",
                Customers = customerList

            };
            return View(customers);
        }
        public ActionResult Details(int? Id)
        {
            var customerList = new List<Customer>
            {
                new Customer{ Id = 1, Name = "John Smith" },
                new Customer{ Id = 2, Name = "Mary Williams" },
            };

            if (!Id.HasValue)
            {
                return HttpNotFound();
            }
            else 
            {
                var customer = customerList.Find(c => c.Id == Id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(customer);
                }
                    
            }
        }
    }
}