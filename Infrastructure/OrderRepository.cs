using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Infrastructure
{
    public class OrderRepository
    {
        private NorthwindContext _context;
        private CustomerRepository _customerRepository;
        public OrderRepository()
        {
            _context = NorthwindContext.GetNorthwindContext();
        }
        public Order GetOrderById(int OrderId)
        {
            _customerRepository = new CustomerRepository();
            var order = _context.Orders.Single(o => o.OrderId == OrderId);
            if (order.CustomerId.Length > 0)
                order.Customer = _customerRepository.GetCustomerByCustomerId(order.CustomerId);
            return order;
        }
        public int CreateOrder(Order Order)
        {
            Order = _context.Orders.Add(Order);
            _context.SaveChanges();
            return Order.OrderId;
        }
        public int CreateOrder(List<OrderDetail> OrderDetails, string CustomerId, decimal Freight, int ShipVia, string ShipName, string ShipAddress, string ShipCity,
            string ShipRegion, string ShipPostalCode, string ShipCountry)
        {
            var order = new Order()
                            {
                                CustomerId = CustomerId,
                                Freight = Freight,
                                OrderDate = DateTime.Today,
                                RequiredDate = DateTime.Today.AddDays(7.0),
                                ShipAddress = ShipAddress,
                                ShipCity = ShipCity,
                                ShipCountry = ShipCountry,
                                ShipPostalCode = ShipPostalCode,
                                ShipRegion = ShipRegion,
                                ShipName = ShipName,
                                ShipVia = ShipVia,
                                OrderDetails = OrderDetails
                            };
            order = _context.Orders.Add(order);
            return order.OrderId;
        }
        public void CreateOrderPayment(int OrderId, Decimal AmountPaid, string CreditCardNumber, DateTime ExpirationDate, string ApprovalCode)
        {
            var orderPayment = new OrderPayment()
                                   {
                                       AmountPaid = AmountPaid,
                                       CreditCardNumber = CreditCardNumber,
                                       ApprovalCode = ApprovalCode,
                                       ExpirationDate = ExpirationDate,
                                       OrderId = OrderId,
                                       PaymentDate = DateTime.Now
                                   };
            _context.OrderPayments.Add(orderPayment);
            _context.SaveChanges();
        }
        public ICollection<Order> GetAllOrdersByCustomerId(string CustomerId)
        {
            return _context.Orders.Where(o => o.CustomerId == CustomerId).OrderByDescending(o => o.OrderDate).ToList();
        }
        public Shipment GetShipmentByOrderId(int OrderId)
        {
            return _context.Shipments.Single(s => s.OrderId == OrderId);
        }
        public void UpdateOrder(Order Order)
        {
            _context.Entry(Order).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }

}
