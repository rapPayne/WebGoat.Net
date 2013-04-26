using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;

namespace WebSite
{
    public partial class RemoveFromCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int _productId = Convert.ToInt32(RouteData.Values["ProductId"]);
                _productId = (_productId == 0) ? Convert.ToInt32(Request.QueryString["ProductId"]) : _productId;

                Cart cart;
                if (Session["Cart"] is Cart)
                    cart = (Cart)Session["Cart"];
                else
                {
                    cart = new Cart();
                }
                var orderDetail = cart.OrderDetails.First(od => od.ProductId == _productId);
                if (orderDetail == null)
                {
                    lblMessage.Text = string.Format("Product {0} was not found in your cart.", _productId);
                    lblMessage.CssClass = "Error";
                    return;
                }
                cart.OrderDetails.Remove(orderDetail);
                Response.Redirect("~/ViewCart.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.Text = string.Format("An error has occurred: {0}", ex.Message);
                lblMessage.CssClass = "Error";
            }
        }
    }
}