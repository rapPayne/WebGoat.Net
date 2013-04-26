using System.Collections.Generic;

namespace Core
{
    public class Category
    {
        public virtual int CategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
