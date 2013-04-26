using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Security;
using Infrastructure;

namespace WebSite.Checkout
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class Orders
    {
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json)]
        public int GetLastOrderId()
        {
            // Add your operation implementation here
            var repo = new OrderRepository();
            var customerRepo = new CustomerRepository();

            var authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                throw new Exception("Not logged in.");
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            var customerId = customerRepo.GetCustomerByUsername(authTicket.Name).CustomerId;
            var order = repo.GetAllOrdersByCustomerId(customerId).OrderByDescending(o => o.OrderId).First();
            return order.OrderId;
        }

        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json)]
        public void UpdateShipAddress(int OrderId, string Address, string City, string Region, string PostalCode, string Country)
        {
            // Add your operation implementation here
            var repo = new OrderRepository();
            var order = repo.GetOrderById(OrderId);
            order.ShipAddress = Address;
            order.ShipCity = City;
            order.ShipRegion = Region;
            order.ShipPostalCode = PostalCode;
            order.ShipCountry = Country;
            repo.UpdateOrder(order);
            return;
        }
    }
}
