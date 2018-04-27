using System;
using System.Linq;
using Core;

namespace Infrastructure
{
    public class CustomerRepository
    {
        private NorthwindContext _context;

        public CustomerRepository()
        {
            _context = NorthwindContext.GetNorthwindContext();
        }

        public Customer GetCustomerByUsername(string Username)
        {
            return _context.Customers.FirstOrDefault(c => c.ContactName == Username);
        }

        public Customer GetCustomerByCustomerId(string CustomerId)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerId == CustomerId);
        }

        public void SaveCustomer(Customer Customer)
        {
            var old = _context.Customers.Single(c => c.CustomerId == Customer.CustomerId);
            old.Address = Customer.Address;
            old.City = Customer.City;
            old.CompanyName = Customer.CompanyName;
            old.ContactName = Customer.ContactName;
            old.ContactTitle = Customer.ContactTitle;
            old.Country = Customer.Country;
            old.Fax = Customer.Fax;
            old.Phone = Customer.Phone;
            old.PostalCode = Customer.PostalCode;
            old.Region = Customer.Region;
            _context.SaveChanges();
        }
        //TODO: Add try/catch logic
        public string CreateCustomer(string CompanyName, string ContactName, string Address, string City, string Region, string PostalCode, string Country)
        {
            var customerId = GenerateCustomerId(CompanyName);
            var customer = new Customer()
                {
                    CompanyName = CompanyName,
                    CustomerId = customerId,
                    ContactName = ContactName,
                    Address = Address,
                    City = City,
                    Region = Region,
                    PostalCode = PostalCode,
                    Country = Country
                };
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customerId;
        }

        public bool CustomerIdExists(string CustomerId)
        {
            return (_context.Customers.Count(c => c.CustomerId == CustomerId)) == 0 ? false : true;
        }

        /// <summary>Returns an unused CustomerId based on the company name</summary>
        /// <param name="CompanyName">What we want to base the CompanyId on.</param>
        /// <returns>An unused CustomerId.</returns>
        private string GenerateCustomerId(string CompanyName)
        {
            var random = new Random();
            var customerId = CompanyName.Replace(" ","");
            customerId = (customerId.Length >= 5) ? customerId.Substring(0, 5) : customerId;
            while (CustomerIdExists(customerId))
            {
                customerId = customerId.Substring(0, 4) + "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"[random.Next(35)];
            }
            return customerId;
        }
    }
}
