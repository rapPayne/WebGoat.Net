using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core;
using Infrastructure;

namespace WebSite
{
    public partial class BlogEntryReply : System.Web.UI.Page
    {
        BlogEntryRepository _blogEntryReposistory = new BlogEntryRepository();
        int _blogEntryId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _blogEntryId = Convert.ToInt32(RouteData.Values["BlogEntryId"]);
                _blogEntryId = (_blogEntryId == 0) ? Convert.ToInt32(Request.QueryString["Id"]) : _blogEntryId;

                //_blogEntryId = Convert.ToInt32(Request.Form["BlogEntryId"]);
                Session["BlogEntryId"] = _blogEntryId;
                if (_blogEntryId == 0)
                {
                    lblErrorMessage.Text = "No blog entry was found.  Please go back and try again.";
                    return;
                }
                var blogEntry = _blogEntryReposistory.GetBlogEntry(_blogEntryId);
                var sb = new StringBuilder();
                sb.Append("<div>");
                sb.AppendFormat("<div class='blogEntryTitle'>{0}</div>", blogEntry.Title);
                sb.AppendFormat("<div class='blogEntryContents'>{0}</div>", blogEntry.Contents);
                sb.AppendFormat("<div class='blogEntryAuthor'>{0}</div>", blogEntry.Author);
                sb.AppendFormat("<div class='blogEntryPostedDate'>{0}</div>", blogEntry.PostedDate);
                sb.Append("</div>");

                lblBlogEntry.Text = sb.ToString();
            }
            else
            {
                _blogEntryId = Convert.ToInt32(Session["BlogEntryId"]);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var userName = User.Identity.Name;
            userName = (string.IsNullOrEmpty(userName) ? "Anonymous" : userName);
            var response = new BlogResponse()
                {
                    Author = userName,
                    Contents = txtBlogEntryReply.Text,
                    BlogEntryId = _blogEntryId,
                    ResponseDate = DateTime.Now
                };
            var repo = new BlogResponseRepository();
            repo.CreateBlogResponse(response);
            Response.Redirect("/Blog");
        }
    }
}