using System.Collections.Generic;
using System.Linq;
using Core;

namespace Infrastructure
{
    public class SupplierRepository
    {
        private NorthwindContext _context;
        public SupplierRepository()
        {
            _context = NorthwindContext.GetNorthwindContext();
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.OrderBy(s => s.CompanyName).ToList();
        }
    }
}
