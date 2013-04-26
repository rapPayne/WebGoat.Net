using System;

namespace Core
{
    public class OrderDetail
    {
        public virtual int OrderId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual short Quantity { get; set; }
        public virtual float Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        public decimal ExtendedPrice
        {
            get
            {
                return UnitPrice * Convert.ToDecimal(1 - Discount) * Quantity;
            }
        }
    }
}
