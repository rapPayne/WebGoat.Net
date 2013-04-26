using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace WebSite
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart cart;
            if (Session["Cart"] is Cart)
                cart = (Cart)Session["Cart"];
            else
            {
                cart = new Cart();
            }
            lblOutput.Text = cart.ToHtml("cartTable");
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout/CheckOut.aspx");
        }
    }
}