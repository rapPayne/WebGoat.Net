using System;

namespace Core
{
    public class Shipment
    {
        public virtual int ShipmentId { get; set; }
        public virtual int OrderId { get; set; }
        public virtual int ShipperId { get; set; }
        public virtual DateTime ShipmentDate { get; set; }
        public virtual string TrackingNumber { get; set; }

        public virtual Order Order { get; set; }
    }
}
