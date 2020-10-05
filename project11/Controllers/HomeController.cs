using project11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project11.Controllers
{
    public class HomeController : Controller
    {
        List<Customer> lstCust = Customer.GetCustomer();
        IEnumerable<Invoice> lstInv = Invoice.GetInvoice();
        public ActionResult Index()
        {
            List<Customer> lstCust2 = Customer.GetCustomer();
            return View(lstCust2);
        }
        public ActionResult createCustomer(int id=0)
        {
            if (id == 0)
            {
                Customer customer = new Customer();
                return View(customer);
            }
            else
            {
                Customer customer = lstCust.Where(s => s.customerId == id).FirstOrDefault<Customer>();
                return View(customer);
            }
        }
        [HttpPost]
        public ActionResult createCustomer(Customer customer)
        {
            if (customer.customerId==0)
            {
                Customer.addCustomer(customer);
                List<Customer> lstCust2 = Customer.GetCustomer();
                return View("index",lstCust2);
            }
            else
            {
                Customer.updateCustomer(customer);
                List<Customer> lstCust2 = Customer.GetCustomer();
                return View("index",lstCust2);
            }
        }
        public ActionResult viewInvoices(int id=0)
        {
            IEnumerable<Invoice> filteredInv = lstInv.Where(s => s.customerid == id);
            return View(filteredInv);
        }
        public ActionResult DeleteCustomer(int id=0)
        {
            Customer.deleteCustomer(id);
            List<Customer> lstCust2 = Customer.GetCustomer();
            return View("index",lstCust2);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}