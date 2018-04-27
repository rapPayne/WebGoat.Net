using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Infrastructure
{
    public class ShipperRepository
    {
        private NorthwindContext _context;
        public ShipperRepository()
        {
            _context = NorthwindContext.GetNorthwindContext();
        }

        public List<Shipper> GetAllShippers()
        {
            return _context.Shippers.OrderBy(s => s.CompanyName).ToList();
        }
        public Dictionary<int, string> GetShippingOptions(decimal OrderSubtotal)
        {
            var dict = new Dictionary<int, string>();
            _context.Shippers.ToList().ForEach(s => dict.Add(s.ShipperId, string.Format("{0} {1} - {2:C}", s.CompanyName, s.ServiceName, s.GetShippingCost(OrderSubtotal))));
            return dict;
        }

        public Shipper GetShipperByShipperId(int ShipperId)
        {
            return _context.Shippers.Single(s => s.ShipperId == ShipperId);
        }
        /// <summary>Gets a tracking number for the supplied shipper</summary>
        /// <param name="Shipper">The shipper object</param>
        /// <returns>The tracking number</returns>
        /// <remarks>
        /// Simulates getting a tracking number.  In the real world, we'd contact their web service
        /// to get a real number.
        /// TODO: Use the check digit algorithms to make it realistic.
        /// Source for tracking number formats: http://answers.google.com/answers/threadview/id/207899.html
        /// </remarks>
        public string GetNextTrackingNumber(Shipper Shipper)
        {
            var random = new Random();
            var companyName = Shipper.CompanyName;
            if (companyName.Contains("UPS"))
                return string.Format("1Z{0} {1} {2} {3} {4} {5}", random.Next(999).ToString("000"), random.Next(999).ToString("000"), random.Next(99).ToString("00"), random.Next(9999).ToString("0000"), random.Next(999).ToString("000"), random.Next(9).ToString("0"));
            else if (companyName.Contains("Fedex"))
                return string.Format("{0}{1}", random.Next(999999).ToString("000000"), random.Next(999999).ToString("000000"));
            else if (companyName.Contains("Postal Service"))
                return string.Format("{0} {1} {2}", random.Next(9999).ToString("0000"), random.Next(9999).ToString("0000"), random.Next(99).ToString("00"));
            else
            {
                return "Could not get a tracking number";
            }
        }
    }
}
