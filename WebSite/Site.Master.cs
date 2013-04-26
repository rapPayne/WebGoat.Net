using System;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.IsInRole("Admin"))
                NavigationMenu.Items.Add(new MenuItem("Admin") { NavigateUrl = "/Admin" });
        }

        protected void HeadLoginStatus_LoggedOut(object sender, EventArgs e)
        {
            Session.Abandon();
        }
    }
}
