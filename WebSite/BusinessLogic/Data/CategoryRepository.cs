using System.Collections.Generic;
using System.Linq;
using Core;

namespace Infrastructure
{
    public class CategoryRepository
    {
        private NorthwindContext _context;
        public CategoryRepository()
        {
            _context = NorthwindContext.GetNorthwindContext();
        }
        public List<Category> GetAllCategories()
        {
            return _context.Categories.OrderBy(c => c.CategoryId).ToList();
        }
    }
}
