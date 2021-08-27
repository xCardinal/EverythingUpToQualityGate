using NUnit.Framework;
using NorthwindBusiness;
using NorthwindData;
using System.Linq;

namespace NorthwindTests
{
    public class CustomerTests
    {
        CustomerManager _customerManager;
        [SetUp]
        public void Setup()
        {
            //SETUP RUNS EVERY TIME ( THE MANDA Customer is constantly being deleted)
            _customerManager = new CustomerManager();
            // remove test entry in DB if present
            using (var db = new NorthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MANDA"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewCustomerIsAdded_TheNumberOfCustomersIncreasesBy1()
        {
            var i = _customerManager.RetrieveAllCustomers();
            _customerManager.Create("MANDA", "Martin Beard", "Sparta Global", "London");

            Assert.That(() => _customerManager.RetrieveAllCustomers().Count, Is.GreaterThan(i.Count));
        }

        [Test]
        public void WhenANewCustomerIsAdded_TheirDetailsAreCorrect()
        {
            //use the create func and check if it creates an individual with the correct details

            var i = _customerManager.RetrieveAllCustomers();
            _customerManager.Create("MANDA", "ADAM", "Sparta Global", "Nowhere");

            using( var db = new NorthwindContext())
            {
                var query1 =
                    from c in db.Customers
                    where c.CustomerId == "MANDA"
                    select c;

                Assert.That(() => query1.FirstOrDefault().ContactName, Is.EqualTo("ADAM"));
            }
        }

        [TestCase("MANDA", "Sergio", "Portugal", "Porto", "ZT0 1AZ")]
        public void WhenACustomerIsUpdated_TheDatabaseIsUpdated(string id, string name, string country, string city, string postcode)
        {
            _customerManager.Create("MANDA", "ADAM", "Sparta Global", "Nowhere");

            var x = _customerManager.Update(id, name, country, city, postcode);
            Assert.That(x, Is.True); 
        }

        [TestCase("MANDA", "Sergio", "Portugal", "Porto", "ZT0 1AZ")]
        public void WhenACustomerIsUpdated_SelectedCustomerIsUpdated(string id, string name, string country, string city, string postcode)
        {
            _customerManager.Create("MANDA", "ADAM", "Sparta Global", "Nowhere");

            var x = _customerManager.Update(id, name, country, city, postcode);
            
            using (var db = new NorthwindContext())
            {
                var query2 =
                    from c in db.Customers
                    where c.CustomerId == id
                    select c;

                Assert.That(() => query2.FirstOrDefault().ContactName, Is.EqualTo(name));
                Assert.That(() => query2.FirstOrDefault().Country, Is.EqualTo(country));
                Assert.That(() => query2.FirstOrDefault().City, Is.EqualTo(city));
                Assert.That(() => query2.FirstOrDefault().PostalCode, Is.EqualTo(postcode));
            }
        }

        [Test]
        public void WhenACustomerIsNotInTheDatabase_Update_ReturnsFalse()
        {
            var x = _customerManager.Update("MANDA", "Sergio", "Portugal", "Porto", "ZT0 1AZ");

            Assert.That(x, Is.False);

        }

        [Test]
        public void WhenACustomerIsRemoved_TheNumberOfCustomersDecreasesBy1()
        {
            _customerManager.Create("MANDA", "ADAM", "Sparta Global", "Nowhere");

            using (var db = new NorthwindContext())
            {
                var n = db.Customers.Count();
                _customerManager.Delete("MANDA");

                Assert.That(_customerManager.RetrieveAllCustomers().Count, Is.LessThan(n));
            }
        }

        [Test]
        public void WhenACustomerIsRemoved_TheyAreNoLongerInTheDatabase()
        {
            _customerManager.Create("MANDA", "ADAM", "Sparta Global", "Nowhere");

            using (var db = new NorthwindContext())
            {
                _customerManager.Delete("MANDA");

                var query3 =
                    from c in db.Customers
                    where c.CustomerId == "MANDA"
                    select c;

                Assert.That(query3.FirstOrDefault(), Is.Null);
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new NorthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MANDA"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }
    }
}