using System;
using Core;
using Infrastructure;

namespace WebSite.Account
{
    public partial class ChangeAccountInfo : System.Web.UI.Page
    {
        string _userName = string.Empty;
        CustomerRepository _customerRepository = new CustomerRepository();
        Customer _customer;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get the user's name from the QueryString parameter.
            _userName = Request.QueryString["Id"];
            _customer = _customerRepository.GetCustomerByUsername(_userName);
            if (_customer == null)
            {
                lblFeedback.Text = "Your user Id is not recognized.  Please login and try again.";
                return;
            }
            if (!IsPostBack)
            {
                txtCompanyName.Text = _customer.CompanyName;
                txtContactTitle.Text = _customer.ContactTitle;
                txtAddress.Text = _customer.Address;
                txtCity.Text = _customer.City;
                txtPostalCode.Text = _customer.PostalCode;
                txtRegion.Text = _customer.Region;
                txtCountry.Text = _customer.Country;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _customer.CompanyName = txtCompanyName.Text;
                _customer.ContactTitle = txtContactTitle.Text;
                _customer.Address = txtAddress.Text;
                _customer.City = txtCity.Text;
                _customer.Region = txtRegion.Text;
                _customer.Country = txtCountry.Text;
                _customer.PostalCode = txtPostalCode.Text;
                _customerRepository.SaveCustomer(_customer);
                lblFeedback.Text = "Your information has been updated.";
            }
            catch (Exception)
            {
                lblFeedback.Text = "An error has occurred in saving.  Please try again.";
            }
        }
    }
}