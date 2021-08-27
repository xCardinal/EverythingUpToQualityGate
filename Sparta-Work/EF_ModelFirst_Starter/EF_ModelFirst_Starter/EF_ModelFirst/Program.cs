using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF_ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SouthwindContext())
            {
                Console.WriteLine("Creating some customers");

                //db.Add(new Customer()
                //{
                //    CustomerId = "MART",
                //    City = "London",
                //    ContactName = "Martin Beard",
                //    PostalCode = "N1"
                //});
                //db.Add(new Customer()
                //{
                //    CustomerId = "CATH",
                //    City = "Birmingham",
                //    ContactName = "Cathy Beard",
                //    PostalCode = "AN1"
                //});

                db.SaveChanges();

                //var query1 =
                //    from c in db.Customers
                //    where c.CustomerId == "CATH"
                //    select c;

                //query1.FirstOrDefault().PostalCode = "AB1";
                //db.SaveChanges();

                var customerQuery = db.Customers.OrderBy(c => c.ContactName);

                //var customer = customerQuery.First();

                var customerArray = customerQuery.ToArray();
                #region notbeingused
                //customer.City = "Birmingham";

                //db.SaveChanges();

                //Console.WriteLine($"First customer is {customer.ContactName} who lives in {customer.City}.");

                //customer.City = "Paris";

                //db.SaveChanges();

                //Console.WriteLine($"First customer is {customer.ContactName} who lives in {customer.City}.");

                //var query1_1 =
                //    db.Customers
                //    .Where(c => c.CustomerId == "CATH");

                //query1_1.FirstOrDefault().City = "Porto";

                //db.SaveChanges();

                //Console.WriteLine($"First customer is {customer.ContactName} who lives in {customer.City}.");

                //add datetime
                //ad ship country of france / brazil

                //db.Add(new Order()
                //{
                //    CustomerId = "CATH",
                //    OrderDate = new DateTime(2010, 1, 1, 8, 0, 15),
                //    ShippedDate = DateTime.Today,
                //    ShipCountry = "France"
                //}); ;



                //var query2 =
                //    db.Orders.Where(s => s.ShipCountry == "France");

                //db.Orders.Remove(query2.FirstOrDefault());

                //var query3 =
                //    db.Orders.Where(s => s.ShipCountry == "Brazil");

                //db.Orders.Remove(query3.FirstOrDefault());

                #endregion
                db.SaveChanges();

                db.RemoveRange(db.Orders.OrderBy(c => c.OrderId));

                db.SaveChanges();

                //------------------------------------

                var martin = db.Customers.Find("MART");

                martin.Orders.Add(new Order() { CustomerId = "MART", OrderDate = DateTime.Now, ShipCountry = "Brazil" });
                martin.Orders.Add(new Order() { CustomerId = "MART", OrderDate = DateTime.Now, ShipCountry = "France" });

                db.SaveChanges();

                //var customerQuery = db.Customers.OrderBy(c => c.ContactName);

                foreach (var c in customerQuery.Include(c=>c.Orders))
                {
                    Console.WriteLine($"{c.ContactName} lives in {c.City}");

                    if(c.Orders.Count > 0)
                    {
                        foreach (var order in c.Orders)
                        {
                            Console.WriteLine($"\tOrders {order.OrderId} by " +
                                $"{order.Customer.ContactName} made on {order.OrderDate.Value.Date}");
                        }
                    }                    
                }
                db.SaveChanges();

                var customers = 
                    db.Customers
                    .OrderBy(c => c.ContactName)
                    .Include(c => c.Orders).ToArray();

                //Console.WriteLine($"\nDelete all Customers");

                //db.RemoveRange(db.Customers.OrderBy(c => c.ContactName));

                //db.RemoveRange(db.Orders.OrderBy(c => c.OrderId));

                db.SaveChanges();

                Console.WriteLine($"\nThere should be {db.Customers.Count()} customers left and {db.Orders.Count()} orders");


                db.StarSigns.
            }
        }
    }
}
