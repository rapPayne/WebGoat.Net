using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebSite
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RegisterRoutes(RouteTable.Routes);

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("ManageProducts",
                "Product/Manage",
                "~/Admin/ManageProducts.aspx",
                false
                );
            routes.MapPageRoute("AddProduct",
                "Product/Add",
                "~/Admin/AddProduct.aspx",
                false
                );
            routes.MapPageRoute("EditProduct",
                "Product/Edit/{ProductId}",
                "~/Admin/EditProduct.aspx",
                false,
                new RouteValueDictionary() { { "ProductId", 1 } }
                );
            routes.MapPageRoute("ViewProduct",
                "Product/{ProductId}",
                "~/Product.aspx",
                false,
                new RouteValueDictionary() { { "ProductId", 1 } }
                );
            routes.MapPageRoute("BlogReply",
                "Blog/Reply/{BlogEntryId}",
                "~/BlogEntryReply.aspx",
                false,
                new RouteValueDictionary() { { "BlogEntryId", 1 } }
                );
            routes.MapPageRoute("Blog",
                "Blog/{StartBlogEntryId}/{NumberOfBlogEntries}",
                "~/Blog.aspx",
                false,
                new RouteValueDictionary() { 
                  { "StartBlogEntryId", 0 }, 
                  {"NumberOfBlogEntries", 4} 
                }
                );
        }
    }
}
