using System;

namespace Core
{
    public class OrderPayment
    {
        public virtual int OrderPaymentId { get; set; }
        public virtual int OrderId { get; set; }
        public virtual string CreditCardNumber { get; set; }
        public virtual DateTime ExpirationDate { get; set; }
        public virtual string CVV { get; set; }
        public virtual decimal AmountPaid { get; set; }
        public virtual DateTime PaymentDate { get; set; }
        public virtual string ApprovalCode { get; set; }

        public virtual Order Order { get; set; }
    }
}
