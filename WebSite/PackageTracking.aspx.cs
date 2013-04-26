using System;
using System.Text;
using Core;
using Infrastructure;

namespace WebSite
{
    public partial class Redirect : System.Web.UI.Page
    {
        string _carrier = string.Empty;
        string _trackingNumber = string.Empty;
        OrderRepository _orderRepository = new OrderRepository();
        CustomerRepository _customerRepository = new CustomerRepository();
        ShipperRepository _shipperRepository = new ShipperRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //If QueryString parameters are available, use them.  If not, get them from the user
                _carrier = Request.QueryString["Carrier"];
                _trackingNumber = Request.QueryString["TrackingNumber"];

                if (!string.IsNullOrEmpty(_carrier) && !string.IsNullOrEmpty(_trackingNumber))
                    Response.Redirect(Order.GetPackageTrackingUrl(_carrier, _trackingNumber));

                //ddlCarriers.SelectedValue = _carrier;
                txtCarrier.Text = _carrier;
                txtTrackingNumber.Text = _trackingNumber;

                //Load this user's orders.
                if (User.Identity.IsAuthenticated)
                {
                    var customerId = _customerRepository.GetCustomerByUsername(User.Identity.Name).CustomerId;
                    var orders = _orderRepository.GetAllOrdersByCustomerId(customerId);
                    if (orders.Count == 0)
                    {
                        lblOrders.Text = "You have no orders.";
                    }
                    else
                    {
                        var sb = new StringBuilder();
                        sb.Append("<table>");
                        sb.AppendFormat("<tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th></tr>", "Order", "Order date", "Shipping Cost", "Shipping Method", "Order Total", "Tracking number");
                        foreach (var order in orders)
                        {
                            var trackingNumber = "No tracking number recorded.";
                            try
                            {
                                trackingNumber = _orderRepository.GetShipmentByOrderId(order.OrderId).TrackingNumber;
                            }
                            catch(Exception)
                            {}
                            var shipper = _shipperRepository.GetShipperByShipperId(order.ShipVia);
                            sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2:C}</td><td>{3}</td><td>{4:C}</td><td>{5}</td></tr>", order.OrderId, order.OrderDate, order.Freight, shipper.CompanyName, order.SubTotal, trackingNumber);
                        }
                        sb.Append("</table>");
                        lblOrders.Text = sb.ToString();
                    }
                    yourOrdersPanel.Visible = true;

                }
            }
        }

        protected void btnTrackPackage_Click(object sender, EventArgs e)
        {
            //_carrier = ddlCarriers.SelectedValue;
            _carrier = txtCarrier.Text;
            _trackingNumber = txtTrackingNumber.Text;

            Response.Redirect(Order.GetPackageTrackingUrl(_carrier, _trackingNumber));
        }
    }
}