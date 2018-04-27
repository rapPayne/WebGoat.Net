using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class Order
    {
        public virtual int OrderId { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual int EmployeeId { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual DateTime RequiredDate { get; set; }
        public virtual DateTime? ShippedDate { get; set; }
        public virtual int ShipVia { get; set; }
        public virtual decimal Freight { get; set; }
        public virtual string ShipName { get; set; }
        public virtual string ShipAddress { get; set; }
        public virtual string ShipCity { get; set; }
        public virtual string ShipRegion { get; set; }
        public virtual string ShipPostalCode { get; set; }
        public virtual string ShipCountry { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Customer Customer { get; set; }
        //TODO: Shipments and Payments should be singular.  Like customer.
        public virtual ICollection<OrderPayment> OrderPayments { get; set; }

        public decimal SubTotal
        {
            get
            {
                return OrderDetails.Sum(od => od.ExtendedPrice);
            }
        }

        public decimal Total
        {
            get
            {
                return this.SubTotal + this.Freight;
            }
        }
        /// <summary>Returns an HTML table with the contents of this cart.</summary>
        /// <returns>The HTML table</returns>
        /// <remarks>
        /// ItemId
        /// Description
        /// Price (including discount)
        /// Quantity
        /// Extended Price
        /// SubTotal
        /// </remarks>
        public string ToHtml(string CssClass)
        {
            var sb = new StringBuilder();
            if (CssClass.Length == 0)
                sb.Append("<table>");
            else
            {
                sb.AppendFormat("<table class='{0}'>", CssClass);
                sb.Append("<tr><th>Product Id</th><th>Product Name</th><th>Unit Price</th><th>Quantity</th><th>Extended Price</th></tr>");
            }
            foreach (var od in OrderDetails)
            {
                sb.AppendFormat("<tr><td><a href='/Product/{0}' runat='server'>{0}</a></td><td>{1}</td><td style='text-align: right;'>{2:C}</td><td style='text-align: right;'>{3}</td><td style='text-align: right;'>{4:C}</td></tr>",
                    od.ProductId, od.Product.ProductName, od.UnitPrice * Convert.ToDecimal(1.0 - od.Discount), od.Quantity, od.ExtendedPrice);
            }
            sb.AppendFormat("<tr><td></td><td style='text-align: right'>Subtotal:</td><td></td><td></td><td class='SubTotal' style='text-align: right;'>{0:C}</td></tr>",
                this.SubTotal);
            sb.AppendFormat("<tr><td></td><td style='text-align: right'>Freight:</td><td></td><td></td><td style='text-align: right;'>{0:C}</td></tr>",
                this.Freight);
            sb.AppendFormat("<tr><td></td><td style='text-align: right'>Total:</td><td></td><td></td><td class='SubTotal' style='text-align: right;'>{0:C}</td></tr>",
                this.Total);
            sb.Append("</table>");
            //sb.AppendFormat("<div>Tracking Number: {0}</div>", );
            return sb.ToString();
        }
        public string ToHtml()
        {
            return ToHtml("");
        }
        public static string GetPackageTrackingUrl(string Carrier, string TrackingNumber)
        {
            string trackingUrl;
            Carrier = Carrier.ToLower();
            switch (Carrier)
            {
                case "fedex":
                case "federalexpress":
                case "federal express":
                    trackingUrl = string.Format("http://www.fedex.com/Tracking?tracknumbers={0}&action=track", TrackingNumber);
                    break;
                case "ups":
                case "unitedpostalservice":
                case "united postal service":
                    //trackingUrl = string.Format("http://wwwapps.ups.com/WebTracking/processInputRequest?InquiryNumber1={0}&tracknums_displayed=1&TypeOfInquiryNumber=T", TrackingNumber);
                    trackingUrl = string.Format("http://wwwapps.ups.com/WebTracking/track?loc=en_US&track.x=Track&trackNums={0}", TrackingNumber);
                    break;
                case "usps":
                case "unitedstatespostalservice":
                case "united states postal service":
                case "postoffice":
                case "post office":
                    trackingUrl = string.Format("http://trkcnfrm1.smi.usps.com/PTSInternetWeb/InterLabelInquiry.do?origTrackNum={0}", TrackingNumber);
                    break;
                default:
                    trackingUrl = string.Format("http://{0}?TrackingNumber={1}", Carrier, TrackingNumber);
                    break;
            }
            return trackingUrl;
        }
    }
}
