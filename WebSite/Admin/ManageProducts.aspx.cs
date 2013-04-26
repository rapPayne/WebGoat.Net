using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infrastructure;

namespace WebSite.Admin
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        private ProductRepository _productRepository = new ProductRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Admin"))
            {
                Response.Redirect("/Account/Login.aspx");
            }
            var sb = new StringBuilder();
            var products = _productRepository.GetAllProducts();
            sb.Append("<div><ul>");
            products.ForEach(p => sb.AppendFormat("<li><a href='/Product/Edit/{0}'>{1}</a>  Price: {2} In stock: {3}  On order: {4}</li>",p.ProductId, p.ProductName, p.UnitPrice, p.UnitsInStock, p.UnitsOnOrder));
            sb.Append("</ul></div>");
            lblOutput.Text = sb.ToString();
        }
    }
}