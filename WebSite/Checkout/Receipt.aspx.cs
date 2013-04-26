using System;
using System.Text;
using Core;
using Infrastructure;

namespace WebSite.Checkout
{
    public partial class CheckoutResults : System.Web.UI.Page
    {
        OrderRepository _orderRepository = new OrderRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            Order order;
            var orderId = (int)(Session["orderId"] ?? 0);
            var requestOrderId = Convert.ToInt32(Request.QueryString["ID"]);
            if (requestOrderId != 0)
                orderId = requestOrderId;
            if (orderId == 0)
            {
                lblError.Text = string.Format("No order specified.  Please try again.");
                return;
            }
            try
            {
                order = _orderRepository.GetOrderById(orderId);
            }
            catch (InvalidOperationException)
            {
                lblError.Text = string.Format("Order {0} was not found.", orderId);
                return;
            }
            var output = new StringBuilder();
            output.Append("<div class='receiptDiv'>");
            output.AppendFormat("<p>Order: {0}</p>", orderId);
            output.Append(order.ToHtml("Receipt"));
            output.Append("</div>");
            lblOutput.Text = output.ToString();
        }
    }
}