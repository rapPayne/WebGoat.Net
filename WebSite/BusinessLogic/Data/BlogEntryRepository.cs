using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Infrastructure
{
    public class BlogEntryRepository
    {
        private NorthwindContext _context;
        public BlogEntryRepository()
        {
            _context = NorthwindContext.GetNorthwindContext();
        }
        public void CreateBlogEntry(BlogEntry Entry)
        {
            //TODO: should put this in a try/catch
            _context.BlogEntries.Add(Entry);
            _context.SaveChanges();
        }
        public BlogEntry GetBlogEntry(int BlogEntryId)
        {
            return _context.BlogEntries.Single(b => b.Id == BlogEntryId);
        }
        public List<BlogEntry> GetTopBlogEntries()
        {
            return this.GetTopBlogEntries(4, 0);
        }
        public List<BlogEntry> GetTopBlogEntries(int NumberOfEntries)
        {
            return this.GetTopBlogEntries(NumberOfEntries, 0);
        }
        public List<BlogEntry> GetTopBlogEntries(int NumberOfEntries, int StartPosition)
        {

            var blogEntries = _context.BlogEntries.OrderByDescending(b => b.PostedDate).Skip(StartPosition).Take(NumberOfEntries);
            return blogEntries.ToList();
        }
    }
}
