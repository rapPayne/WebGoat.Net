using System.Data.Entity;
using Core;

namespace Infrastructure
{
    public class NorthwindContext : DbContext
    {
        private static string _connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Northwnd.mdf;Integrated Security=True";
        public NorthwindContext()
            : base(_connString)
        {
        }

        public DbSet<BlogEntry> BlogEntries { get; set; }
        public DbSet<BlogResponse> BlogResponses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetail>().HasKey(a => new { a.ProductId, a.OrderId });
        }
    }
}
