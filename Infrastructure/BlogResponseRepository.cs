using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Infrastructure
{
    public class BlogResponseRepository
    {
        private NorthwindContext _context;
        public BlogResponseRepository()
        {
            _context = NorthwindContext.GetNorthwindContext();
        }
        public void CreateBlogResponse(BlogResponse Response)
        {
            //TODO: should put this in a try/catch
            _context.BlogResponses.Add(Response);
            _context.SaveChanges();
        }
    }
}
