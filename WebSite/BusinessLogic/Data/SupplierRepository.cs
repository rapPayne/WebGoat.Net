using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Infrastructure
{
    public class SupplierRepository : IDisposable
    {
        private NorthwindContext _context;
        public SupplierRepository()
        {
            _context = new NorthwindContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.OrderBy(s => s.CompanyName).ToList();
        }
    }
}
