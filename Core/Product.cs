using System;

namespace Core
{
    public class Product
    {
        public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual int SupplierId { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string QuantityPerUnit { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual short UnitsInStock { get; set; }
        public virtual short UnitsOnOrder { get; set; }
        public virtual short ReorderLevel { get; set; }
        public virtual bool Discontinued { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }

        public string ToSummaryHtml(string ImageUrl)
        {
            return string.Format("<div class='productListItem'><a href='/Product/{0}'><img src='{1}' alt='{2}' />&nbsp;&nbsp;&nbsp;{2}</a></div>", this.ProductId.ToString(), ImageUrl, this.ProductName);
        }
        public string ToDetailHtml(string ImageUrl)
        {

            return string.Format("<div class='productDetail'><img src='{0}' alt='{1}' /><br />{1}<br />Category: {2}<br />Unit: {3}<br />Price: {4}</div>", 
                ImageUrl, 
                this.ProductName,
                (this.Category ?? new Category() {CategoryName = "No category"}).CategoryName,
                this.QuantityPerUnit,
                this.UnitPrice.ToString("C")
                );
        }
    }
}
