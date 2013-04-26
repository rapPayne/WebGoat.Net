using System;
using System.IO;
using Core;
using Infrastructure;

namespace WebSite
{
    public partial class Product : System.Web.UI.Page
    {
        ProductRepository _repository;
        int _productId;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _productId = Convert.ToInt32(RouteData.Values["ProductId"]);
                _productId = (_productId == 0) ? Convert.ToInt32(Request.QueryString["Id"]) : _productId;
                _repository = new ProductRepository();

                var prod = _repository.GetProductById(_productId);
                pnlAddToCart.Visible = true;
                var imageUrl = "/images/productImages/" + prod.ProductId.ToString() + ".jpg";
                if (!File.Exists(Server.MapPath(imageUrl)))
                {
                    imageUrl = "/images/productImages/NoImage.jpg";
                }
                lblDescription.Text = prod.ToDetailHtml(imageUrl);
            }
            catch (InvalidOperationException)
            {
                lblMessage.Text = "Product not found.";
                lblMessage.CssClass = "Error";
            }
            catch (Exception ex)
            {
                lblMessage.Text = string.Format("An error has occurred: {0}",ex.Message);
                lblMessage.CssClass = "Error";
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            Cart cart;
            if (Session["Cart"] is Cart)
                cart = Session["Cart"] as Cart;
            else
                cart = new Cart();
            short quantity = 1;
            try
            {
                quantity = Convert.ToInt16(txtQuantity.Text);
            }
            catch (Exception ex)
            {
                lblMessage.Text = string.Format("An error has occurred: {0}", ex.ToString());
            }
            //TODO: Put this in try/catch as well
            //TODO: Feels like this is too much business logic.  Should be moved to OrderDetail constructor?
            var productRepository = new ProductRepository();
            var product = productRepository.GetProductById(_productId);
            var orderDetail = new OrderDetail()
                                  {
                                      Discount = 0.0F,
                                      ProductId = _productId,
                                      Quantity = quantity,
                                      Product = product,
                                      UnitPrice = product.UnitPrice
                                  };
            cart.OrderDetails.Add(orderDetail);
            Session["Cart"] = cart;

            Response.Redirect("~/ViewCart.aspx");
        }
    }
}