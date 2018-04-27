using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Cart
    {
        public List<OrderDetail> OrderDetails { get; set; }

        public decimal SubTotal
        {
            get
            {
                decimal subTotal = 0;
                //TODO: Refactor this. Use LINQ with aggregation to get SUM.
                OrderDetails.ForEach(od => subTotal += od.ExtendedPrice);
                return subTotal;
            }
        }

        public Cart()
        {
            OrderDetails = new List<OrderDetail>();
        }

        /// <summary>
        /// Returns an HTML table with the contents of this cart.
        /// </summary>
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
            //TODO: Add ability to delete an orderDetail and to change quantities.
            var sb = new StringBuilder();
            if (CssClass.Length == 0)
                sb.Append("<table>");
            else
            {
                sb.AppendFormat("<table id='cartTable' rules='all' class='{0}'>", CssClass);
                sb.Append("<tr><th>Product Id</th><th>Product Name</th><th>Unit Price</th><th>Quantity</th><th>Extended Price</th></tr>");
            }
            foreach (var od in OrderDetails)
            {
                sb.AppendFormat(
                     "<tr class='itemRow'><td class='productId'>{0}</td><td>{1}</td><td>{2:C}</td><td><input type='text' data-id='{0}' value='{3}' class='quantityInput' /></td><td class='extendedPrice'>{4:C}</td><td><a href='/RemoveFromCart.aspx?ProductId={0}'>remove</a></td></tr>",
                     od.ProductId, od.Product.ProductName, od.UnitPrice * Convert.ToDecimal(1.0 - od.Discount), od.Quantity, od.ExtendedPrice);
            }
            sb.AppendFormat("<tr><td></td><td style='text-align: right'>Subtotal:</td><td></td><td></td><td style='border-top: 5px'>{0:C}</td></tr>",
                this.SubTotal);
            sb.Append("</table>");
            return sb.ToString();
        }
        public string ToHtml()
        {
            return ToHtml("");
        }
    }
}
