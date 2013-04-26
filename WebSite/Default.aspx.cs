using System;
using System.IO;
using System.Web;
using Infrastructure;

namespace WebSite
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sessionCookie = new HttpCookie("SessionId", Session.SessionID);
            Response.Cookies.Add(sessionCookie);

            string output = string.Empty;
            var productRepository = new ProductRepository();
            var top4Products = productRepository.GetTopProducts(4);
            foreach (var product in top4Products)
            {
                var imageUrl = "images/productImages/" + product.ProductId.ToString() + ".jpg";
                if (!File.Exists(Server.MapPath(imageUrl)))
                {
                    imageUrl = "images/productImages/NoImage.jpg";
                }
                output += product.ToSummaryHtml(imageUrl);
            }
            lblProductList.Text = output;
        }
    }
}
