using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class Customer
    {
        public virtual string CustomerId { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string ContactTitle { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public string ToHtml(string CssClass)
        {
            var sb = new StringBuilder();
            if (CssClass.Length == 0)
                sb.Append("<div>");
            else
            {
                sb.AppendFormat("<div class='{0}'>", CssClass);
            }
            sb.AppendFormat("<div class='custLeft'>Company:</div><div class='custRight'>{0}</div>", CompanyName);
            sb.AppendFormat("<div class='custLeft'>Your Title:</div><div class='custRight'>{0}</div>", ContactTitle);
            sb.AppendFormat("<div class='custLeft'>Address:</div><div class='custRight'>{0}</div>", Address);
            sb.AppendFormat("<div class='custLeft'>City:</div><div class='custRight'>{0}</div>", City);
            sb.AppendFormat("<div class='custLeft'>State/region:</div><div class='custRight'>{0}</div>", Region);
            sb.AppendFormat("<div class='custLeft'>Zipcode/postal code:</div><div class='custRight'>{0}</div>", PostalCode);
            sb.AppendFormat("<div class='custLeft'>Country:</div><div class='custRight'>{0}</div>", Country);
            sb.Append("</div>");
            return sb.ToString();
        }
        public string ToHtml()
        {
            return ToHtml("");
        }
    }
}
