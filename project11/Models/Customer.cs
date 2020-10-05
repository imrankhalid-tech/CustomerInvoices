using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.SQLite;

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
            List<Customer> lstCust = new List<Customer>();
            string query = "select * from Customer";
            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\MUHAMMAD IMRAN\source\repos\project11\project11\bin\Chinook_Sqlite_AutoIncrementPKs.sqlite; datetimeformat=CurrentCulture;");
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(query,con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Customer cus = new Customer();
                cus.customerId = Int32.Parse(reader["CustomerId"].ToString());
                cus.firstname = reader["FirstName"].ToString();
                cus.lastname = reader["LastName"].ToString();
                cus.country = reader["Country"].ToString();
                cus.email = reader["Email"].ToString();

                lstCust.Add(cus);
            }
            con.Close();

            List<Customer> lstCust2 = new List<Customer>()
            {
                new Customer{ customerId =1, firstname="Usman", lastname="Ali",  country="Pakistan", email="usman@gmail.com"},
                new Customer{ customerId =2, firstname="Ahsan", lastname="Ali",  country="Pakistan", email="ahsan@gmail.com"},
                new Customer{ customerId =3, firstname="Waqas", lastname="Ali",  country="Pakistan", email="waqas@gmail.com"},
            };
            return lstCust;
        }
        public static void addCustomer(Customer customer)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\MUHAMMAD IMRAN\source\repos\project11\project11\bin\Chinook_Sqlite_AutoIncrementPKs.sqlite; datetimeformat=CurrentCulture;");
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("insert into Customer(FirstName,LastName,Country,Email) values('" + customer.firstname + "','" + customer.lastname + "','" + customer.country + "','" + customer.email + "')",con);
            int r = cmd.ExecuteNonQuery();
            con.Close();
            //here we add customers
        }
        public static void updateCustomer(Customer customer)
        {
            //here we update customers
            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\MUHAMMAD IMRAN\source\repos\project11\project11\bin\Chinook_Sqlite_AutoIncrementPKs.sqlite; datetimeformat=CurrentCulture;");
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("UPDATE Customer SET FirstName='" + customer.firstname + "',LastName='" + customer.lastname + "',Country='" + customer.country + "',Email='" + customer.email + "' where CustomerId='"+customer.customerId+"'", con);
            int r = cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void deleteCustomer(int id)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\MUHAMMAD IMRAN\source\repos\project11\project11\bin\Chinook_Sqlite_AutoIncrementPKs.sqlite; datetimeformat=CurrentCulture;");
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("Delete from Customer  where CustomerId='" + id + "'", con);
            int r = cmd.ExecuteNonQuery();
            con.Close();
            //here we update customers
        }
    }
}
