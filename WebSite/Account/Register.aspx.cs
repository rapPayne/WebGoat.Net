using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using Infrastructure;

namespace WebSite.Account
{
    public partial class Register : System.Web.UI.Page
    {
        string _companyName = "";
        string _contactName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            var address = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txtAddress")).Text;
            var city = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txtCity")).Text;
            var region = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txtRegion")).Text;
            var postalCode = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txtPostalCode")).Text;
            var country = ((TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("txtCountry")).Text;

            var repo = new CustomerRepository();
            repo.CreateCustomer(_companyName, _contactName, address, city, region, postalCode, country);

            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);
            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

        protected void RegisterUser_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            try
            {
                var companyNameTextbox = Page.Master.FindControl("MainContent").FindControl("RegisterUser").FindControl("CreateUserStepContainer").FindControl("CompanyName");
                _companyName = ((TextBox)companyNameTextbox).Text;
                _contactName = RegisterUser.UserName;
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = string.Format("An error has occured. Please tell tech support that you saw this: <br />{0}: {1}", ex.GetType(), ex.Message);
                e.Cancel = true;
            }
        }

    }
}
