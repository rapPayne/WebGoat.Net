using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class BlogResponse
    {
        public virtual int Id { get; set; }
        public virtual int BlogEntryId { get; set; }
        public virtual DateTime ResponseDate { get; set; }
        public virtual string Author { get; set; }
        public virtual string Contents { get; set; }

    }
}
