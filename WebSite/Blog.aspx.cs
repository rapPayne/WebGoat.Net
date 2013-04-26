using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Infrastructure;

namespace WebSite
{
    public partial class Blog : System.Web.UI.Page
    {
        private List<BlogEntry> _blogEntries = new List<BlogEntry>();
        private BlogEntryRepository _repo = new BlogEntryRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            int numberOfBlogEntries = 0;
            int startBlogEntrId = 0;
            var allEntries = new StringBuilder();
            numberOfBlogEntries = Convert.ToInt32(RouteData.Values["NumberOfBlogEntries"]);
            numberOfBlogEntries = (numberOfBlogEntries == 0) ? Convert.ToInt32(Request.QueryString["Num"]) : numberOfBlogEntries;
            numberOfBlogEntries = (numberOfBlogEntries == 0) ? 4 : numberOfBlogEntries;

            startBlogEntrId = Convert.ToInt32(RouteData.Values["StartBlogEntryId"]);
            startBlogEntrId = (startBlogEntrId == 0) ? Convert.ToInt32(Request.QueryString["Id"]) : startBlogEntrId;
            _blogEntries = _repo.GetTopBlogEntries(numberOfBlogEntries, startBlogEntrId);

            foreach (var blogEntry in _blogEntries )
            {
                allEntries.Append("\n\n<div class='blogEntry'>\n");
                allEntries.AppendFormat("<div class='blogEntryTitle'>{0}</div>\n", blogEntry.Title);
                allEntries.AppendFormat("<div class='blogEntryContents'>{0}</div>\n", blogEntry.Contents);
                allEntries.AppendFormat("<div class='blogEntryAuthor'>By {0}</div>\n", blogEntry.Author);
                allEntries.AppendFormat("<div class='blogEntryPostedDate'>{0}</div>\n", blogEntry.PostedDate);
                if (blogEntry.Responses.Count > 0)
                    allEntries.Append("<div class='blogResponseTitle'>Responses</div>\n");
                //Write each blog response to the page.
                foreach (var blogResponse in blogEntry.Responses)
                {
                    allEntries.Append("<div class='blogResponse'>\n");
                    allEntries.AppendFormat("<div class='blogResponseContents'>{0}</div>\n", blogResponse.Contents);
                    allEntries.AppendFormat("<div class='blogResponseSignature'>{0} - {1}</div>\n", blogResponse.Author, blogResponse.ResponseDate);
                    allEntries.Append("</div>\n");
                }
                allEntries.AppendFormat("<button type='button' class='blogRespondButton' data-BlogEntryId='{0}'>Respond</button>\n", blogEntry.Id);
                allEntries.Append("</div>\n");
            }

            this.entriesDiv.InnerHtml = allEntries.ToString();

        }
    }
}