using System;
using System.Web.UI.WebControls;
using Infrastructure;

namespace WebSite.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        ProductRepository _productRepository;
        CategoryRepository _categoryRepository;
        SupplierRepository _supplierRepository;
        Core.Product _prod;
        protected void Page_Load(object sender, EventArgs e)
        {
            _prod = new Core.Product();
            try
            {
                _productRepository = new ProductRepository();
                _categoryRepository = new CategoryRepository();
                _supplierRepository = new SupplierRepository();
                if (!IsPostBack)
                {
                    _categoryRepository.GetAllCategories().ForEach(c => ddlCategoryId.Items.Add(new ListItem(c.CategoryName, c.CategoryId.ToString())));
                    _supplierRepository.GetAllSuppliers().ForEach(s => ddlSupplierId.Items.Add(new ListItem(s.CompanyName, s.SupplierId.ToString())));
                }
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
                _prod.CategoryId = Convert.ToInt32(ddlCategoryId.SelectedValue);
                _prod.Discontinued = chkDiscontinued.Checked;
                _prod.QuantityPerUnit = txtQuantityPerUnit.Text;
                _prod.ReorderLevel = Convert.ToInt16(txtReorderLevel.Text);
                _prod.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
                _prod.UnitsInStock = Convert.ToInt16(txtUnitsInStock.Text);
                _prod.UnitsOnOrder = Convert.ToInt16(txtUnitsOnOrder.Text);
                _prod.SupplierId = Convert.ToInt32(ddlSupplierId.SelectedValue);
                _productRepository.Add(_prod);
                lblMessage.Text = string.Format("Product {0} was added.", _prod.ProductId);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.CssClass = "Error";
            }
        }
    }
}