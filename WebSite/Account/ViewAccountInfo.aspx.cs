using System;
using Infrastructure;

namespace WebSite.Account
{
    public partial class ViewAccountInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var customerRepository = new CustomerRepository();
            var customer = customerRepository.GetCustomerByUsername(User.Identity.Name);
            if (customer == null)
            {
                lblFeedback.Text = "We don't recognize your customer Id. Please log in and try again.";
                return;
            }

            lblCustomerInfo.Text = customer.ToHtml("viewAccountInfoDiv");

            lblCustomerInfo.Text += string.Format(
                "<div class='clear'><a href='ChangeAccountInfo.aspx?Id={0}'>Change your account info.</a></div>",
                customer.ContactName    // ContactName is being repurposed as the foreign key to the user table.  Kludgey, I know.
                );
        }
    }
}