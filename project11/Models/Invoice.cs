using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Data.SQLite;

namespace project11.Models
{
    public class Invoice
    {
        [Display(Name = "Invoive ID")]
        public int invoiceid { get; set; }
        [Display(Name = "Customer ID")]
        public int customerid { get; set; }
        [Display(Name = "Date")]
        public DateTime date { get; set; }
        [Display(Name = "Total")]
        public int total { get; set; }
        public static IEnumerable<Invoice> GetInvoice()
        {
            List<Invoice> lstInv = new List<Invoice>();
            string query = "select * from Invoice";
            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\MUHAMMAD IMRAN\source\repos\project11\project11\bin\Chinook_Sqlite_AutoIncrementPKs.sqlite; datetimeformat=CurrentCulture;");
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Invoice inv = new Invoice();
                inv.invoiceid = Int32.Parse(reader["InvoiceId"].ToString());
                inv.customerid = Int32.Parse(reader["CustomerId"].ToString());
                inv.date = (DateTime) reader["InvoiceDate"];
                //inv.total = int.Parse(reader["Total"].ToString());

                lstInv.Add(inv);
            }
            con.Close();
            //List<Invoice> lstInv = new List<Invoice>()
            //{
            //    new Invoice{invoiceid=1, customerid =1, date=new DateTime(2020,10,1), total=10},
            //    new Invoice{invoiceid=2, customerid =2, date=new DateTime(2020,10,1), total=20},
            //    new Invoice{invoiceid=3, customerid =3, date=new DateTime(2020,10,1), total=30},
            //    new Invoice{invoiceid=4, customerid =2, date=new DateTime(2020,10,1), total=40},
            //    new Invoice{invoiceid=5, customerid =1, date=new DateTime(2020,10,1), total=50},
            //    new Invoice{invoiceid=6, customerid =3, date=new DateTime(2020,10,1), total=60}
            //};
            return lstInv;
        }
    }
}