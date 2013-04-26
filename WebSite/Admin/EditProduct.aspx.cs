using System;
using System.Web.UI.WebControls;
using Infrastructure;

namespace WebSite.Admin
{
    public partial class EditProduct : System.Web.UI.Page
    {
        ProductRepository _productRepository;
        CategoryRepository _categoryRepository;
        int _productId;
        Core.Product _prod;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _productId = Convert.ToInt32(RouteData.Values["ProductId"]);
                _productId = (_productId == 0) ? Convert.ToInt32(Request.QueryString["Id"]) : _productId;
                _productRepository = new ProductRepository();
                _categoryRepository = new CategoryRepository();

                _prod = _productRepository.GetProductById(_productId);
                if (!IsPostBack)
                {
                    _categoryRepository.GetAllCategories().ForEach(c => ddlCategoryId.Items.Add(new ListItem(c.CategoryName, c.CategoryId.ToString())));
                    lblProductId.Text = _prod.ProductId.ToString();
                    txtProductName.Text = _prod.ProductName;
                    ddlCategoryId.SelectedValue = _prod.CategoryId.ToString();
                    txtQuantityPerUnit.Text = _prod.QuantityPerUnit;
                    txtUnitsInStock.Text = _prod.UnitsInStock.ToString();
                    txtUnitsOnOrder.Text = _prod.UnitsOnOrder.ToString();
                    txtUnitPrice.Text = _prod.UnitPrice.ToString();
                    txtReorderLevel.Text = _prod.ReorderLevel.ToString();
                    chkDiscontinued.Checked = _prod.Discontinued;
                }
            }
            catch (InvalidOperationException)
            {
                lblMessage.Text = "Product not found.";
                lblMessage.CssClass = "Error";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "Error";
            }
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                _prod.ProductName = txtProductName.Text;
                _prod.CategoryId = Convert.ToInt16(ddlCategoryId.SelectedValue);
                _prod.Discontinued = chkDiscontinued.Checked;
                _prod.QuantityPerUnit = txtQuantityPerUnit.Text;
                _prod.ReorderLevel = Convert.ToInt16(txtReorderLevel.Text);
                _prod.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                _prod.UnitsInStock = Convert.ToInt16(txtUnitsInStock.Text);
                _prod.UnitsOnOrder = Convert.ToInt16(txtUnitsOnOrder.Text);
                _productRepository.Update(_prod);
                lblMessage.Text = string.Format("Product {0} was updated.", _prod.ProductId);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "Error";
            }
        }
    }
}