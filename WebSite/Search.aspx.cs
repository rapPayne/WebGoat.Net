using System;
using System.Web.UI.WebControls;
using Infrastructure;

namespace WebSite
{
    public partial class Search : System.Web.UI.Page
    {
        ProductRepository _productRepo = new ProductRepository();
        CategoryRepository _categoryRepo = new CategoryRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            _categoryRepo.GetAllCategories().ForEach(c => ddlCategory.Items.Add(new ListItem(c.CategoryName, c.CategoryId.ToString())));

            LoadProducts(sender, e);
        }

        protected void LoadProducts(object sender, EventArgs e)
        {
            var products = _productRepo.FindNonDiscontinuedProducts(txtSearch.Text, Convert.ToInt32(ddlCategory.SelectedValue));
            gvProductList.DataSource = products;
            gvProductList.DataBind();
        }
    }
}