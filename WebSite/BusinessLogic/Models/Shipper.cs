using System;

namespace Core
{
    public class Shipper
    {
        public virtual int ShipperId { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string ServiceName { get; set; }
        public virtual double ShippingCostMultiplier { get; set; }
        public virtual string Phone { get; set; }

        public decimal GetShippingCost(decimal SubTotal)
        {
            return SubTotal * Convert.ToDecimal(ShippingCostMultiplier);
        }
    }
}
