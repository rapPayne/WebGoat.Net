using System;
using System.Web.UI.WebControls;
using Core;
using Infrastructure;

namespace WebSite.Checkout
{
    public partial class Checkout : System.Web.UI.Page
    {
        readonly CustomerRepository _customerRepository = new CustomerRepository();
        readonly OrderRepository _orderRepository = new OrderRepository();
        readonly ShipperRepository _shipperRepository = new ShipperRepository();
        private Cart _cart = new Cart();
        private Customer _customer;
        private string _username;
        private CreditCard _creditCard;
        private int _expiryMonth;
        private int _expiryYear;
        private string _creditCardNumber = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            //Preload the shipping address if available
            _username = User.Identity.Name;
            _customer = _customerRepository.GetCustomerByUsername(_username);
            if (_customer == null)
            {
                lblErrorMessage.Text += "I can't identify you.  Please log in and try again.";
                return;
            }

            //Preload Credit card if available
            _creditCard = new CreditCard() { Filename = Server.MapPath("StoredCreditCards.xml"), Username = _username };
            try
            {
                _creditCard.GetCardForUser();
                _creditCardNumber = _creditCard.Number;
                _expiryMonth = _creditCard.Expiry.Month;
                _expiryYear = _creditCard.Expiry.Year;
            }
            catch (NullReferenceException)
            {
            }

            if (Session["Cart"] == null)
            {
                lblErrorMessage.Text = "You have no items in your cart.";
            }
            else
            {
                if (Session["Cart"] is Cart)
                {
                    _cart = Session["Cart"] as Cart;
                    lblCart.Text = _cart.ToHtml("cartTable");
                }
                else
                {
                    lblErrorMessage.Text = "A problem has occurred. Your cart doesn't seem to be a valid cart.";
                }
            }

            if (!IsPostBack)
            {
                foreach (var option in _shipperRepository.GetShippingOptions(_cart.SubTotal))
                {
                    ddlShipVia.Items.Add(new ListItem( option.Value, option.Key.ToString()));
                }
                txtShipName.Text = _customer.CompanyName;
                txtShipAddress.Text = _customer.Address;
                txtShipCity.Text = _customer.City;
                txtShipRegion.Text = _customer.Region;
                txtShipPostalCode.Text = _customer.PostalCode;
                txtShipCountry.Text = _customer.Country;
                for (int i = 0; i <= 5; i++)
                    ddlExpiryYear.Items.Add((DateTime.Now.Year + i).ToString());
                ddlExpiryMonth.SelectedValue = _expiryMonth.ToString("00");
                ddlExpiryYear.SelectedValue = _expiryYear.ToString("0000");
                txtCreditCardNumber.Text = _creditCard.Number;
            }

        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            var order = new Order();

            //Get method of shipping and freightCost
            order.ShipVia = Convert.ToInt32(ddlShipVia.SelectedValue);
            order.ShipName = txtShipName.Text;
            order.ShipAddress = txtShipAddress.Text;
            order.ShipCity = txtShipCity.Text;
            order.ShipRegion = txtShipRegion.Text;
            order.ShipPostalCode = txtShipPostalCode.Text;
            order.ShipCountry = txtShipCountry.Text;
            order.OrderDetails = _cart.OrderDetails;
            order.CustomerId = _customer.CustomerId;
            order.OrderDate = DateTime.Now;
            order.RequiredDate = DateTime.Now.AddDays(7);
            order.Freight = _shipperRepository.GetShipperByShipperId(Convert.ToInt32(ddlShipVia.SelectedValue)).GetShippingCost(_cart.SubTotal);
            //TODO: Throws an error if we don't set the date. Try to set it to null or something.
            order.ShippedDate = DateTime.Now.AddDays(3);
            order.EmployeeId = 1;

            //Get form of payment
            //If old card is null or if the number, month or year were changed then take what was on the form.
            if (_creditCard.Number.Length <= 4)
            {
                _creditCard.Number = txtCreditCardNumber.Text;
                _creditCard.Expiry = new DateTime(Convert.ToInt32(ddlExpiryYear.SelectedValue),
                    Convert.ToInt32(ddlExpiryMonth.SelectedValue), 1);
            }
            else
            {
                if (txtCreditCardNumber.Text.Substring(txtCreditCardNumber.Text.Length - 4) !=
                _creditCard.Number.Substring(_creditCard.Number.Length - 4))
                {
                    _creditCard.Number = txtCreditCardNumber.Text;
                }
                if (ddlExpiryMonth.SelectedValue != _creditCard.ExpiryMonth.ToString("00") ||
                ddlExpiryYear.SelectedValue != _creditCard.ExpiryYear.ToString("0000"))
                {
                    _creditCard.Expiry = new DateTime(Convert.ToInt32(ddlExpiryYear.SelectedValue),
                        Convert.ToInt32(ddlExpiryMonth.SelectedValue), 1);
                }
            }
            //Authorize payment through our bank or Authorize.net or someone.
            if (!_creditCard.IsValid())
            {
                lblErrorMessage.Text = "That card is not valid.  Please enter a valid card.";
                return;
            }
            var approvalCode = _creditCard.ChargeCard(order.Total);

            if (chkStoreCCNumber.Checked)
                _creditCard.SaveCardForUser();

            var shipment = new Shipment()
                {
                    ShipmentDate = DateTime.Today.AddDays(1),
                    ShipperId = order.ShipVia,
                    TrackingNumber = _shipperRepository.GetNextTrackingNumber(_shipperRepository.GetShipperByShipperId(order.ShipVia)),
                };
            //TODO: Uncommenting this line causes EF to throw exception when creating the order.
            //order.Shipment = shipment;

            //Create the order itself.
            int orderId = _orderRepository.CreateOrder(order);
            Session["OrderId"] = orderId;
            Session["Cart"] = null;

            //Create the payment record.
            _orderRepository.CreateOrderPayment(orderId, order.Total, _creditCard.Number, _creditCard.Expiry, approvalCode);

            //Show success page
            Response.Redirect("Receipt.aspx");
        }
    }
}