using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Infrastructure
{
    public class CategoryRepository : IDisposable
    {
        private NorthwindContext _context;
        public CategoryRepository()
        {
            _context = new NorthwindContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.OrderBy(c => c.CategoryId).ToList();
        }
    }
}
