using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class BlogEntry
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime PostedDate { get; set; }
        public virtual string Contents { get; set; }
        public virtual string Author { get; set; }

        public virtual List<BlogResponse> Responses { get; set; }

        public BlogEntry()
        {
            Responses = new List<BlogResponse>();
        }
    }
}
