using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project11.Models
{
    public class Customer
    {
        [Display(Name = "Customer ID")]
        public int customerId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter First Name")]
        public string firstname { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter Last Name")]
        public string lastname { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Enter Country")]
        public string country { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter Email")]
        public string email { get; set; }
        public static List<Customer> GetCustomer()
        {
            List<Customer> lstCust = new List<Customer>()
            {
                new Customer{ customerId =1, firstname="Usman", lastname="Ali",  country="Pakistan", email="usman@gmail.com"},
                new Customer{ customerId =2, firstname="Ahsan", lastname="Ali",  country="Pakistan", email="ahsan@gmail.com"},
                new Customer{ customerId =3, firstname="Waqas", lastname="Ali",  country="Pakistan", email="waqas@gmail.com"},
            };
            return lstCust;
        }
        public static void addCustomer(Customer customer)
        {
            //here we add customers
        }
        public static void updateCustomer(Customer customer)
        {
            //here we update customers
        }
        public static void deleteCustomer(int id)
        {
            //here we update customers
        }
    }
}
