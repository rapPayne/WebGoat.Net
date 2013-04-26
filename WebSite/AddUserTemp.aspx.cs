using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class AddUserTemp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("admin"))
            {
                lblErrorMessage.Text = "You must be an administrator to add new users. Log back in and try again.";
            }

        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                Membership.CreateUser(txtUsername.Text, txtPassword.Text, txtEmail.Text);
                if (chkAdminUser.Checked)
                {
                    Roles.AddUserToRole(txtUsername.Text, "admin");
                }
                lblErrorMessage.Text = string.Format("{0} was created.", txtUsername.Text);
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = string.Format("An error has occurred: {0}", ex);
            }
        }
    }
}