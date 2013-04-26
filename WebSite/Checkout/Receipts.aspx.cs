using System;
using System.Text;
using Core;
using Infrastructure;

namespace WebSite.Checkout
{
    public partial class Receipts : System.Web.UI.Page
    {
        OrderRepository _orderRepository = new OrderRepository();
        CustomerRepository _customerRepository = new CustomerRepository();
        string _username = string.Empty;
        Customer _customer;

        protected void Page_Load(object sender, EventArgs e)
        {
            _username = User.Identity.Name;
            _customer = _customerRepository.GetCustomerByUsername(_username);
            if (_customer == null)
            {
                lblError.Text += "I can't identify you.  Please log in and try again.";
                return;
            }
            var orders = _orderRepository.GetAllOrdersByCustomerId(_customer.CustomerId);
            
            var output = new StringBuilder();
            output.Append("<table class='something'>");
            output.Append("<tr><th>Details</th><th>Order date</th><th>Total</th></tr>");
            foreach (var order in orders)
            {
                output.AppendFormat("<tr><td><a href='Receipt.aspx?Id={0}'>{0}</a></td><td>{1:D}</td><td>{2:C}</td></tr>", order.OrderId, order.OrderDate,  order.Total);
            }
            output.Append("</table>");
            lblReceipts.Text = output.ToString();
        }
    }
}